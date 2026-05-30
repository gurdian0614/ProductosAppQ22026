
using ProductosAppQ22026.Models;
using SQLite;

namespace ProductosAppQ22026.Services;

public class ProductoService
{
    private SQLiteAsyncConnection _db;

    private async Task Init()
    {
        if (_db is not null) return;
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "productos.db3");
        _db = new SQLiteAsyncConnection(dbPath);
        await _db.CreateTableAsync<Producto>();
    }

    public async Task<List<Producto>> GetProductosAsync()
    {
        await Init();
        return await _db.Table<Producto>().ToListAsync();
    }

    public async Task<int> GuardarProductosAsync(Producto producto)
    {
        await Init();

        if (producto.Id != 0)
            return await _db.UpdateAsync(producto);

        return await _db.InsertAsync(producto);
    }

    public async Task<int> EliminarProductoAsync(Producto producto)
    {
        await Init();
        return await _db.DeleteAsync(producto);
    }
}