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
    public partial class FrnYeniUrun : Form
    {
        public FrnYeniUrun()
        {
            InitializeComponent();
        }

        private void FrnYeniUrun_Load(object sender, EventArgs e)
        {

        }

        private void BtnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DbTeknikServisEntities db = new DbTeknikServisEntities();
            TBLURUN t = new TBLURUN();
            t.AD = TxtUrunAd.Text;
            t.ALISFIYAT = decimal.Parse(TxtAlısFıyat.Text);
            t.SATISFIYAT = decimal.Parse(TxtSatısFıyat.Text);
            t.STOK = short.Parse(TxtStok.Text);
            t.MARKA = TxtMarkaA.Text;
       
            t.KATEGORI = byte.Parse(TxtKategori.Text);
            db.TBLURUNs.Add(t);
            db.SaveChanges();
        
            MessageBox.Show("Ürünler Kaydedildi");
        }

        private void TxtUrunAd_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void TxtUrunAd_Click(object sender, EventArgs e)
        {
            TxtUrunAd.Text = "";
            TxtUrunAd.Focus();
        }
    }
}
