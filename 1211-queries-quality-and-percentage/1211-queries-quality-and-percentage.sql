# Write your MySQL query statement below
select q1.query_name,
 round(avg(q1.rating / q1.position),2) as quality ,
 round(sum(if(q1.rating < 3, 1, 0)) / count(q1.rating) * 100, 2) as poor_query_percentage 
 from Queries q1
 group by q1.query_name
