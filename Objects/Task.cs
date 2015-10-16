using System.Collections.Generic;
using System.Data.SqlClient;

namespace ToDoList
{
  public class Task
  {
    private int id;
    private string description;

    public Task(string Description)
    {
      description = Description;
    }

    public string GetDescription()
    {
      return description;
    }

    public void SetDescription(string newDescription)
    {
      description = newDescription;
    }

    public static List<string> All() {
      List<string> AllDescriptions = new List<string>{};
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;

      try
      {
          conn.Open();
          SqlCommand cmd = new SqlCommand("select * from tasks", conn);
          rdr = cmd.ExecuteReader();

          while (rdr.Read())
          {
              AllDescriptions.Add(rdr.GetString(1));
          }
      }
      finally
      {
          if (rdr != null)
          {
              rdr.Close();
          }

          if (conn != null)
          {
              conn.Close();
          }
      }
      return AllDescriptions;
    }
  }
}
