﻿using System;
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
    public partial class FrmArizaListesi : Form
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLURUNKABULs
                           select new
                           {
                               x.ISLEMID,
                               
                             CARI = x.TBLCARI.AD + x.TBLCARI.SOYAD,
                             PERSONEL = x.TBLPERSONEL.AD + x.TBLPERSONEL.SOYAD,
                             x.GELISTARIH,
                             x.CIKISTARIHI,
                             x.URUNSERINO
                              
                           };
            gridControl1.DataSource = degerler.ToList();

        }
    }
}
