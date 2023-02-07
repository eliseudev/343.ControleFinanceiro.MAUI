namespace _343.ERP.SIGA.Views;

public partial class TransactionList : ContentPage
{
	public TransactionList()
	{
		InitializeComponent();
	}

    private void AdicionarTransacao(object sender, EventArgs args)
    {
        Navigation.PushModalAsync(new TransactionAdd());
    }

    private void EditarTransacao(object sender, EventArgs args)
    {
        Navigation.PushModalAsync(new TransactionEdit());
    }
}
