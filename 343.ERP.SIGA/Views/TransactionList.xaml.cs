using _343.ERP.SIGA.Repositories;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Controls;
using _343.ERP.SIGA.Models;

namespace _343.ERP.SIGA.Views;

public partial class TransactionList : ContentPage
{
    private ITransactionRepository _transactionRepository;

	public TransactionList(ITransactionRepository transactionRepository)
	{
        _transactionRepository = transactionRepository;
		InitializeComponent();

        ReloadGetAll();
        ReloadGrid();
        WeakReferenceMessenger.Default.Register<string>(this, (e, msg) =>
        {
            ReloadGetAll();
        });

    }

    private void ReloadGetAll()
    {
        CollectionViewTransactions.ItemsSource = _transactionRepository.GetAll();
    }

    private void ReloadGrid()
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

    void EditarDespesa(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        //Capturando gesto
        var grid = (Grid)sender;
        var gesture = (TapGestureRecognizer)grid.GestureRecognizers[0];
        Transaction transaction = (Transaction)gesture.CommandParameter;

        var transactionEdit = Handler.MauiContext.Services.GetService<TransactionEdit>();
        //Enviando dados selecionado para view de edição
        transactionEdit.DadosTransacao(transaction);
        Navigation.PushModalAsync(transactionEdit);
    }

}
