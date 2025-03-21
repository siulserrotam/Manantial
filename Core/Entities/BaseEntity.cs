namespace Manantial.Core.Entities
{
    public abstract class BaseEntity
    {
          public int Id { get; set; }
          public DateTime FechaRegistro { get; set; } = DateTime.Now;
          public bool Activo { get; set; } = true;
    }
}