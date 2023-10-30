use pubs

--1) print the store name, title name,, quantity, sale amount, 
--pulisher name, author name for all the sales. Also print those 
--books which have not been sold and authors who have not written.

select stor_name 'Store Name', title 'Title Name', qty 'Quantity',(price*qty) 'Sale Amount', pub_name 'Publisher Name',CONCAT(au_fname,' ',au_lname) 'Author Name'
from sales s right join titles t on s.title_id=t.title_id
right join stores ss on s.stor_id=ss.stor_id 
right join publishers p on t.pub_id=p.pub_id
right join titleauthor ta on t.title_id=ta.title_id
right join authors a on ta.au_id=a.au_id

--2) Create a stored procedure that will take the author name and 
--print the total sales amount for all the books authored by him/her
--Note : - If there are no books sold then print "Sale yet to gear up"

create proc proc_TotalSaleAmount(@authorName varchar(20),@totalsale float out)
as
begin
   declare
    @sale float
	set @sale = (select sum(qty*price) from sales s 
	right join titles t on s.title_id=t.title_id 
	right join titleauthor ta on t.title_id=ta.title_id
	right join authors a on ta.au_id=a.au_id
	where a.au_fname=@authorName
	group by a.au_id)
	set @totalsale= @sale
end

declare @sales int
begin
exec proc_TotalSaleAmount 'Cheryl',@sales out
select @sales 'Total Sales'
end

--3) print the details of the sale when the sale quantity is 
--greater than the sale quantity of all the same titles sold in the same store

SELECT *
FROM Sales s
WHERE qty in (
    SELECT MAX(qty)
    FROM Sales
	group by stor_id, title_id)

--4) Print the average price of every author's books withthe author's full name
select avg(price) 'Average Price', CONCAT(au_fname,' ',au_lname) 'Author Name'
from titles t right join titleauthor tu on t.title_id=tu.title_id
right join authors a on tu.au_id=a.au_id 
group by a.au_id,a.au_fname,a.au_lname

--5) Print the schema of the titles table and locate all the constrants
sp_help titles
EXEC sp_helpconstraint titles

--6) Create a procedure that will take the price and prints the 
--count of book that are priced less than that
create proc proc_priceLesser(@price int, @count int out)
as
begin
	declare @bookcount int
	set @bookcount = (select count(title) from titles where price<@price)
	set @count = @bookcount
end

declare @pricelesser int
begin
exec proc_priceLesser 20,@pricelesser out
select @pricelesser 'Total Sales'
end

--7) Find a way to ensure that the price of books are not updated 
--if the price is below 7

alter trigger trgpricelessthangiven
on titles
instead of update
as
begin
   declare 
	 @price int,
	 @titleId varchar
	 set @price = (select price from inserted)
	 set @titleId =  (select title_id from inserted)
	 if(@price<7)
	 begin
			print 'Price Not Updated'
	end
	else
	begin
	    UPDATE titles SET price=@price WHERE title_id='@titleId';	
	end
end
update titles set price = 8 where title_id='bu1032'


--8) print the books that have 'e' and 'a' in their name
select title 'Books' from titles
where title like '%e%'and title like '%a%'