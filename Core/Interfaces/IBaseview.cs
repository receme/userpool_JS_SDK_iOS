using System;
namespace Core
{
	public interface IBaseview
	{
		void ShowAlert (string message);
		void ShowProgressView (string message = "Please wait...");
		void HideProgressView ();
	}
}

