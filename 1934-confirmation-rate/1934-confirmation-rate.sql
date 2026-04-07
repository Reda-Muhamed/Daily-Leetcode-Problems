select s.user_id,  
COALESCE(round(count(case when action = 'confirmed' then action end) / count(action),2),0) as confirmation_rate
from Signups s
left join Confirmations c on s.user_id = c.user_id
group by s.user_id