
Ext.define('list_model', {
    extend: 'Ext.data.Model',
    fields: [
	{ name: 'NAME', type: 'string' }
]
});

Ext.define('dev_model', {
    extend: 'Ext.data.Model',
    fields: [
	{ name: 'NODENAME', type: 'string' },
	{ name: 'ID_BD', type: 'string' },
    { name: 'ID_GRP', type: 'string' },
    { name: 'CDEVDESC', type: 'string' }
]
,
    idProperty: 'ID_BD'
});


Ext.define('tpl_model', {
    extend: 'Ext.data.Model',
    fields: [
	{ name: 'WEBTEMPLATEID', type: 'string' },
    { name: 'FILENAME', type: 'string' }
	
]
,
    idProperty: 'WEBTEMPLATEID'
});



Ext.define('col_model', {
    extend: 'Ext.data.Model',
    fields: [
	{ name: 'TEXT', type: 'string' },
	{ name: 'DATAINDEX', type: 'string' },
    { name: 'WIDTH', type: 'number' }
],
idProperty:'DATAINDEX'
});



Ext.define('graph_model', {
    extend: 'Ext.data.Model',
    fields: [
	{ name: 'P_DATE', type: 'string' },
	{ name: 'AP', type: 'number' },
	{ name: 'AM', type: 'number' },
	{ name: 'RP', type: 'number' },
	{ name: 'RM', type: 'number' }
    
],
idProperty:'P_DATE'
});



Ext.define('grep_model', {
    extend: 'Ext.data.Model',
    fields: [
	{ name: 'P_DATE', type: 'date'}, 
	{ name: 'P_START', type: 'date'}   , 
	{ name: 'P_END', type: 'date'}   , 
	{ name: 'CODE_01', type: 'number'}, 
	{ name: 'CODE_02', type: 'number'}, 
	{ name: 'CODE_03', type: 'number'}, 
	{ name: 'CODE_04', type: 'number'}
]
});

Ext.define('cost_model', {
    extend: 'Ext.data.Model',
    fields: [
	{ name: 'NODE_ID', type: 'number'}, 
	{ name: 'SENDER_NAME', type: 'string'}   ,
	{ name: 'CODE', type: 'string'}   , 
	{ name: 'NAME', type: 'string'}   , 
	{ name: 'POWERLEVEL_MIN', type: 'string'}, 
	{ name: 'POWERLEVEL_MAX', type: 'string'}, 
	{ name: 'POWER_QUALITY', type: 'string'}, 
	{ name: 'THEYEAR', type: 'string'},
	{ name: 'THEMONTH', type: 'string'},
	{ name: 'I', type: 'string'},
	{ name: 'II', type: 'string'},
	{ name: 'III', type: 'string'},
	{ name: 'IV', type: 'string'},
	{ name: 'V', type: 'string'},
	{ name: 'VI', type: 'string'},
	{ name: 'OPTIMAL', type: 'string'}
]
});


Ext.define('rep_model', {
    extend: 'Ext.data.Model',
    fields: [
	{ name: 'WEBREPORTID', type: 'number'}, 
	{ name: 'CREATEdate', type: 'date'}, 
	{ name: 'USERSID', type: 'number'}   , 
	{ name: 'ID_BD', type: 'number'}   , 
	{ name: 'ID_PTYPE', type: 'number'}, 
	{ name: 'DFROM', type: 'date'}   , 
	{ name: 'DTO', type: 'date'}   , 
	{ name: 'TEMPLATEID', type: 'number'}, 
	{ name: 'REPORTFILE', type: 'string'}, 
	{ name: 'REPORTREADY', type: 'number'}, 
	{ name: 'REPORTMSG', type: 'string'},
	{ name: 'NODENAME', type: 'string'},
	{ name: 'CTYPE', type: 'string'},
	{ name: 'FILENAME', type: 'string' }
],
idProperty:'WEBREPORTID'
});


var enumPtype = Ext.create('Ext.data.ArrayStore', {
    fields: [{ name: 'name' }, { name: 'value', type: 'int'}], data: [
   ['Мгновенные значения', 1]
  ,['Итоговые значения', 2]
//  ,['Часовой архив', 3]
// , ['Суточный архив', 4]
 ]
});

var enumPtype34 = Ext.create('Ext.data.ArrayStore', {
    fields: [{ name: 'name' }, { name: 'value', type: 'int'}], data: [
  ['Часовой архив', 3]
 , ['Суточный архив', 4]
 ]
});


var enumGtype = Ext.create('Ext.data.ArrayStore', {
    fields: [{ name: 'name' }, { name: 'value', type: 'int'}], data: [
	['Среднее получасовое потребление', 4]
   ,['Среднечасовое потребление', 1]
  ,['Ежедневное потребление', 2]
  ,['Недельное потребление', 3]
  
 ]
});


var enumRtype = Ext.create('Ext.data.ArrayStore', {
    fields: [{ name: 'name' }, { name: 'value', type: 'int'}], data: [
	['По прибору учета', 1]
   , ['По группе приборов', 2]
 ]
});

if( typeof(Date.prototype.toLocaleFormat)=='undefined'){
    Date.prototype.toLocaleFormat = function(format) {
		var yyy=this.getYear();
		if (yyy < 2000) {
			yyy= 2000+this.getYear()%100 ;
		}
	    var f = {y : (this.getYear())%100 ,Y : yyy, m : this.getMonth() + 1, d : this.getDate(), H : this.getHours(), M : this.getMinutes(), S : this.getSeconds()}
	    for(var k in f)
	        format = format.replace('%' + k, f[k] < 10 ? "0" + f[k] : f[k]);
	    return format;
	};
}

var last_tpl = "";
var last_tplname = "не задан";

var last_p = "";
var last_pname = "не задан";
var last_d = "";
var last_dname = "узел не выбран";

var date_f =Ext.Date.clearTime( Ext.Date.subtract(new Date(), Ext.Date.DAY, 5) ) ;
var date_t =Ext.Date.clearTime( Ext.Date.add     (new Date(), Ext.Date.DAY, 1) );

var last_f=myDateRenderer(  date_f );
var	last_t=myDateRenderer(  date_t );

var last_y=2017;
var	last_m=5;


var contentPanel;
var menuPanel;

var intervalID = 0;
var dGrid;
var gPanel;



Ext.define('data_model', {
    extend: 'Ext.data.Model',
    fields: [
            { name: 'ID', type: 'number' }
            , { name: 'ID_BD', type: 'string' }
            , { name: 'ID_PTYPE', type: 'string' }
            , { name: 'WORKTIME', type: 'number' }
            , { name: 'DCALL', type: 'date', dateFormat: 'Y-m-d H:i:s' }
             , { name: 'DCOUNTER', type: 'date', dateFormat: 'Y-m-d H:i:s' }
            , { name: 'ERRTIME', type: 'number' }
            , { name: 'OKTIME', type: 'number' }
            , { name: 'ERRTIMEH', type: 'number' }
             , { name: 'HC_CODE', type: 'string' }
             , { name: 'HC', type: 'string' }



            , { name: 'T0', type: 'number' }
            , { name: 'T1', type: 'number' }
            , { name: 'T2', type: 'number' }
            , { name: 'T3', type: 'number' }
            , { name: 'T4', type: 'number' }
            , { name: 'T5', type: 'number' }
            , { name: 'T6', type: 'number' }

            , { name: 'U1', type: 'number' }
            , { name: 'U2', type: 'number' }
            , { name: 'U3', type: 'number' }

            
            , { name: 'G0', type: 'number' }
            , { name: 'G1', type: 'number' }
            , { name: 'G2', type: 'number' }
            , { name: 'G3', type: 'number' }
            , { name: 'G4', type: 'number' }
            , { name: 'G5', type: 'number' }
            , { name: 'G6', type: 'number' }
            

            , { name: 'C1', type: 'number' }
            , { name: 'C2', type: 'number' }
            , { name: 'C3', type: 'number' }


            , { name: 'I0', type: 'number' } 
            , { name: 'I1', type: 'number' }
            , { name: 'I2', type: 'number' }
            , { name: 'I3', type: 'number' }
           

            , { name: 'P0', type: 'number' }
            , { name: 'P1', type: 'number' }
            , { name: 'P2', type: 'number' }
            , { name: 'P3', type: 'number' }
            , { name: 'P4', type: 'number' }
            , { name: 'P5', type: 'number' }
            , { name: 'P6', type: 'number' }


            , { name: 'AP0', type: 'number' } 
            , { name: 'AP1', type: 'number' }
            , { name: 'AP2', type: 'number' }
            , { name: 'AP3', type: 'number' }
            
			, { name: 'AM0', type: 'number' } 
            , { name: 'AM1', type: 'number' }
            , { name: 'AM2', type: 'number' }
            , { name: 'AM3', type: 'number' }
            
            , { name: 'RP0', type: 'number' } 
            , { name: 'RP1', type: 'number' }
            , { name: 'RP2', type: 'number' }
            , { name: 'RP3', type: 'number' }
            
			, { name: 'RM0', type: 'number' } 
            , { name: 'RM1', type: 'number' }
            , { name: 'RM2', type: 'number' }
            , { name: 'RM3', type: 'number' }
			

        ]
});



