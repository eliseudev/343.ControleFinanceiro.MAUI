using _343.ERP.SIGA.Views;

namespace _343.ERP.SIGA;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new TransactionList());
	}
}

