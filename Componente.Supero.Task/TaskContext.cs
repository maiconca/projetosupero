using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Componente.Supero.Task
{
  public class TaskContext : DbContext
  {
    public TaskContext()
      : base("name=DefaultDB")
    {
      Configuration.ProxyCreationEnabled = false;
      Configuration.LazyLoadingEnabled = false;
    }

    public DbSet<Task> ListaTask { get; set; }
    public DbSet<TaskStatus> ListaTaskStatus { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

      modelBuilder.Configurations.Add(new TaskMap());
      modelBuilder.Configurations.Add(new TaskStatusMap());

    }
  }
}

