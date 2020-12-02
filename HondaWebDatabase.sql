CREATE DATABASE HondaWeb
GO
USE HondaWeb
GO

CREATE TABLE Accounts
(
	AccountID INT IDENTITY(0,1) PRIMARY KEY,
	Pass VARCHAR(16) NOT NULL,
	UserName VARCHAR(50) NOT NULL
)
GO

CREATE TABLE Posts
(
	PostID BIGINT IDENTITY(1111,1) PRIMARY KEY,
	Title NVARCHAR(255) NOT NULL,
	Description NVARCHAR(4000),
	CreatedDate DATETIME,
	Content NVARCHAR(MAX),
	Status SMALLINT,
	PostTypeID INT,
	ModifiedDate DATETIME,
	IsHotNews BIT,
	FOREIGN KEY (PostTypeID) REFERENCES PostTypes(PostTypeID)
)
GO

INSERT INTO Posts
VALUES
(N'Honda Civic 2020', N'2020 là năm bùng nổ của Honda', 2020-11-26, N'aaaaaaaaaaaaaaaaaaaaaaaaaaaaa', 1, 1,Null, 1)
GO

CREATE TABLE PostTypes 
(
	PostTypeID INT IDENTITY(0,1) PRIMARY KEY,
	PostTypeName NVARCHAR(255),
	CreatedDate DATETIME,
	ModifiedDate DATETIME,
	SortOrder SMALLINT
)
GO


--INSERT

INSERT INTO Accounts 
	VALUES 
	('admin', 'admin')
	GO

INSERT INTO PostTypes 
VALUES 
(N'Tin tức & sự kiện','2020-11-26','2020-11-26',2),
(N'Dịch vụ','2020-11-26','2020-11-26',1),
(N'Tin tức & sự kiện'),
(N'Tin khuyến mãi'),
(N'Tin tuyển dụng')

GO
