insert into Areas(area,zipcode) values('ABC','12345')
insert into Areas(area,zipcode) values('BBB','12345')
insert into Areas(area,zipcode) values('CCC','12345')
select * from areas

insert into skills values('C','PLT')
insert into skills values('C++','OOPS')
insert into skills values('Java','Web'),('SQL','RDBMS')
select * from skills

insert into Employees(name, age, area) values('Ramu',23,'ABC')
select * from Employees
insert into Employees(name, age, area) values('Somu',34,'BBB'),('Bimu',27,'ABC')
--will not get inserted because of volating refferntial integrity
insert into Employees(name, age, area) values('Ramu',23,'HHH')

insert into EmployeesSkills values(101,'C',7)
insert into EmployeesSkills values(101,'C++',7)
insert into EmployeesSkills values(101,'Java',6)
insert into EmployeesSkills values(102,'Java',7)
insert into EmployeesSkills values(102,'SQL',8)
select * from EmployeesSkills

--change the skill level of the 101 employee in C to 8
update EmployeesSkills set skill_level=8 where employee_id=101 and skill_name='C'

-- update the age of employee Bimu to 29
update Employees set age=29 where employee_id=102


-- update name and age of employee 102
update Employees set name='Komu',age=22 where employee_id=102

--delete 
delete from Skills where skill = 'C'
--delete froim child to delete from parent
delete from EmployeesSkills where skill_name='C'
delete from Skills where skill = 'C'
