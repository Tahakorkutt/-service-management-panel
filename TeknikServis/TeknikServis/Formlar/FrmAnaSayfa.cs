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
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            gridControl4.DataSource = (from x in db.TBLURUNs
                                       select new
                                       {
                                           x.AD,
                                           x.STOK

                                       }).Where(x => x.STOK < 50).ToList();
            gridControl1.DataSource = (from y in db.TBLCARIs
                                       select new
                                       {
                                           y.AD,
                                           y.SOYAD,
                                           y.İL

                                       }).ToList();
            gridControl3.DataSource = db.urunkategori().ToList();

            gridControl2.DataSource = (from Z in db.TBLNOTLARIMs
                                       select new
                                       {
                                           Z.ICERIK,
                                           Z.DURUM
                                          

                                       }).ToList();
        }
    }
}
