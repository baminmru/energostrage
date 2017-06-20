create or replace procedure xml_region_volo (
p IN varchar2
,sd IN varchar2
,ch IN varchar2
)
AUTHID CURRENT_USER
IS
nnls            varchar2(32); -- конвертирование из AL32UTF8 в CL8MSWIN1251;
nodeid          varchar2(32); --
dtimestamp      varchar2(16); --date; -- время формирования документа
sdate           varchar2(16)  := '01.01.2014'; --операционный период
sender_name     varchar2(128) := 'ОАО "Северо-Западный Телеком" Вологодский филиал';
sender_inn      varchar2(12);         --  := '7808020593';
saving_time     varchar2(1)   := '1';
status_val      varchar(1)    := '0'; -- 0-коммерч. инфо, 1-не коммерч. инфо
node_code       varchar2(16);
node_name       varchar2(128);
chanel_code     varchar2(2);   -- 01 (A+); 03 (R+)
chanel_desc     varchar2(512); --
dps             varchar2(4);   -- data period start
dpe             varchar2(4);   -- data period end
dval            varchar2(6);   -- data value
p_start         varchar2(16);
p_end           varchar2(16);   -- 20140101-0000
p_val           varchar2(6);
return          integer := 0;

cursor esender_cur IS
       select ese.sender_inn
              ,ese.sender_name--/*NVL(LENGTH(ese.sender_name),0) as "length",*/
              ,to_char(sysdate,'YYYYMMDDHH24miSS') -- 'YYYYMMDDHH24miSS'
       from beavis.esender ese,beavis.enodes eno,beavis.echanel ech,beavis.edata eda
       where ese.sender_id = eno.sender_id AND eno.node_id = ech.node_id AND ech.chanel_id = eda.chanel_id
       AND eno.mpoint_code = nodeid /*'352578000000470' */ GROUP BY ese.sender_inn,ese.sender_name;

cursor enode_cur IS
       select eno.mpoint_code
              ,eno.mpoint_name --,NVL(LENGTH(eno.mpoint_name),0) as "length"
       from beavis.enodes eno
       where eno.mpoint_code = nodeid /*'352578000000470'*/;

cursor echanel_01_cur IS /* кода может больше одного! */
       select ech.mchanel_code
              ,ech.mchanel_desc /*,NVL(LENGTH(eno.mpoint_name),0) as "length" */
       from beavis.echanel ech, beavis.enodes eno
       where eno.node_id = ech.node_id AND eno.mpoint_code = nodeid AND ech.mchanel_code = chanel_code;

--CURSOR edata_01_cur
cursor edata_01_cur --(sdate IN varchar2, nodeid IN varchar2, chanel_code IN varchar2)
IS
select to_char(eda.p_start,'hh24miss'),to_char(eda.p_end,'hh24miss'),to_char(eda.code_01)
from beavis.edata eda, beavis.echanel ech, beavis.enodes eno
   where eda.chanel_id=ech.chanel_id
     AND ech.node_id=eno.node_id
     AND eda.p_date = to_date(sdate/*'20.01.2014'*/,'dd.mm.yyyy') /*sdate*/
     AND eno.mpoint_code=nodeid /*'352578000000207'*/
     AND ech.mchanel_code=chanel_code;--'01'; -- здесь передавать параметр <measuringchannel code>


--CURSOR edata_03_cur
cursor edata_03_cur --(sdate IN varchar2, nodeid IN varchar2, chanel_code IN varchar2)
IS
select to_char(eda.p_start,'hh24miss'),to_char(eda.p_end,'hh24miss'),to_char(eda.code_03)
from beavis.edata eda, beavis.echanel ech, beavis.enodes eno
   where eda.chanel_id=ech.chanel_id
     AND ech.node_id=eno.node_id
     AND eda.p_date = to_date(sdate/*'20.01.2014'*/,'dd.mm.yyyy') /*sdate*/
     AND eno.mpoint_code=nodeid /*'352578000000207'*/
     AND ech.mchanel_code=chanel_code;--'03'; -- здесь передавать параметр <measuringchannel code>


fd utl_file.file_type; -- объявление дескриптора

BEGIN
--352578000000470 Устюженский р-н Расторопово АТС
--352578000000651 Вологодский р-н Поповича 27 АТС резерв
--352578000000207 Междуреченский р-н Шуйское Шапина 16гараж
nnls   := 'CL8MSWIN1251';
nodeid := p;-- '352578000000470';
sdate  := sd;--'20.01.2014';
chanel_code:= ch;--'01';

if not esender_cur%ISOPEN
THEN
     open esender_cur;
END IF;
fetch esender_cur into sender_inn,sender_name,dtimestamp;

if not enode_cur%ISOPEN
THEN
    open enode_cur;
END IF;
fetch enode_cur into node_code,node_name;

if not echanel_01_cur%ISOPEN
THEN
    open echanel_01_cur;
END IF;
fetch echanel_01_cur into chanel_code,chanel_desc;

fd:= utl_file.fopen('d:\database\utl', nodeid||'_'||chanel_code||'_'||sdate||'.xml', 'w');
-- fd:= utl_file.fopen('D:\db\utl', nodename||'.txt', 'w'); -- домашний каталог