var store_tpl = Ext.create('Ext.data.Store', {
	model: 'tpl_model',
	autoLoad: false,
	autoSync: false,
	proxy: {
		type: 'ajax',
		url: 'tlist.aspx',
		reader: {
			type: 'json'
		, root: 'data'
		, successProperty: 'success'
		, messageProperty: 'msg'
		},
		listeners: {
			exception: function (proxy, response, operation) {
			}
		}
	}
});


var store_graph = Ext.create('Ext.data.Store', {
	model: 'graph_model',
	autoLoad: false,
	autoSync: false,
	proxy: {
		type: 'ajax',
		url: 'g1.aspx',
		reader: {
			type: 'json'
		, root: 'data'
		, successProperty: 'success'
		, messageProperty: 'msg'
		},
		listeners: {
			exception: function (proxy, response, operation) {
			}
		}
	}
});


var store_dev = Ext.create('Ext.data.Store', {
	model: 'dev_model',
	autoLoad: false,
	autoSync: false,
	proxy: {
		type: 'ajax',
		url: 'dev.aspx',
		reader: {
			type: 'json'
		, root: 'data'
		, successProperty: 'success'
		, messageProperty: 'msg'
		},
		listeners: {
			exception: function (proxy, response, operation) {
			    /*
			    Ext.MessageBox.show({
			    title: 'REMOTE EXCEPTION',
			    msg: operation.getError(),
			    icon: Ext.MessageBox.ERROR,
			    buttons: Ext.Msg.OK
			    });
			    */
			}
		}
	}
});

var store_data = Ext.create('Ext.data.Store', {
    model: 'data_model',
    autoLoad: false,
    autoSync: false,
    proxy: {
        type: 'ajax',
        url: 'data.aspx',
        reader: {
            type: 'json'
		    , root: 'data'
		    , successProperty: 'success'
		    , messageProperty: 'msg'
        },
        listeners: {

            exception: function (proxy, response, operation) {
                /*Ext.MessageBox.show({
                title: 'REMOTE EXCEPTION',
                msg: operation.getError(),
                icon: Ext.MessageBox.ERROR,
                buttons: Ext.Msg.OK
                });
                */
            }
        }
        
    },
    listeners: {
        load: function () {
            store_cols.load({ params: { D: last_d, P: last_p} });
        }
    }

    
});

var store_rep = Ext.create('Ext.data.Store', {
    model: 'rep_model',
    autoLoad: false,
    autoSync: false,
    proxy: {
        type: 'ajax',
        url: 'reports.aspx',
        reader: {
            type: 'json'
		    , root: 'data'
		    , successProperty: 'success'
		    , messageProperty: 'msg'
        },
        listeners: {

            exception: function (proxy, response, operation) {
                /*Ext.MessageBox.show({
                title: 'REMOTE EXCEPTION',
                msg: operation.getError(),
                icon: Ext.MessageBox.ERROR,
                buttons: Ext.Msg.OK
                });
                */
            }
        }
        
    }
   
});

var store_grep = Ext.create('Ext.data.Store', {
    model: 'grep_model',
    autoLoad: false,
    autoSync: false,
    proxy: {
        type: 'ajax',
        url: 'greports.aspx',
        reader: {
            type: 'json'
		    , root: 'data'
		    , successProperty: 'success'
		    , messageProperty: 'msg'
        },
        listeners: {

            exception: function (proxy, response, operation) {
                /*Ext.MessageBox.show({
                title: 'REMOTE EXCEPTION',
                msg: operation.getError(),
                icon: Ext.MessageBox.ERROR,
                buttons: Ext.Msg.OK
                });
                */
            }
        }
        
    }
   
});


var newcolumns;
var store_cols = Ext.create('Ext.data.Store', {
    model: 'col_model',
    autoLoad: false,
    autoSync: false,
    proxy: {
        type: 'ajax',
        url: 'columns.aspx',
        reader: {
            type: 'json'
		, root: 'data'
		, successProperty: 'success'
		, messageProperty: 'msg'
        },
        listeners: {
            exception: function (proxy, response, operation) {
                /*Ext.MessageBox.show({
                title: 'REMOTE EXCEPTION',
                msg: operation.getError(),
                icon: Ext.MessageBox.ERROR,
                buttons: Ext.Msg.OK
                });
                */
            }
        }
    },
    listeners: {
        'load': function () {
            newcolumns = new Array();

//            newcolumns.push({ text:"№", xtype: 'rownumberer',  sortable: false, width: 50 });

            if (last_p == 1) {
                newcolumns.push({ text: 'Дата опроса', dataIndex: 'DCALL', width: 170, minWidth: 140, sortable: true, locked: true, xtype: 'datecolumn', format: 'd.m.Y H:i:s' });
                newcolumns.push({ text: 'Дата прибора', dataIndex: 'DCOUNTER', width: 170, minWidth: 140, sortable: true, locked: true, xtype: 'datecolumn', format: 'd.m.Y H:i:s' });
            }
            if (last_p == 2) {
                newcolumns.push({ text: 'Дата прибора', dataIndex: 'DCOUNTER', width: 170, minWidth: 140, sortable: true, locked: true, xtype: 'datecolumn', format: 'd.m.Y H:i:s' });
            }
            if (last_p == 3) {
                newcolumns.push({ text: 'Дата архива', dataIndex: 'DCOUNTER', width: 140, minWidth: 100, sortable: true, locked: true, xtype: 'datecolumn', format: 'd.m.Y H' });
            }
            if (last_p == 4) {
                newcolumns.push({ text: 'Дата архива', dataIndex: 'DCOUNTER', width: 140, minWidth: 100, sortable: true, locked: true, xtype: 'datecolumn', format: 'd.m.Y' });
            }


            store_cols.each(
				function (record, index) {
				    var txt = record.get('TEXT');
				    var di = record.get('DATAINDEX');
				    var w = record.get('WIDTH');
				    var f = record.get('COLFORMAT');
				    if (di != "DCALL" && di != "DCOUNTER") {
				        var formatstr = "0.000";
				        if (f == "N" || f == "F") {
				            if (f == "N")
				                formatstr = "0.00";
				            if (f == "F")
				                formatstr = "0.000";
				            newcolumns.push({ xtype: 'numbercolumn', text: txt, dataIndex: di, sortable: true, width: w, format: formatstr });
				        } else {
				            newcolumns.push({ text: txt, dataIndex: di, sortable: true, width: w });
				        }
				    }
				}
			);

             
            

            dGrid.reconfigure(store_data, newcolumns);
   		    dGrid.setTitle(last_dname + ". " + last_pname + " (" + store_data.getCount() +" зап.)");
        }
    }
});

 
 function myColorRenderer(value, metaData, record, row, col, store, gridView) {
    color = record.get('COLOR');
    if (color == null || color=='') {if (metaData != null) metaData.style = "background-color:whilte";} 
    if (color == 'Red') { if (metaData != null) metaData.style = "background-color:red";}
    if (color == 'Yellow') { if (metaData != null) metaData.style = "background-color:yellow";  }
	if (color == 'Orange') { if (metaData != null) metaData.style = "background-color:orange";  }
	if (color == 'Grey') { if (metaData != null) metaData.style = "background-color:grey";  }
	if (color == 'Purple') { if (metaData != null) metaData.style = "background-color:purple;color:white";  }
	if (color == 'Green') { if (metaData != null) metaData.style = "background-color:green;color:white";  }
	if (color == 'Black') { if (metaData != null) metaData.style = "background-color:black;color:white";  }
	if (color == 'Blue') { if (metaData != null) metaData.style = "background-color:black;color:white";  }
	if (metaData != null) {
		metaData.tdAttr = 'data-qtip="' + Ext.String.htmlEncode(value) + '"';    
	};
    return value;
}


