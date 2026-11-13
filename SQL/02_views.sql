USE ROLE SYSADMIN;
USE WAREHOUSE ETL_WH;

-- HELPER VIEW: checks every raw row once, with simple CASE logic
-- REJECT_REASON is NULL when the row is fine. Both the reject step and the
-- final-load step read from this view, so the rules live in one place
-- The product check uses the PRODUCT_REF reference table
CREATE OR REPLACE VIEW ETL_DEMO.ORDERS.VW_ORDERS_RAW_CHECKED AS
SELECT
  r.*,
  p.CATEGORY AS PRODUCT_CATEGORY,
  CASE
    WHEN r.CUSTOMER_ID IS NULL OR TRIM(r.CUSTOMER_ID) = ''           THEN 'MISSING_CUSTOMER_ID'
    WHEN TRY_TO_DATE(r.ORDER_DATE, 'YYYY-MM-DD') IS NULL             THEN 'BAD_ORDER_DATE'
    WHEN TRY_TO_NUMBER(r.QUANTITY) IS NULL
      OR TRY_TO_NUMBER(r.QUANTITY) <= 0                              THEN 'BAD_QUANTITY'
    WHEN TRY_TO_DECIMAL(r.UNIT_PRICE, 12, 2) IS NULL
      OR TRY_TO_DECIMAL(r.UNIT_PRICE, 12, 2) <= 0                    THEN 'BAD_PRICE'
    WHEN r.EMAIL IS NULL OR r.EMAIL NOT LIKE '%@%'                   THEN 'BAD_EMAIL'
    WHEN p.PRODUCT IS NULL                                           THEN 'UNKNOWN_PRODUCT'
    ELSE NULL
  END AS REJECT_REASON
FROM ETL_DEMO.ORDERS.ORDERS_RAW r
LEFT JOIN ETL_DEMO.ORDERS.PRODUCT_REF p
  ON p.PRODUCT = INITCAP(TRIM(r.PRODUCT));

-- CUSTOMER VIEW: only customer columns, one row per customer, latest load wins (qualify row number)
-- This is how we get the latest information out of the load-date history
CREATE OR REPLACE VIEW ETL_DEMO.ORDERS.VW_CUSTOMER_CURRENT AS
SELECT
  CUSTOMER_ID,
  CUSTOMER_NAME,
  EMAIL,
  LOAD_DATE AS LAST_LOAD_DATE
FROM ETL_DEMO.ORDERS.ORDERS_FINAL
QUALIFY ROW_NUMBER() OVER (
          PARTITION BY CUSTOMER_ID
          ORDER BY LOAD_DATE DESC, LOADED_AT DESC
        ) = 1;