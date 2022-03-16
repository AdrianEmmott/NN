-- Create a new database called 'News'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT name
        FROM sys.databases
        WHERE name = N'News
    '
)
CREATE DATABASE News
GO


use news 
go


create table articles
(
    id UNIQUEIDENTIFIER DEFAULT newid(),
    title NVARCHAR(max) NOT NULL,
    subTitle NVARCHAR(max),
    summary NVARCHAR(max),
    headerImage NVARCHAR(max),
    content NVARCHAR(max),
    author NVARCHAR(max) NOT NULL,
    published bit NULL,
    publishDate DATETIME NULL,
    views int NULL,

    CONSTRAINT pk_articles_id PRIMARY KEY CLUSTERED (id),
)
go

/*
drop table articles
go
*/

/*
alter table articles 
drop CONSTRAINT pk_id
GO
*/

create table tags
(
    id UNIQUEIDENTIFIER DEFAULT newid(),
    parentId UNIQUEIDENTIFIER NULL,
    title NVARCHAR(max) NOT NULL,
    showInNav bit NOT NULL,
    sortOrder int NOT NULL,

    CONSTRAINT pk_tags_id PRIMARY KEY CLUSTERED (id),
    CONSTRAINT fk_tags_parentId FOREIGN KEY (ParentId) REFERENCES tags(id),
)
GO

/*
drop table tags
go
*/

create table articleTags
(
    articleId UNIQUEIDENTIFIER,
    tagId UNIQUEIDENTIFIER,

    PRIMARY KEY (articleId, tagId),

    FOREIGN KEY (articleId) REFERENCES articles(id),
    FOREIGN KEY (tagId) REFERENCES tags(id)
)
go


