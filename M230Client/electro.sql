CREATE TABLE "COUNTERS"."ELECTRO" 
   (	"ID" NUMBER(10,0), 
	"ID_BD" NUMBER(5,0), 
	"ID_PTYPE" NUMBER(2,0), 
	"DCALL" DATE, 
	"DCOUNTER" DATE, 
	"T0" NUMBER(18,6), 
	"T1" NUMBER(18,6), 
	"T2" NUMBER(18,6), 
	"T3" NUMBER(18,6), 
	"T4" NUMBER(18,6), 
	"T5" NUMBER(18,6), 
	"T6" NUMBER(18,6), 
	"C1" NUMBER(18,6), 
	"C2" NUMBER(18,6), 
	"C3" NUMBER(18,6), 
	"C4" NUMBER(18,6), 
	"P0" NUMBER(18,6), 
	"P1" NUMBER(18,6), 
	"P2" NUMBER(18,6), 
	"P3" NUMBER(18,6), 
	"P4" NUMBER(18,6), 
	"P5" NUMBER(18,6), 
	"P6" NUMBER(18,6), 
	"G0" NUMBER(18,6), 
	"G1" NUMBER(18,6), 
	"G2" NUMBER(18,6), 
	"G3" NUMBER(18,6), 
	"G4" NUMBER(18,6), 
	"G5" NUMBER(18,6), 
	"G6" NUMBER(18,6), 
	"U0" NUMBER(18,6), 
	"U1" NUMBER(18,6), 
	"U2" NUMBER(18,6), 
	"U3" NUMBER(18,6), 
	"U4" NUMBER(18,6), 
	"ERRTIME" NUMBER(12,0), 
	"ERRTIMEH" NUMBER(12,0), 
	"HC" VARCHAR2(180), 
	"CHECK_A" NUMBER(1,0) DEFAULT 0, 
	"OKTIME" NUMBER(18,6), 
	"WORKTIME" NUMBER(18,6), 
	"HC_CODE" VARCHAR2(180), 
	"I0" NUMBER, 
	"I1" NUMBER, 
	"I2" NUMBER, 
	"I3" NUMBER, 
	"I4" NUMBER, 
	 CONSTRAINT "ELECTRO_PK" PRIMARY KEY ("ID_BD", "ID_PTYPE", "DCOUNTER", "DCALL")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
 
  CREATE UNIQUE INDEX "COUNTERS"."ELECTRO_PK" ON "COUNTERS"."ELECTRO" ("ID_BD", "ID_PTYPE", "DCOUNTER", "DCALL") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
 
  ALTER TABLE "COUNTERS"."ELECTRO" ADD CONSTRAINT "ELECTRO_PK" PRIMARY KEY ("ID_BD", "ID_PTYPE", "DCOUNTER", "DCALL")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;