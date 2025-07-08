using GuevaraExamenProg3.ViewModels;

namespace GuevaraExamenProg3.Views;

public partial class MostrarLogsView : ContentPage
{
	public MostrarLogsView(RecetaViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}