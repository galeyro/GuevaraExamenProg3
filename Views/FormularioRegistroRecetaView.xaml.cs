using GuevaraExamenProg3.Interfaces;
using GuevaraExamenProg3.ViewModels;

namespace GuevaraExamenProg3.Views;

public partial class FormularioRegistroRecetaView : ContentPage
{
	public FormularioRegistroRecetaView(RecetaViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}