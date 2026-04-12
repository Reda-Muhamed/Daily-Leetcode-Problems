# Write your MySQL query statement below
with temp as (
    select salary from Employee 
    group by salary
    order by salary desc 
    limit 1 offset 1
)
select if(count(salary)=0 , null , salary) as SecondHighestSalary   from temp