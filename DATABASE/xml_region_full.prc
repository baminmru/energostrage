create or replace procedure xml_region_full(sd IN varchar2)
AUTHID CURRENT_USER
IS
mpoint_code  varchar2(16);  -- идентификатор узла (352578000000475)
ch_01        varchar2(2);   -- код канала 01(A+)
ch_03        varchar2(2);   -- код канала 03(R+)
sdate        varchar2(16);  -- операционный период

cursor enode_cur_01 IS
--       select eno.mpoint_code from enodes eno where rownum <=100;
       select eno.mpoint_code from enodes eno, echanel ech where eno.node_id=ech.node_id AND ech.mchanel_code = ch_01;

cursor enode_cur_03 IS
       select eno.mpoint_code from enodes eno, echanel ech where eno.node_id=ech.node_id AND ech.mchanel_code = ch_03;

begin
ch_01 := '01';
ch_03 := '03';
sdate := sd; --'01.01.2014';

     if not enode_cur_01%ISOPEN
        then
            open enode_cur_01;
        end if;
     loop
     fetch enode_cur_01 into mpoint_code;
     exit when enode_cur_01%NOTFOUND;
          beavis.xml_region_volo(mpoint_code,sdate,ch_01);
     end loop;
close enode_cur_01;

     if not enode_cur_03%ISOPEN
        then
            open enode_cur_03;
        end if;
     loop
     fetch enode_cur_03 into mpoint_code;
     exit when enode_cur_03%NOTFOUND;
          beavis.xml_region_volo(mpoint_code,sdate,ch_03);
     end loop;
close enode_cur_03;


end;

--select eno.mpoint_code from enodes eno where rownum <=100;
--select eno.mpoint_code from enodes eno, echanel ech where eno.node_id=ech.node_id AND ech.mchanel_code = '01';
--select eno.mpoint_code from enodes eno, echanel ech where eno.node_id=ech.node_id AND ech.mchanel_code = '03';
/

