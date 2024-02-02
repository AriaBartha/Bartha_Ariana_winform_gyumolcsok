using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_gyumolcsok
{
    public partial class FormGyumolcs : Form
    {
        string muvelet;
        public FormGyumolcs(string muvelet, Object param=null)
        {
            InitializeComponent();
            this.muvelet = muvelet;
            switch (muvelet)
            {
                case "add":
                    this.Text = "Új gyümölcs hozzáadása";
                    buttonMuvelet.Text = "Hozzáad";
                    buttonMuvelet.BackColor = Color.LightGreen;
                    break;
                case "edit":
                    this.Text = "Adatok módosítása";
                    buttonMuvelet.Text = "Módosít";
                    buttonMuvelet.BackColor = Color.Aqua;
                    Gyumolcs gyumolcs = (Gyumolcs)param;
                    textBoxCode.Text = gyumolcs.Code.ToString();
                    textBoxName.Text = gyumolcs.Name.ToString();
                    nuAmount.Value = (int)gyumolcs.Amount;
                    break;
                default:
                    break;
            }
        }

        private void FormGyumolcs_Load(object sender, EventArgs e)
        {
           
        }

        private void buttonMuvelet_Click(object sender, EventArgs e)
        {
            switch (muvelet)
            {
                case "add":
                    addFruit();
                    break;
                case "edit":
                    updateFruit();
                    break;
            }
        }

        private void updateFruit()
        {
            ulong code = ulong.Parse(textBoxCode.Text);
            if (String.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Nem adott meg nevet!");
                textBoxName.Focus();
                return;
            }
            string name = textBoxName.Text;
            int amount = (int)nuAmount.Value;
            Gyumolcs gyumolcs = new Gyumolcs(code, name, amount);
            Program.nyitoForm.listBoxFruitList.Items.Add(gyumolcs);
            this.Close();
        }

        private void addFruit()
        {
            ulong code = (ulong)(Program.nyitoForm.listBoxFruitList.Items.Count + 1);
            if (String.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Nem adott meg nevet!");
                textBoxName.Focus();
                return;
            }
            string name = textBoxName.Text;
            int amount = (int)nuAmount.Value;
            Gyumolcs ujGyumolcs = new Gyumolcs(code, name, amount);
            Program.nyitoForm.listBoxFruitList.Items.Add(ujGyumolcs);
            this.Close();
        }

        
    }
}
