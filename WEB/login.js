var logged = false;
var login = null;
var userid = 0;

function doLogin()
{
		var form=login.getForm();
		if (!form.isValid()) {
            return;
        }
        form.submit({
            method: 'POST',
            waitTitle: 'Соединение',
            waitMsg: 'Отсылка данных...',

            success: function (form, action) {

                var data = Ext.JSON.decode(action.response.responseText);
                logged = true;
                userid = data.data[0].USERSID;
                OnLogin();
            },

            failure: function (form, action) {
                if (action.failureType == 'server') {
                    Ext.Msg.alert('Ошибка авторизации!', 'Неверный пароль или такой пользователь не найден.');
                } else {
                    Ext.Msg.alert('Внимание!', 'Сервер недоступен : ' + action.response.responseText);
                }
                logged = false;
            }
        });
    
}


function GetLogin() {
    login = new Ext.FormPanel({
        labelWidth: 80,
        url: 'login.aspx',
        frame: true,
        height: '100%',
        title: '',
        defaultType: 'textfield',
        monitorValid: true,
        // Specific attributes for the text fields for username / password.
        // The "name" attribute defines the name of variables sent to the server.
        items: [
        {
            fieldLabel: 'Пользователь',
            name: 'U',
            allowBlank: false,
            value: ''
			, listeners: {
			    specialkey: function (field, e) {
			        if (e.getKey() == e.ENTER) {
			            doLogin();
			        }
			    }
			}
        },
        {
            fieldLabel: 'Пароль',
            name: 'P',
            inputType: 'password',
            allowBlank: false,
            value: ''
			, listeners: {
			    specialkey: function (field, e) {
			        if (e.getKey() == e.ENTER) {
			            doLogin();
			        }
			    }
			}
        }
    ],
        // All the magic happens after the user clicks the button
        buttons: [
        {
            text: 'Login',
            iconCls: 'icon-key_go',
            formBind: true,
            // Function that fires when user clicks the button
            handler: doLogin
        }
    ]



    });

    return login;
}



  
