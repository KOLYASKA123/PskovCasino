CREATE TABLE [dbo].[GameSessions]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [GameTypeID] INT NOT NULL, 
    CONSTRAINT [FK_Table_ToTable] FOREIGN KEY ([GameTypeID]) REFERENCES [GameTypes]([ID])
)
