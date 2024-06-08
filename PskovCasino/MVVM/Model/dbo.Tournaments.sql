CREATE TABLE [dbo].[Tournaments]
(
	[ID] INT PRIMARY KEY, 
    [GameSessionID] INT NOT NULL, 
    [MainPrize] INT NOT NULL, 
    CONSTRAINT [FK_Tournaments_ToGameSessions] FOREIGN KEY ([GameSessionID]) REFERENCES [GameSessions]([ID]), 
    CONSTRAINT [CK_Tournaments_GameSessionID] CHECK ([GameSessionID] = 1)
)
