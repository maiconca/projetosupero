using Componente.Supero.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Componente.Web.Supero.Utils
{
  public class Sessions
  {
    public static Task TaskNova
    {
      get
      {
        return HttpContext.Current.Session["TaskNova"] as Task;
      }
      set
      {
        HttpContext.Current.Session["TaskNova"] = value;
      }
    }

    public static Task TaskAntiga
    {
      get
      {
        return HttpContext.Current.Session["TaskAntiga"] as Task;
      }
      set
      {
        HttpContext.Current.Session["TaskAntiga"] = value;
      }
    }

    public static TaskStatus TaskStatus
    {
      get
      {
        return HttpContext.Current.Session["TaskStatus"] as TaskStatus;
      }
      set
      {
        HttpContext.Current.Session["TaskStatus"] = value;
      }
    }

    public static List<TaskStatus> ListaTaskStatus
    {
      get
      {
        return HttpContext.Current.Session["ListaTaskStatus"] as List<TaskStatus>;
      }
      set
      {
        HttpContext.Current.Session["ListaTaskStatus"] = value;
      }
    }

    public static List<Task> ListaTask
    {
      get
      {
        return HttpContext.Current.Session["ListaTask"] as List<Task>;
      }
      set
      {
        HttpContext.Current.Session["ListaTask"] = value;
      }
    }

  }
}