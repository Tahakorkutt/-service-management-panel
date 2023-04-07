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
    public partial class FrmCariEkle : Form
    {
        public FrmCariEkle()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void BtnKaydet_Click(object sender, EventArgs e)
        { TBLCARI t = new TBLCARI();
            t.AD = TxtAd.Text;
            t.SOYAD = TxtSoyad.Text;
            t.İL = Txtİl.Text;
            t.İLCE = Txtİlçe.Text;
            db.TBLCARIs.Add(t);
            db.SaveChanges();
            MessageBox.Show("Yeni Cari Sisteme Başarılı " +
                "Bir Şekilde Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information
                );
       

        }

        private void BtnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
