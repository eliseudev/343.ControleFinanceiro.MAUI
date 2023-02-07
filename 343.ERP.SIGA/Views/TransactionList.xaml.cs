namespace _343.ERP.SIGA.Views;

public partial class TransactionList : ContentPage
{
    private TransactionAdd _transactionAdd;
    private TransactionEdit _transactionEdit;

	public TransactionList(TransactionAdd transactionAdd, TransactionEdit transactionEdit)
	{
        _transactionAdd = transactionAdd;
        _transactionEdit = transactionEdit;
		InitializeComponent();
	}

    private void AdicionarTransacao(object sender, EventArgs args)
    {
        Navigation.PushModalAsync(_transactionAdd);
    }

    private void EditarTransacao(object sender, EventArgs args)
    {
        Navigation.PushModalAsync(_transactionEdit);
    }
}
