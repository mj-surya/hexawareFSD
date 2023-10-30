use pubs

select * from publishers

select * from titles
--select publisher name and the title name
select pub_name 'Publisher Name', title 'Book Name' from publishers join titles
on publishers.pub_id = titles.pub_id

select pub_name 'Publisher Name', title 'Book Name' 
from publishers p join titles t
on p.pub_id = t.pub_id

select p.pub_id 'Publisher Id', pub_name 'Publisher Name', title 'Book Name' 
from publishers p join titles t
on p.pub_id = t.pub_id
order by [Publisher Name]

--outer JOin
select pub_name 'Publisher Name', title 'Book Name' 
from publishers left outer join titles
on publishers.pub_id = titles.pub_id

select t.title Book_Name, s.qty Quantity_Sold
from sales s right outer join titles t
on s.title_id = t.title_id

--print publisher name and employee name
select pub_name 'Publisher', fname 'Employee'
from publishers p join employee e on p.pub_id=e.pub_id

select title 'Book Name', CONCAT(au_fname,' ',au_lname) 'Author Name'
from titles t join titleauthor ta
on t.title_id = ta.title_id 
join authors a on ta.au_id = a.au_id

--Select the publisher name, title name and the sold quantity
select pub_name 'Publisher Name', title 'Book', sum(qty) 'No. of books sold'
from titles t join publishers p
on t.pub_id =p.pub_id
join sales s on t.title_id=s.title_id group by pub_name,title

--cross join
select * from sales cross join employee

create table tbl1
(f1 int,
f2 varchar(20))

insert into tbl1 values(1,'abc'),(2,'efg'),(3,'klj'),(4,'jjj')
--data injection
select * from tbl1 where f1=1;delete from tbl1;


create procedure first_proc
as
begin
select * from authors
end

execute first_proc

create proc proc_InsertSample(@f1 int, @f2 varchar(20))
as
begin
   insert into tbl1 values(@f1,@f2)
end

exec proc_InsertSample 5,'GYH'
exec proc_InsertSample 5,'GYH;delete from tbl1'

create proc proc_Select(@f1 int)
as
begin
   select * from tbl1 where f1=@f1
end
exec proc_Select 1

alter proc proc_Select(@f2 varchar(20))
as
begin
   select * from tbl1 where f2=@f2
end

exec proc_Select '1;delete from tbl1'

--create a proc that will take a author name 
--and fetch the total sales done on his books

create proc proc_GetTotalSaleAmount(@authorName varchar(20),@salemount float out)
as
begin
   declare
    @saleamt float
	set @saleamt = (select sum(s.qty) * sum(t.price) from sales s join titles t 
						on s.title_id=t.title_id
						where t.title_id in
						(select title_id from titleauthor where au_id= 
						(select au_id from authors where au_fname = @authorName)))
	set @salemount = @saleamt
end


select * from authors

declare @amt float
begin
exec proc_GetTotalSaleAmount 'Cheryl',@amt out
print @amt
end

--functions
create function fn_CalculateTax(@price float)
returns float
as
begin
    declare @totalPrice float
	set @totalPrice = @price +(@price*12.36/100)
	return round(@totalPrice,2)
end

select title,price,dbo.fn_CalculateTax(price) 'Nett. Price'
from titles

--create a function that will take the author's first name and last name and 
--give back the full name separated by space
create function fn_GetFullname(@fname varchar(20), @lname varchar(40))
returns varchar(60)
as
begin
	declare @fullname varchar(60)
	set @fullname = Concat(@fname,' ',@lname)
	return @fullname
end

select dbo.fn_GetFullname(au_fname,au_lname) 'Full Name'from authors

--create a procedure that will take the publisher name and give back the total sale 
--for the books published

create proc proc_GetTotalSale(@publisherName varchar(20),@totalsale float out)
as
begin
   declare
    @sale float
	set @sale = (select sum(s.qty) from sales s 
	join titles t on s.title_id=t.title_id 
	where t.pub_id in(select pub_id from publishers where pub_name=@publisherName))
	set @totalsale= @sale
end

declare @sales int
begin
exec proc_GetTotalSale 'Binnet & Hardley',@sales out
select @sales 'Total Sales'
end


select * from publishers
select * from sales
select * from titles

--VIew
create view vwPublisher
as
select pub_id 'Publisher Id', pub_name 'Publisher Name'  from Publishers

select * from vwPublisher

create view vwInvoice
as
 select t.title 'Book Name', sum(s.qty)*sum(t.price) 'Sale Amount' from sales s join titles t
                    on s.title_id=t.title_id
					group by t.title 

select * from vwInvoice


create index idxsample
on tbl1(f1)

sp_help tbl1

create trigger trg_InsertTbl1
on tbl1
for insert
as
begin
   print 'Hello'
end

insert into tbl1 values(101,'UUU')

use dbHexawareFSD

select * from EmployeesSkills

create trigger trgInsertEmployeeSkill
on EmployeesSkills
instead of insert
as
begin
   declare 
	 @skillName varchar(20),
	 @empId int,
	 @level int
	 set @SkillName = (select skill_name from inserted)
	 set @empId =  (select employee_id from inserted)
	 set @level =  (select skill_level from inserted)
	 if((select count(skill) from Skills where skill= @skillName) =0)
	 begin
			print 'Skill not present in skill table'
	end
	else
	begin
	    insert into EmployeesSkills values(@empId,@skillName,@level)	
	end
end

insert into EmployeesSkills values(101,'SQ',8)



