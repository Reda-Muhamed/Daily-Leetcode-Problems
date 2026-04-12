# Write your MySQL query statement below

-- with ranked_employees as (
--     select 
--         departmentid, 
--         name,
--         salary,
--         dense_rank() over (partition by departmentid order by salary desc) as row_num
--     from Employee 
-- ),
-- top_ranked  as (
--     select * from ranked_employees where row_num <=3 
-- )
-- select d.name as Department, t.name as Employee , t.salary
--  from top_ranked t 
--  join Department d on t.departmentid = d.id  

-- Efficient Solution 
with cte as (
    select *, dense_rank() over(partition by departmentId order by salary desc) as rnk
    from Employee
)

select d.name as Department, c.name as Employee, c.salary as Salary
from Department d
join cte c
on d.id = c.departmentId
where rnk in (1,2,3)