using _343.ERP.SIGA.Repositories;

namespace _343.ERP.SIGA.Views;

public partial class TransactionList : ContentPage
{
    private ITransactionRepository _transactionRepository;

	public TransactionList(ITransactionRepository transactionRepository)
	{
        _transactionRepository = transactionRepository;
		InitializeComponent();

        CollectionTransaction.ItemsSource = _transactionRepository.GetAll();
	}

    private void AdicionarTransacao(object sender, EventArgs args)
    {
        var transaction = Handler.MauiContext.Services.GetService<TransactionAdd>();
        Navigation.PushModalAsync(transaction);
    }

    private void EditarTransacao(object sender, EventArgs args)
    {
        var transaction = Handler.MauiContext.Services.GetService<TransactionEdit>();
        Navigation.PushModalAsync(transaction);
    }
}
