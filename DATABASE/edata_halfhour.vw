create or replace force view edata_halfhour as
select  p_date,  to_char(p_end,'HH24') p_hour,case when to_char(p_end,'MI') <30 then '00' else '30' end p_min, sum(nvl(code_01,0)) as AP ,
sum (nvl(code_02,0)) as AM,
sum(nvl(code_03,0)) as RP ,
sum(nvl(code_04,0)) as RM ,
edata.chanel_id
 from edata   group by chanel_id,p_date, to_char(p_end,'HH24'),case when to_char(p_end,'MI') <30 then '00' else '30' end;

