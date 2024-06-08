CREATE TABLE [dbo].[Clients] (
    [ID]       INT          NOT NULL,
    [Username] VARCHAR (50) NOT NULL,
	[Password] TEXT NOT NULL, 
	[ClientStatusID] INT NOT NULL, 
    [Balance]  MONEY        NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC), 
    CONSTRAINT [FK_Clients_ToClientStatus] FOREIGN KEY ([ClientStatusID]) REFERENCES [ClientStatus]([ID])
);


GO

CREATE TRIGGER [dbo].[Trigger_Clients]
    ON [dbo].[Clients]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NoCount ON
    END