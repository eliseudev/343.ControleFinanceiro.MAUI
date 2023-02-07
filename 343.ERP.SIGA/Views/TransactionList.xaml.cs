using _343.ERP.SIGA.Repositories;

namespace _343.ERP.SIGA.Views;

public partial class TransactionList : ContentPage
{
    private ITransactionRepository _transactionRepository;

	public TransactionList(ITransactionRepository transactionRepository)
	{
        _transactionRepository = transactionRepository;
		InitializeComponent();

        CollectionViewTransactions.ItemsSource = _transactionRepository.GetAll();
        Reload();
	}

    private void Reload()
    {
        var items = _transactionRepository.GetAll();

        double income = items.Where(a => a.Type == Models.TransactionType.Income).Sum(a => a.Value);
        double expense = items.Where(a => a.Type == Models.TransactionType.Expenses).Sum(a => a.Value);
        double balance = income - expense;

        LabelIncome.Text = income.ToString("C");
        LabelExpense.Text = expense.ToString("C");
        LabelBalance.Text = balance.ToString("C");
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
