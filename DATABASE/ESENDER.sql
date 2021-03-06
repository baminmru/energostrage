﻿--
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

INSERT INTO BEAVIS.ESENDER(SENDER_ID, SENDER_INN, SENDER_NAME) VALUES
(772, '2222222222', 'Калининград_');
INSERT INTO BEAVIS.ESENDER(SENDER_ID, SENDER_INN, SENDER_NAME) VALUES
(412, '00000001', 'Мурманский филиал_');
INSERT INTO BEAVIS.ESENDER(SENDER_ID, SENDER_INN, SENDER_NAME) VALUES
(472, '00000002', 'Мурманский филиал');
INSERT INTO BEAVIS.ESENDER(SENDER_ID, SENDER_INN, SENDER_NAME) VALUES
(952, '7800000078', 'SNTPORTAL');
INSERT INTO BEAVIS.ESENDER(SENDER_ID, SENDER_INN, SENDER_NAME) VALUES
(112, '7808020593', 'ОАО ''Северо-Западный Телеком'' Вологодский филиал');
INSERT INTO BEAVIS.ESENDER(SENDER_ID, SENDER_INN, SENDER_NAME) VALUES
(352, NULL, 'СПБ');
INSERT INTO BEAVIS.ESENDER(SENDER_ID, SENDER_INN, SENDER_NAME) VALUES
(532, '00000000222', 'Коми филиал');
INSERT INTO BEAVIS.ESENDER(SENDER_ID, SENDER_INN, SENDER_NAME) VALUES
(892, '00000001', 'Мурманский филиал');
INSERT INTO BEAVIS.ESENDER(SENDER_ID, SENDER_INN, SENDER_NAME) VALUES
(232, '7707049388', 'Калиниградский филиал');
INSERT INTO BEAVIS.ESENDER(SENDER_ID, SENDER_INN, SENDER_NAME) VALUES
(292, '7707049388', 'Карельский филиал');
INSERT INTO BEAVIS.ESENDER(SENDER_ID, SENDER_INN, SENDER_NAME) VALUES
(712, '78000001', 'Аскуэ спб');
INSERT INTO BEAVIS.ESENDER(SENDER_ID, SENDER_INN, SENDER_NAME) VALUES
(832, '00000000222', 'Калининградский филиал');

COMMIT;