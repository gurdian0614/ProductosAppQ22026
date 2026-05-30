using ProductosAppQ22026.ViewModels;

namespace ProductosAppQ22026.Views;

public partial class ProductosPage : ContentPage
{
	public ProductosPage(ProductoViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}