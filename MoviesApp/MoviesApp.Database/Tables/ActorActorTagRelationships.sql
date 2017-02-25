CREATE TABLE [dbo].[ActorActorTagRelationships]
(
	[ActorActorTagRelationshipId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ActorId] INT NOT NULL, 
    [ActorTagId] INT NOT NULL, 
	CONSTRAINT FK_ActorActorTagRelationships_ActorId_Actors_ActorId FOREIGN KEY (ActorId)
		REFERENCES dbo.Actors ([ActorId]),
	CONSTRAINT FK_ActorActorTagRelationships_ActorTagId_ActorTags_ActorTagId FOREIGN KEY (ActorTagId)
		REFERENCES dbo.ActorTags ([ActorTagId]),
)
