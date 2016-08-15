using System;
namespace Core
{
	public class AWSConstants
	{
		public const string IDENTITY_POOL_ID = "<Your identity pool>";
		public const string REGION = "<Region you have choosen>";
		public const string USER_POOL_ID = "<Your user pool id>";

		//user pool
		public const string USER_POOL_PROVIDER = "cognito-idp." + REGION + ".amazonaws.com/" + USER_POOL_ID;
	}
}

