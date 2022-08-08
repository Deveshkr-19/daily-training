create database mentorAssignment1

use mentorAssignment1

create table employees(id int primary key identity, empName nvarchar(20), managerID int)

insert into employees values('Mike', 3);
insert into employees values('David', 3);
insert into employees values('Roger', NULL);
insert into employees values('Mary', 2);
insert into employees values('Joseph', 2);
insert into employees values('Ben', 2);

select * from employees

select A.empName as 'Employee Name',
ISNULL(B.empName, 'Top Manager') as 'Manager Name'
from employees A
left join employees B
on A.managerID = B.id




create table Departments(DeptId nvarchar(20), EmpName nvarchar(20), Salary int)
insert into Departments values ('Engg', 'Sam', 1000)
insert into Departments values ('Engg', 'Smith', 2000)
insert into Departments values ('Engg', 'Tom', 2000)
insert into Departments values ('HR', 'Denis', 1500)
insert into Departments values ('HR', 'Denny', 3000)
insert into Departments values ('IT', 'David', 2000)
insert into Departments values ('IT', 'John', 3000)


SELECT DeptId, EmpName, Salary FROM Departments 
WHERE Salary
IN (SELECT MAX(Salary) FROM Departments GROUP BY DeptID)