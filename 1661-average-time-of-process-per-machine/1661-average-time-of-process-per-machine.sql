# Write your MySQL query statement below
select machine_id , round(avg(end - start),3) as processing_time from (
    select machine_id, 
    max(case when activity_type  = 'start' then timestamp end) as start,
    max(case when activity_type  = 'end' then timestamp end) as end
    from Activity
    group by machine_id , process_id 

) as temp
group by machine_id