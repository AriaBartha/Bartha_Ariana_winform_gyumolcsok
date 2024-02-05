using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_gyumolcsok
{
    public partial class GyumolcsAdatok : Form
    {
        public GyumolcsAdatok()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormGyumolcs formGyumolcs = new FormGyumolcs("add");
            formGyumolcs.ShowDialog();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if(listBoxFruitList.SelectedIndex < 0) 
            {
                MessageBox.Show("Nincs kiválasztva gyümölcs!");
                return;
            }
            Gyumolcs gyumolcs = (Gyumolcs)listBoxFruitList.SelectedItem;
            listBoxFruitList.Items.Remove(gyumolcs);
            FormGyumolcs formGyumolcs = new FormGyumolcs("edit", gyumolcs);
            formGyumolcs.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(listBoxFruitList.SelectedIndex < 0)
            {
                MessageBox.Show("Nincs kiválasztva gyümölcs!");
                return;
            }
            Gyumolcs gyumolcs = (Gyumolcs)listBoxFruitList.SelectedItem;
            listBoxFruitList.Items.Remove(gyumolcs);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                using (StreamWriter str = new StreamWriter(fileName))
                {
                    foreach (Gyumolcs item in listBoxFruitList.Items)
                    {
                        str.WriteLine(item.toTxt());
                    }
                    str.Flush();
                }
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            listBoxFruitList.Items.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            ofd.InitialDirectory = Environment.CurrentDirectory;

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                string fruitDataFile = ofd.FileName;
                using (StreamReader sr = new StreamReader(fruitDataFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(';');
                        Gyumolcs ujGyumolcs = new Gyumolcs(line[0], line[1], int.Parse(line[2]));
                        listBoxFruitList.Items.Add(ujGyumolcs);
                    }
                }
            }
        }       
    }
}
