using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Componente.Supero.Task
{
  public class TaskStatusDAL
  {
    public static void CarregaTaskStatus(TaskStatus _TaskStatus, List<TaskStatus> _ListaTaskStatus, TaskContext _TaskContext)
    {
      IQueryable<TaskStatus> query = _TaskContext.ListaTaskStatus;

      if (_TaskStatus.Codigo != 0)
      {
        query = query.Where(c => c.Codigo == _TaskStatus.Codigo);
      }

      if (!string.IsNullOrEmpty(_TaskStatus.Descricao))
      {
        query = query.Where(c => c.Descricao == _TaskStatus.Descricao);
      }


      _ListaTaskStatus.AddRange(query);

    }

  }
}
