# Write your MySQL query statement below
select r.contest_id,ifnull(round(count(r.user_id) / (select count(user_id) from Users)* 100 ,2),0) as percentage 
from Register r 
join Users u on r.user_id = u.user_id
group by r.contest_id
order by percentage desc , r.contest_id 