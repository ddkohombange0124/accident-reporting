using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Website
{
    public partial class RetrieveData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = '|DataDirectory|\Policeweb.mdf'; Integrated Security = True");
            SqlDataAdapter da = new SqlDataAdapter("Select Image,NearestCity,Description from Driver ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ListView1.DataSource = dt;
            ListView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("chart.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("claim.aspx");
        }
    }
}