select * from authors
--where clause restricts the number of rows
select * from authors where state='ca'
--column selection
select au_lname, au_fname from authors 