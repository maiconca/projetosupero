using Componente.Supero.Task;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Componente.Web.Supero.Utils
{

  public class SuperoContext : DbContext
  {
    public SuperoContext()
      : base("name=DefaultDB")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Configurations.Add(new TaskMap());
      modelBuilder.Configurations.Add(new TaskStatusMap());
    }
  }
}