--
-- Скрипт сгенерирован Devart dbForge Studio for Oracle, Версия 3.10.12.0
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/oracle/studio
-- Дата скрипта: 30.05.2017 13:59:12
-- Версия сервера: Oracle Database 11g Express Edition Release 11.2.0.2.0 - Production
-- Версия клиента: 
--

SET SQLBLANKLINES ON;
SET DEFINE OFF;
ALTER SESSION SET NLS_DATE_FORMAT = 'MM/DD/SYYYY HH24:MI:SS';
ALTER SESSION SET NLS_TIMESTAMP_TZ_FORMAT = 'MM/DD/SYYYY HH24:MI:SS.FF TZH:TZM';
ALTER SESSION SET NLS_TIMESTAMP_FORMAT = 'MM/DD/SYYYY HH24:MI:SS.FF';
ALTER SESSION SET NLS_NUMERIC_CHARACTERS = '.,';
ALTER SESSION SET NLS_NCHAR_CONV_EXCP = FALSE;
ALTER SESSION SET TIME_ZONE = '+03:00';

INSERT INTO BEAVIS.GROUPS(GROUPS_ID, NAME, ADDRESS) VALUES
(1, 'Группа приборов 1', 'Адрес группы приборов');
INSERT INTO BEAVIS.GROUPS(GROUPS_ID, NAME, ADDRESS) VALUES
(2, 'Группа приборов 2', 'Адрес группы приборов 2');

COMMIT;