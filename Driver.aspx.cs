using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;

namespace Website
{
    public partial class Driver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox6.Text = "";
            TextBox2.Text = "";
            DropDownList1.SelectedValue = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            

        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            TextBox6.Text = "";
            TextBox2.Text = "";
            DropDownList1.SelectedValue = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
           

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            String VehicleNumber = TextBox6.Text;
            String Name = TextBox2.Text;
            String NearestCity = DropDownList1.SelectedValue;
            String Mobileno= TextBox4.Text;
            
         

                string path = Server.MapPath("Images/");
            if(FileUpload1.HasFile)
            {
                string ext = Path.GetExtension(FileUpload1.FileName);

                if(ext==".jpg" || ext== ".png")
                {
                    FileUpload1.SaveAs(path + FileUpload1.FileName);
                    String name = "Images/" + FileUpload1.FileName;
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\Policeweb.mdf';Integrated Security=True");
                    String sql = "insert into Driver values('" + TextBox6.Text + "','" + TextBox2.Text + "','" + DropDownList1.SelectedValue + "','"+DropDownList2.SelectedValue+"','" + TextBox4.Text + "','"+name+"','"+ TextBox5.Text+ "')";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Response.Write("data inserted successfully");
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                }
                else
                {
                    Label6.Text = "you have to upload jpg or png file";
                }

            }
            else
            {
                Label6.Text = "please select file";
            }

           
           


        }
    }
}