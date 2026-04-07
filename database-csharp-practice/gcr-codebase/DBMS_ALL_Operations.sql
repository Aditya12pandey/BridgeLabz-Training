--Create Database database_name;
create database StudentRecord;

--Use database_name;
Use StudentRecord;

/*create table table_name(
    column_name datatype[constraint],
    column_name datatype[constraint]
);
*/
create table Student(
    StudentId int primary key,
    Name varchar(50) not null,
    Age int,
    Department varchar(30),
    Email varchar(50) unique
);

--DDL commands

--DDL command to add column
/*alter table table_name
add column_name datatype;
*/
alter table Student
add PhoneNumber varchar(12);

select * from Student;

--DDL command to insert record

/*INSERT INTO table_name (column1, column2, ...)
VALUES (value1, value2, ...);
*/
insert into Student(StudentId,Name,Age,Department,Email)
values(1, 'Aditya Vikram Pandey', 21, 'Computer Science', 'amit@gmail.com'), 
      (2, 'Yash ', 21, 'Computer Science', 'yash@gmail.com'),
      (3, 'Harsh ', 21, 'Computer Science', 'harsh@gmail.com'),
      (4, 'Rathee', 21, 'Computer Science', 'banku@gmail.com'),
      (5, 'Kartik', 21, 'Computer Science', 'kartik@gmail.com')

--DDL command to change column datatype

/*ALTER TABLE table_name
ALTER COLUMN column_name new_datatype;
*/
alter table Student
alter column Name varchar(30);


--command to rename table

--EXEC sp_rename 'old_table_name', 'new_table_name';
exec sp_rename 'Student','StudentDetails';


--command to rename a column in a table

--EXEC sp_rename 'table_name.old_column_name','new_column_name','COLUMN';

exec sp_rename 'StudentDetails.Name','StudentName','column';



--Drop a column in a table
/*ALTER TABLE table_name
DROP COLUMN column_name;
*/

alter table StudentDetails
drop column PhoneNumber;

--Truncate a table

--TRUNCATE TABLE table_name;
truncate table StudentDetails;

--update a record in a table
/*UPDATE table_name
SET column_name = value
WHERE condition;
*/

update StudentDetails 
set Department='IT'
where StudentName='Amit Sharma';


--Delete a record from table
/*DELETE FROM table_name
WHERE condition;
*/
delete from StudentDetails
where StudentId=3;

--select specific column from table
/*SELECT column1, column2
FROM table_name;
*/

select StudentName,Department  from StudentDetails;

--select all
--SELECT * FROM table_name;
select * from StudentDetails;

--where clause
/*SELECT *
FROM table_name
WHERE condition;
*/
select * from StudentDetails where Department='IT';
select * from StudentDetails where age>21;

--order by 
/*SELECT *
FROM table_name
ORDER BY column_name ASC | DESC;
*/

select * from StudentDetails order by StudentId desc;

select * from StudentDetails order by StudentId asc;

--Like keyword
/*SELECT *
FROM table_name
WHERE column_name LIKE pattern;
*/
select * from StudentDetails where StudentName like 'A%';

--group by + count
/*SELECT column_name, COUNT(*)
FROM table_name
GROUP BY column_name;
*/

select Department,count(*) as TotalStudents
from StudentDetails
group by Department;

--DCL commands

--CREATE USER user_name FOR LOGIN login_name;

create user User1 without login;
create user User2 without login;

--grant permission

/*GRANT permission1, permission2
ON table_name
TO user_name;
*/

grant select,insert on StudentDetails to User1;

grant select,update,delete on StudentDetails to User2;


CREATE TABLE CourseDetails (
    CourseId INT PRIMARY KEY,
    StudentId INT,
    CourseName VARCHAR(30),
    Duration INT,
    foreign key (StudentId) references StudentDetails(StudentId)
);

INSERT INTO CourseDetails
VALUES
(101, 1, 'Java', 6),
(102, 2, 'Python', 4),
(103, 4, 'C#', 5),
(104, 5, 'React', 3);

--inner join 
/*SELECT columns
FROM table1
INNER JOIN table2
ON condition;
*/
select s.StudentName, s.Department, c.CourseName, c.Duration from StudentDetails s inner join CourseDetails c on s.StudentId=c.StudentId;

--Left join

SELECT s.StudentName, c.CourseName
FROM StudentDetails s
LEFT JOIN CourseDetails c
ON s.StudentId = c.StudentId;

--Right join
SELECT s.StudentName, c.CourseName
FROM StudentDetails s
RIGHT JOIN CourseDetails c
ON s.StudentId = c.StudentId;

--Full outer join
SELECT s.StudentName, c.CourseName
FROM StudentDetails s
FULL OUTER JOIN CourseDetails c
ON s.StudentId = c.StudentId;