function myDateRenderer(value, metaData, record, row, col, store, gridView) 
{ 
    if(value==null) return '';
	var s='';
	if(Ext.isDate(value)){
		
		s = value.toLocaleFormat('%Y-%m-%dT%H:%M:%S');
	}else{
		s = new String(value);
	}
	
	var svalue='';
	if (s !=''){
		  var parts2 = s.split('T');
		  var dparts2  =parts2[0].split('-');
		  var hparts2 =parts2[1].split(':');
		  svalue=dparts2[0]+'-'+ dparts2[1] +'-'+ dparts2[2]+ ' '+hparts2[0] +':'+hparts2[1] +':'+ hparts2[2];
	}

    return svalue;
}


function myTSRenderer(value, metaData, record, row, col, store, gridView) 
{ 
    if(value==null) return '';
	var s='';
	s = new String(value);
	
	
	var svalue='';
	if (s !=''){
		  var parts = s.split('.');
		  if(parts.length==3){
		   svalue=parts[0] +'сут. ' + parts[1] ;
		  }
		  if(parts.length==2){
		   svalue=parts[0];
		  }
		  if(parts.length==1){
			svalue=s
		  }
		  
	}

    return svalue;
}


function OkRenderer(value, metaData, record, row, col, store, gridView) 
{ 
    if(value==null) return 'не готов';
	if(value==0) return 'не готов';
	if(value==1) return 'готов';

}

function D24Renderer(value, metaData, record, row, col, store, gridView) {
    if (value == null) {if (metaData != null) metaData.style = "background-color:cyan";  return '?'; }
    if (value == '0') { if (metaData != null) metaData.style = "background-color:cyan"; return '?'; }
    if (value == '1') { if (metaData != null) metaData.style = "background-color:white"; return 'ОК'; }
    if (value == '2') { if (metaData != null) metaData.style = "background-color:red"; return 'не совпадает с часовыми'; }
    if (value == '3') { if (metaData != null) metaData.style = "background-color:yellow"; return 'не хватает часовых'; }
    
}

function refRenderer(value, metaData, record, row, col, store, gridView) 
{ 

    
	if(record.get('REPORTREADY')==0) return '';
	return '<a href=\''+record.get('REPORTFILE')+'\' target=\'_blank\'>Отчет</a>';

}

function trefRenderer(value, metaData, record, row, col, store, gridView) {


    if (record.get('FILENAME') == '') return '';
    return "<a href='rpt\\template\\" + record.get('TNAME') + "' target='_blank' >" + record.get('FILENAME') +"</a>";

}
function myTipRenderer(value, metaData, record, row, col, store, gridView) {
	if (metaData != null) {
		metaData.tdAttr = 'data-qtip="' + Ext.String.htmlEncode(value) + '"';    
	};
    return Ext.String.htmlEncode(value);
}


function reloadData(){
	
	store_data.load({ params: { D: last_d, P: last_p,  F:last_f, T:last_t} });
}

function reloadGraph(){
	store_graph.load({ params: { D: last_d, P: last_p,  F:last_f, T:last_t} });
}


function reloadGrep(){

    store_grep.load({ params: { D: last_d, P: last_p, F: last_f, T: last_t} });
}

function reloadRep(){

    store_rep.load({ params: { D: last_d, P: last_p, F: last_f, T: last_t} });
}

function reloadTpl(){
	last_tpl="";
	last_tplname="";
	store_tpl.load({ params: { D: last_d, P: last_p} });
}

function GetDataFilter(){
	
		var p1 = Ext.create('Ext.panel.Panel', {
		    layout: {
		        type: 'table',
				columns:2
		    },
		    autoScroll: true,
			items: [
			{

						xtype:  'datefield',
						minWidth:'350',
					
						labelAlign:'top',
						format:'d/m/Y',
						submitFormat:'Y-m-d H:i:s',
						value:  date_f,
						name:  'dev_dfrom',
						itemId: 'dev_dfrom',
						fieldLabel: 'C',
						emptyText: 'С',
						editable: false,

				 		submitEmptyText: false,
						listeners:{
							change: function( fld, newValue, oldValue, eOpts ){
										var dfrom = newValue;
										if(dfrom==null ){
											last_f="";
										}
										if(dfrom!=null ){
											last_f=myDateRenderer(dfrom);
										}
										if(	last_d!="" && last_p!="" 	)
											reloadData();
										
							}
						}
						}
						
					
						,{

						xtype:  'datefield',
						
					
						minWidth:'350',
						labelAlign:'top',
						format:'d/m/Y',
						submitFormat:'Y-m-d H:i:s',
						value:  date_t,
						name:  'dev_dto',
						itemId: 'dev_dto',
						fieldLabel: 'По',
						emptyText: 'По',
						editable: false,
	
						submitEmptyText: false,
						listeners:{
							change: function( fld, newValue, oldValue, eOpts ){
										var dto = newValue;
									
										
										if(dto==null ){
											last_t="";
										}
										if( dto!=null ){
											last_t=myDateRenderer(dto);
										}
											if(	last_d!="" && last_p!="" 	)
											reloadData();
							}
						}
						},
			
			
                    {
                        xtype: 'combobox',
					
					
						minWidth:'350',
                        store: store_dev,
                        itemId: 'dev_id',
                        displayField: 'NAME',
                        valueField: 'ID_BD',
                        fieldLabel: 'Узел',
						emptyText:'Узел',
						labelAlign:'top',
                        editable: false,
                        queryMode: 'local',
						autoSelect:true,
					
                        listeners: {
                            select: function (combo, records, eOpts) {
                                last_d = records[0].get('ID_BD');
                                last_dname=records[0].get("NAME") + ", " + records[0].get("CDEVDESC") ;
                                dGrid.setTitle(last_dname + ". " + last_pname);
								if(	last_d!="" && last_p!="" 	)
											reloadData();
                            }
                        }
                    }
						
						,
                        {
                            xtype: 'combobox',
							minWidth:'350',
						    store: enumPtype,
                            itemId: 'dev_ptype',
                            displayField: 'name',
                            valueField: 'value',
                            fieldLabel: 'Архив',
							emptyText:'Архив',
							labelAlign:'top',
                            editable: false,
                            queryMode: 'local',
							autoSelect:true,
                           
                            listeners: {
                                select: function (combo, records, eOpts) {
                                    last_p = records[0].get('value');
                                    last_pname = records[0].get('name');
                                    dGrid.setTitle(last_dname + ". " + last_pname);
									if(	last_d!="" && last_p!="" 	)
											reloadData();
                                },
								render : function(combo,eOpts) {
									combo.setValue(combo.store.first().data.value);
									last_p =combo.store.first().data.value;
									last_pname =combo.store.first().data.name;
								}
                            }
                        }
                    ]
		}
	);
	return p1;
			
}


function GetCostFilter(){
	
		var p1 = Ext.create('Ext.panel.Panel', {
		    layout: {
		        type: 'table',
				columns:2
		    },
		    autoScroll: true,
			items: [
			{

						xtype:  'numberfield',
						minWidth:'350',
					
						labelAlign:'top',
						value:  2017,
						 maxValue: 2050,
						minValue: 2015,
						name:  'cost_y',
						itemId: 'cost_y',
						fieldLabel: 'Год',
						emptyText: 'Год для вариантов  цен',
						editable: false,

				 		submitEmptyText: false,
						listeners:{
							change: function( fld, newValue, oldValue, eOpts ){
										var dfrom = newValue;
										if(dfrom==null ){
											last_y="";
										}
										if(dfrom!=null ){
											last_y=newValue;
										}
										if(	last_y!="" && last_m!="" 	)
											reloadCosts();
										
							}
						}
			},
						
					
			{

						xtype:  'numberfield',
						minWidth:'350',
					
						labelAlign:'top',
						value:  5,
						maxValue: 12,
						minValue: 1,
						name:  'cost_m',
						itemId: 'cost_m',
						fieldLabel: 'Месяц',
						emptyText: 'Месяц для вариантов цен',
						editable: false,

				 		submitEmptyText: false,
						listeners:{
							change: function( fld, newValue, oldValue, eOpts ){
										var dfrom = newValue;
										if(dfrom==null ){
											last_m="";
										}
										if(dfrom!=null ){
											last_m=newValue;
										}
										if(	last_m!="" && last_y!="" 	)
											reloadCosts();
										
							}
						}
					}
						
						
                    ]
		}
	);
	return p1;
			
}


