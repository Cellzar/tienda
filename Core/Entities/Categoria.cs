namespace Core.Entities;
public class Categoria: BaseEntity
{
    public string Nombre { get; set; }
    public IEnumerable<Producto> Productos { get; set; }
}
