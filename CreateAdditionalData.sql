use Raspored;
insert into Teams (Name)
values
	('Tim 1'),
	('Tim 2'),
	('Tim 3'),
	('Tim 4'),
	('Tim 5');

insert into ShiftTypes (Name, Description)
values
	('D', 'Dnevna smena - od 07h do 19h'),
	('N', 'Noćna smena - od 19h do 07h'),
	('Bo', 'Bolovanje'),
	('GO', 'Godišnji odmor'),
	('8', 'Prepodnevna smena - od 07h do 14h'),
	('24', 'Dežurstvo - 24h'),
	('VP', 'Verski praznik'),
	('PO', 'Plaćeno odsustvo'),
	('NO', 'Neplaćeno odsustvo');

insert into TeamMemberRoles (Name, Description) values
	('VT', 'Vođa smene'),
	('RA', 'Reanimaciona ambulanta'),
	('SR', 'Spoljna reanimacija'),
	('MST', 'Odeljenska medicinska sestra-tehničar');

insert into TeamMembers (UserId, TeamId, TeamMemberRoleId) values
	('58a526d6-fd71-4af7-90d1-a7bb6d6cff41', 1, 1),
	('04fc4544-ff32-451c-8fbe-c9c47a29adba', 1, 4);

insert into Shifts (Date, ShiftTypeId, TeamMemberId) values
	('2023-08-01', 1, 1),
	('2023-08-01', 1, 2),
	('2023-08-02', 2, 1),
	('2023-08-02', 2, 2),
	('2023-08-06', 1, 1),
	('2023-08-06', 1, 2),
	('2023-08-07', 2, 1),
	('2023-08-07', 2, 2),
	('2023-08-11', 1, 1),
	('2023-08-11', 1, 2),
	('2023-08-12', 2, 1),
	('2023-08-12', 2, 2),
	('2023-08-16', 1, 1),
	('2023-08-16', 1, 2),
	('2023-08-17', 2, 1),
	('2023-08-17', 2, 2),
	('2023-08-21', 1, 1),
	('2023-08-21', 1, 2),
	('2023-08-22', 2, 1),
	('2023-08-22', 2, 2),
	('2023-08-26', 1, 1),
	('2023-08-26', 1, 2),
	('2023-08-27', 2, 1),
	('2023-08-27', 2, 2),
	('2023-08-31', 1, 1),
	('2023-08-31', 1, 2);