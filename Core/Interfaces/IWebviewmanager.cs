using System;
namespace Core
{
	public interface IWebviewmanager
	{
		void Signup (string email, string password, string onSuccess, string onFailure);
		void ConfirmRegistration (string email, string code, string onSuccess, string onFailure);
		void RecentConfirmationCode (string email, string onSuccess, string onFailure);
		void AuthenticateUser (string email, string password, string onSuccess, string onFailure);
		void ChangePassword (string email, string oldPassword, string newPassword, string onSuccess, string onFailure);
		void ForgotPassword (string email, string onSuccess, string onFailure);
	}
}

