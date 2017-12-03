using System;
using System.Collections.Generic;
using System.Linq;

namespace Componente.Supero.Task
{
  public class TaskDAL
  {
    public static void CarregaTask(Task _Task, List<Task> _Tasks, TaskContext _TaskContext)
    {
      IQueryable<Task> query = _TaskContext.ListaTask;

      if (_Task.Codigo != 0)
      {
        query = query.Where(c => c.Codigo == _Task.Codigo);
      }

      if (!string.IsNullOrEmpty(_Task.Descricao))
      {
        query = query.Where(c => c.Descricao.Contains(_Task.Descricao));
      }

      if (_Task.DataConclusao != null)
      {
        query = query.Where(c => c.DataConclusao > _Task.DataConclusao && c.DataConclusao < DateTime.Now);
      }

      if (_Task.DataCriacao != null)
      {
        query = query.Where(c => c.DataCriacao > _Task.DataCriacao && c.DataCriacao < DateTime.Now);
      }

      if (_Task.DataEdicao != null)
      {
        query = query.Where(c => c.DataEdicao > _Task.DataEdicao && c.DataEdicao < DateTime.Now);
      }

      if (_Task.DataRemocao != null)
      {
        query = query.Where(c => c.DataRemocao > _Task.DataRemocao && c.DataRemocao < DateTime.Now);
      }

      if (_Task.CodigoTaskStatus != 0)
      {
        query = query.Where(c => c.CodigoTaskStatus == _Task.CodigoTaskStatus);
      }

      query = query.Where(c => c.Ativo == _Task.Ativo);

      _Tasks.AddRange(query);
    }

    internal static void Inserir(Task _Task, TaskContext _TaskContext)
    {
      _TaskContext.ListaTask.Add(_Task);
    }

    internal static void Alterar(Task _TaskNovo, Task _TaskAtual, TaskContext _TaskContext)
    {
      _TaskContext.Entry(_TaskNovo).State = System.Data.Entity.EntityState.Modified;
    }
  }
}