function GetCostFilter2(){
	
		var p1 = Ext.create('Ext.panel.Panel', {
		    layout: {
		        type: 'table',
				columns:2
		    },
		    autoScroll: true,
			items: [
			{

						xtype:  'numberfield',
						minWidth:'350',
					
						labelAlign:'top',
						value:  2017,
						 maxValue: 2050,
						minValue: 2015,
						name:  'cost_y',
						itemId: 'cost_y',
						fieldLabel: 'Год',
						emptyText: 'Год для вариантов  цен',
						editable: false,

				 		submitEmptyText: false,
						listeners:{
							change: function( fld, newValue, oldValue, eOpts ){
										var dfrom = newValue;
										if(dfrom==null ){
											last_y="";
										}
										if(dfrom!=null ){
											last_y=newValue;
										}
										if(	last_y!="" && last_m!="" 	)
											reloadCosts2();
										
							}
						}
			},
						
					
			{

						xtype:  'numberfield',
						minWidth:'350',
					
						labelAlign:'top',
						value:  5,
						maxValue: 12,
						minValue: 1,
						name:  'cost_m',
						itemId: 'cost_m',
						fieldLabel: 'Месяц',
						emptyText: 'Месяц для вариантов цен',
						editable: false,

				 		submitEmptyText: false,
						listeners:{
							change: function( fld, newValue, oldValue, eOpts ){
										var dfrom = newValue;
										if(dfrom==null ){
											last_m="";
										}
										if(dfrom!=null ){
											last_m=newValue;
										}
										if(	last_m!="" && last_y!="" 	)
											reloadCosts2();
										
							}
						}
					}
						
						
                    ]
		}
	);
	return p1;
			
}


function GetG1Filter(){
	
		var p1 = Ext.create('Ext.panel.Panel', {
		    layout: {
		        type: 'table',
				columns:2
		    },
		    autoScroll: true,
			items: [
			{

						xtype:  'datefield',
						minWidth:'350',
					
						labelAlign:'top',
						format:'d/m/Y',
						submitFormat:'Y-m-d H:i:s',
						value:  date_f,
						name:  'dev_dfrom',
						itemId: 'dev_dfrom',
						fieldLabel: 'C',
						emptyText: 'С',
						editable: false,

				 		submitEmptyText: false,
						listeners:{
							change: function( fld, newValue, oldValue, eOpts ){
										var dfrom = newValue;
										if(dfrom==null ){
											last_f="";
										}
										if(dfrom!=null ){
											last_f=myDateRenderer(dfrom);
										}
										if(	last_d!="" && last_p!="" 	)
											reloadGraph();
										
							}
						}
						}
						
					
						,{

						xtype:  'datefield',
						
					
						minWidth:'350',
						labelAlign:'top',
						format:'d/m/Y',
						submitFormat:'Y-m-d H:i:s',
						value:  date_t,
						name:  'dev_dto',
						itemId: 'dev_dto',
						fieldLabel: 'По',
						emptyText: 'По',
						editable: false,
	
						submitEmptyText: false,
						listeners:{
							change: function( fld, newValue, oldValue, eOpts ){
										var dto = newValue;
									
										
										if(dto==null ){
											last_t="";
										}
										if( dto!=null ){
											last_t=myDateRenderer(dto);
										}
											if(	last_d!="" && last_p!="" 	)
											reloadGraph();
							}
						}
						},
			
			
                    {
                        xtype: 'combobox',
					
					
						minWidth:'350',
                        store: store_dev,
                        itemId: 'dev_id',
                        displayField: 'NAME',
                        valueField: 'ID_BD',
                        fieldLabel: 'Узел',
						emptyText:'Узел',
						labelAlign:'top',
                        editable: false,
                        queryMode: 'local',
						autoSelect:true,
	
                        listeners: {
                            select: function (combo, records, eOpts) {
                                last_d = records[0].get('ID_BD');
                                last_dname=records[0].get("NAME") + ", " + records[0].get("CDEVDESC") ;
                                gPanel.setTitle(last_dname + ". " + last_pname);
								if(	last_d!="" && last_p!="" 	)
											reloadGraph();
                            }
						/*	,
								render : function(combo,eOpts) {
									combo.setValue(combo.store.first().data.ID_BD);
								}
								*/
                        }
                    }
						
						,
                        {
                            xtype: 'combobox',
							minWidth:'350',
						    store: enumGtype,
                            itemId: 'g_type',
                            displayField: 'name',
                            valueField: 'value',
                            fieldLabel: 'График',
							emptyText:'График',
							labelAlign:'top',
                            editable: false,
                            queryMode: 'local',
							autoSelect:true,
						
                           
                            listeners: {
                                select: function (combo, records, eOpts) {
                                    last_p = records[0].get('value');
                                    last_pname = records[0].get('name');
                                    gPanel.setTitle(last_dname + ". " + last_pname);
									if(	last_d!="" && last_p!="" 	)
											reloadGraph();
                                },
								render : function(combo,eOpts) {
									combo.setValue(combo.store.first().data.value);
									last_p = combo.store.first().data.value;
									last_pname = combo.store.first().data.name;
								}
								
                            }
                        }
                    ]
		}
	);
	return p1;
			
}



function GetEFilter(){	
		
		var p1 = Ext.create('Ext.panel.Panel', {
		    layout: {
		        type: 'table',
				columns:2
		    },
		    autoScroll: true,
			items: [
					{

						xtype:  'datefield',
						minWidth:'350',
					
						labelAlign:'top',
						format:'d/m/Y',
						submitFormat:'Y-m-d H:i:s',
						value:  date_f,
						name:  'rep_dfrom',
						itemId: 'rep_dfrom',
						fieldLabel: 'C',
						emptyText: 'С',
						editable: false,

				 		submitEmptyText: false,
						listeners:{
							change: function( fld, newValue, oldValue, eOpts ){
										var dfrom = newValue;
										if(dfrom==null ){
											last_f="";
										}
										if(dfrom!=null ){
											last_f=myDateRenderer(dfrom);
										}
										if(	last_d!=""  	)
											reloadGrep();
										
										
							}
						}
						}
						
					
						,{

						xtype:  'datefield',
						
					
						minWidth:'350',
						labelAlign:'top',
						format:'d/m/Y',
						submitFormat:'Y-m-d H:i:s',
						value:  date_t,
						name:  'rep_dto',
						itemId: 'rep_dto',
						fieldLabel: 'По',
						emptyText: 'По',
						editable: false,
	
						submitEmptyText: false,
						listeners:{
							change: function( fld, newValue, oldValue, eOpts ){
										var dto = newValue;
										if(dto==null ){
											last_t="";
										}
										if( dto!=null ){
											last_t=myDateRenderer(dto);
										}
										if(	last_d!="" 	)
											reloadGrep();
										
							}
						}
						},
			
			
                    {
                        xtype: 'combobox',
					
					
						minWidth:'350',
                        store: store_dev,
                        itemId: 'dev_id',
                        displayField: 'NAME',
                        valueField: 'ID_BD',
                        fieldLabel: 'Узел',
						emptyText:'Узел',
						labelAlign:'top',
                        editable: false,
                        queryMode: 'local',
						autoSelect:true,
	
                        listeners: {
                            select: function (combo, records, eOpts) {
                                last_d = records[0].get('ID_BD');
                                last_dname=records[0].get("NAME") + ", " + records[0].get("CDEVDESC") ;
                                dGrid.setTitle(last_dname + ". " + last_pname);
                                
								if(	last_d!=""	)
									reloadGrep();
								
                            }
                        }
                    }
						
						
						
						
						

                    ]
		}
	);
	return p1;
			
}


