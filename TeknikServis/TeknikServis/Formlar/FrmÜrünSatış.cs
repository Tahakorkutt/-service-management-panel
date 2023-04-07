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
    public partial class FrmÜrünSatış : Form
    {
        public FrmÜrünSatış()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUNHAREKET t = new TBLURUNHAREKET();
            t.URUN = int.Parse(TxtID.Text);
            t.MUSTERI = int.Parse(TxtMusteri.Text);
            t.PERSONEL = short.Parse(TxtPersonel.Text);
            t.TARIH = DateTime.Parse(TxtTarih.Text);
            t.ADET = short.Parse(TxtAdet.Text);
            t.FİYAT = decimal.Parse(TxtSatışFiyat.Text);
            t.URUNSERINO = TxtSeriNo.Text;
            db.TBLURUNHAREKETs.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Satış Yapıldı");


        }

        private void BtnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
