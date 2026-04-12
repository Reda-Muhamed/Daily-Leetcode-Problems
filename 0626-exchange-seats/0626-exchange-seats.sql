# Write your MySQL query statement below
-- select id ,
--  if(id % 2 = 1, if((lead(student) over (order by id)) is not null , lead(student) over (order by id) , student),
-- lag(student) over (order by id) ) as student from Seat

-- Efficient solution 

select if(id % 2 = 1 , if(id = (select id from Seat order by id desc limit 1) , id , id + 1) , id - 1 ) as id , student
from Seat 
group by id
order by id