using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Website
{
    public partial class DReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            String NIC = TextBox1.Text;
            String Name = TextBox2.Text;
            String Username = TextBox3.Text;
            String Password = TextBox4.Text;
            String Confirmpassword = TextBox5.Text;
            String Address = TextBox6.Text;

            if (NIC != "" && Name != "" && Username != "" && Password != "" && Confirmpassword != "" && Address != "")
            {
                if (Password == Confirmpassword)
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\Policeweb.mdf';Integrated Security=True");
                    String sql = "insert into DReg values('" + NIC + "','" + Name + "','" + Username + "','" + Password + "','" + Confirmpassword + "','" + Address + "')";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Response.Write("data inserted successfully");
                        Response.Redirect("Retrieve.aspx");
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                }
                else
                {
                    Response.Write("password and confirm password are not matching");
                }
            }
            else
            {
                Response.Write("please insert all data to field");
            }


        }
        protected void Button2_Click1(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";

        }
    }
}