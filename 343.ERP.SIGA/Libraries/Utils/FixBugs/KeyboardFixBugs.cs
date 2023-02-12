using System;
using Microsoft.Maui.Platform;

namespace _343.ERP.SIGA.Libraries.Utils.FixBugs
{
	public class KeyboardFixBugs
	{
		public static void HideKeyboard()
		{
#if ANDROID
			if (Platform.CurrentActivity.CurrentFocus != null)
				Platform.CurrentActivity.HideKeyboard(Platform.CurrentActivity.CurrentFocus);
#endif
		}
	}
}

