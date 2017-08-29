--
-- Скрипт сгенерирован Devart dbForge Studio for Oracle, Версия 3.10.12.0
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/oracle/studio
-- Дата скрипта: 29.08.2017 15:08:25
-- Версия сервера: Oracle Database 11g Express Edition Release 11.2.0.2.0 - Production
-- Версия клиента: 
--


CONNECT beavis/beavis7654@PIRE:1521/XE;


-- 
-- Установка схемы по умолчанию
--
ALTER SESSION SET CURRENT_SCHEMA = "BEAVIS";

SET SQLBLANKLINES ON;
SET DEFINE OFF;
ALTER SESSION SET NLS_DATE_FORMAT = 'MM/DD/SYYYY HH24:MI:SS';
ALTER SESSION SET NLS_TIMESTAMP_TZ_FORMAT = 'MM/DD/SYYYY HH24:MI:SS.FF TZH:TZM';
ALTER SESSION SET NLS_TIMESTAMP_FORMAT = 'MM/DD/SYYYY HH24:MI:SS.FF';
ALTER SESSION SET NLS_NUMERIC_CHARACTERS = '.,';
ALTER SESSION SET NLS_NCHAR_CONV_EXCP = FALSE;
ALTER SESSION SET TIME_ZONE = '+03:00';

--
-- Описание для последовательности BMODEMS_SEQ
--
CREATE SEQUENCE BMODEMS_SEQ
START WITH 65
INCREMENT BY 1
MAXVALUE 99999
NOCACHE;

--
-- Описание для последовательности COMPORTS_SEQ
--
CREATE SEQUENCE COMPORTS_SEQ
START WITH 1
INCREMENT BY 1
MAXVALUE 99999
NOCACHE;

--
-- Описание для последовательности ECHANEL_SEQ
--
CREATE SEQUENCE ECHANEL_SEQ
START WITH 34043
INCREMENT BY 3
MAXVALUE 9999999;

--
-- Описание для последовательности EDATA_SEQ
--
CREATE SEQUENCE EDATA_SEQ
START WITH 190052434
INCREMENT BY 1
MAXVALUE 99999999999999999999999999;

--
-- Описание для последовательности ELOADED_SEQ
--
CREATE SEQUENCE ELOADED_SEQ
START WITH 7
INCREMENT BY 3
MAXVALUE 9999999999999;

--
-- Описание для последовательности ENODE_SEQ
--
CREATE SEQUENCE ENODE_SEQ
START WITH 124923
INCREMENT BY 3
MAXVALUE 9999999;

--
-- Описание для последовательности ESENDER_SEQ
--
CREATE SEQUENCE ESENDER_SEQ
START WITH 1070
INCREMENT BY 1
MAXVALUE 9999999;

--
-- Описание для последовательности GROUPS_SEQ
--
CREATE SEQUENCE GROUPS_SEQ
START WITH 11
INCREMENT BY 1
MAXVALUE 9999999999
CACHE 10;

--
-- Описание для последовательности IPADDR_SEQ
--
CREATE SEQUENCE IPADDR_SEQ
START WITH 2
INCREMENT BY 1
MAXVALUE 99999
NOCACHE;

--
-- Описание для последовательности MASKSLINE_SEQ
--
CREATE SEQUENCE MASKSLINE_SEQ
START WITH 210
INCREMENT BY 1
MAXVALUE 99999
NOCACHE;

--
-- Описание для последовательности MASKS_SEQ
--
CREATE SEQUENCE MASKS_SEQ
START WITH 5
INCREMENT BY 1
MAXVALUE 99999
NOCACHE;

--
-- Описание для последовательности PEEK_INFO_SEQ
--
CREATE SEQUENCE PEEK_INFO_SEQ
START WITH 61
INCREMENT BY 1;

--
-- Описание для последовательности PR_INFO_SEQ
--
CREATE SEQUENCE PR_INFO_SEQ
START WITH 681
INCREMENT BY 1;

--
-- Описание для последовательности TBL_SEQ
--
CREATE SEQUENCE TBL_SEQ
START WITH 470
INCREMENT BY 3
MAXVALUE 99999
NOCACHE;

--
-- Описание для последовательности USERS_SEQ
--
CREATE SEQUENCE USERS_SEQ
START WITH 17
INCREMENT BY 1
MAXVALUE 99999
NOCACHE;

--
-- Описание для последовательности WEBREPORT_SEQ
--
CREATE SEQUENCE WEBREPORT_SEQ
START WITH 97
INCREMENT BY 1
MAXVALUE 99999
NOCACHE;

--
-- Описание для последовательности WEBTEMPLATE_SEQ
--
CREATE SEQUENCE WEBTEMPLATE_SEQ
START WITH 221
INCREMENT BY 1
MAXVALUE 9999999999999999;

--
-- Описание для последовательности WHOGIVETOP_SEQ
--
CREATE SEQUENCE WHOGIVETOP_SEQ
START WITH 21
INCREMENT BY 1
MAXVALUE 99999;

--
-- Описание для синонима V_EDATA_EXPORT
--
CREATE OR REPLACE SYNONYM V_EDATA_EXPORT
FOR EDATA2;

--
-- Описание для T_VC
--
CREATE OR REPLACE TYPE T_VC AS
TABLE OF VARCHAR2(4000);
/

