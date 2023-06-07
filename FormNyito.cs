using Kovacs_Istvan_12_console;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kovacs_Istvan_12_GUI
{
    public partial class FormNyito : Form
    {
        Database db = new Database();
        public FormNyito()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateKonyvek();
            updateVasarlok();
        }

        private void updateVasarlok()
        {
            lbVasarlok.Items.Clear();
            lbVasarlok.Items.AddRange(db.getVasarlo().ToArray());
        }

        private void updateKonyvek()
        {
            lbKonyvek.Items.Clear();
            lbKonyvek.Items.AddRange(db.getKonyv().ToArray());
        }

        private void btnVasarol_Click(object sender, EventArgs e)
        {
            if (lbKonyvek.SelectedIndex < 0)
            {
                MessageBox.Show("Nem választott könyvet!");
                return;
            }

            if (lbVasarlok.SelectedIndex < 0)
            {
                MessageBox.Show("Nem választott vásárlót!");
                return;
            }

            int darab = Convert.ToInt32(nudMennyiseg.Value);
            int konyvAzon = ((Konyv)lbKonyvek.SelectedItem).KonyvID;
            int vasarloAzon = ((Vasarlo)lbVasarlok.SelectedItem).VasarloID;

            db.insertVasarlas(konyvAzon, vasarloAzon, darab);
        }
    }
}
