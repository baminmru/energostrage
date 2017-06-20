create or replace procedure xml_nls_test --(p IN number,sdate IN varchar2,edate IN varchar2)
AUTHID CURRENT_USER
IS
nnls      varchar2(32);
nodeid    varchar2(32);
node_code varchar2(32);
node_name varchar2(512);

cursor enode_cur IS
       select eno.mpoint_code,eno.mpoint_name --,NVL(LENGTH(eno.mpoint_name),0) as "length"
       from beavis.enodes eno where eno.mpoint_code = nodeid /*'352578000000470'*/;

fd utl_file.file_type;
BEGIN
--alter session set nls_lang := 'CL8MSWIN1251';

nodeid := '352578000000470';
nnls   := 'CL8MSWIN1251';

if not enode_cur%ISOPEN
THEN
    open enode_cur;
END IF;
fetch enode_cur into node_code,node_name;

fd:= utl_file.fopen('d:\database\utl', nodeid||'_'||'nls_test'||'.xml', 'w');

utl_file.put_line(fd,'<?xml version="1.0" encoding="windows-1251" ?>'); -- необходимо windows-1251 utf-8
utl_file.put_line(fd,'<message clas="CAE020" version="1" number="1">');
utl_file.put_line(fd,convert('<measuringpoint code='||'"'||node_code||'"'||' '||'name='||'"'||node_name||'"'||'>',nnls));
utl_file.put_line(fd,convert('</measuringpoint>',nnls));
utl_file.put_line(fd,convert('</message>',nnls));

close enode_cur;
utl_file.fclose(fd);

END;
/*
select * from v$session
select * from v$sesstat
select * from v$statname

GRANT debug any procedure, debug connect session TO beavis
*/
/*
select * from nls_database_parameters
where parameter IN ('NLS_CHARACTERSET','NLS_NCHAR_CHARACTERSET')

select * from nls_session_parameters
where parameter = 'NLS_LENGTH_SEMANTICS'
*/
/

