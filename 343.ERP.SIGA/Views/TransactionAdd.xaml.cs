using System.Text;
using _343.ERP.SIGA.Models;

namespace _343.ERP.SIGA.Views;

public partial class TransactionAdd : ContentPage
{
	public TransactionAdd()
	{
		InitializeComponent();
	}

    private void Voltar(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }

    void Button_Save(System.Object sender, System.EventArgs e)
    {
        if (ValidarDados() == false) return;

        Transaction transaction = new Transaction
        {
            Nome = EntryName.Text,
            Type = RadioIncome.IsChecked == true ? TransactionType.Income : TransactionType.Expenses,
            Date = DatePikerDate.Date,
            Value = double.Parse(EnttyValue.Text)
        };


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

        if (string.IsNullOrEmpty(EnttyValue.Text) && !double.TryParse(EnttyValue.Text, out result))
        {
            sb.AppendLine("O ampo 'Valor' é inválido");
            valid = false;
        }

        if (valid == false) LabelError.Text = sb.ToString();

        return valid;
    }
}
