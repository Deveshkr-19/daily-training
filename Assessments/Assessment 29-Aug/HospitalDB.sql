create database HospitalDB

use HospitalDB

create table Doctors(id int primary key, doc_name nvarchar(20), specialization nvarchar(20), 
age int, email nvarchar(20), mobile numeric(18,0), salary numeric(18,0), doc_address nvarchar(20));

create table Patients(id int primary key, pat_name nvarchar(20), age int, email nvarchar(20),
mobile numeric(18,0), insuranceID numeric(18,0), pat_address nvarchar(20), vaccRec nvarchar(20));

create table Beds(bedNo int primary key, roomNo int, patID int,
constraint fk_bed_patID
foreign key (patID)
references Patients (id));


-- *************** PROCEDURES ***************


-- Creating procedure for/and inserting values into Doctors table

create procedure sp_insertDoctor
(
@id int, 
@doc_name nvarchar(20), 
@specialization nvarchar(20), 
@age int, 
@email nvarchar(20), 
@mobile numeric(18,0), 
@salary numeric(18,0), 
@doc_address nvarchar(20)
)
as
begin

insert into Doctors(id, doc_name, specialization, age, email, mobile, salary, doc_address) values 
(@id, @doc_name, @specialization, @age, @email, @mobile, @salary, @doc_address)

end

exec sp_insertDoctor
@id = 101, 
@doc_name = "Devesh",
@specialization = "MBBS",
@age = 28,
@email = "devesh@mail.com",
@mobile = 8758746573,
@salary = 230000,
@doc_address = "Delhi"

exec sp_insertDoctor
@id = 102, 
@doc_name = "Deepak",
@specialization = "MD",
@age = 31,
@email = "deepak@mail.com",
@mobile = 8753286573,
@salary = 360000,
@doc_address = "Delhi"

exec sp_insertDoctor
@id = 103, 
@doc_name = "Deeksha",
@specialization = "MBBS",
@age = 39,
@email = "deeksha@mail.com",
@mobile = 8758951573,
@salary = 310000,
@doc_address = "Lucknow"

exec sp_insertDoctor
@id = 104, 
@doc_name = "Deepesh",
@specialization = "MBBS",
@age = 26,
@email = "deepesh@mail.com",
@mobile = 8758823583,
@salary = 370000,
@doc_address = "Kanpur"

exec sp_insertDoctor
@id = 105, 
@doc_name = "Deepika",
@specialization = "MD",
@age = 25,
@email = "deepika@mail.com",
@mobile = 8758721573,
@salary = 280000,
@doc_address = "Delhi"

exec sp_insertDoctor
@id = 106, 
@doc_name = "Devyansh",
@specialization = "MBBS",
@age = 34,
@email = "devyansh@mail.com",
@mobile = 8718321573,
@salary = 300000,
@doc_address = "Lucknow"

select * from Doctors;


-- Creating procedure for/and inserting values into Patients table

create procedure sp_insertPatient
(
@id int, 
@pat_name nvarchar(20), 
@age int,
@email nvarchar(20),  
@mobile numeric(18,0),  
@insuranceID numeric(18,0), 
@pat_address nvarchar(20),
@vaccRec nvarchar(20)
)
as
begin

insert into Patients(id, pat_name, age, email, mobile, insuranceID, pat_address, vaccRec) values 
(@id, @pat_name, @age, @email, @mobile, @insuranceID, @pat_address, @vaccRec)

end


exec sp_insertPatient
@id = 901, 
@pat_name = "Ajay",
@age = 58,
@email = "ajay@mail.com",
@mobile = 9874321573,
@insuranceID = 12345,
@pat_address = "Lucknow",
@vaccRec = "Yes"

exec sp_insertPatient
@id = 902, 
@pat_name = "Amit",
@age = 63,
@email = "amit@mail.com",
@mobile = 9572321573,
@insuranceID = 12375,
@pat_address = "Lucknow",
@vaccRec = "Yes"

exec sp_insertPatient
@id = 903, 
@pat_name = "Atul",
@age = 71,
@email = "atul@mail.com",
@mobile = 9871291573,
@insuranceID = 17445,
@pat_address = "Kanpur",
@vaccRec = "No"

exec sp_insertPatient
@id = 904, 
@pat_name = "Ashutosh",
@age = 76,
@email = "ashutosh@mail.com",
@mobile = 9836441573,
@insuranceID = 11945,
@pat_address = "Delhi",
@vaccRec = "Yes"

exec sp_insertPatient
@id = 905, 
@pat_name = "Abhay",
@age = 52,
@email = "abhay@mail.com",
@mobile = 9810421573,
@insuranceID = 12215,
@pat_address = "Delhi",
@vaccRec = "No"

exec sp_insertPatient
@id = 906, 
@pat_name = "Anshu",
@age = 83,
@email = "anshu@mail.com",
@mobile = 9819571573,
@insuranceID = 18115,
@pat_address = "Lucknow",
@vaccRec = "Yes"

select * from Patients





-- Creating procedure for/and inserting values into Beds table

create procedure sp_insertBed
(
@bedNo int,
@roomNo int,
@patID int
)
as
begin

insert into Beds(bedNo, roomNo, patID) values 
(@bedNo, @roomNo, @patID)

end


exec sp_insertBed
@bedNo = 12,
@roomNo = 6,
@patID = 903

exec sp_insertBed
@bedNo = 8,
@roomNo = 2,
@patID = 901

exec sp_insertBed
@bedNo = 14,
@roomNo = 5,
@patID = 902

exec sp_insertBed
@bedNo = 9,
@roomNo = 1,
@patID = 906

exec sp_insertBed
@bedNo = 3,
@roomNo = 11,
@patID = 905

select * from beds


-- *************** TRIGGERS ***************

create table Doctors_log(logID int primary key identity, docID int, operation nvarchar(20), updateDate Datetime);

select * from Doctors_log

-- Creating trigger for inserting into Doctors table

create trigger DoctorInsertTrigger
on Doctors
for insert
as
insert into Doctors_log(docID, operation, updateDate)
select id, 'Data Inserted', GETDATE() from inserted



create table Patients_log(logID int primary key identity, patID int, operation nvarchar(20), updateDate Datetime);

select * from Patients_log

-- Creating trigger for inserting into Patients table

create trigger PatientInsertTrigger
on Patients
for insert
as
insert into Patients_log(patID, operation, updateDate)
select id, 'Data Inserted', GETDATE() from inserted



create table Bed_Logs(logID int primary key identity, bedNo int, operation nvarchar(20), updateDate Datetime);

select * from Bed_Logs

-- Creating trigger for inserting into Beds table

create trigger BedInsertTrigger
on Beds
for insert
as
insert into Bed_Logs(bedNo, operation, updateDate)
select bedNo, 'Data Inserted', GETDATE() from inserted
