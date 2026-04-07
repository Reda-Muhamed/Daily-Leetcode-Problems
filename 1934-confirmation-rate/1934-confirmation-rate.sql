select s.user_id,  
round(ifnull(avg(if(action = 'confirmed' , 1 , 0)),0),2) as confirmation_rate
from Signups s
left join Confirmations c on s.user_id = c.user_id
group by s.user_id