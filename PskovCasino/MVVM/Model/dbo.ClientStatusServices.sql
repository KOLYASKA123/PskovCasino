CREATE TABLE [dbo].[ClientStatusServices]
(
    [ServiceID] INT NOT NULL, 
    [ClientStatusID] INT NOT NULL, 
    CONSTRAINT [FK_ClientStatusServices_ToServicesToID] FOREIGN KEY ([ServiceID]) REFERENCES [Services]([ID]), 
    CONSTRAINT [FK_ClientStatusServices_ToTable] FOREIGN KEY ([ClientStatusID]) REFERENCES [ClientStatus]([ID]) 
)
