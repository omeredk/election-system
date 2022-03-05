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
    public partial class FrmGraphics : Form
    {
        public FrmGraphics()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-CJTBSKD;Initial Catalog=dbelection;Integrated Security=True");

        private void FrmGraphics_Load(object sender, EventArgs e)
        {
            //How to get CityName's to combobox1
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select CityName from TBLCity", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            baglanti.Close();

            //How to get results
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select SUM(AParty), SUM(BParty), SUM(CParty), SUM(DParty), SUM(EParty) FROM TBLCity", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                chart1.Series["Party"].Points.AddXY("A Party", dr2[0]);
                chart1.Series["Party"].Points.AddXY("B Party", dr2[1]);
                chart1.Series["Party"].Points.AddXY("C Party", dr2[2]);
                chart1.Series["Party"].Points.AddXY("D Party", dr2[3]);
                chart1.Series["Party"].Points.AddXY("E Party", dr2[4]);
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLCity where CityName=@P1", baglanti);
            komut.Parameters.AddWithValue("@P1", comboBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();

            while(dr.Read())
            {
                progressBar1.Value = int.Parse(dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());

                LblA.Text = dr[2].ToString();
                LblB.Text = dr[3].ToString();
                LblC.Text = dr[4].ToString();
                LblD.Text = dr[5].ToString();
                LblE.Text = dr[6].ToString();

                chart1.Series["Party"].Points.Clear();
                chart1.Series["Party"].Points.AddXY("A Party", dr[2]);
                chart1.Series["Party"].Points.AddXY("B Party", dr[3]);
                chart1.Series["Party"].Points.AddXY("C Party", dr[4]);
                chart1.Series["Party"].Points.AddXY("D Party", dr[5]);
                chart1.Series["Party"].Points.AddXY("E Party", dr[6]);
            }
            baglanti.Close();
        }

    }
}
