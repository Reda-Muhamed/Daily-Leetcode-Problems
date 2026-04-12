# Write your MySQL query statement below
with temp as (
    select visited_on , sum(amount) as amount 
     from Customer
     group by visited_on 
),
 temp2 as(
    select visited_on ,
    sum(amount) over (order by visited_on ROWS BETWEEN 6 PRECEDING AND CURRENT ROW) as amount , 
    round(avg(amount) over (order by visited_on ROWS BETWEEN 6 PRECEDING AND CURRENT ROW),2) as average_amount
    from temp 
)
select visited_on, amount,average_amount 
from temp2 
where visited_on >= (select date_add(min(visited_on) , interval 6 day) from temp2 )

