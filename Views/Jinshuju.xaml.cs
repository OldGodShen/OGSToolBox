using OGSToolBox.ViewsModels;

namespace OGSToolBox.Views;

public partial class Jinshuju : ContentPage
{
	public Jinshuju()
	{
		InitializeComponent();

		this.BindingContext = new JinshujuViewModel();
	}
}