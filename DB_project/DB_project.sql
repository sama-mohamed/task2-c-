create database DB_project
create schema project

create table project.patient(
UR int primary key,
name varchar(50),
age int,
email varchar(50),
phone int ,
medicare_card_num numeric
)
alter table project.patient add city varchar(50)

create table project.doctor(
id int primary key,
name varchar(50),
years_of_exp int,
specialty varchar(50),
email varchar(50),
phone int,
patient_id int
foreign key (patient_id) references project.patient(UR)
)

create table project.drug_company(
id int primary key,
name varchar(50),
address varchar(50),
phone int
)

create table project.drugs(
id int primary key,
trade_name varchar(50),
strength varchar(50),
company_id int
foreign key (company_id) references project.drug_company(id)
on delete cascade
)

create table project.prescriptions(
id int primary key,
date datetime2,
quantity int,
drug_id int
foreign key (drug_id) references project.drugs(id)
)

create table project.prescriptions_data(
patient_id int,
doctor_id int,
prescripton_id int
foreign key (patient_id) references project.patient(UR),
foreign key (doctor_id) references project.doctor(id),
foreign key (prescripton_id) references project.prescriptions(id)
)

--1-SELECT: Retrieve all columns from the Doctor table.
select * from project.doctor

--2-ORDER BY: List patients in the Patient table in ascending order of their ages.
select name from project.patient
order by age asc

--3-OFFSET FETCH: Retrieve the first 10 patients from the Patient table, starting from the 5th record.
select * from project.patient
order by UR 
offset 4 rows
fetch next 10 rows only

--4-SELECT TOP: Retrieve the top 5 doctors from the Doctor table.
select top 5 * from project.doctor

--5-SELECT DISTINCT: Get a list of unique address from the Patient table.
select distinct name from project.patient

--6-WHERE: Retrieve patients from the Patient table who are aged 25.
select * from project.patient where age=25

--7-NULL: Retrieve patients from the Patient table whose email is not provided.
select * from project.patient where email is null

--8-AND: Retrieve doctors from the Doctor table who have experience greater than 5 years and specialize in 'Cardiology'.
select name from project.doctor where years_of_exp>5 and specialty='Cardiology'

--9-IN: Retrieve doctors from the Doctor table whose speciality is either 'Dermatology' or 'Oncology'.
select name from project.doctor where specialty in ('Oncology','Dermatology')

--10-BETWEEN: Retrieve patients from the Patient table whose ages are between 18 and 30.
select * from project.patient where age between 18 and 30

--11-LIKE: Retrieve doctors from the Doctor table whose names start with 'Dr.'.
select * from project.doctor where name like 'Dr%'

--12-Column & Table Aliases: Select the name and email of doctors, aliasing them as 'DoctorName' and 'DoctorEmail'.
select d.name as DoctorName ,d.email as DoctorEmail from project.doctor d 

--13-Joins: Retrieve all prescriptions with corresponding patient names.
select pres.id,pres.date,pres.quantity,d.trade_name,d.strength,p.name from project.prescriptions pres ,project.drugs d,project.patient p,project.prescriptions_data data
where data.patient_id=p.UR and pres.id=data.prescripton_id and pres.drug_id=d.id
--14-GROUP BY: Retrieve the count of patients grouped by their cities.
select city ,count(UR) from project.patient group by city

--15-HAVING: Retrieve cities with more than 3 patients.
select city ,count(UR) from project.patient group by city
having count(UR)>5

--16-GROUPING SETS: Retrieve counts of patients grouped by cities and ages.
select city ,count(UR) from project.patient group by city ,age

--17-CUBE: Retrieve counts of patients considering all possible combinations of city and age.
select city,age,count(*) from project.patient
group by cube(city,age)

--18-ROLLUP: Retrieve counts of patients rolled up by city.
select city,count(*) from project.patient
group by rollup(city)

--19-EXISTS: Retrieve patients who have at least one prescription.
select * from project.patient where exists(select 1 from project.prescriptions where project.patient.UR=project.prescriptions.id)

--20-UNION: Retrieve a combined list of doctors and patients.
select * from project.doctor union select * from project.patient

--21-Common Table Expression (CTE): Retrieve patients along with their doctors using a CTE.


--22-INSERT: Insert a new doctor into the Doctor table.
insert into project.doctor (
id,
name,
years_of_exp ,
specialty,
email,
phone,
patient_id
)
values(
1,
'ahmed',
5,
'Orthopedic surgeon',
'ahmed@gmail',
123456,
1
)

--23-INSERT Multiple Rows: Insert multiple patients into the Patient table.
insert into project.patient(
UR,
name,
age,
email,
phone,
medicare_card_num 
)
values(
2,
'ahmed',
5,
'ahmed@gmail',
123456,
123456
),
(
3,
'rana',
12,
'rana@gmail',
123456,
123456
),
(
4,
'kareem',
30,
'kareem@gmail',
123456,
123456
)
--24-UPDATE: Update the phone number of a doctor.
update project.doctor set phone=11111 where id=1

--25-UPDATE JOIN: Update the city of patients who have a prescription from a specific doctor.

--26-DELETE: Delete a patient from the Patient table.
delete from project.patient where UR=1

--27-Transaction: Insert a new doctor and a patient, ensuring both operations succeed or fail together.
begin transaction
insert into project.doctor (id,
name,
years_of_exp ,specialty,email,phone,patient_id)values(2,'mohamed',3,' surgeon','mmmm@gmail',123456,3)
insert into project.patient(UR,name,age,email,phone,medicare_card_num,city)values(5,'ali',
55,'ali@gmail',555555,000456,'cairo')
commit;

--28-View: Create a view that combines patient and doctor information for easy access.

--29-Index: Create an index on the 'phone' column of the Patient table to improve search performance.
create index patient_phone on project.patient(phone)

--30-Backup: Perform a backup of the entire database to ensure data safety.
