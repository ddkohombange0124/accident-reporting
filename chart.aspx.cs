using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

namespace Website
{
    public partial class chart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                LoadData();
            }
        }    
            void LoadData()
            {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\Policeweb.mdf';Integrated Security=True");
            
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select Vehicletype,sum(amount) As totamount from chart group by Vehicletype", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.Close();

                }
                string[] x = new string[dt.Rows.Count];
                int[] y = new int[dt.Rows.Count];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    x[i] = dt.Rows[i][0].ToString();
                    y[i] = Convert.ToInt32(dt.Rows[i][1]);
                }
                Chart1.Series[0].Points.DataBindXY(x, y);
                Chart1.Series[0].ChartType = SeriesChartType.Pie;
               // Chart1.Legends[0].Enabled = true;
            }

        


        
    }
}