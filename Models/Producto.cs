
using SQLite;

namespace ProductosAppQ22026.Models;

public class Producto
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [NotNull]
    public string Nombre { get; set;}

    public string Descripcion { get; set; }

    public double Precio { get; set; }

    public int Stock { get; set; }
}