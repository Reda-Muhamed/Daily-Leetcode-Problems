# Write your MySQL query statement below
-- with temp as (
--     select num from MyNumbers
--     group by num
--     having(count(num) = 1)
-- )
-- select max(num) as num from temp
-- 
-- Efficient solution
--
select case when count(num) = 1 then num else null end as num
from MyNumbers 
group by num
order by num desc limit 1