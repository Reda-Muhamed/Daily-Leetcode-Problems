with weatherTemp as(
    select id, recordDate, temperature,
    lag(temperature) over (order by recordDate) as prevTemp,
    lag(recordDate) over (order by recordDate) as prevDate
    from Weather
)
select id from weatherTemp
where temperature > prevTemp and datediff(recordDate,prevDate)= 1