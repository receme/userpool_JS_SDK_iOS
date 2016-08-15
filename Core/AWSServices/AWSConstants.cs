using System;
namespace Core
{
	public class AWSConstants
	{
		public const string IDENTITY_POOL_ID = "us-east-1:98fb4e4b-c96d-4f5f-9917-13e6bb250e54";
		public const string REGION = "us-west-2";
		public const string USER_POOL_ID = "us-west-2_Og3WVNHh7";

		//user pool
		public const string USER_POOL_PROVIDER = "cognito-idp." + REGION + ".amazonaws.com/" + USER_POOL_ID;
	}
}

