IF EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[YangVwContactAgeDays]'))
DROP VIEW [dbo].[YangVwContactAgeDays]
GO
CREATE VIEW YangVwContactAgeDays as
select Id as YangId, Name as YangName, BirthDate as YangBirthDate, 
datediff(DAY,BirthDate, getdate()) as YangAgeDays
from Contact
GO