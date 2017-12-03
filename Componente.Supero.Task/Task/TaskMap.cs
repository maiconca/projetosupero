using System.Data.Entity.ModelConfiguration;

namespace Componente.Supero.Task
{
  public class TaskMap : EntityTypeConfiguration<Task>
  {
    public TaskMap()
    {
      HasKey(t => t.Codigo);

      ToTable("Task");

      HasRequired(t => t.TaskStatus).WithMany().HasForeignKey(t => t.CodigoTaskStatus);
    }
  }
}
