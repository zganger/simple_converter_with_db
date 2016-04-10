using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Modify : System.Web.UI.Page
{
    private const string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Lab5DB.mdf;Integrated Security = True";
    private string AddConfirmation;
    private string DelConfirmation;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void AddConversion_Click(object sender, EventArgs e)
    {
        ShowFactorPrint.Visible = false;
        double infactor;
        bool factorAcceptable;
        bool unitAcceptable;
        if (Double.TryParse(Factor.Text, out infactor))
        {
            ErrorBox.Visible = false;
            factorAcceptable = true;
        }
        else
        {
            Factor.Text = "";
            ErrorBox.Text = "Please enter a valid factor!";
            ErrorBox.Visible = true;
            factorAcceptable = false;
        }
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        SqlCommand read = new SqlCommand("SELECT * FROM Conversions", conn);
        SqlDataReader reader = read.ExecuteReader();
        int i = 0;
        int newID = i;
        unitAcceptable = true;
        while (reader.Read())
        {
            string u = (string)reader["Unit"];
            if (String.Compare(u, Unit.Text) == 0)
            {
                Unit.Text = "";
                Factor.Text = "";
                ErrorBox.Text = "This unit already exists!";
                ErrorBox.Visible = true;
                unitAcceptable = false;
                break;
            } else {
                i++;
                newID = i;
            }
        }
        conn.Close();
        if (factorAcceptable && unitAcceptable)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Conversions (Id, Unit, Factor) VALUES (@Id, @Unit, @Factor)");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@Id", (newID + 1));
            cmd.Parameters.AddWithValue("@Unit", Unit.Text);
            cmd.Parameters.AddWithValue("@Factor", Factor.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            AddConfirmation = "Successfully added " + Unit.Text + " with factor " + Factor.Text + ".";
            Unit.Text = "";
            Factor.Text = "";
            ErrorBox.Text = AddConfirmation;
            ErrorBox.Visible = true;
            HoldsID.DataBind();
        }
    }

    protected void ShowFactor_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Conversions", conn);
        SqlDataReader reader = cmd.ExecuteReader();
        int selected = int.Parse(HoldsID.SelectedItem.Value);
        int i = 1;
        while (reader.Read())
        {
            double f = (double)reader["Factor"];
            if(i == selected)
            {
                ShowFactorPrint.Text = f.ToString();
                ShowFactorPrint.Visible = true;
                break;
            }
            i++;
        }
        conn.Close();
        ErrorBox.Visible = false;
    }

    protected void Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void HoldsID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowFactorPrint.Visible = false;
        ErrorBox.Visible = false;
    }

    protected void DeleteConversion_Click(object sender, EventArgs e)
    {
        ShowFactorPrint.Visible = false;
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM Conversions WHERE Id = @Id", conn);
        cmd.Parameters.AddWithValue("@Id", HoldsID.SelectedItem.Value);
        string toRemove = HoldsID.SelectedItem.Text;
        cmd.ExecuteNonQuery();
        conn.Close();
        DelConfirmation = "Successfully removed " + toRemove + ".";
        ErrorBox.Text = DelConfirmation;
        ErrorBox.Visible = true;
        HoldsID.DataBind();
    }
}