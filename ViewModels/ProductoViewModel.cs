
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductosAppQ22026.Models;
using ProductosAppQ22026.Services;

namespace ProductosAppQ22026.ViewModels;

public partial class ProductoViewModel : ObservableObject
{
    private readonly ProductoService _service;

    [ObservableProperty]
    private string nombre;

    [ObservableProperty]
    private string descripcion;

    [ObservableProperty]
    private double precio;

    [ObservableProperty]
    private int stock;

    [ObservableProperty]
    private Producto? productoSeleccionado;

    public ObservableCollection<Producto> Productos { get; } = new();

    public ProductoViewModel(ProductoService service)
    {
        _service = service;
    }

    [RelayCommand]
    private async Task CargarProductos()
    {
        List<Producto> lista = await _service.GetProductosAsync();
        Productos.Clear();

        foreach (Producto p in lista)
        {
            Productos.Add(p);
        }
    }

    [RelayCommand]
    private async Task Guardar()
    {
        if (string.IsNullOrWhiteSpace(Nombre)) return;

        Producto producto = ProductoSeleccionado ?? new Producto();
        producto.Nombre = Nombre;
        producto.Descripcion = Descripcion;
        producto.Precio = Precio;
        producto.Stock = Stock;

        await _service.GuardarProductosAsync(producto);
        await CargarProductos();
    }

    [RelayCommand]
    private async Task Eliminar(Producto producto)
    {
        await _service.EliminarProductoAsync(producto);
        await CargarProductos();
    }

    public void Limpiar()
    {
        Nombre = string.Empty;
        Descripcion = string.Empty;
        Precio = 0;
        Stock = 0;
        ProductoSeleccionado = null;
    }

}