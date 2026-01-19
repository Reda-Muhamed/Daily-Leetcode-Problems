# Write your MySQL query statement below
-- select patient_id, patient_name, conditions 
-- from Patients
-- where  REGEXP_LIKE(conditions, '^DIAB1','c') or REGEXP_LIKE(conditions, '\\sDIAB1','c')
SELECT patient_id, patient_name, conditions
FROM Patients
WHERE conditions LIKE 'DIAB1%'      -- DIAB1 at start
   OR conditions LIKE '% DIAB1%'    -- DIAB1 in middle or end