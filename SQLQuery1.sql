create database Mart

use Mart

create table users(
	Id int primary key identity not null,
	Name varchar(50) not null,
	Email varchar(50) not null,
	Password varchar(50) not null,
	Role varchar(50) not null
)

create table categories(
Id int primary key identity not null,
Name varchar(50) not null
)

create table brands(
Id int primary key identity not null,
Name varchar(50) not null
)

create table contactquery(
Id int primary key identity not null,
Name varchar(50) not null,
Email varchar(50) not null,
Subject varchar(200) not null,
Message text not null
)

create table products(
Id int primary key identity not null,
Name varchar(50) not null,
BrandId int foreign key references brands(Id),
CategoryId int foreign key references categories(Id),
Price float not null,
Featured varchar(50) not null,
Details text not null
)

create table productimages(
Id int primary key identity not null,
ImageURL varchar(200) not null,
ProductId int foreign key references products(Id)
)

create table tbl_user(
Id int primary key identity not null,
	Name varchar(50) not null,
	Email varchar(50) not null,
	Password varchar(50) not null
)

create table orders(
Id int primary key identity not null,
InvoiceNo int default null,
CustomerId int foreign key references users(Id) ,
Name varchar(50) not null,
Email varchar(50) not null,
Address varchar(500) not null,
CellNo bigint not null,
OrderDate datetime not null,
Remarks text default null,
DeliveryCharge int default null,
Amount money default null,
TotalAmount float default null,
Payment_Type varchar(50),
Status varchar(50) default null
)

alter table orders
add constraint FK_Constraint_De__ID
foreign key (CustomerId) references tbl_User(ID);

create table orderdetails(
Id int primary key identity,
ProductId int foreign key references products(Id),
Price float not null,
Quantity int not null,
OrderId int foreign key references orders(Id)
)
