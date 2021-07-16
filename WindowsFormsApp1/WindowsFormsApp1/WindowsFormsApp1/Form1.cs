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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-7TQL9MR;Initial Catalog=DB;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter da;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void getir()
        {
            baglanti.Open();


           da = new SqlDataAdapter("SELECT  URUNADI,KADI,URUNRENGI,URUNADET,URUNMALIYET,URUNFIYAT,URUNID FROM URUN INNER JOIN KATEGORI ON URUN.URUNK = KATEGORI.KID  ", baglanti);





            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            getir();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            urunAd.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            urunK.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            urunRengi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            urunAdet.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            urunFiyat.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            urunMaliyet.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            //dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            urunID.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           string sorgu= "INSERT INTO URUN (URUNADI,URUNK,URUNRENGI,URUNADET,URUNFIYAT,URUNMALIYET,URUNID) VALUES  (@URUNADI,@URUNK,@URUNRENGI,@URUNADET,@URUNFIYAT,@URUNMALIYET,@URUNID)";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@URUNADI", urunAd.Text);
            komut.Parameters.AddWithValue("@URUNK", urunK.Text);
            komut.Parameters.AddWithValue("@URUNRENGI", urunRengi.Text);
            komut.Parameters.AddWithValue("@URUNADET", urunAdet.Text);
            komut.Parameters.AddWithValue("@URUNFIYAT", urunFiyat.Text);
            komut.Parameters.AddWithValue("@URUNMALIYET", urunMaliyet.Text);
            komut.Parameters.AddWithValue("@URUNID", urunID.Text);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            getir();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM URUN WHERE URUNID=@URUNID";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@URUNID", Convert.ToInt32(urunID.Text));

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            getir();

        }
    }
}
