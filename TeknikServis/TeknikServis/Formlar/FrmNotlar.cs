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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TBLNOTLARIMs.Where(x => x.DURUM == false).ToList();
            gridControl2.DataSource = db.TBLNOTLARIMs.Where(y => y.DURUM == true).ToList();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLNOTLARIM t = new TBLNOTLARIM();
            t.BASLIK = TxtBaslik.Text;
            t.ICERIK = Txtİçerik.Text;
            t.DURUM = false;
            db.TBLNOTLARIMs.Add(t);
            db.SaveChanges();
            MessageBox.Show("Not Başarıyla Kaydedilkdi", "Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if(checkEdit1.Checked == true)
            {
                int id = int.Parse(TxttID.Text);
                var deger = db.TBLNOTLARIMs.Find(id);
                
                deger.DURUM = true;
                
                db.SaveChanges();
                MessageBox.Show("Not durumu başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
          TxttID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();

        }
    }
}
