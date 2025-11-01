# Write your MySQL query statement below
select name from (
    select managerId as id, count(managerId) as count1 from Employee  group by managerId 
)as t join Employee e on t.id = e.id
where count1 >= 5
