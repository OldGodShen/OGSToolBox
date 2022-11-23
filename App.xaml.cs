using OGSToolBox.Views;

namespace OGSToolBox;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
