using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace Componente.Supero.Task
{
  public class TaskStatusMap : EntityTypeConfiguration<TaskStatus>
  {
    public TaskStatusMap()
    {
      HasKey(t => t.Codigo);

      ToTable("TaskStatus");

      Property(t => t.Codigo).HasColumnName("Codigo");
      Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar").HasMaxLength(50);
    }
  }
}
