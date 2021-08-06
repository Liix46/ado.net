create database StepDatabase
go

use StepDatabase
go

create table Branches
(
	Id int primary key identity,
	Country nvarchar(30) not null,
	City nvarchar(30) not null,
	Street nvarchar(30) not null,
	UNIQUE(Country,City,Street)
)

create table ContactsBranches
(
	Id int primary key identity,
	BranchesId int not null,
	WebSite nvarchar(40) not null,
	Phone nvarchar(20) not null,
	FOREIGN KEY (BranchesId) REFERENCES  Branches (Id) ON DELETE CASCADE
)

create table Position
(
	Id int primary key identity,
	Name nvarchar(30) not null unique,
	RateHour money not null
	CONSTRAINT CK_Position_RateHour CHECK(RateHour >=0),
)

create table Workers
(
	Id int primary key identity,
	FirstName nvarchar(20) not null,
	LastName nvarchar(20) not null,
	DataBirth Date not null,
	EmploymentDate Date not null,
	DismissalDate Date
)

create table Specialists
(
	Id int primary key identity,
	BranchesId int,
	WorkersId int,
	PositionId int,
	CONSTRAINT FK_Branches_Id FOREIGN KEY (BranchesId) REFERENCES Branches(Id),
	CONSTRAINT FK_Workers_Id FOREIGN KEY (WorkersId) REFERENCES Workers(Id),
	CONSTRAINT FK_Position_Id FOREIGN KEY (PositionId) REFERENCES Position(Id),
)

create table Subjects
(
	Id int primary key identity,
	Name nvarchar(30) not null unique
)

create table NameCourses
(
	Id int primary key identity,
	Name nvarchar(30) not null unique
)

create table Courses 
(
	Id int primary key identity,
	NameCoursesId int,
	SubjectId int,
	CountHours int,
	Describe nvarchar(max),
	CONSTRAINT FK_NameCourses_Id FOREIGN KEY (NameCoursesId) REFERENCES NameCourses(Id),
	CONSTRAINT FK_Subject_Id FOREIGN KEY (SubjectId) REFERENCES Subjects(Id),
)

create table Clients
(
	Id int primary key identity,
	FirstName nvarchar(20) not null,
	LastName nvarchar(20) not null,
	Phone nvarchar(20) not null unique
)

create table NameGroups
(
	Id int primary key identity,
	Name nvarchar(20) not null unique
)

create table Groups
(
	Id int primary key identity,
	ClientId int,
	NameCourseId int,
	NameGroupsId int,
	CONSTRAINT FK_Clients_Id FOREIGN KEY (ClientId) REFERENCES Clients(Id),
	CONSTRAINT FK_Groups_NameCourseId FOREIGN KEY (NameCourseId) REFERENCES NameCourses(Id),
	CONSTRAINT FK_Groups_NameGroupId FOREIGN KEY (NameGroupsId) REFERENCES NameGroups(Id)
)

create table ProgressStudy
(
	Id int primary key identity,
	SpecialistId int,
	GroupId int,
	Subject nvarchar(30) not null,
	CountHours int,
	CONSTRAINT CK_ProgressStudy_CountHours CHECK(CountHours >0),
	CONSTRAINT FK_ProgressStudy_SpecialistsId FOREIGN KEY (SpecialistId) REFERENCES Specialists(Id),
	CONSTRAINT FK_ProgressStudy_GroupsId FOREIGN KEY (GroupId) REFERENCES Groups(Id)
)
