namespace OGSToolBox.Views;
using OGSToolBox.ViewsModels;

public partial class Ruoyi : ContentPage
{

	public Ruoyi()
	{
		InitializeComponent();

        this.BindingContext = new RuoyiLoginModel();
    }
	

}

