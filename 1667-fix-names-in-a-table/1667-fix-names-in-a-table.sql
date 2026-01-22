# Write your MySQL query statement below
select user_id ,  IF(
    name LIKE '% %',
  CONCAT(
  upper(left(SUBSTRING_INDEX(name, ' ', 1),1)),
  lower(SUBSTRING(SUBSTRING_INDEX(name,' ',1),2)),
  ' ',
  lower(SUBSTRING_INDEX(name, ' ', -1))
),  CONCAT(
  upper(left(SUBSTRING_INDEX(name, ' ', 1),1)),
  lower(SUBSTRING(SUBSTRING_INDEX(name,' ',1),2)))
 ) as name
from Users 
order by user_id
