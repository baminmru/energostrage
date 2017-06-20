create or replace force view v_stat as
select  chanel_id,year, stddev(nvl(code_01,0)) D ,median(nvl(code_01,0)) M  from edata_week  group by chanel_id,YEAR -- order  by chanel_id,YEAR
;

