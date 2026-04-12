# Write your MySQL query statement below
with temp as (
    select id, num, lead(num) over (order by id) as nN,  lag(num) over (order by id) as pN
    from Logs
)
select distinct num as ConsecutiveNums from temp 
where num = nN and num = pN
