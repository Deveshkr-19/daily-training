use bank_db

create table Customers_log(logID int primary key identity, custId int, operation nvarchar(20), updateDate Datetime);

select * from Customers_log

-- Creating trigger for inserting into CustomerDetails table

create trigger CustomerInsertTrigger
on CustomerDetails
for insert
as
insert into Customers_log(custId, operation, updateDate)
select custId, 'Data Inserted', GETDATE() from inserted

-- Customer update trigger


create trigger CustomerUpdateTrigger
on CustomerDetails
after update
as
insert into Customers_log(custId,operation,updateDate)
select custId,'Data Updated', GETDATE() from deleted

-- Customers delete trigger

create trigger CustomerDeleteTrigger
on CustomerDetails
after delete
as
insert into Customers_log(custId,operation,updateDate)
select custId,'Data Deleted', GETDATE() from deleted