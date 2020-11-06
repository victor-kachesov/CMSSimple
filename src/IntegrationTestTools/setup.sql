CREATE DATABASE cms;
GO
USE cms;
GO
CREATE TABLE dbo.articles (
	id uniqueidentifier NOT NULL,
	title nvarchar(100) NULL,
	body nvarchar(MAX) NULL,
	deleted bit NULL,
	[timestamp] datetime2(7) NULL,
	CONSTRAINT articles_PK PRIMARY KEY (id)
);
GO