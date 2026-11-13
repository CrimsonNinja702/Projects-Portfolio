-- Run the blocks below one after the other, in order
USE ROLE SYSADMIN;
USE WAREHOUSE ETL_WH;


-- DAY 1: Run the BATCH 1 INSERT from 04_sample_data.sql first, then:
-- (Using fixed dates so you can see two different load dates)
CALL ETL_DEMO.ORDERS.SP_RUN_ORDERS_ETL('2026-11-12'::DATE);
-- Expected to see: Archived: 10, rejected: 5, loaded: 4

SELECT * FROM ETL_DEMO.ORDERS.ORDERS_REJECTED ORDER BY ORDER_ID;     -- 5 rows, each with a reason
SELECT * FROM ETL_DEMO.ORDERS.ORDERS_FINAL    ORDER BY ORDER_ID;     -- 4 rows (duplicate ORD-003 removed)
SELECT COUNT(*) AS RAW_ROWS FROM ETL_DEMO.ORDERS.ORDERS_RAW;         -- 0, raw was emptied

-- DAY 2: Run the BATCH 2 INSERT from 04_sample_data.sql, then:
CALL ETL_DEMO.ORDERS.SP_RUN_ORDERS_ETL('2026-11-13'::DATE);
-- Expected to see: Archived: 4, rejected: 1, loaded: 3

-- Both load dates are kept, so we can see how things changed:
-- Should be duplicate order_ids with different column values now 
SELECT ORDER_ID, STATUS, EMAIL, LOAD_DATE
FROM ETL_DEMO.ORDERS.ORDERS_FINAL
WHERE ORDER_ID IN ('ORD-001', 'ORD-003')
ORDER BY ORDER_ID, LOAD_DATE;

-- The customer view shows only the latest details (C001 should have the new email):
SELECT * FROM ETL_DEMO.ORDERS.VW_CUSTOMER_CURRENT ORDER BY CUSTOMER_ID;   -- 4 customers

-- Totals:
SELECT COUNT(*) AS HISTORY_ROWS  FROM ETL_DEMO.ORDERS.ORDERS_RAW_HISTORY;  -- 14
SELECT COUNT(*) AS REJECTED_ROWS FROM ETL_DEMO.ORDERS.ORDERS_REJECTED;     -- 6
SELECT COUNT(*) AS FINAL_ROWS    FROM ETL_DEMO.ORDERS.ORDERS_FINAL;        -- 7

SELECT * FROM ETL_DEMO.ORDERS.ETL_RUN_LOG ORDER BY STARTED_AT DESC;





-- Just for checking along the way
SELECT COUNT(*) AS RAW_ROWS      FROM ETL_DEMO.ORDERS.ORDERS_RAW;
SELECT COUNT(*) AS HISTORY_ROWS  FROM ETL_DEMO.ORDERS.ORDERS_RAW_HISTORY;
SELECT COUNT(*) AS REJECTED_ROWS FROM ETL_DEMO.ORDERS.ORDERS_REJECTED;
SELECT COUNT(*) AS FINAL_ROWS    FROM ETL_DEMO.ORDERS.ORDERS_FINAL;