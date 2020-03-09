using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Snooker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string elsoSor = "";
        List<versenyzo> lista = new List<versenyzo>();

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("snooker.txt"))
            {
                using (StreamReader sr = new StreamReader("snooker.txt", Encoding.UTF8))
                {
                    elsoSor = sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        string sor = sr.ReadLine();
                        int helyezes = int.Parse(sor.Split(';')[0]);
                        string nev = sor.Split(';')[1];
                        string orszag = sor.Split(';')[2];
                        int nyeremeny = int.Parse(sor.Split(';')[3]);

                        versenyzo v = new versenyzo(helyezes, nev, orszag, nyeremeny);
                        ListViewItem lvi = new ListViewItem(helyezes.ToString());
                        lvi.SubItems.Add(nev);
                        lvi.SubItems.Add(orszag);
                        lvi.SubItems.Add(nyeremeny.ToString());
                        listView1.Items.Add(lvi);

                        for (int i = 0; i < listView1.Columns.Count; i++)
                        {
                            listView1.Columns[i].Text = elsoSor.Split(';')[i];
                        }
                        textBox1.Text = listView1.Items.Count.ToString();
                        bool vanE = true;
                        foreach (var item in orszag)
                        {
                            if (item.ToString() == orszag)
                            {
                                vanE = false;
                                break;
                            }
                        }
                        if (vanE)
                        {
                            comboBox1.Items.Add(orszag);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nem létezik a snooker.txt", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);
            }
            /*if (listView1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    listView1.Items.RemoveAt(i);
                    listView1.SelectedItems.Clear();
                }
            }
            else
            {
                MessageBox.Show("Nincs kijelölt sor!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int osszeg = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                osszeg += int.Parse(item.SubItems[3].Text);
            }
            int atlag = osszeg / listView1.Items.Count;
            textBox2.Text = atlag.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[2].Text != comboBox1.SelectedItem.ToString())
                {
                    listView1.Items.Remove(item);
                }
            }
        }
    }
}