using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            var degerler = db.TBLURUNs.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA)
                .Select(z => new
            {
                Marka = z.Key,
                Toplam = z.Count()
            });
            gridControl1.DataSource = degerler.ToList();
            chartControl1.Series["Series 1"].Points.AddPoint("Siemens", 4);
            chartControl1.Series["Series 1"].Points.AddPoint("Arçelik", 6);
            chartControl1.Series["Series 1"].Points.AddPoint("Vestel", 7);
            chartControl1.Series["Series 1"].Points.AddPoint("Beko", 2);
            chartControl1.Series["Series 1"].Points.AddPoint("LENOVO", 9);

            chartControl2.Series["KATEGORİLER"].Points.AddPoint("BEYAZ EŞYA", 6);
            chartControl2.Series["KATEGORİLER"].Points.AddPoint("BİLGİSAYAR", 7);
            chartControl2.Series["KATEGORİLER"].Points.AddPoint("KÜÇÜK EV ALETLERİ", 6);
            chartControl2.Series["KATEGORİLER"].Points.AddPoint("TV", 7);
            chartControl2.Series["KATEGORİLER"].Points.AddPoint("TELEFON", 1);
            chartControl2.Series["KATEGORİLER"].Points.AddPoint("DİĞER", 2);


        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
