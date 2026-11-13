-- Always prefer using three-part names: DATABASE.SCHEMA.OBJECT
USE ROLE SYSADMIN;

-- Suspends after 60s idle for cost control
CREATE WAREHOUSE IF NOT EXISTS ETL_WH
  WAREHOUSE_SIZE = 'XSMALL'
  AUTO_SUSPEND = 60
  AUTO_RESUME = TRUE
  INITIALLY_SUSPENDED = TRUE;

USE WAREHOUSE ETL_WH;

CREATE DATABASE IF NOT EXISTS ETL_DEMO;
CREATE SCHEMA IF NOT EXISTS ETL_DEMO.ORDERS;

-- RAW (source): everything is VARCHAR so a bad value can never break the load.
-- TRANSIENT = no Fail-safe storage, cheaper for data we can reload.
-- This table is emptied at the end of every run; the history table keeps a copy.
CREATE TRANSIENT TABLE IF NOT EXISTS ETL_DEMO.ORDERS.ORDERS_RAW (
  ORDER_ID      VARCHAR,
  CUSTOMER_ID   VARCHAR,
  CUSTOMER_NAME VARCHAR,
  EMAIL         VARCHAR,
  ORDER_DATE    VARCHAR,
  PRODUCT       VARCHAR,
  QUANTITY      VARCHAR,
  UNIT_PRICE    VARCHAR,
  STATUS        VARCHAR,
  _BATCH_ID     VARCHAR,
  _LOADED_AT    TIMESTAMP_NTZ DEFAULT CURRENT_TIMESTAMP()
);

-- HISTORY: a permanent copy of every raw row we have ever received.
CREATE TABLE IF NOT EXISTS ETL_DEMO.ORDERS.ORDERS_RAW_HISTORY (
  ORDER_ID      VARCHAR,
  CUSTOMER_ID   VARCHAR,
  CUSTOMER_NAME VARCHAR,
  EMAIL         VARCHAR,
  ORDER_DATE    VARCHAR,
  PRODUCT       VARCHAR,
  QUANTITY      VARCHAR,
  UNIT_PRICE    VARCHAR,
  STATUS        VARCHAR,
  _BATCH_ID     VARCHAR,
  _LOADED_AT    TIMESTAMP_NTZ,
  ARCHIVED_AT   TIMESTAMP_NTZ DEFAULT CURRENT_TIMESTAMP()
);

-- REJECTED: rows that fail a check are kept (not silently dropped) with a reason.
CREATE TRANSIENT TABLE IF NOT EXISTS ETL_DEMO.ORDERS.ORDERS_REJECTED (
  ORDER_ID        VARCHAR,
  CUSTOMER_ID     VARCHAR,
  CUSTOMER_NAME   VARCHAR,
  EMAIL           VARCHAR,
  ORDER_DATE      VARCHAR,
  PRODUCT         VARCHAR,
  QUANTITY        VARCHAR,
  UNIT_PRICE      VARCHAR,
  STATUS          VARCHAR,
  SOURCE_BATCH_ID VARCHAR,
  REJECT_REASON   VARCHAR,
  REJECTED_AT     TIMESTAMP_NTZ DEFAULT CURRENT_TIMESTAMP()
);

-- REFERENCE table: the list of products we accept, and their category.
CREATE TABLE IF NOT EXISTS ETL_DEMO.ORDERS.PRODUCT_REF (
  PRODUCT  VARCHAR,
  CATEGORY VARCHAR
);

-- Fill the reference table. NOT EXISTS means re-running this adds nothing twice.
INSERT INTO ETL_DEMO.ORDERS.PRODUCT_REF (PRODUCT, CATEGORY)
SELECT v.PRODUCT, v.CATEGORY
FROM (VALUES
        ('Laptop',   'Computers'),
        ('Monitor',  'Displays'),
        ('Keyboard', 'Accessories'),
        ('Headset',  'Accessories'),
        ('Webcam',   'Accessories')
     ) AS v (PRODUCT, CATEGORY)
WHERE NOT EXISTS (
  SELECT 1
  FROM ETL_DEMO.ORDERS.PRODUCT_REF p
  WHERE p.PRODUCT = v.PRODUCT
);

-- FINAL (processed): all clean data. Each load adds a new LOAD_DATE snapshot,
-- so we keep history and can still work out the current picture, and use LOAD_DATE to separate
CREATE TABLE IF NOT EXISTS ETL_DEMO.ORDERS.ORDERS_FINAL (
  ORDER_ID         VARCHAR,
  CUSTOMER_ID      VARCHAR,
  CUSTOMER_NAME    VARCHAR,
  EMAIL            VARCHAR,
  ORDER_DATE       DATE,
  PRODUCT          VARCHAR,
  PRODUCT_CATEGORY VARCHAR,
  QUANTITY         NUMBER(10,0),
  UNIT_PRICE       NUMBER(12,2),
  LINE_TOTAL       NUMBER(14,2),
  STATUS           VARCHAR,
  LOAD_DATE        DATE,
  LOADED_AT        TIMESTAMP_NTZ DEFAULT CURRENT_TIMESTAMP()
);

-- One row per procedure run: the first place to look when something fails.
CREATE TABLE IF NOT EXISTS ETL_DEMO.ORDERS.ETL_RUN_LOG (
  RUN_ID         VARCHAR,
  PROC_NAME      VARCHAR,
  STATUS         VARCHAR,
  ROWS_PROCESSED NUMBER,
  ROWS_REJECTED  NUMBER,
  ERROR_MESSAGE  VARCHAR,
  STARTED_AT     TIMESTAMP_NTZ,
  ENDED_AT       TIMESTAMP_NTZ
);