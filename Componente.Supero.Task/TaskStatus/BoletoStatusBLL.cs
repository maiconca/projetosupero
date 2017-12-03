using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Componente.Supero.Task
{
  public class TaskStatusBLL
  {
    public static void CarregaTaskStatus(TaskStatus _TaskStatus, List<TaskStatus> _ListaTaskStatus)
    {
      using (TaskContext TaskContext = new TaskContext())
      {
        TaskStatusDAL.CarregaTaskStatus(_TaskStatus, _ListaTaskStatus, TaskContext);
      }
    }
    public static int SituacaoTaskStatus(string _Descricao)
    {
      int Codigo = 0;

      List<TaskStatus> ListaTaskStatus = new List<TaskStatus>();
      TaskStatus TaskStatus = new TaskStatus();
      TaskStatus.Descricao = _Descricao;
      TaskStatusBLL.CarregaTaskStatus(TaskStatus, ListaTaskStatus);

      foreach (var situacao in ListaTaskStatus)
      {
        Codigo = situacao.Codigo;
      }
      return Codigo;
    }
  }
}
