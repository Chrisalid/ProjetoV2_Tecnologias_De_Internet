
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/28/2020 11:20:30
-- Generated from EDMX file: C:\Users\Chris\source\repos\WebREST\WebREST\Models\EDMRpg.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BDRpg];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PersonagensS'
CREATE TABLE [dbo].[PersonagensS] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Tipo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'HabilidadesS'
CREATE TABLE [dbo].[HabilidadesS] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Tipo] nvarchar(max)  NOT NULL,
    [Detalhe] nvarchar(max)  NOT NULL,
    [PersonagensId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PersonagensS'
ALTER TABLE [dbo].[PersonagensS]
ADD CONSTRAINT [PK_PersonagensS]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HabilidadesS'
ALTER TABLE [dbo].[HabilidadesS]
ADD CONSTRAINT [PK_HabilidadesS]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PersonagensId] in table 'HabilidadesS'
ALTER TABLE [dbo].[HabilidadesS]
ADD CONSTRAINT [FK_PersonagensHabilidades]
    FOREIGN KEY ([PersonagensId])
    REFERENCES [dbo].[PersonagensS]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonagensHabilidades'
CREATE INDEX [IX_FK_PersonagensHabilidades]
ON [dbo].[HabilidadesS]
    ([PersonagensId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------