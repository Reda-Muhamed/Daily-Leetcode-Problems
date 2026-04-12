# Write your MySQL query statement below
-- with temp as (
--     select id, num, lead(num) over (order by id) as nN,  lag(num) over (order by id) as pN
--     from Logs
-- )
-- select distinct num as ConsecutiveNums from temp 
-- where num = nN and num = pN

-- Efficient solution

select distinct l1.num as ConsecutiveNums from Logs l1 , Logs l2 , Logs l3
where l1.num = l2.num and l2.num = l3.num and l2.id = l1.id + 1 and l2.id = l3.id - 1