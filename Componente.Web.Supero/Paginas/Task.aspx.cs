using Componente.Supero.Dicionario;
using Componente.Supero.Task;
using Componente.Web.Supero.Utils;
using Omnes.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Componente.Web.Supero.Paginas
{
  public partial class Task : System.Web.UI.Page
  {
    private struct IndexColunaGvTask
    {
      public const int cCodigo = 0;
      public const int cDescricao = 1;
      public const int cDataCriacao = 2;
      public const int cDataEdicao = 3;
      public const int cDataRemocao = 4;
      public const int cDataConclusao = 5;
      public const int cTaskStatus = 6;
      public const int cAcao = 7;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        Carrega();

        GridViewUtils.BindGrid(gvTask, new List<Task>());
      }
    }

    private void Carrega()
    {
      if (Sessions.ListaTaskStatus == null)
      {
        Sessions.ListaTaskStatus = new List<TaskStatus>();
        TaskStatus TaskStatus = new TaskStatus();
        TaskStatusBLL.CarregaTaskStatus(TaskStatus, Sessions.ListaTaskStatus);
      }

      Utils.Utils.CarregaTextValueDdl(ddlTaskStatus, "Descricao", "Codigo");

      ddlTaskStatus.DataSource = Sessions.ListaTaskStatus;
      ddlTaskStatus.DataBind();

    }

    protected void btnPesquisa_Click(object sender, EventArgs e)
    {
      Sessions.ListaTask = new List<Componente.Supero.Task.Task>();
      Sessions.TaskNova = new Componente.Supero.Task.Task();

      Sessions.TaskNova.Descricao = txtDescricaoInicio.Text;
      if (!string.IsNullOrEmpty(txtDataConclusao.Value))
      {
        Sessions.TaskNova.DataConclusao = Convert.ToDateTime(txtDataConclusao.Value);
      }

      if (!string.IsNullOrEmpty(txtDataCriacao.Value))
      {
        Sessions.TaskNova.DataCriacao = Convert.ToDateTime(txtDataCriacao.Value);
      }

      if (!string.IsNullOrEmpty(txtDataEdicao.Value))
      {
        Sessions.TaskNova.DataEdicao = Convert.ToDateTime(txtDataEdicao.Value);
      }

      if (!string.IsNullOrEmpty(txtDataRemocao.Value))
      {
        Sessions.TaskNova.DataRemocao = Convert.ToDateTime(txtDataRemocao.Value);
      }

      Sessions.TaskNova.CodigoTaskStatus = Convert.ToInt32(ddlTaskStatus.SelectedValue);

      if (!string.IsNullOrEmpty(txtCodigo.Text))
      {
        Sessions.TaskNova.Codigo = Convert.ToInt32(txtCodigo.Text);
      }

      Sessions.TaskNova.Ativo = true;

      TaskBLL.CarregaTask(Sessions.TaskNova, Sessions.ListaTask);

      GridViewUtils.BindGrid(gvTask, Sessions.ListaTask);
    }

    protected void gvTask_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      switch (e.Row.RowType)
      {
        case DataControlRowType.Header:
          e.Row.Cells[IndexColunaGvTask.cDescricao].Width = new Unit("50%");
          e.Row.Cells[IndexColunaGvTask.cAcao].Width = new Unit("233");
          break;
        case DataControlRowType.DataRow:
          Componente.Supero.Task.Task t = e.Row.DataItem as Componente.Supero.Task.Task;
          e.Row.Cells[IndexColunaGvTask.cCodigo].Text = t.Codigo.ToString();
          e.Row.Cells[IndexColunaGvTask.cDescricao].Text = t.Descricao.ToString();
          e.Row.Cells[IndexColunaGvTask.cDataCriacao].Text = Convert.ToDateTime(t.DataCriacao).ToString("dd/MM/yyyy");

          if (t.DataEdicao != null)
          {
            e.Row.Cells[IndexColunaGvTask.cDataEdicao].Text = Convert.ToDateTime(t.DataEdicao).ToString("dd/MM/yyyy");
          }

          if (t.DataRemocao != null)
          {
            e.Row.Cells[IndexColunaGvTask.cDataRemocao].Text = Convert.ToDateTime(t.DataRemocao).ToString("dd/MM/yyyy");
          }

          if (t.DataConclusao != null)
          {
            e.Row.Cells[IndexColunaGvTask.cDataConclusao].Text = Convert.ToDateTime(t.DataConclusao).ToString("dd/MM/yyyy");
          }

          e.Row.Cells[IndexColunaGvTask.cTaskStatus].Text = Sessions.ListaTaskStatus.Where(x => x.Codigo == t.CodigoTaskStatus).FirstOrDefault().Descricao;

          break;
        default:
          break;
      }
    }

    protected void gvTask_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if (!e.CommandName.Equals("btnEditar") && !e.CommandName.Equals("btnExcluir") && !e.CommandName.Equals("btnDetalhar") && !e.CommandName.Equals("btnAprovar") && !e.CommandName.Equals("btnReprovar") && !e.CommandName.Equals("btnConcluir"))
      {
        return;
      }

      int index = Convert.ToInt32(e.CommandArgument);
      int Codigo = Convert.ToInt32(gvTask.Rows[index].Cells[0].Text);

      Sessions.TaskAntiga = Sessions.ListaTask.Where(p => p.Codigo == Codigo).FirstOrDefault();

      switch (e.CommandName)
      {
        case "btnEditar":
          btnAlterarTask_Click();
          break;

        case "btnExcluir":
          btnExcluirTask_Click();
          break;

        case "btnDetalhar":
          btnDetalharTask_Click();
          break;

        case "btnAprovar":
          btnAprovarTask_Click();
          break;

        case "btnReprovar":
          btnReprovarTask_Click();
          break;

        case "btnConcluir":
          btnConcluirTask_Click();
          break;
        default:
          return;
      }
    }

    private void btnConcluirTask_Click()
    {
      Sessions.TaskAntiga.DataConclusao = DateTime.Now;
      SetarStatus("Concluído");
    }

    private void btnReprovarTask_Click()
    {
      Sessions.TaskAntiga.DataRemocao = DateTime.Now;
      SetarStatus("Reprovado");
    }

    private void SetarStatus(string _Status)
    {
      Sessions.TaskNova = Sessions.TaskAntiga.Clone() as Componente.Supero.Task.Task;
      Sessions.TaskNova.CodigoTaskStatus = Sessions.ListaTaskStatus.Where(x => x.Descricao == _Status).FirstOrDefault().Codigo;
      TaskBLL.EscalonadorTask(Sessions.TaskNova, Sessions.TaskAntiga);

      btnPesquisa_Click(null, null);
    }

    private void btnAprovarTask_Click()
    {
      SetarStatus("Aprovado");
    }

    private void btnDetalharTask_Click()
    {
      ScriptManager.RegisterStartupScript(form1, this.GetType(), "modalTask", "$('#modalTask').modal('show');", true);
    }

    private void btnExcluirTask_Click()
    {
      Sessions.TaskNova = Sessions.TaskAntiga.Clone() as Componente.Supero.Task.Task;
      Sessions.TaskNova.DataRemocao = DateTime.Now;
      Sessions.TaskNova.Ativo = false;
      TaskBLL.EscalonadorTask(Sessions.TaskNova, Sessions.TaskAntiga);

      btnPesquisa_Click(null, null);

    }

    private void btnAlterarTask_Click()
    {
      txtDescricaoCadastro.Text = Sessions.TaskAntiga.Descricao.ToString();
      AbrirModal();
    }

    private void AbrirModal()
    {
      ScriptManager.RegisterStartupScript(form1, this.GetType(), "modalTask", "$('#modalTask').modal('show');", true);
    }

    protected void btnSalvarTask_Click(object sender, EventArgs e)
    {
      if (Sessions.TaskAntiga != null)
      {
        Sessions.TaskNova = Sessions.TaskAntiga.Clone() as Componente.Supero.Task.Task;
        Sessions.TaskNova.DataEdicao = DateTime.Now;
      }
      else
      {
        Sessions.TaskNova = new Componente.Supero.Task.Task();
        Sessions.TaskNova.DataCriacao = DateTime.Now;
      }

      Componente.Supero.Task.Task t = new Componente.Supero.Task.Task();

      Sessions.TaskNova.Ativo = true;
      Sessions.TaskNova.CodigoTaskStatus = Sessions.ListaTaskStatus.Where(x => x.Descricao == "Aberto").FirstOrDefault().Codigo;
      Sessions.TaskNova.Descricao = txtDescricaoCadastro.Text;

      TaskBLL.EscalonadorTask(Sessions.TaskNova, Sessions.TaskAntiga);

      Sessions.TaskAntiga = null;
      Sessions.TaskNova = null;

      txtDescricaoCadastro.Text = string.Empty;

      btnPesquisa_Click(null, null);
    }
  }
}