--
-- Описание для таблицы CLUSTERING
--
CREATE TABLE CLUSTERING (
  NODE_ID        NUMBER        NOT NULL,
  CLUSTER_NUMBER NUMBER        NOT NULL,
  CLUSTER_VALUE  NUMBER(18, 6) NOT NULL,
  CONSTRAINT CLUSTERING_PK PRIMARY KEY (NODE_ID) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                       NEXT 1 M
                                                                                       MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

--
-- Описание для таблицы COSTCALCULATION
--
CREATE TABLE COSTCALCULATION (
  NODE_ID  NUMBER       NOT NULL,
  THEYEAR  NUMBER(*, 0) NOT NULL,
  THEMONTH NUMBER(*, 0) NOT NULL,
  I        NUMBER(18, 6),
  II       NUMBER(18, 6),
  III      NUMBER(18, 6),
  IV       NUMBER(18, 6),
  V        NUMBER(18, 6),
  VI       NUMBER(18, 6),
  OPTIMAL  NVARCHAR2(5)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

CREATE UNIQUE INDEX UK_COSTCALCULATION ON COSTCALCULATION (NODE_ID, THEYEAR, THEMONTH)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

--
-- Описание для таблицы DEVCLASSES
--
CREATE TABLE DEVCLASSES (
  ID_CLASS  NUMBER(2, 0) NOT NULL,
  CLASSNAME VARCHAR2(24 BYTE),
  CONSTRAINT DEVCLASS_PRI PRIMARY KEY (ID_CLASS) USING INDEX TABLESPACE USERS STORAGE (INITIAL 128 K
                                                                                       NEXT 1 M
                                                                                       MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 128 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON TABLE DEVCLASSES IS 'Классы приборов';

--
-- Описание для таблицы EDATA_AGG
--
CREATE TABLE EDATA_AGG (
  NODE_ID NUMBER(*, 0),
  P_DATE  DATE,
  CODE_01 NUMBER(18, 6),
  CODE_02 NUMBER(18, 6),
  CODE_03 NUMBER(18, 6),
  CODE_04 NUMBER(18, 6),
  CONSTRAINT PK_EDATA_AGG PRIMARY KEY (NODE_ID, P_DATE) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                              NEXT 1 M
                                                                                              MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

--
-- Описание для таблицы EDATA_WEEK
--
CREATE TABLE EDATA_WEEK (
  NODE_ID NUMBER DEFAULT 0,
  YEAR    NUMBER,
  WEEK    NUMBER,
  CODE_01 NUMBER(18, 6),
  CODE_02 NUMBER(18, 6),
  CODE_03 NUMBER(18, 6),
  CODE_04 NUMBER(18, 6)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

--
-- Описание для таблицы EDATA_WEEKMULT
--
CREATE TABLE EDATA_WEEKMULT (
  NODE_ID NUMBER(*, 0),
  WEEK    NUMBER,
  CODE_01 NUMBER(18, 6),
  CODE_02 NUMBER(18, 6),
  CODE_03 NUMBER(18, 6),
  CODE_04 NUMBER(18, 6),
  AR      NUMBER(18, 6),
  CONSTRAINT PK_EDATA_WEEKMULT PRIMARY KEY (NODE_ID, WEEK) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                                 NEXT 1 M
                                                                                                 MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

--
-- Описание для таблицы EDATA2
--
CREATE TABLE EDATA2 (
  DATA_ID   NUMBER(*, 0)     NOT NULL,
  C_DATE    DATE,
  LIGHTSAVE VARCHAR2(1 BYTE) DEFAULT 0,
  P_DATE    DATE,
  P_START   DATE,
  P_END     DATE,
  CODE_01   NUMBER(18, 6),
  CODE_02   NUMBER(18, 6),
  CODE_03   NUMBER(18, 6),
  CODE_04   NUMBER(18, 6),
  NODE_ID   NUMBER           NOT NULL,
  CONSTRAINT PK_EDATA1_COPY PRIMARY KEY (DATA_ID) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                        NEXT 1 M
                                                                                        MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

CREATE INDEX IDX_EDATA2 ON EDATA2 (NODE_ID, P_DATE)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON COLUMN EDATA2.C_DATE IS 'Дата создания файла <timestamp>';
COMMENT ON COLUMN EDATA2.CODE_01 IS 'Активный привем (A+)';
COMMENT ON COLUMN EDATA2.CODE_02 IS 'Активная отдача (A-)';
COMMENT ON COLUMN EDATA2.CODE_03 IS 'Реактивный прием (R+)';
COMMENT ON COLUMN EDATA2.CODE_04 IS 'Реакитвная отдача (R-)';
COMMENT ON COLUMN EDATA2.LIGHTSAVE IS 'Время зимнее/летнее/признак перевода вр. 0/1/2 <daylightsavingtime>';
COMMENT ON COLUMN EDATA2.P_DATE IS 'Дата операционного периода <day>';
COMMENT ON COLUMN EDATA2.P_END IS 'Дата и время окончания периода  (формат - DTГГГГММДДччммсс)';
COMMENT ON COLUMN EDATA2.P_START IS 'Дата и время начала периода (формат - DTГГГГММДДччммсс)';

--
-- Описание для таблицы ELECTRO
--
CREATE TABLE ELECTRO (
  ID       NUMBER(10, 0),
  ID_BD    NUMBER(5, 0)  NOT NULL,
  ID_PTYPE NUMBER(2, 0)  NOT NULL,
  DCALL    DATE          NOT NULL,
  DCOUNTER DATE          NOT NULL,
  T0       NUMBER(18, 6) DEFAULT 0,
  T1       NUMBER(18, 6) DEFAULT 0,
  T2       NUMBER(18, 6) DEFAULT 0,
  T3       NUMBER(18, 6) DEFAULT 0,
  T4       NUMBER(18, 6) DEFAULT 0,
  T5       NUMBER(18, 6) DEFAULT 0,
  C1       NUMBER(18, 6) DEFAULT 0,
  C2       NUMBER(18, 6) DEFAULT 0,
  C3       NUMBER(18, 6) DEFAULT 0,
  P0       NUMBER(18, 6) DEFAULT 0,
  P1       NUMBER(18, 6) DEFAULT 0,
  P2       NUMBER(18, 6) DEFAULT 0,
  P3       NUMBER(18, 6) DEFAULT 0,
  G0       NUMBER(18, 6) DEFAULT 0,
  G1       NUMBER(18, 6) DEFAULT 0,
  G2       NUMBER(18, 6) DEFAULT 0,
  G3       NUMBER(18, 6) DEFAULT 0,
  G4       NUMBER(18, 6) DEFAULT 0,
  G5       NUMBER(18, 6) DEFAULT 0,
  U1       NUMBER(18, 6) DEFAULT 0,
  U2       NUMBER(18, 6) DEFAULT 0,
  U3       NUMBER(18, 6) DEFAULT 0,
  ERRTIME  NUMBER(12, 0),
  ERRTIMEH NUMBER(12, 0),
  HC       VARCHAR2(180 BYTE),
  CHECK_A  NUMBER(1, 0)  DEFAULT 0,
  OKTIME   NUMBER(18, 6),
  WORKTIME NUMBER(18, 6),
  HC_CODE  VARCHAR2(180 BYTE),
  I1       NUMBER        DEFAULT 0,
  I2       NUMBER        DEFAULT 0,
  I3       NUMBER        DEFAULT 0,
  AP1      NUMBER        DEFAULT 0,
  AP2      NUMBER        DEFAULT 0,
  AP3      NUMBER        DEFAULT 0,
  AP0      NUMBER        DEFAULT 0,
  AM0      NUMBER        DEFAULT 0 NOT NULL,
  AM1      NUMBER        DEFAULT 0,
  AM2      NUMBER        DEFAULT 0,
  AM3      NUMBER        DEFAULT 0,
  RP0      NUMBER        DEFAULT 0,
  RP1      NUMBER        DEFAULT 0,
  RP2      NUMBER        DEFAULT 0,
  RP3      NUMBER        DEFAULT 0,
  RM0      NUMBER        DEFAULT 0,
  RM1      NUMBER        DEFAULT 0,
  RM2      NUMBER        DEFAULT 0,
  RM3      NUMBER        DEFAULT 0,
  CONSTRAINT ELECTRO_PK PRIMARY KEY (ID_BD, ID_PTYPE, DCOUNTER, DCALL) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                                             NEXT 1 M
                                                                                                             MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON COLUMN ELECTRO.AM0 IS 'Активная - общ';
COMMENT ON COLUMN ELECTRO.AM1 IS 'Активная - ф 1';
COMMENT ON COLUMN ELECTRO.AM2 IS 'Активная - ф 2';
COMMENT ON COLUMN ELECTRO.AM3 IS 'Активная - ф 3';
COMMENT ON COLUMN ELECTRO.AP0 IS 'Активная + общ';
COMMENT ON COLUMN ELECTRO.AP1 IS 'Активная + Ф 1';
COMMENT ON COLUMN ELECTRO.AP2 IS 'Активная + Ф 2';
COMMENT ON COLUMN ELECTRO.AP3 IS 'Активная + Ф 3';
COMMENT ON COLUMN ELECTRO.C1 IS 'Косинус фи 1 фаза';
COMMENT ON COLUMN ELECTRO.C2 IS 'Косинус фи 2 фаза';
COMMENT ON COLUMN ELECTRO.C3 IS 'Косинус фи 3 фаза';
COMMENT ON COLUMN ELECTRO.G0 IS 'Накопленная энергия общая';
COMMENT ON COLUMN ELECTRO.G1 IS 'Накопленная энергия тариф 1';
COMMENT ON COLUMN ELECTRO.G2 IS 'Накопленная энергия тариф 2';
COMMENT ON COLUMN ELECTRO.G3 IS 'Накопленная энергия тариф  3';
COMMENT ON COLUMN ELECTRO.G4 IS 'Накопленная энергия тариф 4';
COMMENT ON COLUMN ELECTRO.G5 IS 'Накопленная энергия потери';
COMMENT ON COLUMN ELECTRO.I1 IS 'Ток ф 1';
COMMENT ON COLUMN ELECTRO.I2 IS 'Ток ф 2';
COMMENT ON COLUMN ELECTRO.I3 IS 'Ток ф3';
COMMENT ON COLUMN ELECTRO.P0 IS 'Мощность общая';
COMMENT ON COLUMN ELECTRO.P1 IS 'Мощность ф 1';
COMMENT ON COLUMN ELECTRO.P2 IS 'Мощность ф 2';
COMMENT ON COLUMN ELECTRO.P3 IS 'Мощность ф 3';
COMMENT ON COLUMN ELECTRO.RM0 IS 'Реактивная - общ';
COMMENT ON COLUMN ELECTRO.RM1 IS 'Реактивная - ф 1';
COMMENT ON COLUMN ELECTRO.RM2 IS 'Реактивная - ф 2';
COMMENT ON COLUMN ELECTRO.RM3 IS 'Реактивная - ф 3';
COMMENT ON COLUMN ELECTRO.RP0 IS 'Реактивная + общ';
COMMENT ON COLUMN ELECTRO.RP1 IS 'Реактивная + ф1';
COMMENT ON COLUMN ELECTRO.RP2 IS 'Реактивная + ф 2';
COMMENT ON COLUMN ELECTRO.RP3 IS 'Реактивная + ф3';
COMMENT ON COLUMN ELECTRO.T0 IS 'Энергия тариф сумма';
COMMENT ON COLUMN ELECTRO.T1 IS 'Энергия тариф 1';
COMMENT ON COLUMN ELECTRO.T2 IS 'Энергия тариф 2';
COMMENT ON COLUMN ELECTRO.T3 IS 'Энергия тариф 3';
COMMENT ON COLUMN ELECTRO.T4 IS 'Энергия тариф 4';
COMMENT ON COLUMN ELECTRO.T5 IS 'Энергия потери';
COMMENT ON COLUMN ELECTRO.U1 IS 'Напряжение ф 1';
COMMENT ON COLUMN ELECTRO.U2 IS 'Напряжение ф 2';
COMMENT ON COLUMN ELECTRO.U3 IS 'Напряжение ф 3';

--
-- Описание для таблицы ELOADED
--
CREATE TABLE ELOADED (
  LOADED_ID  NUMBER(*, 0),
  LOADEDNAME VARCHAR2(128 BYTE)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

--
-- Описание для таблицы ENODECOLORS
--
CREATE TABLE ENODECOLORS (
  NODEID NUMBER(15, 0) NOT NULL,
  WEEK1  VARCHAR2(20 BYTE),
  WEEK2  VARCHAR2(40 BYTE),
  WEEK3  VARCHAR2(40 BYTE),
  WEEK4  VARCHAR2(40 BYTE),
  WEEK5  VARCHAR2(40 BYTE),
  WEEK6  VARCHAR2(40 BYTE),
  WEEK7  VARCHAR2(40 BYTE),
  WEEK8  VARCHAR2(40 BYTE),
  WEEK9  VARCHAR2(40 BYTE),
  WEEK10 VARCHAR2(40 BYTE),
  WEEK11 VARCHAR2(40 BYTE),
  WEEK12 VARCHAR2(40 BYTE),
  WEEK13 VARCHAR2(40 BYTE),
  WEEK14 VARCHAR2(40 BYTE),
  WEEK15 VARCHAR2(40 BYTE),
  WEEK16 VARCHAR2(40 BYTE),
  WEEK17 VARCHAR2(40 BYTE),
  WEEK18 VARCHAR2(40 BYTE),
  WEEK19 VARCHAR2(40 BYTE),
  WEEK20 VARCHAR2(40 BYTE),
  WEEK21 VARCHAR2(40 BYTE),
  WEEK22 VARCHAR2(40 BYTE),
  WEEK23 VARCHAR2(40 BYTE),
  WEEK24 VARCHAR2(40 BYTE),
  WEEK25 VARCHAR2(40 BYTE),
  WEEK26 VARCHAR2(40 BYTE),
  WEEK27 VARCHAR2(40 BYTE),
  WEEK28 VARCHAR2(40 BYTE),
  WEEK29 VARCHAR2(40 BYTE),
  WEEK30 VARCHAR2(40 BYTE),
  WEEK31 VARCHAR2(40 BYTE),
  WEEK32 VARCHAR2(40 BYTE),
  WEEK33 VARCHAR2(40 BYTE),
  WEEK34 VARCHAR2(40 BYTE),
  WEEK35 VARCHAR2(40 BYTE),
  WEEK36 VARCHAR2(40 BYTE),
  WEEK37 VARCHAR2(40 BYTE),
  WEEK38 VARCHAR2(40 BYTE),
  WEEK39 VARCHAR2(40 BYTE),
  WEEK40 VARCHAR2(40 BYTE),
  WEEK41 VARCHAR2(40 BYTE),
  WEEK42 VARCHAR2(40 BYTE),
  WEEK43 VARCHAR2(40 BYTE),
  WEEK44 VARCHAR2(40 BYTE),
  WEEK45 VARCHAR2(40 BYTE),
  WEEK46 VARCHAR2(40 BYTE),
  WEEK47 VARCHAR2(40 BYTE),
  WEEK48 VARCHAR2(40 BYTE),
  WEEK49 VARCHAR2(40 BYTE),
  WEEK50 VARCHAR2(40 BYTE),
  WEEK51 VARCHAR2(40 BYTE),
  WEEK52 VARCHAR2(40 BYTE),
  WEEK53 VARCHAR2(40 BYTE)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

--
-- Описание для таблицы ENODES
--
CREATE TABLE ENODES (
  NODE_ID        NUMBER(*, 0)  NOT NULL,
  SENDER_ID      NUMBER(*, 0),
  MPOINT_CODE    VARCHAR2(64 BYTE),
  MPOINT_NAME    VARCHAR2(512 BYTE),
  ID_DEV         NUMBER(2, 0),
  ID_MASK        NUMBER(4, 0),
  NPIP           VARCHAR2(40 BYTE),
  NPPASSWORD     VARCHAR2(60 BYTE),
  NPQUERY        NUMBER(1, 0)  DEFAULT 0,
  NPLOCK         DATE,
  HIDEROW        NUMBER(1, 0)  DEFAULT 0,
  TRANSPORT      NUMBER(1, 0)  DEFAULT 0,
  IPPORT         NUMBER(5, 0),
  NOCPORT        VARCHAR2(40 BYTE),
  SRV_IP_ID      NUMBER(5, 0),
  CALLERID       VARCHAR2(30 BYTE),
  HOURSHIFT      NUMBER(3, 0)  DEFAULT 0,
  CFIO1          VARCHAR2(64 BYTE),
  CPHONE1        VARCHAR2(32 BYTE),
  CFIO2          VARCHAR2(64 BYTE),
  CPHONE2        VARCHAR2(32 BYTE),
  CADDRESS       VARCHAR2(200 BYTE),
  ID_MASKSUM     NUMBER(4, 0),
  MAPX           NUMBER(11, 7) DEFAULT 0,
  MAPY           NUMBER(11, 7) DEFAULT 0,
  FULLADDRESS    VARCHAR2(200 BYTE),
  ID_MASKDAY     NUMBER(4, 0),
  NETADDR        NUMBER(3, 0)  DEFAULT 0,
  GROUPS_ID      NUMBER(10, 0),
  KI             NUMBER(18, 6) DEFAULT 1,
  KU             NUMBER(18, 6) DEFAULT 1,
  P_AP           NUMBER(18, 6) DEFAULT 0 NOT NULL,
  P_AM           NUMBER(18, 6) DEFAULT 0,
  P_RP           NUMBER(18, 6) DEFAULT 0,
  P_RM           NUMBER(18, 6) DEFAULT 0,
  KVTCOST        NUMBER(18, 6) DEFAULT 4.6,
  ECOLOR         VARCHAR2(40 BYTE),
  POWERLEVEL_MIN NUMBER(18, 6),
  POWERLEVEL_MAX NUMBER(18, 6),
  POWER_QUALITY  NVARCHAR2(50),
  COST_CATEGORY  NVARCHAR2(50),
  WHOGIVE        NUMBER(5, 0),
  DOGOVOR        NVARCHAR2(120),
  CONSTRAINT PK_ENODES PRIMARY KEY (NODE_ID) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                   NEXT 1 M
                                                                                   MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

CREATE INDEX ENODES_IDX ON ENODES (SENDER_ID, MPOINT_CODE, MPOINT_NAME)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

CREATE INDEX ENODES_IDX2 ON ENODES (SENDER_ID)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON COLUMN ENODES.CADDRESS IS 'адрес';
COMMENT ON COLUMN ENODES.CALLERID IS 'идентификатор  вызывающего устройста ( АССВ)';
COMMENT ON COLUMN ENODES.CFIO1 IS 'ФИО 1';
COMMENT ON COLUMN ENODES.CFIO2 IS 'ФИО 2';
COMMENT ON COLUMN ENODES.CPHONE1 IS 'Телефон 1';
COMMENT ON COLUMN ENODES.CPHONE2 IS 'Телефон 2';
COMMENT ON COLUMN ENODES.ECOLOR IS 'Цвет для отображения режима экономии';
COMMENT ON COLUMN ENODES.FULLADDRESS IS 'полный адрес для расчета координат';
COMMENT ON COLUMN ENODES.GROUPS_ID IS 'Идентификатор группы узлов';
COMMENT ON COLUMN ENODES.HIDEROW IS 'скрыть строку';
COMMENT ON COLUMN ENODES.HOURSHIFT IS 'сдвиг  для анализа соответствия часовых данных';
COMMENT ON COLUMN ENODES.ID_DEV IS 'тип устройства';
COMMENT ON COLUMN ENODES.ID_MASK IS 'маска текущих';
COMMENT ON COLUMN ENODES.ID_MASKDAY IS 'маска суточных';
COMMENT ON COLUMN ENODES.ID_MASKSUM IS 'маска итоговых';
COMMENT ON COLUMN ENODES.IPPORT IS 'порт или индекс порта';
COMMENT ON COLUMN ENODES.KI IS 'Трансформация по току';
COMMENT ON COLUMN ENODES.KU IS 'Трансформация по напряжению';
COMMENT ON COLUMN ENODES.KVTCOST IS 'Стоимость киловата (руб)';
COMMENT ON COLUMN ENODES.MAPX IS 'Координата на карте широта';
COMMENT ON COLUMN ENODES.MAPY IS 'Координата на карте долгота';
COMMENT ON COLUMN ENODES.MPOINT_CODE IS 'Код - идентификатор объекта <measuringpoint code>';
COMMENT ON COLUMN ENODES.MPOINT_NAME IS 'Название объекта потребления энергоресурса <measuringpoint name>';
COMMENT ON COLUMN ENODES.NETADDR IS 'Сетевой адрес прибора';
COMMENT ON COLUMN ENODES.NOCPORT IS 'номер ком порта';
COMMENT ON COLUMN ENODES.NPIP IS 'адрес ip';
COMMENT ON COLUMN ENODES.NPLOCK IS 'блокировка ';
COMMENT ON COLUMN ENODES.NPPASSWORD IS 'пароль для доступа к прибору';
COMMENT ON COLUMN ENODES.NPQUERY IS 'опрос включен или нет';
COMMENT ON COLUMN ENODES.P_AM IS 'Потери при измерении активной- нагрузки';
COMMENT ON COLUMN ENODES.P_AP IS 'Потери при измерении активной+ нагрузки';
COMMENT ON COLUMN ENODES.P_RM IS 'Потери при измерении реактивной- нагрузки';
COMMENT ON COLUMN ENODES.P_RP IS 'Потери при измерении реактивной+ нагрузки';
COMMENT ON COLUMN ENODES.SENDER_ID IS 'филиал';
COMMENT ON COLUMN ENODES.SRV_IP_ID IS 'сервер опроса';
COMMENT ON COLUMN ENODES.TRANSPORT IS 'тип транспорта';

--
-- Описание для таблицы ESENDER
--
CREATE TABLE ESENDER (
  SENDER_ID   NUMBER(*, 0) NOT NULL,
  SENDER_INN  VARCHAR2(11 BYTE),
  SENDER_NAME VARCHAR2(128 BYTE),
  CONSTRAINT PK_SENDER PRIMARY KEY (SENDER_ID) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                     NEXT 1 M
                                                                                     MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON COLUMN ESENDER.SENDER_INN IS 'ИНН идентификатор организации ';
COMMENT ON COLUMN ESENDER.SENDER_NAME IS 'Название организации';

--
-- Описание для таблицы GROUPS
--
CREATE TABLE GROUPS (
  GROUPS_ID NUMBER(10, 0),
  NAME      VARCHAR2(255 BYTE),
  ADDRESS   VARCHAR2(255 BYTE),
  CONSTRAINT GROUPS_PK PRIMARY KEY (GROUPS_ID) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                     NEXT 1 M
                                                                                     MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

--
-- Описание для таблицы IPADDR
--
CREATE TABLE IPADDR (
  ID_IP        NUMBER(4, 0)      NOT NULL,
  CIPADDR      VARCHAR2(20 BYTE) NOT NULL,
  MACHINE      VARCHAR2(64 BYTE),
  TERMINAL     VARCHAR2(16 BYTE),
  AUTO_PROCESS NUMBER(10, 0),
  AUTO_OP_REQ  NUMBER(3, 0),
  CONSTRAINT IPADDR_PRI PRIMARY KEY (ID_IP) USING INDEX TABLESPACE USERS STORAGE (INITIAL 128 K
                                                                                  NEXT 1 M
                                                                                  MAXEXTENTS UNLIMITED),
  CONSTRAINT IPADDR_UNI UNIQUE (CIPADDR) USING INDEX TABLESPACE USERS STORAGE (INITIAL 128 K
                                                                               NEXT 1 M
                                                                               MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 128 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON COLUMN IPADDR.AUTO_OP_REQ IS 'Команда/статус для автоопроса';
COMMENT ON COLUMN IPADDR.AUTO_PROCESS IS 'Идентификатор приложения автоопроса';
COMMENT ON COLUMN IPADDR.CIPADDR IS 'IP адрес';

--
-- Описание для таблицы LOADEDFILES
--
CREATE TABLE LOADEDFILES (
  FILE_NAME VARCHAR2(255 BYTE) NOT NULL,
  LOADDATE  DATE,
  FSIZE     NUMBER,
  CONSTRAINT LOADEDFILES PRIMARY KEY (FILE_NAME) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                       NEXT 1 M
                                                                                       MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

--
-- Описание для таблицы MASKSLINE
--
CREATE TABLE MASKSLINE (
  ID_MASKL  NUMBER(4, 0)       NOT NULL,
  ID_MASK   NUMBER(4, 0)       NOT NULL,
  CFLD      VARCHAR2(240 BYTE) NOT NULL,
  CHEADER   VARCHAR2(16 BYTE),
  DENTER    DATE,
  ID_USR    NUMBER(4, 0),
  ID_TYPE   NUMBER(2, 0),
  SEQUENCE  NUMBER(4, 0),
  COLWIDTH  NUMBER(5, 2),
  COLFORMAT VARCHAR2(1 BYTE),
  COLHIDDEN NUMBER(1, 0)       DEFAULT 0,
  CONSTRAINT MASKSLINE_PRI PRIMARY KEY (ID_MASKL) USING INDEX TABLESPACE USERS STORAGE (INITIAL 128 K
                                                                                        NEXT 1 M
                                                                                        MAXEXTENTS UNLIMITED),
  CONSTRAINT MASKSLINE_UNI UNIQUE (CFLD, ID_MASK) USING INDEX TABLESPACE USERS STORAGE (INITIAL 128 K
                                                                                        NEXT 1 M
                                                                                        MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 128 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

CREATE INDEX MASKSLINE_ID_MASK ON MASKSLINE (ID_MASK)
TABLESPACE USERS
STORAGE (INITIAL 128 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON TABLE MASKSLINE IS 'Поля шаблона';
COMMENT ON COLUMN MASKSLINE.CFLD IS 'Имя поля';
COMMENT ON COLUMN MASKSLINE.CHEADER IS 'Имя заголовка для таблицы';
COMMENT ON COLUMN MASKSLINE.ID_MASK IS '->MASKS';
COMMENT ON COLUMN MASKSLINE.ID_MASKL IS 'PK';
COMMENT ON COLUMN MASKSLINE.ID_TYPE IS '->PARAMTYPE';

--
-- Описание для таблицы PEEK_INFO
--
CREATE TABLE PEEK_INFO (
  FILENAME  NVARCHAR2(50),
  PAGENAME  NVARCHAR2(50),
  ID        NUMBER,
  THEYEAR   NUMBER(*, 0),
  THEMONTH  NUMBER(*, 0),
  CATEGORY  NVARCHAR2(5),
  SUBTARRIF NVARCHAR2(50),
  CONSTRAINT PK_PEEK_INFO_ID PRIMARY KEY (ID) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                    NEXT 1 M
                                                                                    MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON TABLE PEEK_INFO IS 'данные о пиквых часах по категориям';
COMMENT ON COLUMN PEEK_INFO.CATEGORY IS 'ценовая категория';
COMMENT ON COLUMN PEEK_INFO.FILENAME IS 'файл из которого загружена матрица';
COMMENT ON COLUMN PEEK_INFO.ID IS 'ключ';
COMMENT ON COLUMN PEEK_INFO.PAGENAME IS 'страница с которой загружена';
COMMENT ON COLUMN PEEK_INFO.SUBTARRIF IS 'День,Пик,Полупик,Ночь';
COMMENT ON COLUMN PEEK_INFO.THEMONTH IS 'месяц';
COMMENT ON COLUMN PEEK_INFO.THEYEAR IS 'год';

--
-- Описание для таблицы PHONECHANNEL
--
CREATE TABLE PHONECHANNEL (
  TID    NUMBER,
  TPHONE VARCHAR2(16 BYTE),
  TCOM   VARCHAR2(6 BYTE)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

--
-- Описание для таблицы PHONEDURATION
--
CREATE TABLE PHONEDURATION (
  TID   NUMBER,
  TDATE DATE,
  TNUM  VARCHAR2(16 BYTE),
  TDUR  VARCHAR2(8 BYTE),
  TCOST VARCHAR2(24 BYTE)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON COLUMN PHONEDURATION.TCOST IS 'Цена сверх тарифа';
COMMENT ON COLUMN PHONEDURATION.TDATE IS 'Дата и время сессии связи';
COMMENT ON COLUMN PHONEDURATION.TDUR IS 'Время сеанса связи';
COMMENT ON COLUMN PHONEDURATION.TID IS 'Идентификатор 1-COM4, тел. +7-981-113-97-99; 2-COM5, тел. +7-981-749-44-09;';
COMMENT ON COLUMN PHONEDURATION.TNUM IS 'Номер телефона с которым выполнялась связь';

--
-- Описание для таблицы PR_INFO
--
CREATE TABLE PR_INFO (
  FILENAME   NVARCHAR2(50) NOT NULL,
  PAGENAME   NVARCHAR2(50) NOT NULL,
  ID         NUMBER,
  MINPOWER   NUMBER(18, 6),
  MAXPOWER   NUMBER(18, 6),
  POWERLEVEL NVARCHAR2(10),
  HEADERTEXT NVARCHAR2(255),
  THEYEAR    NUMBER(*, 0),
  THEMONTH   NUMBER(*, 0),
  POWERTEXT  NVARCHAR2(255),
  CATEGORY   NVARCHAR2(5),
  POWERCOST  NUMBER(18, 6),
  SUBTARRIF  NVARCHAR2(50),
  PEREDACHA  NUMBER(18, 6) DEFAULT 0,
  CONSTRAINT PK_PR_INFO_ID PRIMARY KEY (ID) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                  NEXT 1 M
                                                                                  MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON TABLE PR_INFO IS 'матрица для расчета стоимости по категориям';
COMMENT ON COLUMN PR_INFO.CATEGORY IS 'ценовая категория';
COMMENT ON COLUMN PR_INFO.FILENAME IS 'файл из которого загружена матрица';
COMMENT ON COLUMN PR_INFO.HEADERTEXT IS 'текст из заголовка таблицы для проверки';
COMMENT ON COLUMN PR_INFO.ID IS 'ключ';
COMMENT ON COLUMN PR_INFO.MAXPOWER IS 'верхний предел  разрешенной мощности';
COMMENT ON COLUMN PR_INFO.MINPOWER IS 'нижний предел разрешенной мощности';
COMMENT ON COLUMN PR_INFO.PAGENAME IS 'страница с которой загружена';
COMMENT ON COLUMN PR_INFO.POWERCOST IS 'ставка за мощность';
COMMENT ON COLUMN PR_INFO.POWERLEVEL IS 'уровень напряжения';
COMMENT ON COLUMN PR_INFO.POWERTEXT IS 'текст с описанием разрешонной мощности для проверки';
COMMENT ON COLUMN PR_INFO.SUBTARRIF IS 'День,Пик,Полупик,Ночь только для 1 и 2 категории';
COMMENT ON COLUMN PR_INFO.THEMONTH IS 'месяц';
COMMENT ON COLUMN PR_INFO.THEYEAR IS 'год';

--
-- Описание для таблицы TBL
--
CREATE TABLE TBL (
  SID   NUMBER(*, 0) NOT NULL,
  SNAME VARCHAR2(64 BYTE),
  DEPNO NUMBER(2, 0),
  CONSTRAINT PK_TBL PRIMARY KEY (SID) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                            NEXT 1 M
                                                                            MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

--
-- Описание для таблицы USERGROUP
--
CREATE TABLE USERGROUP (
  USERSID NUMBER NOT NULL,
  ID_GRP  NUMBER NOT NULL,
  CONSTRAINT USREGROUP_PK PRIMARY KEY (USERSID, ID_GRP) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                              NEXT 1 M
                                                                                              MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

--
-- Описание для таблицы USERS
--
CREATE TABLE USERS (
  USERSID  NUMBER            NOT NULL,
  LOGIN    VARCHAR2(60 BYTE) NOT NULL,
  PASSWORD VARCHAR2(60 BYTE) NOT NULL,
  LOCKED   NUMBER(1, 0)      DEFAULT 0,
  EMAIL    VARCHAR2(256 BYTE),
  CONSTRAINT USERS_PK PRIMARY KEY (USERSID) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                  NEXT 1 M
                                                                                  MAXEXTENTS UNLIMITED),
  CONSTRAINT USERS_UK UNIQUE (LOGIN) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                           NEXT 1 M
                                                                           MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON TABLE USERS IS 'таблица пользователей для WEB доступа';
COMMENT ON COLUMN USERS.EMAIL IS 'email ';
COMMENT ON COLUMN USERS.LOCKED IS 'заблокирован вход';
COMMENT ON COLUMN USERS.LOGIN IS 'логин';
COMMENT ON COLUMN USERS.PASSWORD IS 'пароль';
COMMENT ON COLUMN USERS.USERSID IS 'идентификатор пользователя';

--
-- Описание для таблицы WEBTEMPLATE
--
CREATE TABLE WEBTEMPLATE (
  WEBTEMPLATEID NUMBER NOT NULL,
  ID_BD         NUMBER NOT NULL,
  ID_PTYPE      NUMBER NOT NULL,
  FILENAME      VARCHAR2(255 BYTE),
  NAME          VARCHAR2(255 BYTE),
  CONSTRAINT WEBTEMPLATE_PK PRIMARY KEY (WEBTEMPLATEID) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                              NEXT 1 M
                                                                                              MAXEXTENTS UNLIMITED),
  CONSTRAINT WEBTEMPLATE_UK UNIQUE (ID_BD, ID_PTYPE, FILENAME) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                                     NEXT 1 M
                                                                                                     MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON TABLE WEBTEMPLATE IS 'Шаблоны отчетов на будущее';
COMMENT ON COLUMN WEBTEMPLATE.FILENAME IS 'имя файла шаблона';
COMMENT ON COLUMN WEBTEMPLATE.ID_BD IS 'устройство';
COMMENT ON COLUMN WEBTEMPLATE.ID_PTYPE IS 'тип архива';
COMMENT ON COLUMN WEBTEMPLATE.NAME IS 'название шаблона';
COMMENT ON COLUMN WEBTEMPLATE.WEBTEMPLATEID IS 'id шаблона';

--
-- Описание для таблицы WHOGIVETOP
--
CREATE TABLE WHOGIVETOP (
  ID_WHOTOP NUMBER(5, 0) NOT NULL,
  CNAME     VARCHAR2(64 BYTE),
  CADDRESS  VARCHAR2(200 BYTE),
  CFIO      VARCHAR2(64 BYTE),
  CPHONE    VARCHAR2(32 BYTE),
  DUPD      VARCHAR2(12 BYTE),
  CONSTRAINT WHOGIVETOP_ PRIMARY KEY (ID_WHOTOP) USING INDEX TABLESPACE USERS STORAGE (INITIAL 128 K
                                                                                       NEXT 1 M
                                                                                       MAXEXTENTS UNLIMITED),
  CONSTRAINT WHOGIVETOP_UNI UNIQUE (CNAME) USING INDEX TABLESPACE USERS STORAGE (INITIAL 128 K
                                                                                 NEXT 1 M
                                                                                 MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 128 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON TABLE WHOGIVETOP IS 'Снабжающая организация';
COMMENT ON COLUMN WHOGIVETOP.CADDRESS IS 'Адрес';
COMMENT ON COLUMN WHOGIVETOP.CFIO IS 'Контактное лицо';
COMMENT ON COLUMN WHOGIVETOP.CNAME IS 'Название';
COMMENT ON COLUMN WHOGIVETOP.CPHONE IS 'Телефон';
COMMENT ON COLUMN WHOGIVETOP.ID_WHOTOP IS 'PK';

--
-- Описание для таблицы BMODEMS
--
CREATE TABLE BMODEMS (
  ID_MODEM     NUMBER(5, 0) NOT NULL,
  ID_BD        NUMBER(5, 0),
  CPHONE       VARCHAR2(24 BYTE),
  CSPEED       VARCHAR2(6 BYTE),
  CDATABIT     VARCHAR2(1 BYTE),
  CPARITY      VARCHAR2(1 BYTE),
  CSTOPBITS    VARCHAR2(1 BYTE),
  CPREFPHONE   VARCHAR2(10 BYTE),
  CONNECTLIMIT NUMBER(5, 0),
  PARAMLIMIT   NUMBER(3, 1),
  CONSTRAINT BMODEMS_PRI PRIMARY KEY (ID_MODEM) USING INDEX TABLESPACE USERS STORAGE (INITIAL 128 K
                                                                                      NEXT 1 M
                                                                                      MAXEXTENTS UNLIMITED),
  CONSTRAINT BMODEMS_BDEVICES FOREIGN KEY (ID_BD)
  REFERENCES ENODES (NODE_ID)
)
TABLESPACE USERS
STORAGE (INITIAL 128 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

CREATE INDEX BMODEMS_ID_BD ON BMODEMS (ID_BD)
TABLESPACE USERS
STORAGE (INITIAL 128 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON TABLE BMODEMS IS 'Модемы в узлах учета';
COMMENT ON COLUMN BMODEMS.CDATABIT IS 'Биты данных';
COMMENT ON COLUMN BMODEMS.CONNECTLIMIT IS 'Лимит времени на установку связи';
COMMENT ON COLUMN BMODEMS.CPARITY IS 'Четность';
COMMENT ON COLUMN BMODEMS.CPHONE IS 'Телефон';
COMMENT ON COLUMN BMODEMS.CPREFPHONE IS 'Префикс местной АТС';
COMMENT ON COLUMN BMODEMS.CSPEED IS 'Скорость бод';
COMMENT ON COLUMN BMODEMS.CSTOPBITS IS 'Стоповые биты';
COMMENT ON COLUMN BMODEMS.ID_BD IS '->BDEVICES';
COMMENT ON COLUMN BMODEMS.ID_MODEM IS 'PK';
COMMENT ON COLUMN BMODEMS.PARAMLIMIT IS 'Лимит времени на опрос 1 параметра';

--
-- Описание для таблицы COMPORTS
--
CREATE TABLE COMPORTS (
  ID_CP     NUMBER(4, 0)     NOT NULL,
  ID_IP     NUMBER(4, 0)     NOT NULL,
  COMPORT   VARCHAR2(5 BYTE) NOT NULL,
  DUPD      CHAR(12 BYTE),
  CTYPECALL VARCHAR2(1 BYTE),
  CATSCODE  VARCHAR2(16 BYTE),
  USEDUNTIL DATE,
  CONSTRAINT COMPORT_PRI PRIMARY KEY (ID_CP) USING INDEX TABLESPACE USERS STORAGE (INITIAL 128 K
                                                                                   NEXT 1 M
                                                                                   MAXEXTENTS UNLIMITED),
  CONSTRAINT COMPORT_IPADDR FOREIGN KEY (ID_IP)
  REFERENCES IPADDR (ID_IP),
  CONSTRAINT COMPORT_UNI UNIQUE (COMPORT, ID_IP) USING INDEX TABLESPACE USERS STORAGE (INITIAL 128 K
                                                                                       NEXT 1 M
                                                                                       MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 128 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON TABLE COMPORTS IS 'Порты RS232';
COMMENT ON COLUMN COMPORTS.CATSCODE IS 'Код местной атс';
COMMENT ON COLUMN COMPORTS.COMPORT IS 'COM Port';
COMMENT ON COLUMN COMPORTS.CTYPECALL IS 'T'' - тоновый  ''P'' - пульсовый';
COMMENT ON COLUMN COMPORTS.ID_CP IS 'PK';
COMMENT ON COLUMN COMPORTS.ID_IP IS '->IPADDR';
COMMENT ON COLUMN COMPORTS.USEDUNTIL IS 'Используется системой ( занят) до указанного времени';

--
-- Описание для таблицы DEVICES
--
CREATE TABLE DEVICES (
  ID_DEV   NUMBER(2, 0) NOT NULL,
  CDEVNAME VARCHAR2(24 BYTE),
  CDEVDESC VARCHAR2(254 BYTE),
  ID_CLASS NUMBER(2, 0),
  DLLNAME  VARCHAR2(80 BYTE),
  CONSTRAINT DEVICE_PRI PRIMARY KEY (ID_DEV) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                   NEXT 1 M
                                                                                   MAXEXTENTS UNLIMITED),
  CONSTRAINT DEVICE_DEVCLASS FOREIGN KEY (ID_CLASS)
  REFERENCES DEVCLASSES (ID_CLASS),
  CONSTRAINT DEVICE_UNI UNIQUE (CDEVNAME) USING INDEX TABLESPACE USERS STORAGE (INITIAL 128 K
                                                                                NEXT 1 M
                                                                                MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 128 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON TABLE DEVICES IS 'Устройства';
COMMENT ON COLUMN DEVICES.CDEVDESC IS 'Описание';
COMMENT ON COLUMN DEVICES.CDEVNAME IS 'Имя устройства';
COMMENT ON COLUMN DEVICES.DLLNAME IS 'Название DLL c драйвером';
COMMENT ON COLUMN DEVICES.ID_CLASS IS '->DEVCLASSES';
COMMENT ON COLUMN DEVICES.ID_DEV IS 'PK';

--
-- Описание для таблицы ESTAT
--
CREATE TABLE ESTAT (
  SENDERID NUMBER(18, 0) NOT NULL,
  THEYEAR  NUMBER(4, 0)  NOT NULL,
  THEMONTH NUMBER(2, 0)  NOT NULL,
  COST     NUMBER(18, 6),
  POWER    NUMBER(18, 6),
  CONSTRAINT ESTAT_PK PRIMARY KEY (SENDERID, THEYEAR, THEMONTH) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                                      NEXT 1 M
                                                                                                      MAXEXTENTS UNLIMITED),
  CONSTRAINT ESTAT_FK FOREIGN KEY (SENDERID)
  REFERENCES ESENDER (SENDER_ID)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON COLUMN ESTAT.COST IS 'Стоимость ';
COMMENT ON COLUMN ESTAT.POWER IS 'Мощность';
COMMENT ON COLUMN ESTAT.SENDERID IS 'Филиал';
COMMENT ON COLUMN ESTAT.THEMONTH IS 'Месяц';
COMMENT ON COLUMN ESTAT.THEYEAR IS 'Год';

--
-- Описание для таблицы PEEK_DATA
--
CREATE TABLE PEEK_DATA (
  PEEK_INFO_ID NUMBER(*, 0) NOT NULL,
  THEDATE      DATE,
  HOUR         NUMBER(*, 0),
  CONSTRAINT PK_PEEK_DATA PRIMARY KEY (PEEK_INFO_ID, THEDATE, HOUR) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                                          NEXT 1 M
                                                                                                          MAXEXTENTS UNLIMITED),
  CONSTRAINT FK_PEEK_DATA_PEEK_INFO_ID FOREIGN KEY (PEEK_INFO_ID)
  REFERENCES PEEK_INFO (ID) ON DELETE CASCADE
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON TABLE PEEK_DATA IS 'данные матрицы пиковых интервалов';
COMMENT ON COLUMN PEEK_DATA.HOUR IS 'номер часа';
COMMENT ON COLUMN PEEK_DATA.PEEK_INFO_ID IS 'ключ матрицы';
COMMENT ON COLUMN PEEK_DATA.THEDATE IS 'дата';

--
-- Описание для таблицы PLANCALL
--
CREATE TABLE PLANCALL (
  ID_BD          NUMBER(5, 0)     NOT NULL,
  DBEG           DATE,
  CSTATUS        NUMBER(2, 0)     DEFAULT 0,
  ICALL          NUMBER(6, 0),
  NUMCALL        NUMBER(2, 0),
  CCURR          VARCHAR2(1 BYTE) DEFAULT '0',
  CHOUR          VARCHAR2(1 BYTE) DEFAULT '0',
  C24            VARCHAR2(1 BYTE) DEFAULT '0',
  CSUM           VARCHAR2(1 BYTE) DEFAULT '0',
  NUMHOUR        NUMBER(2, 0),
  NUM24          NUMBER(2, 0),
  NMAXCALL       NUMBER(2, 0),
  MINREPEAT      NUMBER(2, 0)     DEFAULT 0,
  DUPD           VARCHAR2(12 BYTE),
  ID_USR         NUMBER(4, 0),
  DLOCK          DATE,
  DBEG24         DATE,
  ICALL24        NUMBER(6, 0),
  DBEGCURR       DATE,
  ICALLCURR      NUMBER(6, 0),
  DBEGSUM        DATE,
  ICALLSUM       NUMBER(6, 0),
  CHNRONLY       CHAR(1 BYTE),
  C24NRONLY      CHAR(1 BYTE),
  DNEXTHOUR      DATE,
  DNEXT24        DATE,
  DNEXTCURR      DATE,
  DNEXTSUM       DATE,
  DLASTCALL      DATE,
  DLASTDAY       DATE,
  DLASTHOUR      DATE,
  MUSTREPEATDAY  VARCHAR2(1 BYTE),
  MUSTREPEATHOUR VARCHAR2(1 BYTE),
  NCALL          NUMBER(2, 0)     DEFAULT 0,
  CONSTRAINT PLAN_BDEV FOREIGN KEY (ID_BD)
  REFERENCES ENODES (NODE_ID)
)
TABLESPACE USERS
STORAGE (INITIAL 128 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

CREATE INDEX PLAN_ID_BD ON PLANCALL (ID_BD)
TABLESPACE USERS
STORAGE (INITIAL 128 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON TABLE PLANCALL IS 'План опроса устройств';
COMMENT ON COLUMN PLANCALL.C24 IS '1'' - опрашивать суточные';
COMMENT ON COLUMN PLANCALL.C24NRONLY IS 'Только непрочитанные часовые';
COMMENT ON COLUMN PLANCALL.CCURR IS '1'' - опрашивать текущие';
COMMENT ON COLUMN PLANCALL.CHNRONLY IS 'Только непрочитанные суточные';
COMMENT ON COLUMN PLANCALL.CHOUR IS '1'' - опрашивать часовые';
COMMENT ON COLUMN PLANCALL.CSTATUS IS '0 - норма   1 - заблокирован пользователем   2 - заблокирован системой';
COMMENT ON COLUMN PLANCALL.CSUM IS '1'' - опрашивать итоговые';
COMMENT ON COLUMN PLANCALL.DBEG IS 'Дата начала опроса  часовых';
COMMENT ON COLUMN PLANCALL.DBEG24 IS 'Дата начала опроса  суточных';
COMMENT ON COLUMN PLANCALL.DBEGCURR IS 'Дата начала опроса мгновенных';
COMMENT ON COLUMN PLANCALL.DBEGSUM IS 'Дата начала опроса тотальных';
COMMENT ON COLUMN PLANCALL.DLASTCALL IS 'Дата последнего опроса счетчика';
COMMENT ON COLUMN PLANCALL.DLASTDAY IS 'Дата последнего опроса суточных';
COMMENT ON COLUMN PLANCALL.DLASTHOUR IS 'Дата последнего опроса часовых';
COMMENT ON COLUMN PLANCALL.DLOCK IS 'Когда заблокирован';
COMMENT ON COLUMN PLANCALL.DNEXT24 IS 'Дата следующего опроса суточных';
COMMENT ON COLUMN PLANCALL.DNEXTCURR IS 'Дата следующего опроса мгновенных';
COMMENT ON COLUMN PLANCALL.DNEXTHOUR IS 'Дата следующего опроса часовых';
COMMENT ON COLUMN PLANCALL.DNEXTSUM IS 'Дата следующего опроса тотальных';
COMMENT ON COLUMN PLANCALL.ICALL IS 'Интервал опроса (минут) часовых';
COMMENT ON COLUMN PLANCALL.ICALL24 IS 'Интервал опроса (часов) суточных';
COMMENT ON COLUMN PLANCALL.ICALLCURR IS 'Интервал опроса (минут) мгновенных';
COMMENT ON COLUMN PLANCALL.ICALLSUM IS 'Интервал опроса (минут) тотальных';
COMMENT ON COLUMN PLANCALL.ID_BD IS '->BDEVICES';
COMMENT ON COLUMN PLANCALL.MINREPEAT IS 'При неудачом дозвоне повторить через MINREPEAT минут';
COMMENT ON COLUMN PLANCALL.MUSTREPEATDAY IS 'Требование повтора съема суточных';
COMMENT ON COLUMN PLANCALL.MUSTREPEATHOUR IS 'Требование повтора съема часовых';
COMMENT ON COLUMN PLANCALL.NCALL IS 'Номер  попытки  соединения в  текущем цикле опроса';
COMMENT ON COLUMN PLANCALL.NMAXCALL IS 'Max число попыток дозвона';
COMMENT ON COLUMN PLANCALL.NUM24 IS 'За сколько суток опрашивать суточные';
COMMENT ON COLUMN PLANCALL.NUMCALL IS 'Сколько раз опросить (0 - циклический опрос)';
COMMENT ON COLUMN PLANCALL.NUMHOUR IS 'За сколько часов опрашивать часовые';

--
-- Описание для таблицы PR_DATA
--
CREATE TABLE PR_DATA (
  PR_INFO_ID NUMBER(*, 0) NOT NULL,
  THEDATE    DATE,
  HOUR       NUMBER(*, 0),
  VALUE      NUMBER(18, 6),
  CONSTRAINT PK_PR_DATA PRIMARY KEY (PR_INFO_ID, THEDATE, HOUR) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                                      NEXT 1 M
                                                                                                      MAXEXTENTS UNLIMITED),
  CONSTRAINT FK_PR_DATA_PR_INFO_ID FOREIGN KEY (PR_INFO_ID)
  REFERENCES PR_INFO (ID) ON DELETE CASCADE
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON TABLE PR_DATA IS 'данные матрицы цен';
COMMENT ON COLUMN PR_DATA.HOUR IS 'номер часа';
COMMENT ON COLUMN PR_DATA.PR_INFO_ID IS 'ключ матрицы';
COMMENT ON COLUMN PR_DATA.THEDATE IS 'дата';
COMMENT ON COLUMN PR_DATA.VALUE IS 'ставка';

--
-- Описание для таблицы WEBREPORT
--
CREATE TABLE WEBREPORT (
  WEBREPORTID NUMBER,
  CREATEDATE  DATE         DEFAULT sysdate,
  USERSID     NUMBER       NOT NULL,
  ID_BD       NUMBER       NOT NULL,
  ID_PTYPE    NUMBER       NOT NULL,
  DFROM       DATE         NOT NULL,
  DTO         DATE         NOT NULL,
  TEMPLATEID  NUMBER,
  REPORTFILE  VARCHAR2(500 BYTE),
  REPORTREADY NUMBER(1, 0) DEFAULT 0,
  REPORTMSG   VARCHAR2(128 BYTE),
  CONSTRAINT WEBREPORT_PK PRIMARY KEY (WEBREPORTID) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                          NEXT 1 M
                                                                                          MAXEXTENTS UNLIMITED),
  CONSTRAINT WEBREPORT_USR FOREIGN KEY (USERSID)
  REFERENCES USERS (USERSID)
)
TABLESPACE USERS
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON TABLE WEBREPORT IS 'запрос и результат отчета для WEB  подсистемы';
COMMENT ON COLUMN WEBREPORT.CREATEDATE IS 'дата создания запроса';
COMMENT ON COLUMN WEBREPORT.DFROM IS 'дата С';
COMMENT ON COLUMN WEBREPORT.DTO IS 'дата По';
COMMENT ON COLUMN WEBREPORT.ID_BD IS 'устройство';
COMMENT ON COLUMN WEBREPORT.ID_PTYPE IS 'тип архива';
COMMENT ON COLUMN WEBREPORT.REPORTFILE IS 'имя файла отчета';
COMMENT ON COLUMN WEBREPORT.REPORTMSG IS 'сообщение модуля отчетов';
COMMENT ON COLUMN WEBREPORT.REPORTREADY IS 'отчет готов';
COMMENT ON COLUMN WEBREPORT.TEMPLATEID IS 'id шаблона';
COMMENT ON COLUMN WEBREPORT.USERSID IS 'Пользователь';
COMMENT ON COLUMN WEBREPORT.WEBREPORTID IS 'уникальный идентификатор';

--
-- Описание для таблицы MASKS
--
CREATE TABLE MASKS (
  ID_MASK NUMBER(4, 0) NOT NULL,
  CNAME   VARCHAR2(80 BYTE),
  CTYPE   VARCHAR2(1 BYTE),
  ID_DEV  NUMBER(2, 0),
  ID_TYPE NUMBER(2, 0),
  CONSTRAINT MASKS_PRI PRIMARY KEY (ID_MASK) USING INDEX TABLESPACE USERS STORAGE (INITIAL 128 K
                                                                                   NEXT 1 M
                                                                                   MAXEXTENTS UNLIMITED),
  CONSTRAINT MASKS_DEVICES FOREIGN KEY (ID_DEV)
  REFERENCES DEVICES (ID_DEV),
  CONSTRAINT MASKS_UNI UNIQUE (CNAME, ID_TYPE) USING INDEX TABLESPACE USERS STORAGE (INITIAL 64 K
                                                                                     NEXT 1 M
                                                                                     MAXEXTENTS UNLIMITED)
)
TABLESPACE USERS
STORAGE (INITIAL 128 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMENT ON TABLE MASKS IS 'Шаблоны опроса';
COMMENT ON COLUMN MASKS.CNAME IS 'Имя шаблона';
COMMENT ON COLUMN MASKS.CTYPE IS '1'' - оперативные  ''2'' - системные';
COMMENT ON COLUMN MASKS.ID_DEV IS '->DEVICES';
COMMENT ON COLUMN MASKS.ID_MASK IS 'PK';
COMMENT ON COLUMN MASKS.ID_TYPE IS '->PARAMTYPE';

--
-- Описание для процедуры XML_NLS_TEST
--
CREATE OR REPLACE procedure xml_nls_test --(p IN number,sdate IN varchar2,edate IN varchar2)
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

--
-- Описание для процедуры XML_REGION_VOLO
--
CREATE OR REPLACE procedure xml_region_volo (
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

--
-- Описание для процедуры XML_REGION_FULL
--
CREATE OR REPLACE procedure xml_region_full(sd IN varchar2)
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

--
-- Описание для представления BDEVICES
--
CREATE OR REPLACE VIEW BDEVICES (
  NODE_ID,
  SENDER_ID,
  MPOINT_CODE,
  MPOINT_NAME,
  ID_DEV,
  ID_MASK,
  NPIP,
  NPPASSWORD,
  NPQUERY,
  NPLOCK,
  HIDEROW,
  TRANSPORT,
  IPPORT,
  NOCPORT,
  SRV_IP_ID,
  CALLERID,
  HOURSHIFT,
  CFIO1,
  CPHONE1,
  CFIO2,
  CPHONE2,
  CADDRESS,
  ID_MASKSUM,
  MAPX,
  MAPY,
  FULLADDRESS,
  ID_MASKDAY,
  NETADDR,
  ID_BD
) AS
    SELECT ENODES."NODE_ID",
           ENODES."SENDER_ID",
           ENODES."MPOINT_CODE",
           ENODES."MPOINT_NAME",
           ENODES."ID_DEV",
           ENODES."ID_MASK",
           ENODES."NPIP",
           ENODES."NPPASSWORD",
           ENODES."NPQUERY",
           ENODES."NPLOCK",
           ENODES."HIDEROW",
           ENODES."TRANSPORT",
           ENODES."IPPORT",
           ENODES."NOCPORT",
           ENODES."SRV_IP_ID",
           ENODES."CALLERID",
           ENODES."HOURSHIFT",
           ENODES."CFIO1",
           ENODES."CPHONE1",
           ENODES."CFIO2",
           ENODES."CPHONE2",
           ENODES."CADDRESS",
           ENODES."ID_MASKSUM",
           ENODES."MAPX",
           ENODES."MAPY",
           ENODES."FULLADDRESS",
           ENODES."ID_MASKDAY",
           ENODES."NETADDR",
           ENODES.NODE_ID ID_BD
      FROM ENODES;

--
-- Описание для представления BGROUPS
--
CREATE OR REPLACE VIEW BGROUPS (
  ID_GRP,
  CGRPNM
) AS
    SELECT SENDER_ID ID_GRP,
           SENDER_NAME CGRPNM
      FROM ESENDER;

--
-- Описание для представления V_COST
--
CREATE OR REPLACE VIEW V_COST (
  NODE_ID,
  SENDER_NAME,
  CODE,
  NAME,
  POWERLEVEL_MIN,
  POWERLEVEL_MAX,
  POWER_QUALITY,
  THEYEAR,
  THEMONTH,
  I,
  II,
  III,
  IV,
  V,
  VI,
  OPTIMAL
) AS
    SELECT COSTCALCULATION.NODE_ID,
           ESENDER.SENDER_NAME,
           mpoint_code code,
           mpoint_name name,
           POWERLEVEL_MIN,
           POWERLEVEL_MAX,
           POWER_QUALITY,
           THEYEAR,
           THEMONTH,
           I,
           II,
           III,
           IV,
           V,
           VI,
           OPTIMAL
      FROM COSTCALCULATION
        JOIN enodes
          ON enodes.node_id = COSTCALCULATION.node_id
        JOIN esender
          ON ESENDER.SENDER_ID = enodes.SENDER_ID;

--
-- Описание для представления V_EDATA
--
CREATE OR REPLACE VIEW V_EDATA (
  DATA_ID,
  NODE_ID,
  P_DATE,
  P_START,
  P_END,
  CODE_01,
  CODE_02,
  CODE_03,
  CODE_04
) AS
    SELECT DATA_ID,
           node_id,
           p_date,
           p_start,
           p_end,
           (NVL(code_01, 0)) CODE_01,
           (NVL(code_02, 0)) CODE_02,
           (NVL(code_03, 0)) CODE_03,
           (NVL(code_04, 0)) CODE_04
      FROM edata2;

--
-- Описание для представления V_STAT
--
CREATE OR REPLACE VIEW V_STAT (
  NODE_ID,
  YEAR,
  D,
  M
) AS
    SELECT node_id,
           year,
           STDDEV(NVL(code_01, 0)) D,
           MEDIAN (NVL(code_01, 0)) M
      FROM edata_week
      GROUP BY node_id,
               YEAR;

--
-- Описание для представления EDATA_HALFHOUR
--
CREATE OR REPLACE VIEW EDATA_HALFHOUR (
  P_DATE,
  P_HOUR,
  P_MIN,
  AP,
  AM,
  RP,
  RM,
  NODE_ID
) AS
    SELECT p_date,
           TO_CHAR(p_end, 'HH24') p_hour,
           CASE WHEN TO_CHAR(p_end, 'MI') < 30 THEN '00' ELSE '30' END p_min,
           SUM(NVL(code_01, 0)) AS AP,
           SUM(NVL(code_02, 0)) AS AM,
           SUM(NVL(code_03, 0)) AS RP,
           SUM(NVL(code_04, 0)) AS RM,
           v_edata.node_id
      FROM v_edata
      GROUP BY node_id,
               p_date,
               TO_CHAR(p_end, 'HH24'),
               CASE WHEN TO_CHAR(p_end, 'MI') < 30 THEN '00' ELSE '30' END;

--
-- Описание для представления EDATA_HOUR
--
CREATE OR REPLACE VIEW EDATA_HOUR (
  P_DATE,
  P_HOUR,
  AP,
  AM,
  RP,
  RM,
  NODE_ID,
  DW
) AS
    SELECT p_date,
           TO_CHAR(p_end, 'HH24') p_hour,
           SUM(NVL(code_01, 0)) AS AP,
           SUM(NVL(code_02, 0)) AS AM,
           SUM(NVL(code_03, 0)) AS RP,
           SUM(NVL(code_04, 0)) AS RM,
           v_edata.node_id,
           TO_CHAR(p_end, 'DY') DW
      FROM v_edata
      GROUP BY node_id,
               p_date,
               TO_CHAR(p_end, 'DY'),
               TO_CHAR(p_end, 'HH24');

COMMIT;

-- 
-- Установка схемы по умолчанию
--
DECLARE
  p VARCHAR2(255);
BEGIN 
  SELECT USER INTO p FROM DUAL;
  EXECUTE IMMEDIATE 'ALTER SESSION SET CURRENT_SCHEMA = ' || p;
END;
/