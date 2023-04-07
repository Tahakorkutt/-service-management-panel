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
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLCARIs
                                      select new
                                      {
                                          x.AD,
                                          x.ID,
                                          x.SOYAD,
                                          x.İL,
                                          x.İLCE
                                      };
            gridControl1.DataSource = degerler.ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLCARI t = new TBLCARI();
            t.AD = TxtAd.Text;
            t.SOYAD = TxtSoyad.Text;
            t.İL = lookUpEdit2.Text;
            t.İLCE = lookUpEdit3.Text;
            db.TBLCARIs.Add(t);
            db.SaveChanges();
            MessageBox.Show("Cari sisteme eklendi");

        }
    }
}
