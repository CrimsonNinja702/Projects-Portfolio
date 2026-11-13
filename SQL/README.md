# Orders ETL in Snowflake

!! Built as a learning project with AI assistance, then tested and modified by me !!

A small ETL pipeline in Snowflake SQL. It takes messy order data, checks and cleans it, keeps a history, and loads it into a final table by load date. 
All data is made up for testing, so it runs on a free Snowflake trial with no external files.

## Why I built this

I work with Snowflake daily and wanted a public project that shows the same patterns I use regularly. This includes: history tables, de-duplication and load-date snapshots. 
I used made-up data so nothing from my employer is involved.

## What it does

This project is a small and relatively simple ETL pipeline in Snowflake. 

- Messy order data lands into the raw table, and a set of stored procedures then process it. 
- First, a copy of the raw data is saved to a history table for auditing reasons. 
- Next, each row is checked (missing customer, bad email or date, invalid quantity or price, unknown product, etc...). 
- Rows that fail are saved to a rejected table with the reason. Rows that pass are cleaned, de-duped, and loaded into a final table stamped with a load date, so changes between loads are kept. 
- A view returns the latest customer details from that table using a window function. 
- The raw table is emptied only after a successful run, and every run is written to a log table. 
- Checks along the way stop the same data being loaded twice, this is done with methods such as a simple NOT EXISTS.

## How to run it

1. `01_setup.sql` creates the warehouse, database, schema and tables, and fills the product reference table.
2. `02_views.sql` creates the checking view and the customer view.
3. `03_procs.sql` creates the four main procedures.
4. `04_sample_data.sql`, batch 1 only. Highlight just the Batch 1 `INSERT` and run it. Don't run the whole file.
5. `05_run_and_check.sql`. Run `CALL ETL_DEMO.ORDERS.SP_RUN_ORDERS_ETL('2026-11-12'::DATE);` and then the checks under it.
   - You should see `Archived: 10, rejected: 5, loaded: 4`.
   - That means 5 rows in the rejected table, 4 in the final table, and 0 in the raw table.
6. `04_sample_data.sql`, batch 2 only. Highlight and run just the Batch 2 `INSERT`.
7. `05_run_and_check.sql`. Run the second `CALL` with `'2026-11-13'::DATE` and then the remaining checks.
   - You should see `Archived: 4, rejected: 1, loaded: 3`.
   - `ORD-001` and `ORD-003` appear twice with different load dates, and the customer view shows four customers, with `C001` on the new email.
   - Totals: 14 history rows, 6 rejected rows, 7 final rows.

## Limitations

- The sample data is inserted by hand. A real source would arrive via `COPY INTO` or Snowpipe.
- `ORDERS_REJECTED` is transient, so rejected rows have no Fail-safe and only short Time Travel.
- The `NOT EXISTS` checks could use a more detailed business key. Rows can be silently skipped if the same `_BATCH_ID` is reused for a reload.
- The final-table check uses `ORDER_ID` plus `LOAD_DATE`, so an updated status arriving in a second file on the same day is skipped.
- The biggest limitation: there are no scheduled tasks, so the procedures have to be called by hand. In a real setup this would run on a Snowflake Task.

## What I learned

- `VALUES` doesn't allow functions like `UUID_STRING()` in Snowflake. I switched my log inserts to `INSERT ... SELECT` and it worked.
- When I re-ran a batch and got all zeros, I first thought something was broken. It was actually the `NOT EXISTS` checks stopping the same data being loaded twice.

## Next steps

- Add the task calls to make it fully automated.
- Create a more reliable business key.
- Add masking to certain columns for data security.