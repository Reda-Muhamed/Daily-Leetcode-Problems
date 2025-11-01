# Write your MySQL query statement below
select Signups.user_id , round(COALESCE(conPart , 0)/COALESCE(conall,1),2) as confirmation_rate from Signups 
    left join (select user_id, count(case when action='confirmed' then 1 end) as conPart,
            count(action) as conall
            from Confirmations 
            group by user_id

        )as t
        on t.user_id = Signups.user_id
