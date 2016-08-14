(function init() {
    AWSCognito.config.update({
        region: config.region,
        credentials: new AWS.CognitoIdentityCredentials({
            IdentityPoolId: config.identityPoolId
        }),
        accessKeyId: 'placeholder',
        secretAccessKey: 'placeholder'
    });
    UserPool = new AWSCognito.CognitoIdentityServiceProvider.CognitoUserPool({
        UserPoolId: config.userPoolId,
        ClientId: config.clientId
    });
    console.log = function (msg) {
        Mt.API.info(msg);
    };
})();