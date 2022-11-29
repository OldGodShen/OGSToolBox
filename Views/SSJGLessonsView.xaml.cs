using CommunityToolkit.Maui.Alerts;
using OGSToolBox.ViewsModels;
using System.Diagnostics;

namespace OGSToolBox.Views;

[QueryProperty("TokenGet","token")]
public partial class SSJGLessonsView : ContentPage
{
	public string TokenGet { get; set; }
	public SSJGLessonsView()
	{
		InitializeComponent();
        this.BindingContext = new LessonsViewModel();
    }

}