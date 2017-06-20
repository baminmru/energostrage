---------------------------------------------
-- Export file for user BEAVIS@ORA11PIR    --
-- Created by bami on 31.01.2017, 13:54:33 --
---------------------------------------------

set define off
spool all.log

prompt
prompt Creating table ENODES
prompt =====================
prompt
@@enodes.tab
prompt
prompt Creating table BMODEMS
prompt ======================
prompt
@@bmodems.tab
prompt
prompt Creating table CLUSTERING
prompt =========================
prompt
@@clustering.tab
prompt
prompt Creating table IPADDR
prompt =====================
prompt
@@ipaddr.tab
prompt
prompt Creating table COMPORTS
prompt =======================
prompt
@@comports.tab
prompt
prompt Creating table DEVCLASSES
prompt =========================
prompt
@@devclasses.tab
prompt
prompt Creating table DEVICES
prompt ======================
prompt
@@devices.tab
prompt
prompt Creating table ECHANEL
prompt ======================
prompt
@@echanel.tab
prompt
prompt Creating table EDATA
prompt ====================
prompt
@@edata.tab
prompt
prompt Creating table EDATA_AGG
prompt ========================
prompt
@@edata_agg.tab
prompt
prompt Creating table EDATA_WEEK
prompt =========================
prompt
@@edata_week.tab
prompt
prompt Creating table EDATA_WEEKMULT
prompt =============================
prompt
@@edata_weekmult.tab
prompt
prompt Creating table ELECTRO
prompt ======================
prompt
@@electro.tab
prompt
prompt Creating table ELOADED
prompt ======================
prompt
@@eloaded.tab
prompt
prompt Creating table ESENDER
prompt ======================
prompt
@@esender.tab
prompt
prompt Creating table GROUPS
prompt =====================
prompt
@@groups.tab
prompt
prompt Creating table LOADEDFILES
prompt ==========================
prompt
@@loadedfiles.tab
prompt
prompt Creating table MASKS
prompt ====================
prompt
@@masks.tab
prompt
prompt Creating table MASKSLINE
prompt ========================
prompt
@@masksline.tab
prompt
prompt Creating table PHONECHANNEL
prompt ===========================
prompt
@@phonechannel.tab
prompt
prompt Creating table PHONEDURATION
prompt ============================
prompt
@@phoneduration.tab
prompt
prompt Creating table PLANCALL
prompt =======================
prompt
@@plancall.tab
prompt
prompt Creating table TBL
prompt ==================
prompt
@@tbl.tab
prompt
prompt Creating table USERGROUP
prompt ========================
prompt
@@usergroup.tab
prompt
prompt Creating table USERS
prompt ====================
prompt
@@users.tab
prompt
prompt Creating table WEBREPORT
prompt ========================
prompt
@@webreport.tab
prompt
prompt Creating table WEBTEMPLATE
prompt ==========================
prompt
@@webtemplate.tab
prompt
prompt Creating sequence BMODEMS_SEQ
prompt =============================
prompt
@@bmodems_seq.seq
prompt
prompt Creating sequence COMPORTS_SEQ
prompt ==============================
prompt
@@comports_seq.seq
prompt
prompt Creating sequence ECHANEL_SEQ
prompt =============================
prompt
@@echanel_seq.seq
prompt
prompt Creating sequence EDATA_SEQ
prompt ===========================
prompt
@@edata_seq.seq
prompt
prompt Creating sequence ELOADED_SEQ
prompt =============================
prompt
@@eloaded_seq.seq
prompt
prompt Creating sequence ENODE_SEQ
prompt ===========================
prompt
@@enode_seq.seq
prompt
prompt Creating sequence ESENDER_SEQ
prompt =============================
prompt
@@esender_seq.seq
prompt
prompt Creating sequence GROUPS_SEQ
prompt ============================
prompt
@@groups_seq.seq
prompt
prompt Creating sequence IPADDR_SEQ
prompt ============================
prompt
@@ipaddr_seq.seq
prompt
prompt Creating sequence MASKSLINE_SEQ
prompt ===============================
prompt
@@masksline_seq.seq
prompt
prompt Creating sequence MASKS_SEQ
prompt ===========================
prompt
@@masks_seq.seq
prompt
prompt Creating sequence TBL_SEQ
prompt =========================
prompt
@@tbl_seq.seq
prompt
prompt Creating sequence USERS_SEQ
prompt ===========================
prompt
@@users_seq.seq
prompt
prompt Creating sequence WEBREPORT_SEQ
prompt ===============================
prompt
@@webreport_seq.seq
prompt
prompt Creating sequence WEBTEMPLATE_SEQ
prompt =================================
prompt
@@webtemplate_seq.seq
prompt
prompt Creating view BDEVICES
prompt ======================
prompt
@@bdevices.vw
prompt
prompt Creating view BGROUPS
prompt =====================
prompt
@@bgroups.vw
prompt
prompt Creating view EDATA_HALFHOUR
prompt ============================
prompt
@@edata_halfhour.vw
prompt
prompt Creating view EDATA_HOUR
prompt ========================
prompt
@@edata_hour.vw
prompt
prompt Creating view V_STAT
prompt ====================
prompt
@@v_stat.vw
prompt
prompt Creating type T_VC
prompt ==================
prompt
@@t_vc.tps
prompt
prompt Creating procedure XML_NLS_TEST
prompt ===============================
prompt
@@xml_nls_test.prc
prompt
prompt Creating procedure XML_REGION_VOLO
prompt ==================================
prompt
@@xml_region_volo.prc
prompt
prompt Creating procedure XML_REGION_FULL
prompt ==================================
prompt
@@xml_region_full.prc

spool off
