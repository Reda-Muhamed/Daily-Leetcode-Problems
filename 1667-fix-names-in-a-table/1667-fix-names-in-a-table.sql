# Write your MySQL query statement below
-- select user_id ,
-- if(
--     name like '% %',
--     concat(upper(left(substring_index(name, ' ', 1),1)),lower(substring(substring_index(name,' ',1),2)),' ',lower(substring_index(name, ' ', 2)))
--   ,  
--   concat(
--     upper(left(substring_index(name, ' ', 1),1)),
--     lower(substring(substring_index(name,' ',1),2)))
--  ) as name
-- from Users
-- order by user_id

-- Efficient solution
select user_id ,concat(upper(left(name,1)),lower(substring(name,2))) as name
from Users
order by user_id