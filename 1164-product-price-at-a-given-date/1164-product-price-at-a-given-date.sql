# Write your MySQL query statement below
with temp as(
    select product_id , max(change_date) as lDate
    from Products 
    where (change_date<='2019-08-16')
    group by product_id
    order by change_date desc
)

select distinct p.product_id , if((p.product_id) not in (
        select product_id from temp
    ),10, p.new_price) as price
 from Products p 
 where (p.product_id , p.change_date) in (
    select * from temp
 ) or ((p.product_id) not in (
    select product_id from temp
 ))
