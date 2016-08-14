var UserPoolGateway = {

    userSignUp: function (email, password, success, failure) {
        var attributeEmail = new AWSCognito.CognitoIdentityServiceProvider.CognitoUserAttribute({
            Name: 'email',
            Value: email
        });
        UserPool.signUp(email, password, [attributeEmail], null, function (err, result) {
            return err ? failure(err) : success(result.user);
        });
    },

    confirmUser: function (email, code, success, failure) {
        new AWSCognito.CognitoIdentityServiceProvider.CognitoUser({
            Username: email,
            Pool: UserPool
        }).confirmRegistration(code, true, function (err, result) {
                return err ? failure(err) : success(result);
            });
    },


    resendConfirmationCode: function (email, success, failure) {
        new AWSCognito.CognitoIdentityServiceProvider.CognitoUser({
            Username: email,
            Pool: UserPool
        }).resendConfirmationCode(function (err, result) {
                return err ? failure(err) : success(result);
            });
    },


    userLogin: function (email, password, success, failure) {
        var authenticationDetails = new AWSCognito.CognitoIdentityServiceProvider.AuthenticationDetails({
            Username: email,
            Password: password
        });
        new AWSCognito.CognitoIdentityServiceProvider.CognitoUser({
            Username: email,
            Pool: UserPool
        }).authenticateUser(authenticationDetails, {
                onSuccess: function (result) {
                    updateLogin(result.getIdToken().getJwtToken());
                    success(result.getIdToken().getJwtToken());
                },
                onFailure: function (err) {
                    failure(err);
                }
            });
    },

    changePassword: function (email, oldPassword, newPassword, success, failure) {
        new AWSCognito.CognitoIdentityServiceProvider.CognitoUser({
            Username: email,
            Pool: UserPool
        }).changePassword(oldPassword, newPassword, function (err, result) {
                return err ? failure(err) : success(result.user());
            });
    },

    forgotPassword: function (email, success, failure) {
        var cognitoUser = new AWSCognito.CognitoIdentityServiceProvider.CognitoUser({
            Username: email,
            Pool: UserPool
        });
        cognitoUser.forgotPassword({
            onSuccess: function (result) {
                success(result);
            },
            onFailure: function (err) {
                failure(err);
            },
            inputVerificationCode: function () {
                var verificationCode = prompt('Please input verification code ', '');
                var newPassword = prompt('Enter new password ', '');
                cognitoUser.confirmPassword(verificationCode, newPassword, this);
            }
        });
    },

    getCurrentUser: function () {
        return UserPool.getCurrentUser();
    },

    getCurrentUserSession: function (success, failure) {
        var cognitoUser = getCurrentUser();
        if (!cognitoUser) {
            return failure("Please Login");
        }
        cognitoUser.getSession(function (err, session) {
            return err ? failure(err) : success(session);
        });

    },

    signOut: function () {
        getCurrentUser.signOut();
    },

    openOrCreateDataset: function (dataSetName, success, failure) {
        AWS.config.credentials.get(function () {
            new AWS.CognitoSyncManager().openOrCreateDataset(dataSetName, function (err, dataset) {
                return err ? failure(err) : success(dataset);
            });
        });
    },

    readRecord: function (dataSetName, recordName, success, failure) {
        AWS.config.credentials.get(function () {
            new AWS.CognitoSyncManager().openOrCreateDataset(dataSetName, function (err, dataset) {
                if (err) {
                    return failure(err);
                }
                dataset.get(recordName, function (err, value) {
                    return err ? failure(err) : success(value);
                });
            });
        });
    },

    writeRecord: function (dataSetName, newRecord, newValue, success, failure) {
        AWS.config.credentials.get(function () {
            new AWS.CognitoSyncManager().openOrCreateDataset(dataSetName, function (err, dataset) {
                if (err) {
                    return failure(err);
                }
                dataset.put(newRecord, newValue, function (err, record) {
                    return err ? failure(err) : success(record);
                });
            });
        });
    },

    deleteRecord: function (dataSetName, recordName, success, failure) {
        AWS.config.credentials.get(function () {
            new AWS.CognitoSyncManager().openOrCreateDataset(dataSetName, function (err, dataset) {
                if (err) {
                    return failure(err);
                }
                dataset.remove(recordName, function (err, record) {
                    return err ? failure(err) : success(record);
                });
            });
        });
    }

};

var updateLogin = function (token) {
    var credentials = {};
    var url = 'cognito-idp.' + config.region + '.amazonaws.com/' + config.userPoolId;
    credentials['Logins'] = {};
    credentials['Logins'][url] = token;
    credentials['IdentityPoolId'] = config.identityPoolId;
    AWSCognito.config.update({
        credentials: new AWS.CognitoIdentityCredentials(credentials)
    });
};