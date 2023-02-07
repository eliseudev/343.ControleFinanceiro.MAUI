using _343.ERP.SIGA.Views;

namespace _343.ERP.SIGA;

public partial class App : Application
{
	public App(TransactionList listPage)
	{
		InitializeComponent();

		MainPage = new NavigationPage(listPage);
	}
}

