using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected List<double> conv = new List<double>();
    private const string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Lab5DB.mdf;Integrated Security = True";
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Conversions", conn);
        SqlDataReader reader = cmd.ExecuteReader();
        int i = 0;
        while (reader.Read())
        {
            double f = (double)reader["Factor"];
            conv.Add(f);
            i++;
        }
        conn.Close();
    }

    protected void Convert_Click(object sender, EventArgs e)
    {
        double innum;
        ErrorBox.Visible = false;
        int inindex = fromList.SelectedIndex;
        int outindex = toList.SelectedIndex;
        if (inindex == outindex)
        {
            num1.Text = "";
            ErrorBox.Text = "You're converting to the same unit! Try again.";
            ErrorBox.Visible = true;
        }
        else
        {
            if (Double.TryParse(num1.Text, out innum))
            {
                ErrorBox.Visible = false;
                num2.Text = ((innum * conv[inindex]) / conv[outindex]).ToString();
            }
            else
            {
                num1.Text = "";
                ErrorBox.Text = "Please enter a valid number!";
                ErrorBox.Visible = true;
            }
        }
    }

    protected void DBEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Modify.aspx");
    }
}