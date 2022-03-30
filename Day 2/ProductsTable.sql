create database shoppingAPPMVC
use shoppingAPPMVC
create table products
(
	pId int primary key,
	pName varchar(20),
	pCategory varchar(20),
	pPrice int,
	pIsInStock bit,
	pDiscount int
)


insert into products values(101,'Pepsi','Cold-Drink',50,1,5)


insert into products values(102,'Maggie','Fast-Food',50,1,5)

insert into products values(103,'Fossil','Cold-Drink',50,1,5)

insert into products values(104,'IPhone','Cold-Drink',50,1,5)

select * from products


create table customers
(
	cId int primary key,
	cName varchar(20),
	cCity varchar(20),
	cWalletBalance int,
	cIsActive bit,
	cCustomerType varchar(20)
)

insert into customers values(201,'Rishi','Pune',8000,1,'Good')
insert into customers values(202,'Arjun','Chennai',8000,1,'Excellent')
insert into customers values(203,'Mahesh','Hyderabad',0,0,'Excellent')


select * from customers




create table deptInfo
(
	deptNo int primary key,
	deptName varchar(20),
	deptLocation varchar(20),
	deptHead varchar(20)
)
insert into deptInfo values(10,'IT','Mumbai','Mohan')
insert into deptInfo values(20,'Accounts','New Yark','Steve')
insert into deptInfo values(30,'Transport','Pune','Mike')
insert into deptInfo values(40,'HR','Paris','Stephen')

create table EmployeeInfo
(
	empNo int primary key,
	empName varchar(20),
	empDesignation varchar(20),
	empSalary int,
	empDept int,

	constraint chk_designation check(empDesignation in ('Developer','Accounts','HR')),
	constraint fk_empDept foreign key(empDept) references deptInfo
)
insert into EmployeeInfo values(1,'Nikhil','Developer',600,10)
insert into EmployeeInfo values(2,'Kriti','HR',600,40)
insert into EmployeeInfo values(3,'Mansi','Developer',600,10)
insert into EmployeeInfo values(4,'Aman','Accounts',600,20)





