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

namespace TeknikServis.Formlar
{
    public partial class FrmCariİller : Form
    {
        public FrmCariİller()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-T8MH2CT\SQLKORKUT;Initial Catalog=DbTeknikServis;Integrated Security=True");
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmCariİller_Load(object sender, EventArgs e)
        {
           // chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 22);
            //chartControl1.Series["Series 1"].Points.AddPoint("İstanbul", 12);
           // chartControl1.Series["Series 1"].Points.AddPoint("İzmir",8);

            //chartControl1.Series["Series 1"].Points.AddPoint("Bursa", 14);

            gridControl1.DataSource = db.TBLCARIs.OrderBy(x => x.İL).
                GroupBy(y => y.İL).
                Select(z => new { İL = z.Key, TOPLAM = z.Count() }).ToList();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select İL , COUNT (*) FROM TBLCARI group by İL", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]),int.Parse( dr[1].ToString()));
            }
            baglanti.Close();
        }
    }
}
