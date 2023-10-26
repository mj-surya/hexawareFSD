create table emp (
    empno int identity(1,1) constraint pk_empno primary key,
    empname varchar(25),
    salary int,
    deptname varchar(50) ,
    bossno int 
)

CREATE TABLE DEPARTMENT (
    deptname VARCHAR(50) constraint pk_deptname PRIMARY KEY,
    deptfloor INT,
    phone int,
    empno INT NOT NULL
)

CREATE TABLE SALES (
    salesno INT identity(101,1) constraint pk_salesno PRIMARY KEY,
    saleqty INT,
    itemname VARCHAR(50),
    deptname VARCHAR(50),
)

CREATE TABLE ITEM (
    itemname VARCHAR(50) constraint pk_itemname PRIMARY KEY,
    itemtype VARCHAR(25),
    itemcolor VARCHAR(25)
)

--adding constraints after inserting data in all tables

alter table Emp
add CONSTRAINT fk_deptname foreign key(deptname) references Department(deptname)

alter table Emp
add CONSTRAINT fk_bossno foreign key(bossno) references Emp(empno)

alter table Department
add CONSTRAINT fk_empno foreign key(empno) references Emp(empno)

alter table Sales
add CONSTRAINT fk_itemname foreign key(itemname) references item(itemname)

alter table sales
alter column deptname varchar(50)

alter table Sales
add CONSTRAINT fk_deptnames foreign key(deptname) references Department(deptname)