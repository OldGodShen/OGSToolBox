using CommunityToolkit.Maui.Alerts;
using OGSToolBox.ViewsModels;
using System.Diagnostics;

namespace OGSToolBox.Views;

[QueryProperty("token", "token")]
public partial class SSJGLessonsView : ContentPage
{
	public string token { get; set; }
	public SSJGLessonsView()
	{
		InitializeComponent();
    }

}