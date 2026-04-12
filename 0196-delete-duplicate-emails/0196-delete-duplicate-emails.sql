
-- delete p1 from Person p1
-- join Person p2 on p2.email = p1.email and p1.id > p2.id

-- Another solution

delete from Person where id not in (
    select minid from (
        select min(id) as minid from Person group by email
    )as t
)