
using Componente.Supero.Dicionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Componente.Web.Supero.Utils
{
  public class Utils
  {
    public static void CarregaTextValueDdl(System.Web.UI.WebControls.DropDownList _Ddl, string _DataTextField, string _DataValueField)
    {
      _Ddl.DataTextField = _DataTextField;
      _Ddl.DataValueField = _DataValueField;
      _Ddl.Items.Clear();
      _Ddl.SelectedIndex = -1;
      _Ddl.SelectedValue = null;
      _Ddl.ClearSelection();


    }
  }
}