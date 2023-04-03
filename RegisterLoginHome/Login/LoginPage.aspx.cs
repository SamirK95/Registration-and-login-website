using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLoginPage_Click(object sender, EventArgs e)
    {
        string username = usernameID.Value;
        string password = passwordID.Value;
        string konekcija = ConfigurationManager.ConnectionStrings["myConnectionLog"].ConnectionString;

        // Prvo provjeravamo postoji li korisnik s unesenim korisničkim imenom
        string sqlUpitKorisnik = "SELECT COUNT(*) FROM Registration WHERE userName=@username";
        SqlConnection sqlKonekcijaKorisnik = new SqlConnection(konekcija);
        sqlKonekcijaKorisnik.Open();

        SqlCommand sqlKomandaKorisnik = new SqlCommand(sqlUpitKorisnik, sqlKonekcijaKorisnik);
        sqlKomandaKorisnik.Parameters.AddWithValue("@username", usernameID.Value);

        int brojPronadjenihKorisnika = (int)sqlKomandaKorisnik.ExecuteScalar();

        if (brojPronadjenihKorisnika == 0)
        {
            // Ako korisnik ne postoji u bazi podataka, ispisati poruku
            lblIspis.Text = "Registracija je neophodna. Molimo registrujte se!";
        }
        else
        {
            // Ako korisnik postoji, provjeriti lozinku
            string sqlUpitLozinka = "SELECT COUNT(*) FROM Registration WHERE userName=@username AND pass=@password";
            SqlConnection sqlKonekcijaLozinka = new SqlConnection(konekcija);
            sqlKonekcijaLozinka.Open();

            SqlCommand sqlKomandaLozinka = new SqlCommand(sqlUpitLozinka, sqlKonekcijaLozinka);
            sqlKomandaLozinka.Parameters.AddWithValue("@username", usernameID.Value);
            sqlKomandaLozinka.Parameters.AddWithValue("@password", passwordID.Value);

            int brojPronadjenihLozinka = (int)sqlKomandaLozinka.ExecuteScalar();

            if (brojPronadjenihLozinka > 0)
            {
                // Ako lozinka odgovara, preusmjeri korisnika na početnu stranicu
                Response.Redirect("http://localhost:62526/Forms/Home.aspx");
            }
            else
            {
                // Ako lozinka nije ispravna, ispisi poruku
                lblIspis.Text = "Pogrešan password. Pokušajte ponovo.";
            }
        }
    }
}