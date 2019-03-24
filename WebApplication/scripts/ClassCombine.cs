using System;
using System.Collections.Generic;

namespace WebApplication.scripts
{
    public class ClassCombine
    {

  public string combine(string path)
        {
            
            path = path.Substring(0, 1).ToUpper() + path.Substring(1);
            List<string> list = new List<string>();

            for (int i = 0; i < path.Length; i++)
            {
                list.Add(path[i].ToString());
            }

            path = String.Empty;

            for (int a = 0; a < list.Count; a++)
            {
                if (list[a].Equals("\\") && a<list.Count-1)
                {
                   list[a + 1] = list[a + 1].ToUpper();
                }

                path += list[a];

            }

            return path.TrimEnd();

        }

    }
}