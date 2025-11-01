select id  from (
    select id,temperature,recordDate,lag(temperature) over (order by recordDate ) as prevTemp, lag(recordDate) over (order by recordDate ) as prevDate
    from Weather
)
 as t  
where (temperature > prevTemp and DATEDIFF(recordDate , prevDate)= 1);
