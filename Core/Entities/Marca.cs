
namespace Core.Entities;
public class Marca: BaseEntity
{
    public string Nombre { get; set; }
    public IEnumerable<Producto> Productos { get; set; }
}
