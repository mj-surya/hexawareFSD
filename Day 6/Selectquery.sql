use pubs

select * from authors
select * from titles

--projection
select au_fname, phone from authors
select au_fname 'Author', phone 'Contact Number' from authors
select au_fname as 'Author', phone as 'Contact Number' from authors
select au_fname Author, phone Contact_Number from authors

--selection
select * from authors where contract=0
select * from titles where royalty>10
select * from titles where royalty>10 or price>15
select title, price, royalty, advance from titles where royalty>10 or price >15
select title 'Book Name', price 'Cost', royalty 'Royalty Paid',
advance 'Advance received'
from titles 
where royalty  >10 and price>15

select title, price from titles where price >= 10 and price <=25
select title, price from titles where price between 10 and 25

select * from titles where title like 'the%'

--fetch those title that have 'data' any where in teh title
select * from titles where title like '%data%'

--fetch those titles whcih are published before '1991-06-18 00:00:00.000'
select title from titles where pubdate < '1991-06-18 00:00:00.000'

--fetch the book name and the price of those books that have been published by 0877
select title 'Book Name', price 'Price' from titles where pub_id=0877

-- fetch  book name, price nad notes of books from business    type that re priced in
-- the range of 15 to 100
select title 'Book Name', price 'Price', notes 'Notes' 
from titles
where type='business' and price between 15 and 100

--I want the books that have price of 10 or 20 or 30
select * from titles where price =10 or price = 20 or price = 30

select * from titles where price in (10, 20, 30)

--Aggrigate data
select avg(price) 'Average Price' from titles
select Min(price) 'Minimum Price' from titles

select avg(price) 'Average Price' from titles
where type='business'

--identify null
select * from titles where price is null

--sub total and grouping
select type 'Type name', AVG(price) 'Averge price'from titles group by type

select state, count(au_id) from authors group by state

select title_id, count(ord_num) 'number of times sold'
from sales group by title_id

select title_id, count(ord_num) 'number of times sold'
from sales
group by title_id 
having count(ord_num) >1

select type 'Type name', AVG(price) 'Averge price'
from titles 
where price >10
group by type
having AVG(price)>18

---sorting
select * from authors order by state,city,au_fname

select type 'Type name', AVG(price) 'Averge price'
from titles 
where price >10
group by type
having AVG(price)>18
order by Type desc

--subqueries

select * from titles
select * from sales
select title_id from titles where title = 'Straight Talk About Computers'
select * from sales where title_id = 'BU7832'

select * from sales where title_id =
(select title_id from titles where title = 'Straight Talk About Computers')

select * from authors

Select * from titles where title_id in(
select title_id from titleauthor where au_id = 
(select au_id from authors where au_lname = 'White'))

select * from sales
select * from titles
select * from publishers

--print title name for books that have been sold
select title 'Title' from titles where title_id in 
(select title_id from sales)


--fetch the average price of titles that hvae been published by publishers 
--who are from USA. Print only if the average is greater than the average of
-- all the titles
--sort them by asencending order of the average

select title 'Title', Avg(price) 'Average Price'
from titles
where pub_id in (select pub_id from publishers where country='USA')
group by title
having avg(price)>(select avg(price) from titles)
order by avg(price)