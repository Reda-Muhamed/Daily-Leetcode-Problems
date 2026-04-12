# Write your MySQL query statement below
select id ,
 if(id % 2 = 1, if((lead(student) over (order by id)) is not null , lead(student) over (order by id) , student),
lag(student) over (order by id) ) as student from Seat