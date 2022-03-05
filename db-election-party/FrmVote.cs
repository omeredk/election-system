using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace db_election_party
{
    public partial class TxtCityName : Form
    {
        public TxtCityName()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-CJTBSKD;Initial Catalog=dbelection;Integrated Security=True");
        private void BtnVote_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLCity (CityName,AParty, BParty, CParty, DParty, EParty) values (@P1, @P2, @P3, @P4, @P5, @P6)", baglanti);
            komut.Parameters.AddWithValue("@P1", TxtCity.Text);
            komut.Parameters.AddWithValue("@P2", TxtA.Text);
            komut.Parameters.AddWithValue("@P3", TxtB.Text);
            komut.Parameters.AddWithValue("@P4", TxtC.Text);
            komut.Parameters.AddWithValue("@P5", TxtD.Text);
            komut.Parameters.AddWithValue("@P6", TxtE.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("SUCCES!");
        }

        private void BtnResults_Click(object sender, EventArgs e)
        {
            FrmGraphics fr = new FrmGraphics();
            fr.Show();
        }
    }
}
