using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register_RegisterPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegisterPage_Click(object sender, EventArgs e)
    {
        string eMail = mailID.Value;
        string username = txtUserName.Value;
        string password = txtPassword.Value;
        string konekcija = ConfigurationManager.ConnectionStrings["myConnectionLog"].ConnectionString;
        // provjeri postoji li korisnik s istim emailom
        string sqlProvjeriEmail = "SELECT COUNT(*) FROM Registration WHERE email=@eMail";
        SqlConnection sqlKonekcijaEmail = new SqlConnection(konekcija);
        sqlKonekcijaEmail.Open();
        SqlCommand sqlKomandaEmail = new SqlCommand(sqlProvjeriEmail, sqlKonekcijaEmail);
        sqlKomandaEmail.Parameters.AddWithValue("@eMail", eMail);
        int brojEmailova = (int)sqlKomandaEmail.ExecuteScalar();

        // provjeri postoji li korisnik s istim usernameom
        string sqlProvjeriUsername = "SELECT COUNT(*) FROM Registration WHERE userName=@username";
        SqlConnection sqlKonekcijaUsername = new SqlConnection(konekcija);
        sqlKonekcijaUsername.Open();
        SqlCommand sqlKomandaUsername = new SqlCommand(sqlProvjeriUsername, sqlKonekcijaUsername);
        sqlKomandaUsername.Parameters.AddWithValue("@username", username);
        int brojUsernamea = (int)sqlKomandaUsername.ExecuteScalar();

        if (brojEmailova > 0)
        {
            lblIspis.Text = "E-mail koji ste upisali već se koristi.";
        }
        else if (brojUsernamea > 0)
        {
            lblIspis.Text = "Username već postoji.";
        }
        else
        {
            
            string sqlUpit = "INSERT INTO Registration (email, userName, pass) VALUES (@eMail, @username, @password)";
            SqlConnection sqlKonekcija = new SqlConnection(konekcija);
            sqlKonekcija.Open();

            SqlCommand sqlKomanda = new SqlCommand(sqlUpit, sqlKonekcija);
            sqlKomanda.Parameters.AddWithValue("@username", txtUserName.Value);
            sqlKomanda.Parameters.AddWithValue("@password", txtPassword.Value);
            sqlKomanda.Parameters.AddWithValue("@email", mailID.Value);


            int brojDodanihRedova = sqlKomanda.ExecuteNonQuery();

            if (brojDodanihRedova == 1)
            {
                lblIspis.Text = "Uspješno ste se registrovali";
            }
            else
            {
                lblIspis.Text = "Neuspješna registracija!";
            }
        }
    }
}