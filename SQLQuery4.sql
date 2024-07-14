insert into Passwords(EmployeeID,EmployeePassword)
values(12,0xab)

select * from Passwords

delete  from Passwords
where EmployeePassword = 0xAB