using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Omnes.Utils
{
  public class GridViewUtils
  {
    /// <summary>
    /// Classe que pega o datakey da linha do grid selecionado
    /// </summary>
    /// <param name="e"></param>
    /// <param name="gridView"></param>
    /// <returns></returns>
    public static string RowCommand(object e, GridView gridView)
    {
      GridViewCommandEventArgs gridViewCommand = e as GridViewCommandEventArgs;

      if (gridViewCommand.CommandName == "Select")
      {
        // Determine the index of the selected row.
        int index = Convert.ToInt32(gridViewCommand.CommandArgument);
        string numberDataKey = gridView.DataKeys[index].Value.ToString();

        return numberDataKey;
      }
      else
      {
        return string.Empty;
      }
    }

    /// <summary>
    /// Atribui o click na linha para pode selecionar
    /// </summary>
    /// <param name="Rows"></param>
    /// <param name="gridView"></param>
    /// <param name="page"></param>
    public static void Render(GridView gridView, Page page)
    {
      {
        foreach (GridViewRow row in gridView.Rows)
        {
          if (row.RowType == DataControlRowType.DataRow)
          {
            row.Attributes["onclick"] =
              page.ClientScript.GetPostBackClientHyperlink(gridView,
                "Select$" + row.DataItemIndex, true);
          }
        }
      }
    }

    /// <summary>
    /// Troca de Pagina
    /// </summary>
    /// <param name="gridView"></param>
    /// <param name="SessionCollection"></param>
    /// <param name="e"></param>
    public static void PageIndexChanging(GridView gridView, object SessionCollection, GridViewPageEventArgs e)
    {
      gridView.DataSource = SessionCollection;
      gridView.PageIndex = e.NewPageIndex;
      gridView.DataBind();
      gridView.SelectedIndex = -1;
    }

    /// <summary>
    /// Método que só ira da DataSource na Session e Bind no grid 
    /// </summary>
    /// <param name="gridView"></param>
    /// <param name="categoryCollection"></param>
    public static void BindGrid(GridView gridView, Object SessionCollection)
    {
      gridView.DataSource = SessionCollection;
      gridView.DataBind();
    }

    public static void ExibirGrid(GridView gridView)
    {
      gridView.DataSource = null;
      gridView.DataBind();
    }


    public static List<object> GetCheckedObjects(GridView gv, string columnName, IList collection)
    {
      List<object> result = new List<object>();

      for (int i = 0; i < gv.Rows.Count; i++)
      {
        GridViewRow row = gv.Rows[i];
        bool isChecked = ((CheckBox)row.FindControl(columnName)).Checked;
        gv.SelectedIndex = -1;

        if (isChecked)
        {
          result.Add(collection[i]);
        }
      }

      return result;
    }

    public static bool ValidaSelecaoGrid(GridView _GridView)
    {
      if (_GridView.SelectedIndex == -1)
      {
        return false;
      }
      return true;
    }
  }
}