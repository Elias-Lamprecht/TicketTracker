DROP TABLE IF EXISTS Note;
DROP TABLE IF EXISTS Ticket;
DROP TABLE IF EXISTS [Status];
DROP TABLE IF EXISTS [Priority];

create table [Status] (
	StatusId uniqueidentifier primary key,
	Title nvarchar(32) not null,
	[Description] nvarchar(128) not null
)

create table [Priority] (
	PriorityId uniqueidentifier primary key,
	Title nvarchar(32) not null,
	[Description] nvarchar(128) not null
)

create table Ticket (
	TicketId uniqueidentifier primary key,
	TicketNumber int not null,
	Title nvarchar(32) not null,
	
	[StatusId] uniqueidentifier not null,
	constraint FK_Ticket_TicketId_Status_StatusId
        foreign key (StatusId)
            references [Status] (StatusId),

	[PriorityId] uniqueidentifier not null,
	constraint FK_Ticket_TicketId_Priority_PriorityId
        foreign key (PriorityId)
            references [Priority] (PriorityId),
)

create table Note (
	NoteId uniqueidentifier primary key,
	TicketId uniqueidentifier not null,
    constraint FK_Note_TicketId_Ticket_TicketId
        foreign key (TicketId)
            references Ticket (TicketId),
	[Text] nvarchar(128) not null
)