var Client = {

    signUp: function (email, password, successEvt, failureEvt) {
        UserPoolGateway.userSignUp(email, password,
            function onSuccess(result) {
                callback(result, successEvt);
            },
            function onFailure(errMsg) {
                callback(errMsg, failureEvt);
            })
    },
    confirmRegistration: function (email, code, successEvt, failureEvt) {
        UserPoolGateway.confirmUser(email, code,
            function onSuccess(result) {
                callback(result, successEvt)
            },
            function onFailure(errMsg) {
                callback(errMsg, failureEvt);
            })

    },
    resendConfirmationCode: function (email, successEvt, failureEvt) {
        UserPoolGateway.resendConfirmationCode(email,
            function onSuccess(result) {
                callback(result, successEvt);
            },
            function onFailure(errMsg) {
                callback(errMsg, failureEvt);
            })
    },
    authenticateUser: function (email, password, successEvt, failureEvt) {
        UserPoolGateway.userLogin(
            email,
            password,
            function onSuccess(result) {
                callback(result, successEvt);
            },
            function onFailure(errMsg) {
                callback(errMsg, failureEvt);
            })
    },
    changePassword: function (email, oldP, newP, successEvt, failureEvt) {
        UserPoolGateway.changePassword(email, oldP, newP,
            function onSuccess(result) {
                callback(result, successEvt);
            },
            function onFailure(errMsg) {
                callback(errMsg, failureEvt);
            })
    },
    forgotPassword: function (email, successEvt, failureEvt) {
        UserPoolGateway.forgotPassword(
            email,
            function onSuccess(result) {
                callback(result, successEvt);
            },
            function onFailure(errMsg) {
                callback(errMsg, failureEvt);
            })
    }

};


var callback = function (data, evt) {
    console.log("Firing " + evt + " event");
    console.log("With data : " + data);
    fireEvent(data, evt);
};


var fireEvent = function (data, evt) {
    Mt.App.fireEvent(evt, {
        data: data
    });
    console.log(evt + " fired");
};


