using System.Text;
using _343.ERP.SIGA.Models;
using _343.ERP.SIGA.Repositories;
using CommunityToolkit.Mvvm.Messaging;

namespace _343.ERP.SIGA.Views;

public partial class TransactionEdit : ContentPage
{
    private ITransactionRepository _repository;

    private Transaction _transaction;

	public TransactionEdit(ITransactionRepository repository)
	{
        _repository = repository;
		InitializeComponent();
	}

	private void Voltar(object sender, TappedEventArgs e)
	{
		Navigation.PopModalAsync();
	}

	public void DadosTransacao(Transaction transaction)
	{
		_transaction = transaction;

		if (transaction.Type == TransactionType.Income)
			RadioIncome.IsChecked = true;
		else
			RadioExpense.IsChecked = true;

		EntryName.Text = _transaction.Nome;
		DatePikerDate.Date = _transaction.Date.Date;
		EnttyValue.Text = _transaction.Value.ToString();
	}

    void Button_Save(System.Object sender, System.EventArgs e)
    {
        if (ValidarDados() == false) return;

        SaveTransactionInDataBase();

        Navigation.PopModalAsync();

        EntryName.IsEnabled = false;
        EnttyValue.IsEnabled = false;

        WeakReferenceMessenger.Default.Send<string>(string.Empty);
    }

    private void SaveTransactionInDataBase()
    {
        Transaction transaction = new Transaction
        {
            Id = _transaction.Id,
            Nome = EntryName.Text,
            Type = RadioIncome.IsChecked == true ? TransactionType.Income : TransactionType.Expenses,
            Date = DatePikerDate.Date,
            Value = double.Parse(EnttyValue.Text)
        };

        _repository.Update(transaction);
    }

    private bool ValidarDados()
    {
        bool valid = true;
        double result;
        StringBuilder sb = new StringBuilder();

        if (string.IsNullOrEmpty(EntryName.Text) || string.IsNullOrWhiteSpace(EntryName.Text))
        {
            sb.AppendLine("O campo 'Nome' deve ser preenhido!");
            valid = false;
        }

        if (string.IsNullOrWhiteSpace(EnttyValue.Text) || string.IsNullOrWhiteSpace(EnttyValue.Text))
        {
            sb.AppendLine("O campo 'Valor' deve ser preenchido");
            valid = false;
        }

        if (!string.IsNullOrEmpty(EnttyValue.Text) && !double.TryParse(EnttyValue.Text, out result))
        {
            sb.AppendLine("O campo 'Valor' é inválido");
            valid = false;
        }

        if (valid == false)
        {
            LabelError.IsVisible = true;
            LabelError.Text = sb.ToString();
        }

        return valid;
    }
}
