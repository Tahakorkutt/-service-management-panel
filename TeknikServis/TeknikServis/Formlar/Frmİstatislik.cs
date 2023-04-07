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
    public partial class Frmİstatislik : Form
    {
        public Frmİstatislik()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void Frmİstatislik_Load(object sender, EventArgs e)
        {
            labelControl2.Text = db.TBLURUNs.Count().ToString();
            labelControl3.Text = db.TBLKATEGORIs.Count().ToString();
            labelControl5.Text = db.TBLURUNs.Sum(x => x.STOK).ToString();
            labelControl9.Text = (from x in db.TBLURUNs
                                   orderby x.STOK descending
                                   select x.AD).FirstOrDefault();
            labelControl11.Text = (from x in db.TBLURUNs
                                   orderby x.STOK ascending
                                   select x.AD).FirstOrDefault();
            labelControl15.Text = (from x in db.TBLURUNs
                                   orderby x.SATISFIYAT descending
                                   select x.AD).FirstOrDefault();
            labelControl31.Text = (from x in db.TBLURUNs
                                   select x.MARKA).Distinct().Count().ToString();
            labelControl17.Text = db.TBLURUNs.Count(x => x.KATEGORI == 3).ToString();
            labelControl19.Text = db.TBLURUNs.Count(x => x.KATEGORI == 4).ToString();
        }

        private void pictureEdit5_EditValueChanged(object sender, EventArgs e)
        {
                    }
    }
}
