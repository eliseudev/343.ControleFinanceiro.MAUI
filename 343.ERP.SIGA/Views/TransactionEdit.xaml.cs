namespace _343.ERP.SIGA.Views;

public partial class TransactionEdit : ContentPage
{
	public TransactionEdit()
	{
		InitializeComponent();
	}

	private void Voltar(object sender, TappedEventArgs e)
	{
		Navigation.PopModalAsync();
	}
}
