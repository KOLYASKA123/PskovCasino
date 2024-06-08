CREATE TABLE [dbo].[GameParticipants]
(
    [ClientID] INT NOT NULL, 
    [GameSessionID] INT NOT NULL, 
    [InitialPayment] MONEY NOT NULL, 
    [WinPayment] MONEY NOT NULL, 
    CONSTRAINT [FK_GameParticipants_ToClients] FOREIGN KEY ([ClientID]) REFERENCES [Clients]([ID]), 
    CONSTRAINT [FK_GameParticipants_ToGameSessions] FOREIGN KEY ([GameSessionID]) REFERENCES [GameSessions]([ID])
)
