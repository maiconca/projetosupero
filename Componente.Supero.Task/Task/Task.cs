using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Componente.Supero.Task
{
  public class Task : ICloneable
  {
    public int Codigo { get; set; }
    public bool Ativo { get; set; }
    public string Descricao { get; set; }
    public DateTime? DataCriacao { get; set; }
    public DateTime? DataEdicao { get; set; }
    public DateTime? DataRemocao { get; set; }
    public DateTime? DataConclusao { get; set; }

    public int CodigoTaskStatus { get; set; }

    public TaskStatus TaskStatus { get; set; }

    public object Clone()
    {
      return MemberwiseClone();
    }
  }
}