function GetRepFilter(){
	
		var p1 = Ext.create('Ext.panel.Panel', {
		    layout: {
		        type: 'table',
				columns:2
		    },
		    autoScroll: true,
			items: [
			{

						xtype:  'datefield',
						minWidth:'350',
					
						labelAlign:'top',
						format:'d/m/Y',
						submitFormat:'Y-m-d H:i:s',
						value:  date_f,
						name:  'rep_dfrom',
						itemId: 'rep_dfrom',
						fieldLabel: 'C',
						emptyText: 'С',
						editable: false,

				 		submitEmptyText: false,
						listeners:{
							change: function( fld, newValue, oldValue, eOpts ){
										var dfrom = newValue;
										if(dfrom==null ){
											last_f="";
										}
										if(dfrom!=null ){
											last_f=myDateRenderer(dfrom);
										}
										if(	last_d!="" && last_p!="" 	)
											reloadRep();
										else
											last_tpl="";
										
							}
						}
						}
						
					
						,{

						xtype:  'datefield',
						
					
						minWidth:'350',
						labelAlign:'top',
						format:'d/m/Y',
						submitFormat:'Y-m-d H:i:s',
						value:  date_t,
						name:  'rep_dto',
						itemId: 'rep_dto',
						fieldLabel: 'По',
						emptyText: 'По',
						editable: false,
	
						submitEmptyText: false,
						listeners:{
							change: function( fld, newValue, oldValue, eOpts ){
										var dto = newValue;
										if(dto==null ){
											last_t="";
										}
										if( dto!=null ){
											last_t=myDateRenderer(dto);
										}
										if(	last_d!="" && last_p!="" 	)
											reloadRep();
										else
											last_tpl="";
							}
						}
						},
			
			
                    {
                        xtype: 'combobox',
					
					
						minWidth:'350',
                        store: store_dev,
                        itemId: 'dev_id',
                        displayField: 'NAME',
                        valueField: 'ID_BD',
                        fieldLabel: 'Узел',
						emptyText:'Узел',
						labelAlign:'top',
                        editable: false,
                        queryMode: 'local',
						autoSelect:true,
	
                        listeners: {
                            select: function (combo, records, eOpts) {
                                last_d = records[0].get('ID_BD');
                                last_dname=records[0].get("NAME") + ", " + records[0].get("CDEVDESC") ;
                                dGrid.setTitle(last_dname + ". " + last_pname);
                                
								if(	last_d!="" && last_p!="" 	){
									reloadTpl();
									combo.up('panel').down('#tpl_fld').setValue(null);
									reloadRep();
								}else{
									last_tpl="";
								}
                            }
                        }
                    }
						
						,
                        {
                            xtype: 'combobox',
							minWidth:'350',
							store: enumRtype,
                            itemId: 'dev_ptype',
                            displayField: 'name',
                            valueField: 'value',
                            fieldLabel: 'Архив',
							emptyText:'Архив',
							labelAlign:'top',
                            editable: false,
                            queryMode: 'local',
							autoSelect:true,
						
                           
                            listeners: {
                                select: function (combo, records, eOpts) {
                                    last_p = records[0].get('value');
                                    last_pname = records[0].get('name');
                                    dGrid.setTitle(last_dname + ". " + last_pname);
                    
									if(	last_d!="" && last_p!="" 	){
											reloadTpl();
											combo.up('panel').down('#tpl_fld').setValue(null);
											reloadRep();
									}else{
										last_tpl="";
									}
                                },
								render : function(combo,eOpts) {
									combo.setValue(combo.store.first().data.value);
									last_p = combo.store.first().data.value;
									last_pname = combo.store.first().data.name;
									
								}
                            }
                        }
						
						
							,
                        {
                            xtype: 'combobox',
							minWidth:'350',
						    store: store_tpl,
                            itemId: 'tpl_fld',
                            displayField: 'FILENAME',
                            valueField: 'WEBTEMPLATEID',
                            fieldLabel: 'Шаблон',
							emptyText:'Шаблон',
							labelAlign:'top',
                            editable: false,
                            queryMode: 'local',
							autoSelect:true,
                           
                            listeners: {
                                select: function (combo, records, eOpts) {
                                    last_tpl = records[0].get('WEBTEMPLATEID');
                                    last_tplname = records[0].get('FILENAME');
									if(	last_d!="" && last_p!="" 	)
											reloadRep();
                                },
								render : function(combo,eOpts) {
									combo.setValue(null);
									last_tpl = "";
									last_tplname = "";
								}
                            }
                        }
                        ,
                        {
                            xtype: 'button',
                            minWidth: '350',
							minHeight:60,
                            iconCls: 'icon-table_add',
                            text: 'Добавить шаблон',
                            itemId: 'bAddTpl',
                            handler: onAddTplClick
                        }

                    ]
		}
	);
	return p1;
			
}

function GetRepPanel() {

	dGrid=Ext.create('Ext.grid.Panel',	{ xtype: 'grid',
					itemId: 'rep_grid',
					autoScroll:true,
					store: store_rep,

					dockedItems: [{
					    xtype: 'toolbar',
					    items: [ {
					        iconCls: 'icon-page_add',
					        text: 'Создать отчет',
					        itemId: 'bAddRep',
					        scope: this,
					        handler: onAddClick
					    } ,
						{
					        iconCls: 'icon-page_refresh',
					        text: 'Обновить',
					        itemId: 'bRefresh',
					        scope: this,
					        handler: function(){
								reloadRep();
							}
					    } 
						]
					}], 
					columns: [
							{ text: 'Дата создания', dataIndex: 'CREATEDATE', width: 140, minWidth: 150, sortable: true, renderer:myDateRenderer},
							{ text: 'С', dataIndex: 'DFROM', width: 140, minWidth: 150, sortable: true , renderer:myDateRenderer},
							{ text: 'По', dataIndex: 'DTO', width: 140, minWidth: 150, sortable: true , renderer:myDateRenderer},
							{ text: 'Тип отчета', dataIndex: 'CTYPE', width: 120, minWidth: 100, sortable: true },
                            { text: 'Узел', dataIndex: 'NODENAME', width: 120, minWidth: 100, sortable: true },
							{ text: 'Шаблон', dataIndex: 'FILENAME', width: 120, minWidth: 100, sortable: true, renderer: trefRenderer },
                            { text: 'Готовность', dataIndex: 'REPORTREADY', width: 100, minWidth: 50, sortable: true ,renderer:OkRenderer},
							{ text: 'Файл', dataIndex: 'REPORTREADY', width: 100, minWidth: 50, sortable: true ,renderer:refRenderer},
                            { text: 'Ошибка', dataIndex: 'REPORTMSG',  minWidth: 100, sortable: true, flex:1 ,renderer:myTipRenderer}
						]
				});

    var p1 = Ext.create('Ext.panel.Panel', 
	{
            title: 'Отчеты',
			layout: 'fit',
			autoScroll:true,
			items: [
				dGrid
			]
		}
      
    );
	
	intervalID = window.setInterval(reloadRep, 60000);

    return p1;
}

function onAddTplClick() {
	if(	last_d!="" && last_p!="" 	){
		var edit = Ext.create('EditWindow_addtpl');
		edit.show();  
	}else{
			Ext.MessageBox.show({
                title:  'Ошибка',
                msg:    'Необходимо выбрать узел и тип архива!',
                buttons: Ext.MessageBox.OK,
                icon:   Ext.MessageBox.ERROR
        		});
	}
}



function onAddTplClick() {
	if(	last_d!="" && last_p!="" 	){
		var edit = Ext.create('EditWindow_addtpl');
		edit.show();  
	}else{
			Ext.MessageBox.show({
                title:  'Ошибка',
                msg:    'Необходимо выбрать узел и тип архива!',
                buttons: Ext.MessageBox.OK,
                icon:   Ext.MessageBox.ERROR
        		});
	}
}

function onExportClick() {
    var wn =last_dname +". "+last_pname;
    var config = { title: wn , columns: newcolumns };
    var workbook = new Workbook(config);
    workbook.addWorksheet(dGrid.store, config);
    var x = workbook.render();
    window.open('data:application/vnd.ms-excel;base64,' + Base64.encode(x), '_blank');
}

function onExportClick2() {
    var wn ="";
    var config = { title: wn , columns: dGrid.columns };
    var workbook = new Workbook(config);
    workbook.addWorksheet(dGrid.store, config);
    var x = workbook.render();
    window.open('data:application/vnd.ms-excel;base64,' + Base64.encode(x), '_blank');
}

function onExportPDFClick() {
    
    window.open("data_pdf.aspx?D="+last_d+"&P="+last_p+"&F="+last_f+"&T="+last_t, '_blank');
}

