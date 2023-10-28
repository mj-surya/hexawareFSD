use pubs

--1) Print all the titles names
select title 'Title Name' from titles

--2) Print all the titles that have been published by 1389
select title 'Title Name' from titles where pub_id=1389

--3) Print the books that have price in rangeof 10 to 15
select title 'Books', price 'Price' from titles where price between 10 and 15

--4) Print those books that have no price
select title 'Books', price 'Price' from titles where price is null

--5) Print the book names that strat with 'The'
select title 'Title' from titles where title like 'the%'

--6) Print the book names that do not have 'v' in their name
select title 'Title' from titles where title not like '%v%'

--7) print the books sorted by the royalty
select title 'Book', royalty 'Royalty' from titles order by royalty

--8) print the books sorted by publisher in descending then by types in asending then by price in descending
select title 'Books' from titles order by pub_id desc, type, price desc

--9) Print the average price of books in every type
select type 'Book Type', avg(price) 'Average Price' from titles group by type

--10) print all the types in uniques
select type 'Unique Types' from titles group by type

--11) Print the first 2 costliest books
select TOP 2 title 'Title', price 'Price' from titles order by price desc

--12) Print books that are of type business and have price less than 20 which also have advance greater than 7000
select title 'Books' from titles where type='business' and price < 20 and advance > 7000

--13) Select those publisher id and number of books which have price between 15 to 25 and 
--have 'It' in its name. Print only those which have count greater than 2. Also sort the 
--result in ascending order of count
select pub_id 'Publisher Id', count(title) 'Number of Books' 
from titles
where price between 15 and 25 and title like '%it%' 
group by pub_id
having count(title) > 2
order by count(title)

--14) Print the Authors who are from 'CA'
select au_fname 'Authors' from authors where state ='CA'

--15) Print the count of authors from every state
select state 'State', count(au_fname) 'Count of Authors' from authors group by state


-----------------------------------------------------------------------------------------------------------------------------------------------------
--SET 2--

--1) Print the storeid and number of orders for the store
select stor_id 'Store Id', count(ord_num) 'Nomber of Orders' from sales group by (stor_id)

--2) print the numebr of orders for every title
select title_id 'Title Id', count(ord_num) 'Nomber of Orders' from sales group by (title_id)

--3) print the publisher name and book name
select title 'Book Name', pub_name 'Publisher Name'
from titles t, publishers p
where t.pub_id=p.pub_id

--4) Print the author full name for al the authors
select concat(au_fname,' ',au_lname) 'Author Full Name' from authors

--5) Print the price or every book with tax (price+price*12.36/100)
select title 'Books', (price+price*12.36/100) 'Taxed Price' from titles

--6) Print the author name, title name
select title 'Title', au_fname 'Author' from titleauthor ta,titles t, authors a
where a.au_id=ta.au_id and t.title_id=ta.title_id
select * from publishers
--7) print the author name, title name and the publisher name
select title 'Title', au_fname 'Author', pub_name 'Publisher Name'  
from titleauthor ta,titles t, authors a, publishers p
where a.au_id=ta.au_id and t.title_id=ta.title_id and t.pub_id=p.pub_id

--8) Print the average price of books pulished by every publisher
select pub_name 'Publisher Name', avg(price) 'Average Price'
from titles t, publishers p
where t.pub_id=p.pub_id
group by p.pub_name

--9) print the books published by 'Marjorie'
select title
from titles t
where title_id in (select title_id from titleauthor 
where au_id in (select au_id from authors where au_fname='marjorie'))

--10) Print the order numbers of books published by 'New Moon Books'
select ord_num
from sales
where title_id in (select title_id from titles 
where pub_id in (select pub_id from publishers 
where pub_name='new moon books'))

--11) Print the number of orders for every publisher
select pub_name 'Publishers', count(ord_num) 'Total Orders'
from sales s left join titles t on s.title_id=t.title_id 
left join publishers p on t.pub_id=p.pub_id
group by pub_name

--12) print the order number , book name, quantity, price and the total price for all orders
select ord_num 'Order Number',title 'Book Name', qty 'Quantity', price 'Price',price*qty 'Total Price'
from titles t, sales s
where t.title_id=s.title_id

--13) print he total order quantity for every book
select title 'Books', Count(ord_num)
from sales s, titles t
where t.title_id=s.title_id
group by t.title

--14) print the total ordervalue for every book
select ord_num 'Order Number', price*qty 'Order Value'
from titles t,sales s

--15) print the orders that are for the books published by the publisher for which 'Paolo' works for
select ord_num 'Order Number' from sales 
where title_id in (select title_id from titles 
where pub_id=(select pub_id from employee where fname='paolo'))
