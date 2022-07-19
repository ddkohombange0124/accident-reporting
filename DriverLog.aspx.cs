using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Website
{
    public partial class DriverLog : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\policeweb.mdf';Integrated Security=True;Connect Timeout=30");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("RetrieveData.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand passcomm = new SqlCommand("Select email,password from Log where email='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'", con);
            con.Open();
            SqlDataReader dr = passcomm.ExecuteReader();
            if (dr.Read())
            {
                Session["id"] = TextBox1.Text;
                Response.Redirect("Retrieve.aspx");
            }
            else
            {
                Response.Write("data not match");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reg.aspx");
        }

        

      
    }
    
}