function onAddClick() {

   Ext.Ajax.request({
		url:    'addreport.aspx',
		method:  'POST',
		params: { 
					D: last_d, 
					P: last_p,  
					F:last_f, 
					T:last_t, 
					TPL:last_tpl, 
					U:userid
				}
				,
		 success: function(response){
			reloadRep();
		 }
	});

}

function GetG1Panel(){
	
	gPanel =Ext.create('Ext.Panel',	
	       { xtype: 'panel',
			itemId: 'p_graph',
			items:[
			{
            xtype: 'cartesian',
            width: '100%',
            height: 500,
            /*legend: {
                docked: 'top'
            },
			*/
            store: store_graph,
            insetPadding: 40,
            //interactions: 'itemhighlight',
            
            axes: [{
                type: 'numeric',
                fields: ['AP', 'AM', 'RP', 'RM' ],
                position: 'left',
                grid: true,
                minimum: -5
                
            }, {
                type: 'category',
                fields: 'P_DATE',
                position: 'bottom',
                grid: true,
                label: {
                    rotate: {
                        degrees: -45
                    }
                }
            }],
			
			
			
			/*
			
			 {
                type: 'line',
                axis: 'left',
                title: 'Firefox',
                xField: 'month',
                yField: 'data2',
                style: {
                    lineWidth: 4
                },
                marker: {
                    radius: 4
                },
                highlight: {
                    fillStyle: '#000',
                    radius: 5,
                    lineWidth: 2,
                    strokeStyle: '#fff'
                },
                tooltip: {
                    trackMouse: true,
                    style: 'background: #fff',
                    renderer: function(storeItem, item) {
                        var title = item.series.getTitle();
                        this.setHtml(title + ' for ' + storeItem.get('month') + ': ' + storeItem.get(item.series.getYField()) + '%');
                    }
                }
            }
			*/
            series: [{
                type: 'line',
                axis: 'left',
                title: 'Ap',
                xField: 'P_DATE',
                yField: 'AP',
                style: {
                    lineWidth: 4
                },
                marker: {
                    radius: 4
                },
                highlight: {
                    fillStyle: '#000',
                    radius: 5,
                    lineWidth: 2,
                    strokeStyle: '#fff'
                },
                tooltip: {
                    trackMouse: true,
                    style: 'background: #fff',
                     renderer: function(storeItem, item) {
                        var title = 'Активная +';
                        this.setHtml(title + '  ' + storeItem.get('P_DATE') + ': ' + storeItem.get(item.series.getYField()) );
                    }
                }
            }, {
                type: 'line',
                axis: 'left',
                title: 'Am',
                xField: 'P_DATE',
                yField: 'AM',
                style: {
                    lineWidth: 4
                },
                marker: {
                    radius: 4
                },
                highlight: {
                    fillStyle: '#000',
                    radius: 5,
                    lineWidth: 2,
                    strokeStyle: '#fff'
                },
                tooltip: {
                    trackMouse: true,
                    style: 'background: #fff',
					  renderer: function(storeItem, item) {
                         var title = 'Активная -';
                        this.setHtml(title + '  ' + storeItem.get('P_DATE') + ': ' + storeItem.get(item.series.getYField()) );
                    }
                }
            }, {
                type: 'line',
                axis: 'left',
                title: 'Rp',
                xField: 'P_DATE',
                yField: 'RP',
                style: {
                    lineWidth: 4
                },
                marker: {
                    radius: 4
                },
                highlight: {
                    fillStyle: '#000',
                    radius: 5,
                    lineWidth: 2,
                    strokeStyle: '#fff'
                },
                tooltip: {
                    trackMouse: true,
                    style: 'background: #fff',
					  renderer: function(storeItem, item) {
                         var title = 'Реактивная +';
                        this.setHtml(title + '  ' + storeItem.get('P_DATE') + ': ' + storeItem.get(item.series.getYField()) );
                    }
                }
            }, {
                type: 'line',
                axis: 'left',
                title: 'Rm',
                xField: 'P_DATE',
                yField: 'RM',
                style: {
                    lineWidth: 4
                },
                marker: {
                    radius: 4
                },
                highlight: {
                    fillStyle: '#000',
                    radius: 5,
                    lineWidth: 2,
                    strokeStyle: '#fff'
					 
                }
				
				,
                tooltip: {
                    trackMouse: true,
                    style: 'background: #fff',
                    renderer: function(storeItem, item) {
                       var title = 'Реактивная -';
                        this.setHtml(title + '  ' + storeItem.get('P_DATE') + ': ' + storeItem.get(item.series.getYField()) );
                    }
                }
           }]
        }]
	}
	);
	return gPanel; 
	
	
}

function GetDataPanel() {

	dGrid=Ext.create('Ext.grid.Panel',	{ xtype: 'grid',
					itemId: 'data_grid',
					autoScroll:true,
					store: store_data,

					dockedItems: [{
					    xtype: 'toolbar',
					    items: [ {
					        iconCls: 'icon-page_excel',
					        text: 'Экспорт',
					        itemId: 'bExport',
					        scope: this,
					        handler: onExportClick
					    } 
						]
					}], 

					
					columns: [
							//{ text: 'Дата опроса', dataIndex: 'DCALL', width: 80, minWidth: 70, sortable: true, locked: true },
							{ text: 'Дата архива', dataIndex: 'DCOUNTER', width: 120, minWidth: 140, sortable: true , renderer:myDateRenderer},
							{ text: 'T1', dataIndex: 'T1', width: 100, minWidth: 50, sortable: true },
                            { text: 'T2', dataIndex: 'T2', width: 100, minWidth: 50, sortable: true }
							
						
							

						]
				});

    var p1 = Ext.create('Ext.panel.Panel', 
	{
            title: 'Данные по узлу',
			layout: 'fit',
			autoScroll:true,
			items: [
				dGrid
			]
		}
      
    );

    return p1;
}




function GetEPanel() {

	dGrid=Ext.create('Ext.grid.Panel',	{ xtype: 'grid',
					itemId: 'rep_grid',
					autoScroll:true,
					store: store_grep,

					dockedItems: [{
					    xtype: 'toolbar',
					    items: [ 
						{
					        iconCls: 'icon-page_refresh',
					        text: 'Обновить',
					        itemId: 'bRefresh',
					        scope: this,
					        handler: function(){
								reloadGrep();
							}
					    } 
						]
					}], 
					columns: [
							{ text: 'Дата', dataIndex: 'P_DATE', width: 140, minWidth: 150, sortable: true, renderer:myDateRenderer},
							{ text: 'С', dataIndex: 'P_START', width: 140, minWidth: 150, sortable: true , renderer:myDateRenderer},
							{ text: 'По', dataIndex: 'P_END', width: 140, minWidth: 150, sortable: true , renderer:myDateRenderer},
							{ text: 'Ap', dataIndex: 'CODE_01', width: 120, minWidth: 100, sortable: false },
                            { text: 'Am', dataIndex: 'CODE_02', width: 120, minWidth: 100, sortable: false },
							{ text: 'Rp', dataIndex: 'CODE_03', width: 120, minWidth: 100, sortable: false },
                            { text: 'Rm', dataIndex: 'CODE_04', width: 100, minWidth: 50, sortable: false}
						]
				});

    var p1 = Ext.create('Ext.panel.Panel', 
	{
            title: 'Данные по узлу',
			layout: 'fit',
			autoScroll:true,
			items: [
				dGrid
			]
		}
      
    );
	
	intervalID = window.setInterval(reloadGrep, 60000);

    return p1;
}


