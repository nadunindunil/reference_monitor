CREATE TABLE [dbo].[file] (
    [name]        VARCHAR (50) NOT NULL,
    [path]        VARCHAR (50) NOT NULL,
    [secretLevel] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([name] ASC)
);

