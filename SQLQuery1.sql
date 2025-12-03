create database Pms
use Pms

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'Pms')
BEGIN
    EXEC('CREATE SCHEMA Pms')
END
GO
 
-- Create Employees Table
CREATE TABLE Pms.Employees (
    EmployeeId INT PRIMARY KEY IDENTITY(1,1),
    FullName VARCHAR(512) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Department NVARCHAR(100) NOT NULL
)
GO
 
-- Create Projects Table
CREATE TABLE Pms.Projects (
    ProjectId INT PRIMARY KEY IDENTITY(1,1),
    ProjectName NVARCHAR(255) NOT NULL,
    Details NVARCHAR(MAX),
    LeadEmployeeId INT FOREIGN KEY REFERENCES Pms.Employees(EmployeeId),
    Priority NVARCHAR(50) CHECK (Priority IN ('Low', 'Medium', 'High')) NOT NULL,
    Deadline DATE NOT NULL
)
GO
 
-- Insert Sample Data into Employees
INSERT INTO Pms.Employees (FullName, Email, PasswordHash, Department)
VALUES 
    ('Jane Smith', 'jane.smith@example.com', 'hashedpass123', 'Marketing'),
    ('Mark Johnson', 'mark.johnson@example.com', 'hashedpass456', 'Engineering'),
    ('Priya Patel', 'priya.patel@example.com', 'hashedpass789', 'Design'),
    ('Tom Lee', 'tom.lee@example.com', 'hashedpass101', 'Engineering'),
    ('Sara Brown', 'sara.brown@example.com', 'hashedpass202', 'HR')
GO
 
-- Insert Sample Data into Projects
INSERT INTO Pms.Projects (ProjectName, Details, LeadEmployeeId, Priority, Deadline)
VALUES 
    ('Website Redesign', 'Redesign company website for better UX', 1, 'High', '2025-06-01'),
    ('Mobile App Dev', 'Develop a new mobile app for clients', 2, 'Medium', '2025-08-15'),
    ('Brand Campaign', 'Launch a new marketing campaign', 1, 'High', '2025-05-20'),
    ('UI Overhaul', 'Update user interface for software', 3, 'Low', '2025-07-30'),
    ('Employee Training', 'Organize training sessions for staff', 5, 'Medium', '2025-09-10')
GO
 
-- Verify the Data (Optional)
SELECT * FROM Pms.Employees
SELECT * FROM Pms.Projects
GO



create or alter procedure sp_registerEmployee
@Fullname varchar(20),
@Email varchar(20),
@Pass varchar(20),
@Department varchar(20)
as
	begin
		insert into Pms.Employees(FullName,Email,PasswordHash,Department)
		values(@Fullname,@Email,@Pass,@Department)

		select * from Pms.Employees where Email= @Email
	end
 
exec sp_registerEmployee @Fullname='Tom',@Email='Tom@gmail.com',@Pass='efafaaffafaf',@Department='MBA'
 
create or alter procedure sp_loginEmployee
@Email varchar(200),
@Pass varchar(200)
as	
	begin
		IF EXISTS(select 1 from Pms.Employees where Email=@Email and PasswordHash=@Pass)
		begin
			select * from Pms.Employees
			where Email=@Email and PasswordHash = @Pass 
		end
	end
 
exec sp_loginEmployee 'sara.brown@example.com','hashedpass202'
 
create or alter procedure sp_Show_Project
@Priority varchar(20)=NULL
as
	begin
		IF @Priority IS NULL
			begin
				select * from Pms.Projects;
			end
		ELSE
			begin
				select * from pms.Projects where Priority=@Priority;
			end
	end

exec sp_Show_Project @Priority='Low'
 
create or alter procedure sp_Upsert_Project
@projectid int,
@projectname varchar(20),
@details varchar(50),
@Leadempid int,
@priority varchar(5),
@deadline datetime
as
	begin
		IF EXISTS(select 1 from pms.Projects where ProjectId=@projectid)
		begin
			update pms.Projects set
			ProjectName=@projectname,
			Details=@details,
			LeadEmployeeId=@Leadempid,
			Priority=@priority,
			Deadline=@deadline
			where ProjectId=@projectid
		end
		ELSE
		begin
			insert into pms.Projects(ProjectName,Details,LeadEmployeeId,Priority,Deadline)
			values (@projectname,@details,@Leadempid,@priority,@deadline)
			set @projectid = SCOPE_IDENTITY();
		end
		select * from Pms.Projects where ProjectId =  @projectid
	end



 