menuPanel = Ext.create('Ext.panel.Panel', 
		{ region:'north', layout:'hbox', height:60 ,
			items:[
			
					{
						toggleGroup:'menu',
						xtype: 'button',
						scale: 'small',
						text: 'Статус',
		 				iconCls: 'icon-chart_bar',
						itemId: 'cmd_status',
						border: 1,
						minWidth: 200,
						style: {
							borderColor: 'cyan',
							borderStyle: 'solid'
						},
						handler: function () {
							contentPanel.removeAll();
							if(intervalID!=0){
								window.clearInterval(intervalID);
								intervalID=0;
							}
							contentPanel.add(GetStatusPanel());
							filterPanel.removeAll();
							filterPanel.setVisible(false);
							store_status.load({ params: { U: userid} });
							
						}


					},

					{
						toggleGroup:'menu',
						xtype: 'button',
						scale: 'small',
						text: 'Архив (M230)',
		 				iconCls: 'icon-page_white_zip',
						itemId: 'cmd_arch',
						border: 1,
						minWidth: 200,
						style: {
							borderColor: 'cyan',
							borderStyle: 'solid'
						},
						handler: function () {
							contentPanel.removeAll();
							if(intervalID!=0){
								window.clearInterval(intervalID);
								intervalID=0;
							}
							contentPanel.add(GetDataPanel());
							filterPanel.removeAll();
							filterPanel.add(GetDataFilter());
							filterPanel.setVisible(true);
							filterPanel.expand();
							filterPanel.setTitle('Фильтр');
							store_dev.load({ params: { U: userid} });
							
						}


					},
					
					{
						toggleGroup:'menu',
						xtype: 'button',
						scale: 'small',
						text: 'Исходные данные',
		 				iconCls: 'icon-grid',
						itemId: 'cmd_data',
						border: 1,
						minWidth: 200,
						style: {
							borderColor: 'cyan',
							borderStyle: 'solid'
						},
						handler: function () {
							contentPanel.removeAll();
							if(intervalID!=0){
								window.clearInterval(intervalID);
								intervalID=0;
							}
							contentPanel.add(GetEPanel());
							filterPanel.removeAll();
							filterPanel.add(GetEFilter());
							filterPanel.setVisible(true);
							filterPanel.expand();
							filterPanel.setTitle('Фильтр');
							store_dev.load({ params: { U: userid} });
							
						}


					},
					
					
					{	
						toggleGroup:'menu',
						xtype: 'button',
						scale: 'small',
						text: 'Графики',
						iconCls: 'icon-chart_line',
						itemId: 'cmd_g1',
						border: 1,
						minWidth: 200,
						//flex:1,
						style: {
							borderColor: 'cyan',
							borderStyle: 'solid'
						},
						handler: function () {
						    contentPanel.removeAll();
							if(intervalID!=0){
								window.clearInterval(intervalID);
								intervalID=0;
							}
							contentPanel.add(GetG1Panel());
							filterPanel.removeAll();
							filterPanel.add(GetG1Filter());
							filterPanel.setVisible(true);
							filterPanel.expand();
							filterPanel.setTitle('Фильтр');
							store_dev.load({ params: { U: userid} });
							

						}
					}
					,
					
					
					{	
						toggleGroup:'menu',
						xtype: 'button',
						scale: 'small',
						text: 'Отчет',
						iconCls: 'icon-script',
						itemId: 'cmd_rep',
						border: 1,
						minWidth: 200,
						//flex:1,
						style: {
							borderColor: 'cyan',
							borderStyle: 'solid'
						},
						handler: function () {
						    contentPanel.removeAll();
							if(intervalID!=0){
								window.clearInterval(intervalID);
								intervalID=0;
							}
							contentPanel.add(GetRepPanel());
							filterPanel.removeAll();
							filterPanel.add(GetRepFilter());
							filterPanel.setVisible(true);
							filterPanel.expand();
							filterPanel.setTitle('Фильтр');
							store_dev.load({ params: { U: userid} });
							

						}
					},
					{
						toggleGroup:'menu',
						xtype: 'button',
						scale: 'small',
						text: 'Цены',
		 				iconCls: 'icon-money',
						itemId: 'cmd_cost',
						border: 1,
						minWidth: 200,
						style: {
							borderColor: 'cyan',
							borderStyle: 'solid'
						},
						handler: function () {
							contentPanel.removeAll();
							if(intervalID!=0){
								window.clearInterval(intervalID);
								intervalID=0;
							}
							
							contentPanel.add(GetCostsPanel());
							filterPanel.removeAll();
							filterPanel.add(GetCostFilter());
							filterPanel.setVisible(true);
							filterPanel.expand();
							filterPanel.setTitle('Фильтр');
							store_dev.load({ params: { U: userid} });
							store_costs.load({ params: { U: userid,Y:last_y,M:last_m} });
							
						}


					}
					,
					{
						toggleGroup:'menu',
						xtype: 'button',
						scale: 'small',
						text: 'Цены по объекту',
		 				iconCls: 'icon-money',
						itemId: 'cmd_cost2',
						border: 1,
						minWidth: 200,
						style: {
							borderColor: 'cyan',
							borderStyle: 'solid'
						},
						handler: function () {
							contentPanel.removeAll();
							if(intervalID!=0){
								window.clearInterval(intervalID);
								intervalID=0;
							}
							
							contentPanel.add(GetCostsPanel2());
							filterPanel.removeAll();
							filterPanel.add(GetCostFilter2());
							filterPanel.setVisible(true);
							filterPanel.expand();
							filterPanel.setTitle('Фильтр');
							store_dev.load({ params: { U: userid} });
							store_costs2.load({ params: { U: userid,Y:last_y,M:last_m} });
							
						}


					}
					
				]
			} 
		);

contentPanel=Ext.create('Ext.panel.Panel', { region:'center', layout:'fit' } );

filterPanel=Ext.create('Ext.panel.Panel', { hidden:true, title:'Регистрация', region:'north', layout:'fit' , // width: 180,  //west
	            collapsible: true,
                collapsed:false,
				autoScroll:true,
             	titleCollapse :true,
				border:true} 
				);


Ext.define('status_model', {
    extend: 'Ext.data.Model',
    fields: [
	{ name: 'SENDERNAME', type: 'string' },
	{ name: 'CODE', type: 'string' },
	{ name: 'NAME', type: 'string' },
	{ name: 'COLOR', type: 'string' },
	{ name: 'APLUS', type: 'string' },
	{ name: 'PRC', type: 'string' },
    { name: 'NODE_ID', type: 'number' }
],
    idProperty: 'ID_BD'
});

				
				
var store_status = Ext.create('Ext.data.Store', {
	model: 'status_model',
	autoLoad: false,
	autoSync: false,
	proxy: {
		type: 'ajax',
		url: 'status.aspx',
		reader: {
			type: 'json'
		, root: 'data'
		, successProperty: 'success'
		, messageProperty: 'msg'
		},
		listeners: {
			exception: function (proxy, response, operation) {
			    /*
			    Ext.MessageBox.show({
			    title: 'REMOTE EXCEPTION',
			    msg: operation.getError(),
			    icon: Ext.MessageBox.ERROR,
			    buttons: Ext.Msg.OK
			    });
			    */
			}
		}
	}
});



function reloadStatus(){
	store_status.load({ params: { U: userid} });
}


var store_costs = Ext.create('Ext.data.Store', {
	model: 'cost_model',
	autoLoad: false,
	autoSync: false,
	proxy: {
		type: 'ajax',
		url: 'costs.aspx',
		reader: {
			type: 'json'
		, root: 'data'
		, successProperty: 'success'
		, messageProperty: 'msg'
		},
		listeners: {
			exception: function (proxy, response, operation) {
			    /*
			    Ext.MessageBox.show({
			    title: 'REMOTE EXCEPTION',
			    msg: operation.getError(),
			    icon: Ext.MessageBox.ERROR,
			    buttons: Ext.Msg.OK
			    });
			    */
			}
		}
	}
});

var store_costs2 = Ext.create('Ext.data.Store', {
	model: 'cost_model',
	autoLoad: false,
	autoSync: false,
	proxy: {
		type: 'ajax',
		url: 'costs2.aspx',
		reader: {
			type: 'json'
		, root: 'data'
		, successProperty: 'success'
		, messageProperty: 'msg'
		},
		listeners: {
			exception: function (proxy, response, operation) {
			    /*
			    Ext.MessageBox.show({
			    title: 'REMOTE EXCEPTION',
			    msg: operation.getError(),
			    icon: Ext.MessageBox.ERROR,
			    buttons: Ext.Msg.OK
			    });
			    */
			}
		}
	}
});

function reloadCosts(){
	store_costs.load({ params: {  Y:last_y, M: last_m} });
}

function reloadCosts2(){
	store_costs2.load({ params: {  Y:last_y, M: last_m} });
}
				
