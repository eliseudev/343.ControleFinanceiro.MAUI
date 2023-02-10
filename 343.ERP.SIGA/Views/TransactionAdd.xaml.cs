using System.Text;
using _343.ERP.SIGA.Models;
using _343.ERP.SIGA.Repositories;
using CommunityToolkit.Mvvm.Messaging;

namespace _343.ERP.SIGA.Views;

public partial class TransactionAdd : ContentPage
{
    private ITransactionRepository _transactionRepository;

	public TransactionAdd(ITransactionRepository transactionRepository)
	{
        _transactionRepository = transactionRepository;
		InitializeComponent();
	}

    private void Voltar(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
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
            Nome = EntryName.Text,
            Type = RadioIncome.IsChecked == true ? TransactionType.Income : TransactionType.Expenses,
            Date = DatePikerDate.Date,
            Value = double.Parse(EnttyValue.Text)
        };

        _transactionRepository.Add(transaction);
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

        if(string.IsNullOrWhiteSpace(EnttyValue.Text) || string.IsNullOrWhiteSpace(EnttyValue.Text))
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
