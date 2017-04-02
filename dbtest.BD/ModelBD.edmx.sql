
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/02/2017 11:18:33
-- Generated from EDMX file: Z:\Google Drive\Works\dbserver\Projeto\dbtest.BD\ModelBD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [dbtest];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[RestaurantSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RestaurantSet];
GO
IF OBJECT_ID(N'[dbo].[RestaurantSettingsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RestaurantSettingsSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'RestaurantSet'
CREATE TABLE [dbo].[RestaurantSet] (
    [Id] bigint  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [VotedInWeek] bit  NOT NULL,
    [DateVoted] datetime  NULL,
    [Votes] int  NOT NULL
);
GO

-- Creating table 'RestaurantSettingsSet'
CREATE TABLE [dbo].[RestaurantSettingsSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [User] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [RestaurantVotedId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'RestaurantSet'
ALTER TABLE [dbo].[RestaurantSet]
ADD CONSTRAINT [PK_RestaurantSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RestaurantSettingsSet'
ALTER TABLE [dbo].[RestaurantSettingsSet]
ADD CONSTRAINT [PK_RestaurantSettingsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------