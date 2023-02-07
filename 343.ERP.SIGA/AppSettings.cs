using System;
namespace _343.ERP.SIGA
{
	public class AppSettings
	{
		private static string DatabasenName = "database.db";
		private static string DatabaseDirectory = FileSystem.AppDataDirectory;
		public static string DatabasePath = Path.Combine(DatabaseDirectory, DatabasenName);
	}
}

