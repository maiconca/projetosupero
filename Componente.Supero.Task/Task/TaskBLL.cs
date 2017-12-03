
using System;
using System.Collections.Generic;
using System.Linq;

namespace Componente.Supero.Task
{
  public class TaskBLL
  {
    /// <summary>
    /// Método que irá fazer a pesquisa das tasks
    /// </summary>
    /// <param name="_Task"></param>
    /// <param name="_ListaTask"></param>
    public static void CarregaTask(Task _Task, List<Task> _ListaTask)
    {
      using (TaskContext TaskContext = new TaskContext())
      {
        TaskDAL.CarregaTask(_Task, _ListaTask, TaskContext);
      }
    }

    /// <summary>
    /// Método que ira cuidar da persistência das Task
    /// </summary>
    /// <param name="_TaskNovo"></param>
    /// <param name="_TaskAtual"></param>
    public static void EscalonadorTask(Task _TaskNovo, Task _TaskAtual = null)
    {
      using (TaskContext TaskContext = new TaskContext())
      {
        using (var dbContextTransaction = TaskContext.Database.BeginTransaction())
        {
          try
          {
            if (ValidaAcaoEscalonador(_TaskAtual, _TaskNovo))
            {
              TaskDAL.Alterar(_TaskNovo, _TaskAtual, TaskContext);
            }
            else
            {
              TaskDAL.Inserir(_TaskNovo, TaskContext);
            }

            TaskContext.SaveChanges();
            dbContextTransaction.Commit();
          }
          catch (Exception)
          {
            dbContextTransaction.Rollback();
            throw;
          }
          finally
          {
            dbContextTransaction.Dispose();
          }
        }
      }
    }

    /// <summary>
    /// Método que valida o escalonador pra inserir ou alterar
    /// </summary>
    /// <param name="_TaskAtual"></param>
    /// <param name="_TaskNovo"></param>
    /// <returns></returns>
    private static bool ValidaAcaoEscalonador(Task _TaskAtual, Task _TaskNovo)
    {
      if ((_TaskAtual != null || _TaskNovo.Ativo == false) && _TaskNovo.Codigo != 0)
      {
        return true;
      }
      return false;
    }
  }
}
