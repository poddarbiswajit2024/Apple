--select * from INETBILLKOHIMA.dbo.SYSTEMUSERMASTER where priv =1


select * from inetbilldimapur.dbo.REGOTRCPLANS order by OTRCID


use INETBILLKOHIMA
update REGOTRCPLANS set status='D' where otrcid='OTRC2017'
update REGOTRCPLANS set status='D' where otrcid='OTRC2016'

use INETBILLMOKOKCHUNG
insert into REGOTRCPLANS
values ('OTRC999', '999 Subscription Refundable Plan', 999, 0, 0,0,0,0,0,0,0,0,0,0,'A','SEMP1854', GETDATE(), '')

insert into REGOTRCPLANS
values ('OTRC2499', '2499 Subscription Refundable Plan', 2499, 0, 0,0,0,0,0,0,0,0,0,0,'A','SEMP1854', GETDATE(), 'Added 1 august 2019' )

insert into REGOTRCPLANS
values ('OTRC4499', '4499 Subscription Refundable Plan', 4499, 0, 0,0,0,0,0,0,0,0,0,0,'A','SEMP1854', GETDATE(), 'Added 1 august 2019' )

select * from REGOTRCPLANS where status='a'