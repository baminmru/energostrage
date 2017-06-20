
Ext.require([
'Ext.form.*'
]);





Ext.define('Form_addtpl', {
extend:  'Ext.form.Panel',
alias: 'widget.f_addtpl',
initComponent: function(){
      Ext.apply(this,{
        items: [
				{
						minWidth: 740,
						width: 740,
						maxWidth: 740,
						x: 5, 
						y: 0, 

						xtype:  'filefield',
						name:   'theref_fu',
						itemId:   'theref_fu',
						fieldLabel:  'Файл',
						buttonText:"Выбрать",
						buttonConfig: {
									iconCls:'icon-iu_upload'
								},
						allowBlank:true
						,labelWidth: 120
				}

       ], 
	   width: 760,
       height: 120 ,
        dockedItems: [{
            xtype:  'toolbar',
            dock:   'bottom',
            ui:     'footer',
                items: ['->', {
                    iconCls:  'icon-accept',
                    itemId:  'save',
                    text:   'Сохранить',
                    disabled: false,
                    scope:  this,
                    handler : this.onSave
                }
               , {
                    iconCls:  'icon-cancel',
                    text:   'Закрыть',
                    scope:  this,
                    handler : this.onReset
                }
              ]
            }] // dockedItems
        }); //Ext.apply
        this.callParent();
    }, //initComponent 
   
    onSave: function(){
         form = this.getForm();
        if (form.isValid()) {
           form.submit({
               url: 'addtemplate.aspx',
                        params: { 
                            D: last_d, 
                            P: last_p 
                        },
                        waitMsg: 'Загрузка ...',
                        success: function(fp, o) {
                            Ext.MessageBox.show({
								title:  'Успешно',
								msg:    'Файл шаблона загружен',
								buttons: Ext.MessageBox.OK,
								icon:   Ext.MessageBox.INFO
								});
                      
                            form.owner.ownerCt.close();
							reloadTpl();
                        }
                    });
			
			
        }else{
        		Ext.MessageBox.show({
                title:  'Ошибка',
                msg:    'Не все обязательные поля заполнены!',
                buttons: Ext.MessageBox.OK,
                icon:   Ext.MessageBox.ERROR
        		});
        }
    },
    onReset: function(){
       
        this.ownerCt.close();
    }
}); // 'Ext.Define

Ext.define('EditWindow_addtpl', {
    extend:  'Ext.window.Window',
    maxHeight: 634,
    maxWidth: 900,
    autoScroll:true,
    minWidth: 750,
    width: 800,
    minHeight:160,
    height:200,
    constrainHeader :true,
    layout:  'absolute',
    autoShow: true,
    modal: true,
    closable: false,
    closeAction: 'destroy',
    iconCls:  'icon-application_form',
    title:  'Новый шаблон',
    items:[{
        xtype:  'f_addtpl'
	}]
	});
