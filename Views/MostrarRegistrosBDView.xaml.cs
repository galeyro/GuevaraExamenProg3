using GuevaraExamenProg3.ViewModels;

namespace GuevaraExamenProg3.Views;

public partial class MostrarRegistrosBDView : ContentPage
{
	public MostrarRegistrosBDView(RecetaViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}