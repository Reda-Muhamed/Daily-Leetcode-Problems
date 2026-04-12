# Write your MySQL query statement below
-- with temp as (
--     select departmentId , salary 
--      from Employee 
--      order by departmentId ,salary desc
-- )
with ranked_employees as (
    select 
        departmentid, 
        name,
        salary,
        dense_rank() over (partition by departmentid order by salary desc) as row_num
    from Employee 
),
top_ranked  as (
    select * from ranked_employees where row_num <=3 
)
select d.name as Department, t.name as Employee , t.salary
 from top_ranked t 
 join Department d on t.departmentid = d.id  