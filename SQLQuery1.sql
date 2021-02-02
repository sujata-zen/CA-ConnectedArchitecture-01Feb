use WFA3DotNet
-------------------------------------------------------

create table EmployeeADO
(
	empid int not null primary key identity(1,1),
	empname varchar(20),
	empsal float,
	empdept varchar(20),
	
);


insert into EmployeeADO values('Riyansh',73836.28,'Sales');
insert into EmployeeADO values('Kritika',37436.58,'Developement');
insert into EmployeeADO values('Shrutika',73862.11,'Testing');
insert into EmployeeADO values('Vedika',63266.28,'Sales');
insert into EmployeeADO values('Advik',14836.93,'Developement');
insert into EmployeeADO values('Preet',63791.32,'Testing');
insert into EmployeeADO values('Vinita',783432,'Developement');
insert into EmployeeADO values('Shaheer',89326.28,'Marketing');
insert into EmployeeADO values('Kanishka',462398,'Sales');
insert into EmployeeADO values('Anshik',48742.90,'Marketing');

select * from EmployeeADO


-------Tables With Foreign Key Relations
create table DeptADO1
(																							
	DeptId int not null primary key,
	DeptLoc varchar(20),
	
);
select * from DeptADO1
create table EmployeeADO1
(
	EmpId int not null primary key identity(1,1),
	EmpName varchar(20), --And this are  column numbers
	empsal float,
	EmpDept varchar(20),
	DeptNo int Foreign Key references DeptADO1(deptid) --here deptno is feoreign key
);
select * from DeptADO1
insert into DeptADO1 values(11,'Pune')
insert into DeptADO1 values(12,'Banglore')
insert into DeptADO1 values(13,'Dhule')
insert into DeptADO1 values(14,'Mumbai')

insert into EmployeeADO1 values('Riyansh',73836.28,'Sales',11);
insert into EmployeeADO1 values('Kritika',37436.58,'Developement',12);
insert into EmployeeADO1 values('Shrutika',73862.11,'Testing',13);
insert into EmployeeADO1 values('Vedika',63266.28,'Sales',14);
insert into EmployeeADO1 values('Advik',14836.93,'Developement',11);
insert into EmployeeADO1 values('Preet',63791.32,'Testing',13);
insert into EmployeeADO1 values('Vinita',783432,'Developement',14);
insert into EmployeeADO1 values('Shaheer',89326.28,'Marketing',12);
insert into EmployeeADO1 values('Kanishka',462398,'Sales',11);
insert into EmployeeADO1 values('Anshik',48742.90,'Marketing',14);
select * from EmployeeADO1

--SP for Inserting Row
create proc sp_InsertDetails3
   @empname varchar(20),
   @empsal float,
   @empDept varchar(20),
   @deptId int
   as
   begin
   insert into EmployeeADO1(Empname,EmpSal,EmpDept,DeptNo) values(@empname,@empsal,@empdept,@deptId)
   end
   exec sp_InsertDetails3 'Avantika',72396.5,Sales,12

--SP for Deleteing Row
   create proc sp_DeleteDetails
   @empid int  
   as
   begin
   delete from EmployeeADO1
   where empid = @empid
   end
   exec sp_DeleteDetails 4

 --SP for Updating Row
create proc sp_UpdateDetails
@empid int,
@empname varchar(20),
@empsal float,
@empdept varchar(20),
@deptId int
as
begin
update EmployeeADO1 set EmpName=@empname,empsal=@empsal,empdept=@empdept,DeptNo=@deptId
where EmpId=@empid
end
execute sp_UpdateDetails 11,'Riya',64391.45,Testing,12

--SP for searching data
 create proc sp_SearchForDetails1
   @empid int
   as
   begin
   select ee.empid,ee.empname,ee.empsal,ee.empdept,de.deptloc
   from EmployeeADO1 ee
   join DeptADO1 de
   on ee.DeptNo = de.DeptId
   where empid = @empid
   end
   exec sp_SearchForDetails1 




