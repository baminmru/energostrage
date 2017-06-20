select * from Shet join ShetChars on Shet.idShet = ShetChars.idShet
join  ShetCharsDefault on ShetChars.IdChars =ShetCharsDefault.idShetCharsDefault
select * from ShetChars
select * from BalansGroup
select * from BalansGroupShetDtLabelSnapShot
select * from ShetCharsDefault where idCommand in (61,65,66,67)
select * from ShetCharsDtLabel
select * from BalansGroupShet

select Shet.idShet,worknumber,naimnode,nameparentnode 
from Shet join BalansGroupShetDtLabelSnapShot on Shet.idShet= BalansGroupShetDtLabelSnapShot.idShet

select top 1000 * from ResIsmEnergy where idShet=491 order by dtPriem
select distinct Command  from ResIsmEnergy where idShet=491


select top 20000  Shet.idShet,worknumber,naimnode,nameparentnode,ResIsmProfil.ActPl,ActMin,ReactPl,ReactMin,dtProfil 
from Shet join BalansGroupShetDtLabelSnapShot on Shet.idShet= BalansGroupShetDtLabelSnapShot.idShet
join ResIsmProfil on Shet.idShet=ResIsmProfil.idShet order by Shet.idShet, dtProfil 
