create database airlines

use airlines

create table flights(flightID int primary key identity, flightName nvarchar(20), fromCity nvarchar(20), toCity nvarchar(20), seatingCapacity int)
select * from flights

create table passengers(passID int primary key identity, passName nvarchar(50), flightID int, seatNo nvarchar(20), 
constraint fk_pass_flightID foreign key (flightID) references flights(flightID))
select * from passengers

create table employees(empID int primary key identity, empName nvarchar(50), flightID int, empRole nvarchar(20))
select * from employees

insert into flights values('Air Bus 191', 'Delhi', 'Mumbai', 385)
insert into flights values('Air Bus 871', 'Delhi', 'Lucknow', 306)
insert into flights values('Air Bus 911', 'Delhi', 'Gorakhpur', 170)
insert into flights values('Air Bus 211', 'Delhi', 'Patna', 125)
insert into flights values('Air Bus 363', 'Delhi', 'Kashmir', 105)
insert into flights values('Air Bus 922', 'Delhi', 'Chennai', 300)
insert into flights values('Air Bus 142', 'Delhi', 'Kochi', 215)
insert into flights values('Air Bus 311', 'Delhi', 'Kanpur', 115)
insert into flights values('Air Bus 628', 'Delhi', 'Jaipur', 330)
insert into flights values('Air Bus 125', 'Delhi', 'Raipur', 245)

select * from flights

insert into passengers values('Devesh Kumar Singh', 2, 'C3')
insert into passengers values('Ajay Yadav', 1, 'D8')
insert into passengers values('Atul Kumar', 2, 'H3')
insert into passengers values('Abhi Singh', 5, 'A3')
insert into passengers values('Anuj Rawat', 3, 'A8')
insert into passengers values('Ritu Singh', 1, 'A4')
insert into passengers values('Apoorv Singh', 5, 'H1')
insert into passengers values('Shashank Singh', 4, 'D6')
insert into passengers values('Vijay Kumar', 7, 'F5')
insert into passengers values('Mohammad Faizan', 6, 'G7')

select * from passengers

insert into employees values('Ayushi Gupta', 2, 'Air Hostess')
insert into employees values('Anushka Sharma', 1, 'Air Hostess')
insert into employees values('Vanshika Verma', 1, 'Pilot')
insert into employees values('Vaishnavi Rao', 3, 'Air Hostess')
insert into employees values('Kashish Kumar', 2, 'Pilot')
insert into employees values('Ravi Kumar', 3, 'Pilot')
insert into employees values('Rihan Bajpayee', 4, 'Pilot')
insert into employees values('Yash Yadav', 5, 'Pilot')
insert into employees values('Ishani Gupta', 5, 'Air Hostess')
insert into employees values('Siddharth Tiwari', 4, 'Air Hostess')
select * from employees

create procedure sp_flights_list
as 
begin
select * from flights
end

exec sp_flights_list



create procedure sp_passengers_list
as 
begin
select * from passengers
end

exec sp_passengers_list

create procedure sp_employees_list
as 
begin
select * from employees
end

exec sp_employees_list



create procedure sp_pass_flights
as
begin
select p.passName as Passenger, f.flightName as Flight, f.fromCity as 'Departure Location', 
f.toCity as 'Arrival Location', p.seatNo as 'Seat Number'
from passengers p
left join
flights f
on p.flightID=f.flightID
end

exec sp_pass_flights



create procedure sp_emp_flights
as
begin
select e.empRole as 'Employee Role', e.empName as Employee, f.flightName as Flight
from employees e
left join
flights f
on e.flightID=f.flightID
order by Employee
end

exec sp_emp_flights