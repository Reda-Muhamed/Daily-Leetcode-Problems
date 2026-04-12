# Write your MySQL query statement below

(select u.name as results from Users u
join MovieRating m on u.user_id = m.user_id 
group by m.user_id
order by count(m.movie_id) desc,u.name limit 1
)
union all
(
select m.title as results from MovieRating mR 
join Movies m on m.movie_id = mR.movie_id and mR.created_at >= '2020-02-1' and mR.created_at <='2020-02-29' 
group by mR.movie_id
order by avg(mR.rating) desc, m.title limit 1)