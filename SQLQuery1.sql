create database onlinebooking
use onlinebooking

create table BusInventory
(BookingId int primary key identity(101,1),
BusName nvarchar(15) not null,
BusCategory nvarchar(10) Check (BusCategory IN ('Ac','Non AC')),
Availability_Seats int not null,
Boarding nvarchar(50),
Departure nvarchar(50),
StartTime datetime,
EndTime datetime,
Price int)

insert into businventory values('OrangeTravels','Ac',23,'JBS,Hyderabad','Bangalore','2024-01-22 10:34:53.44','2024-01-23 11:34:53.44',850)

create table usersignup 
(  
  FullName varchar(80),
  Dob varchar(80),
  Mobile varchar(10),
  Email varchar(80),
  State varchar(80),
  City varchar(80),
  Pincode varchar(6),
  Address varchar(80),
  username varchar(80) primary key,
  password varchar(80)
)
drop table usersign
insert into usersignup values('Rohithkumar','06-01-2000','7207415896','rohith@gmail.com','Telangana','Karimnagar',505001,'sainagar/karimnagar','Rohith','rohith@123')

create table adminlogin
(
 UserName varchar(90) primary key,
 Password varchar(90),
)

insert into adminlogin values('Rohithkumar','Rohith123')

select * from BusInventory
select * from usersignup
select * from adminlogin