utl_file.put_line(fd,convert('<?xml version="1.0" encoding="windows-1251" ?>',nnls)); -- необходимо windows-1251 utf-8
utl_file.put_line(fd,convert('<message class="CAE020" version="1" number="1">',nnls));
utl_file.put_line(fd,convert('<datetime>',nnls));
utl_file.put_line(fd,convert('<timestamp>'||dtimestamp||'</timestamp>',nnls));
--utl_file.put_line(fd,'<timestamp>'||to_char(dtimestamp,'yyyymmddhh24miss')||'</timestamp>');
utl_file.put_line(fd,convert('<daylightsavingtime>'||saving_time||'</daylightsavingtime>',nnls));
utl_file.put_line(fd,convert('<day>'||to_char(to_date(sdate,'dd.mm.yyyy'),'yyyymmdd')||'</day>',nnls));
utl_file.put_line(fd,convert('</datetime>',nnls));
utl_file.put_line(fd,convert('<sender>',nnls));
utl_file.put_line(fd,convert('<name>'||sender_name||'</name>',nnls));
utl_file.put_line(fd,convert('<inn>'||sender_inn||'</inn>',nnls));
utl_file.put_line(fd,convert('</sender>',nnls));
--utl_file.new_line(fd); -- удалить
utl_file.put_line(fd,convert('<area>',nnls));
utl_file.put_line(fd,convert('<inn>'||sender_inn||'</inn>',nnls));
utl_file.put_line(fd,convert('<name>'||sender_name||'</name>',nnls));
utl_file.put_line(fd,convert('<measuringpoint code='||'"'||node_code||'"'||' '||'name='||'"'||node_name||'"'||'>',nnls));
-- utl_file.new_line(fd); -- удалить
-- формировать список с каналом 01 A+ и список с каналом 03 R+ и обработать
-- формировать два списка A+ и R+, передавать параметр <measuringchannel code>, последовательно обрабатывать списки
utl_file.put_line(fd,convert('<measuringchannel code='||'"'||chanel_code||'"'||' '||'desc='||'"'||chanel_desc||'"'||'>',nnls));
utl_file.new_line(fd); -- удалить
utl_file.new_line(fd); -- удалить

--close esender_cur;
--close enode_cur;
--close echanel_01_cur;

/* ===================================================== */
if chanel_code = '01' then
BEGIN

     if not edata_01_cur%ISOPEN
        THEN
            OPEN edata_01_cur;
        END IF;

LOOP
   FETCH edata_01_cur INTO
         p_start,p_end,p_val;
   EXIT WHEN edata_01_cur%NOTFOUND;

--utl_file.put_line(fd,'<period start='||'"'||p_start||'"'||' '||'end='||'"'||p_end||'"'||'>');
utl_file.put_line(fd,convert('<period start='||'"DT'||to_char(to_date(sdate,'dd.mm.yyyy'),'yyyymmdd')||p_start||'"'||' '||'end='||'"DT'||to_char(to_date(sdate,'dd.mm.yyyy'),'yyyymmdd')||p_end||'"'||'>'||'<value>'||p_val||'</value>'||'</period>',nnls));
--utl_file.put_line(fd,'<value>'||p_val||'</value>');
--utl_file.put_line(fd,'</period>');
END LOOP;

close edata_01_cur;

END; -- BEGIN



elsif chanel_code = '03' then
BEGIN

      if not edata_03_cur%ISOPEN
         THEN
             OPEN edata_03_cur;
         END IF;

LOOP
   FETCH edata_03_cur INTO
         p_start,p_end,p_val;
   EXIT WHEN edata_03_cur%NOTFOUND;
--utl_file.put_line(fd,'<period start='||'"'||p_start||'"'||' '||'end='||'"'||p_end||'"'||'>');
utl_file.put_line(fd,convert('<period start='||'"DT'||to_char(to_date(sdate,'dd.mm.yyyy'),'yyyymmdd')||p_start||'"'||' '||'end='||'"DT'||to_char(to_date(sdate,'dd.mm.yyyy'),'yyyymmdd')||p_end||'"'||'>'||'<value>'||p_val||'</value>'||'</period>',nnls));
--utl_file.put_line(fd,'<value>'||p_val||'</value>');
--utl_file.put_line(fd,'</period>');
END LOOP;

close edata_03_cur;

END; -- BEGIN

end if;
-- to_char(to_date(sdate,'dd.mm.yyyy'),'yyyymmdd')
/* ===================================================== */

--return = sql%rowcount;
--utl_file.put_line(fd, 'кол-во строк: '||to_char(return);


close esender_cur;
close enode_cur;
close echanel_01_cur;
--close edata_01_cur;
--close edata_03_cur;

utl_file.new_line(fd); -- удалить
utl_file.new_line(fd); -- удалить
--utl_file.put_line(fd,'</measuringchannel></measuringpoint></area>');
utl_file.put_line(fd,convert('</measuringchannel>',nnls));
utl_file.put_line(fd,convert('</measuringpoint>',nnls));
utl_file.put_line(fd,convert('</area>',nnls));
utl_file.put_line(fd,convert('</message>',nnls));
utl_file.fclose(fd);
END;
/

