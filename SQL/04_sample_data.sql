-- Pretend source data. In a real scenario this table would be filled by
-- COPY INTO from a stage (a file drop). Make sure to run one batch at a time
USE ROLE SYSADMIN;
USE WAREHOUSE ETL_WH;

-- BATCH 1 (10 rows: 5 good, 1 duplicate, 5 bad)
INSERT INTO ETL_DEMO.ORDERS.ORDERS_RAW
  (ORDER_ID, CUSTOMER_ID, CUSTOMER_NAME, EMAIL, ORDER_DATE, PRODUCT, QUANTITY, UNIT_PRICE, STATUS, _BATCH_ID)
VALUES
  ('ord-001', 'c001', 'thabo mokoena',  'thabo@example.com',   '2026-11-01', 'Laptop',   '1',  '14999.00', 'completed', 'BATCH_001'),
  ('ORD-002', 'C002', 'AISHA PATEL',    'aisha@example.com',   '2026-11-01', 'Monitor',  '2',  '3499.00',  'Shipped',   'BATCH_001'),
  ('ORD-003', 'C003', 'Liam Naidoo',    'liam@example.com',    '2026-11-02', 'Keyboard', '3',  '599.00',   'pending',   'BATCH_001'),
  ('ORD-003', 'C003', 'Liam Naidoo',    'liam@example.com',    '2026-11-02', 'Keyboard', '3',  '599.00',   'pending',   'BATCH_001'),  -- duplicate
  ('ORD-004', NULL,   'Sipho Dlamini',  'sipho@example.com',   '2026-11-02', 'Monitor',  '1',  '3499.00',  'pending',   'BATCH_001'),  -- missing customer
  ('ORD-005', 'C004', 'Emma Jones',     'emma-at-example.com', '2026-11-03', 'Headset',  '1',  '899.00',   'pending',   'BATCH_001'),  -- bad email
  ('ORD-006', 'C005', 'Ravi Singh',     'ravi@example.com',    '2026-11-03', 'Webcam',   '-1', '749.00',   'pending',   'BATCH_001'),  -- bad quantity
  ('ORD-007', 'C006', 'Zanele Khumalo', 'zanele@example.com',  'not a date', 'Headset',  '1',  '899.00',   'pending',   'BATCH_001'),  -- bad date
  ('ORD-008', 'C007', 'Chris Botha',    'chris@example.com',   '2026-11-04', 'Toaster',  '1',  '399.00',   'completed', 'BATCH_001'),  -- unknown product
  ('ORD-009', 'C001', 'Thabo Mokoena',  'thabo@example.com',   '2026-11-05', 'Headset',  '2',  '899.00',   'cancelled', 'BATCH_001');

-- BATCH 2 (the next day: 4 rows) 
-- ORD-003 is now completed, C001 has a new email, ORD-010 is new, ORD-011 is bad.
INSERT INTO ETL_DEMO.ORDERS.ORDERS_RAW
  (ORDER_ID, CUSTOMER_ID, CUSTOMER_NAME, EMAIL, ORDER_DATE, PRODUCT, QUANTITY, UNIT_PRICE, STATUS, _BATCH_ID)
VALUES
  ('ORD-003', 'C003', 'Liam Naidoo',    'liam@example.com',      '2026-11-02', 'Keyboard', '3', '599.00',   'completed', 'BATCH_002'),
  ('ORD-001', 'C001', 'Thabo Mokoena',  'thabo.new@example.com', '2026-11-01', 'Laptop',   '1', '14999.00', 'completed', 'BATCH_002'),
  ('ORD-010', 'C008', 'Sipho Dlamini',  'sipho@example.com',     '2026-11-06', 'Monitor',  '1', '3499.00',  'pending',   'BATCH_002'),
  ('ORD-011', 'C009', 'Test Person',    '',                      '2026-11-06', 'Laptop',   '1', '14999.00', 'pending',   'BATCH_002');  -- bad email