drop table if exists Note
drop table if exists [Status]
drop table if exists Ticket

create table [Status] (
	StatusId uniqueidentifier primary key,
	Title nvarchar(32) not null,
	[Description] nvarchar(128) not null
)

create table Ticket (
	TicketId uniqueidentifier primary key,
	TicketNumber int not null,
	[StatusId] uniqueidentifier not null,
	constraint FK_Ticket_TicketId_Status_StatusId
        foreign key (StatusId)
            references [Status] (StatusId),
)

create table Note (
	NoteId uniqueidentifier primary key,
	TicketId uniqueidentifier not null,
    constraint FK_Note_TicketId_Ticket_TicketId
        foreign key (TicketId)
            references Ticket (TicketId),
	[Text] nvarchar(128) not null
)