function GetStatusPanel() {

    sGrid = Ext.create('Ext.grid.Panel', { xtype: 'grid',
        itemId: 'rep_grid',
        autoScroll: true,
        store: store_status,

        dockedItems: [{
            xtype: 'toolbar',
            items: [
						    {
						        iconCls: 'icon-page_refresh',
						        text: 'Обновить',
						        itemId: 'bRefresh',
						        scope: this,
						        handler: function () {
						            reloadStatus();
						        }
						    }
						]
        }],
        columns: [

    	                    { text: 'Филиал', dataIndex: 'SENDERNAME', width: 120, minWidth: 50, sortable: true, renderer: myColorRenderer },
							{ text: 'Код', dataIndex: 'CODE', width: 200, minWidth: 50, sortable: true, renderer: myColorRenderer },
							{ text: 'Узел', dataIndex: 'NAME', width: 200, minWidth: 50, sortable: true, renderer: myColorRenderer },
							{ text: '% к пред. неделе', dataIndex: 'PRC', minWidth: 90, flex: 1, sortable: true, renderer: myColorRenderer },
                            { text: 'Потребление', dataIndex: 'APLUS', minWidth: 50, flex: 1, sortable: true, renderer: myColorRenderer }

						]
    });

    var p1 = Ext.create('Ext.panel.Panel',
				{
				    title: 'Статус',
				    layout: 'fit',
				    autoScroll: true,
				    items: [
						sGrid
					]
				}

			);

    intervalID = window.setInterval(reloadStatus, 60000);

    return p1;
}

	

function GetCostsPanel() {

    dGrid = Ext.create('Ext.grid.Panel', { xtype: 'grid',
        itemId: 'cost_grid',
        autoScroll: true,
        store: store_costs,

        dockedItems: [{
            xtype: 'toolbar',
            items: [
						    {
						        iconCls: 'icon-page_refresh',
						        text: 'Обновить',
						        itemId: 'bRefresh',
						        scope: this,
						        handler: function () {
						            reloadCosts();
						        }
						    }, 
							{
					        iconCls: 'icon-page_excel',
					        text: 'Экспорт',
					        itemId: 'bExport',
					        scope: this,
					        handler: onExportClick2
					    } 
						]
        }],
        columns: [

    	                    { text: 'Филиал', dataIndex: 'SENDER_NAME', width: 120, minWidth: 50, sortable: true ,renderer:myTipRenderer},
							{ text: 'Код', dataIndex: 'CODE', width: 100, minWidth: 50, sortable: true,renderer:myTipRenderer},
							{ text: 'Узел', dataIndex: 'NAME', width: 250, minWidth: 50, sortable: true,renderer:myTipRenderer},
							{ text: 'У.Н.', dataIndex: 'POWER_QUALITY', minWidth: 90, flex: 1, sortable: true,renderer:myTipRenderer},
                            { text: 'Р.М. от', dataIndex: 'POWERLEVEL_MIN', minWidth: 50, flex: 1, sortable: true,renderer:myTipRenderer },
							{ text: 'Р.М. до', dataIndex: 'POWERLEVEL_MAX', minWidth: 50, flex: 1, sortable: true,renderer:myTipRenderer },
							{ text: 'Год', dataIndex: 'THEYEAR', minWidth: 50, flex: 1, sortable: false ,renderer:myTipRenderer},
							{ text: 'Месяц', dataIndex: 'THEMONTH', minWidth: 50, flex: 1, sortable: false,renderer:myTipRenderer },
							{ text: 'Оптимальная<br/>категория', dataIndex: 'OPTIMAL', minWidth: 100, flex: 1, sortable: true ,renderer:myTipRenderer},
							{ text: 'I', dataIndex: 'I', minWidth: 50, flex: 1, sortable: false ,renderer:myTipRenderer},
							{ text: 'II', dataIndex: 'II', minWidth: 50, flex: 1, sortable: false ,renderer:myTipRenderer},
							{ text: 'III', dataIndex: 'III', minWidth: 50, flex: 1, sortable: false,renderer:myTipRenderer },
							{ text: 'IV', dataIndex: 'IV', minWidth: 50, flex: 1, sortable: false ,renderer:myTipRenderer},
							{ text: 'V', dataIndex: 'V', minWidth: 50, flex: 1, sortable: false ,renderer:myTipRenderer},
							{ text: 'VI', dataIndex: 'VI', minWidth: 50, flex: 1, sortable: false ,renderer:myTipRenderer}
						
							

						]
    });

    var p1 = Ext.create('Ext.panel.Panel',
				{
				    title: 'Варианты расчета стоимости',
				    layout: 'fit',
				    autoScroll: true,
				    items: [
						dGrid
					]
				}

			);

    intervalID = window.setInterval(reloadStatus, 60000);

    return p1;
}	
	

function GetCostsPanel2() {

    dGrid = Ext.create('Ext.grid.Panel', { xtype: 'grid',
        itemId: 'cost_grid',
        autoScroll: true,
        store: store_costs2,

        dockedItems: [{
            xtype: 'toolbar',
            items: [
						    {
						        iconCls: 'icon-page_refresh',
						        text: 'Обновить',
						        itemId: 'bRefresh',
						        scope: this,
						        handler: function () {
						            reloadCosts();
						        }
						    }, 
							{
					        iconCls: 'icon-page_excel',
					        text: 'Экспорт',
					        itemId: 'bExport',
					        scope: this,
					        handler: onExportClick2
					    } 
						]
        }],
        columns: [

    	                    { text: 'Филиал', dataIndex: 'SENDER_NAME', width: 120, minWidth: 50, sortable: true ,renderer:myTipRenderer},
							{ text: 'Код', dataIndex: 'CODE', width: 100, minWidth: 50, sortable: true,renderer:myTipRenderer},
							//{ text: 'Узел', dataIndex: 'NAME', width: 250, minWidth: 50, sortable: true,renderer:myTipRenderer},
							{ text: 'У.Н.', dataIndex: 'POWER_QUALITY', minWidth: 90, flex: 1, sortable: true,renderer:myTipRenderer},
                            { text: 'Р.М. от', dataIndex: 'POWERLEVEL_MIN', minWidth: 50, flex: 1, sortable: true,renderer:myTipRenderer },
							{ text: 'Р.М. до', dataIndex: 'POWERLEVEL_MAX', minWidth: 50, flex: 1, sortable: true,renderer:myTipRenderer },
							{ text: 'Год', dataIndex: 'THEYEAR', minWidth: 50, flex: 1, sortable: false ,renderer:myTipRenderer},
							{ text: 'Месяц', dataIndex: 'THEMONTH', minWidth: 50, flex: 1, sortable: false,renderer:myTipRenderer },
							//{ text: 'Оптимальная<br/>категория', dataIndex: 'OPTIMAL', minWidth: 100, flex: 1, sortable: true ,renderer:myTipRenderer},
							{ text: 'I', dataIndex: 'I', minWidth: 50, flex: 1, sortable: false ,renderer:myTipRenderer},
							{ text: 'II', dataIndex: 'II', minWidth: 50, flex: 1, sortable: false ,renderer:myTipRenderer},
							{ text: 'III', dataIndex: 'III', minWidth: 50, flex: 1, sortable: false,renderer:myTipRenderer },
							{ text: 'IV', dataIndex: 'IV', minWidth: 50, flex: 1, sortable: false ,renderer:myTipRenderer},
							{ text: 'V', dataIndex: 'V', minWidth: 50, flex: 1, sortable: false ,renderer:myTipRenderer},
							{ text: 'VI', dataIndex: 'VI', minWidth: 50, flex: 1, sortable: false ,renderer:myTipRenderer}
						
							

						]
    });

    var p1 = Ext.create('Ext.panel.Panel',
				{
				    title: 'Варианты расчета стоимости',
				    layout: 'fit',
				    autoScroll: true,
				    items: [
						dGrid
					]
				}

			);

    intervalID = window.setInterval(reloadStatus, 60000);

    return p1;
}		

function OnLogin(){
	contentPanel.removeAll();
	if (intervalID != 0) {
		window.clearInterval(intervalID);
		intervalID = 0;
	}
	menuPanel.setVisible(true);
	filterPanel.removeAll();
	filterPanel.setVisible(false);
    


}


Ext.application(
 {
     name: 'MyApp',

     launch: function () {
         var vPort = new Ext.container.Viewport(

	    {
	        renderTo: Ext.getBody(),
	        layout: 'border',
	        items: [
			menuPanel,
            filterPanel,
			contentPanel
		]

	    }
		);

		menuPanel.setVisible(false);
	    filterPanel.removeAll();
	    filterPanel.add(GetLogin());
	    filterPanel.setVisible(true);
	    filterPanel.expand();
        

     }
 }
);