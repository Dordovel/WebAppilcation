using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.scripts;

namespace WebApplication.Pages
{
    public partial class Read : System.Web.UI.Page
    {
        public string path;
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Request.QueryString["name"];
            if (string.IsNullOrEmpty(name))
            {
                Response.Redirect("~/Pages/HomePage.aspx");
            }

            else
            {
                ClassCombine combine=new ClassCombine();
                path = combine.combine(Server.MapPath(name));

                FileStream file=new FileStream(path,FileMode.Open,FileAccess.Read);

                var encod=Encoding.GetEncoding("windows-1251");

                StreamReader stream = new StreamReader(file, encod);

                label.Text = stream.ReadToEnd();

            }
        }
        

    }
}