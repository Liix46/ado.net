create database sales
go

use sales
go

create table buyers
(
	Id int primary key identity,
	FirstName nvarchar(20) not null,
	LastName nvarchar(20) not null,
	constraint ck_buyers_Name check(FirstName !='' and LastName !='')
)

create table sellers
(
	Id int primary key identity,
	FirstName nvarchar(20) not null,
	LastName nvarchar(20) not null,
	constraint ck_sellers_Name check(FirstName !='' and LastName !='')
)

create table sales
(
	Id int primary key identity,
	BuyersId int,
	SellersId int,
	TransactAmount float,
	TransactDate Date,
	foreign key (BuyersId) references buyers (Id),
	foreign key (SellersId) references sellers (Id),
	constraint ck_sales_Amount check(TransactAmount > 0),
)

	
insert into buyers(FirstName,LastName)
values ('Tom','Cruise')
insert into buyers(FirstName,LastName)
values ('Joaquin','Phoenix')
insert into buyers(FirstName,LastName)
values ('Johnny','Depp')
go

insert into Sellers(FirstName,LastName)
values('Jennifer','Lawrence')
insert into Sellers(FirstName,LastName)
values('Angelina','Jolie')
GO

insert into Sales(BuyersId,SellersId,TransactAmount,TransactDate)
values(1,1,10,GETDATE())
insert into Sales(BuyersId,SellersId,TransactAmount,TransactDate)
values(2,1,200,GETDATE())
insert into Sales(BuyersId,SellersId,TransactAmount,TransactDate)
values(3,1,100,GETDATE())

insert into Sales(BuyersId,SellersId,TransactAmount,TransactDate)
values(1,2,150,GETDATE())
insert into Sales(BuyersId,SellersId,TransactAmount,TransactDate)
values(2,2,30,GETDATE())
insert into Sales(BuyersId,SellersId,TransactAmount,TransactDate)
values(3,2,70,GETDATE())
