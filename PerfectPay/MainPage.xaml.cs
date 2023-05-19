namespace PerfectPay;

public partial class MainPage : ContentPage
{
	decimal bill = 0;
	int tipRate = 0;
	int personCount = 1;
	


	public MainPage()
	{
		InitializeComponent();
	}


    private void SliderTip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		tipRate = (int)SliderTip.Value;
		LabelTip.Text = $"Tip: {tipRate}%";
		CalculateTotal();
    }

    private void Tip_Button_Clicked(object sender, EventArgs e)
    {
		if (sender is Button)
		{
			var button = (Button)sender;
			var percentage = int.Parse(button.Text.Replace("%", ""));

			SliderTip.Value = percentage;
		}
    }
    private void ButtonMinus_Clicked(object sender, EventArgs e)
    {
		if (personCount < 2)
			return;

		personCount--;
        LabelPersonCount.Text = personCount.ToString();
		CalculateTotal();
    }

    private void ButtonPlus_Clicked(object sender, EventArgs e)
    {
        personCount++;
        LabelPersonCount.Text = personCount.ToString();
		CalculateTotal();
    }

    private void CalculateTotal()
	{
		var totalTip = (bill / 100) * tipRate;

		var tipByPerson = totalTip / personCount;
		LabelTipByPerson.Text = $"{tipByPerson:C}";

		var subtotal = bill / personCount;
		LabelSubTotal.Text = $"{subtotal:C}";


        var totalByPerson = (bill + totalTip) / personCount;

		LabelTotal.Text = $"{totalByPerson:C}";

	}

    private void EntryBill_Completed(object sender, EventArgs e)
    {
        bill = decimal.Parse(EntryBill.Text);
        CalculateTotal();
    }
}

