using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestione_edicole
{
    public partial class Form1 : Form
    {
        public struct articolo
        {
            public string nome;
            public decimal prezzo;
            public string autore;
            public DateTime Data;
            public string codice;
            public string tipo;
            public int quantita;
        
        }
        articolo[] ele = new articolo[100];
        articolo nuovo=default(articolo);
        int num = 0;
        int numf = 0;
        public Form1()
        {
            InitializeComponent();

            textBox5.Enabled = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            //textBox11.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Compilare tutti i campi");
                return;
            }
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false)
            {
                MessageBox.Show("Inserire Tipo dell'articolo");
                return;
            }
           
            nuovo.tipo = "sas"; //per evitare che dopo dia errore
            nuovo.nome = textBox1.Text;
            nuovo.prezzo = Decimal.Parse(textBox3.Text);
            nuovo.autore = textBox2.Text;
            nuovo.Data = DateTime.Now;
            nuovo.quantita = int.Parse(textBox4.Text);
            nuovo.codice = textBox6.Text;
            if (radioButton1.Checked == true)
            {
                nuovo.tipo = "giornale";
            }
            if (radioButton2.Checked == true)
            {
                nuovo.tipo = "libro";
            }
            if (radioButton3.Checked == true)
            {
                nuovo.tipo = "rivista";
            }
            if (radioButton4.Checked == true)
            {
                nuovo.tipo = "materiale";
            }
            ele[num] = nuovo;
            num++;

            var row = new string[] { nuovo.nome, nuovo.autore, nuovo.prezzo.ToString(), nuovo.codice, nuovo.quantita.ToString(), nuovo.tipo };
            var listrow = new ListViewItem(row);
            var listrow4 = new ListViewItem(row);
            listView1.Items.Add(listrow);
            

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();

            

            //Funzioni delle info
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            //String a = (e.KeyCode).ToString();
            //char b = Char.Parse(a);
            //if (!(Char.IsNumber(b)))
            //{
            //    MessageBox.Show("Non puoi inserire lettere in questo campo");
            //    textBox3.Clear();
            //}

            //char.Parse((e.KeyCode).ToString());

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.B || e.KeyCode == Keys.C || e.KeyCode == Keys.D || e.KeyCode == Keys.E || e.KeyCode == Keys.F || e.KeyCode == Keys.G || e.KeyCode == Keys.H || e.KeyCode == Keys.I || e.KeyCode == Keys.J || e.KeyCode == Keys.K || e.KeyCode == Keys.L || e.KeyCode == Keys.M || e.KeyCode == Keys.N || e.KeyCode == Keys.O || e.KeyCode == Keys.P || e.KeyCode == Keys.Q || e.KeyCode == Keys.R || e.KeyCode == Keys.S || e.KeyCode == Keys.T || e.KeyCode == Keys.U || e.KeyCode == Keys.V || e.KeyCode == Keys.W || e.KeyCode == Keys.X || e.KeyCode == Keys.Y || e.KeyCode == Keys.Z)
            {
                MessageBox.Show("Non puoi inserire lettere in questo campo");
                textBox3.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = Class1.Max(ele , num);
            label11.Text = (ele[x].prezzo).ToString();

            x = Class1.Min(ele, num);
            label12.Text = (ele[x].prezzo).ToString();

            decimal med = Class1.Media(ele, num);
            label13.Text = (med).ToString();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void caricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel3.Visible = false;
        }

        private void btn_aggiorna_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();



            if (radioButton5.Checked == false && radioButton6.Checked == false && radioButton7.Checked == false && radioButton8.Checked == false)
            {
                int x = default(int);
                while (x < num)
                {
                    var row = new string[] { ele[x].nome, ele[x].autore, ele[x].prezzo.ToString(), ele[x].codice, ele[x].quantita.ToString(), ele[x].tipo };
                    var listrow4 = new ListViewItem(row);
                    listView1.Items.Add(listrow4);
                    x++;
                }
                return;
            }


            articolo[] elef = new articolo[num];
            int numf = 0;

            if (radioButton5.Checked == true)
            {
                string filtro = "rivista";
                Class1.Filtra(ele,  elef, num, ref numf, filtro);
            }

            if (radioButton6.Checked == true)
            {
                string filtro = "giornale";
                Class1.Filtra(ele, elef, num, ref numf, filtro);
            }

            if (radioButton7.Checked == true)
            {
                string filtro = "libro";
                Class1.Filtra(ele,  elef, num, ref numf, filtro);
            }

            if (radioButton8.Checked == true)
            {
                string filtro = "materiale";
                Class1.Filtra(ele,  elef, num, ref numf, filtro);
            }

            int y = default(int);
            while (y < numf)
            {
                var row = new string[] { elef[y].nome, elef[y].autore, elef[y].prezzo.ToString(), elef[y].codice, elef[y].quantita.ToString(), elef[y].tipo };
                var listrow4 = new ListViewItem(row);
                listView1.Items.Add(listrow4);
                y++;
            }

            numf = 0;

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


            int k = listView1.SelectedIndices.Count;
            if (k == 0)
            {
                return;
            }
            int pos = Class1.cercaPos(ele, num, listView1.SelectedItems[0].SubItems[0].Text);
            textBox5.Text = ele[pos].nome;
            textBox7.Text = ele[pos].autore;
            textBox8.Text = ele[pos].prezzo.ToString();
            textBox9.Text = ele[pos].codice;
            textBox10.Text = ele[pos].quantita.ToString();

            if (ele[pos].tipo == "giornale")
                radioButton12.Checked = true;

            if (ele[pos].tipo == "libro")
                radioButton11.Checked = true;

            if (ele[pos].tipo == "rivista")
                radioButton10.Checked = true;

            if (ele[pos].tipo == "materiale")
                radioButton9.Checked = true;

            //textBox11.Text = ele[pos].tipo;

            textBox5.Enabled = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
            //textBox11.Visible = true;
        }

        private void btn_modi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) == true || string.IsNullOrEmpty(textBox7.Text) == true || string.IsNullOrEmpty(textBox8.Text) == true || string.IsNullOrEmpty(textBox9.Text) == true || string.IsNullOrEmpty(textBox10.Text) == true) //|| string.IsNullOrEmpty(textBox11.Text) == true
            {
                MessageBox.Show("completare tutti i campi");
                return;
            }
            articolo k = default(articolo);
            k.nome = textBox5.Text;
            k.autore = textBox7.Text;
            k.prezzo = decimal.Parse(textBox8.Text);
            k.codice = textBox9.Text;
            k.quantita = int.Parse(textBox10.Text);
            //k.tipo ="libro";
            if (radioButton10.Checked == true)
                k.tipo = "rivista";

            if (radioButton9.Checked == true)
                k.tipo = "materiale";

            if (radioButton11.Checked == true)
                k.tipo = "libro";

            if (radioButton12.Checked == true)
                k.tipo = "giornale";


            try
            {
                k.prezzo = decimal.Parse(textBox8.Text);
                k.quantita = int.Parse(textBox10.Text);
            }
            catch
            {
                MessageBox.Show("dati inseriti scorretti");
                return;
            }

            int x = listView1.SelectedIndices.Count;
            if (x == 0)
            {
                return;
            }
            int pos = Class1.cerca(ele, num, listView1.SelectedItems[0].SubItems[0].Text);
            ele[pos] = k;
            
            textBox5.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            //textBox11.Clear();
            MessageBox.Show("dati modificati correttamente");
            btn_aggiorna.PerformClick();
        }

        private void radio_prezzo_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (radio_prezzo.Checked == true)
            {
                Class1.ordinaprezzo(ele, num);
            }

            int x = default(int);
            while (x < num)
            {
                var row = new string[] { ele[x].nome, ele[x].autore, ele[x].prezzo.ToString(), ele[x].codice, ele[x].quantita.ToString(), ele[x].tipo };
                var listrow = new ListViewItem(row);
                listView1.Items.Add(listrow);
                x++;
            }
        }

        private void radio_tipo_CheckedChanged(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            if (radio_tipo.Checked == true)
            {
                Class1.ordinatipo(ele, num);
            }

            int x = default(int);
            while (x < num)
            {
                var row = new string[] { ele[x].nome, ele[x].autore, ele[x].prezzo.ToString(), ele[x].codice, ele[x].quantita.ToString(), ele[x].tipo };
                var listrow = new ListViewItem(row);
                listView1.Items.Add(listrow);
                x++;
            }
        }

        private void btn_eli_Click(object sender, EventArgs e)
        {
            int k = listView1.SelectedIndices.Count;
            if (k == 0)
            {
                return;
            }
            bool el = Class1.elimina(ele, ref num, listView1.SelectedItems[0].SubItems[0].Text);
            if (el == true)
            {
                MessageBox.Show("programma eliminato");

                btn_aggiorna_Click(sender, e);

                textBox5.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                //textBox11.Clear();

                textBox5.Enabled = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                //textBox11.Visible = false;
                return;
                
            }
        }

        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = false;
            
        }

        private void inserireNomeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            string nomeFile = textBox12.Text;
            Class1.LeggiDaFile(ele, ref num, nomeFile);
            var row = new string[] { nuovo.nome, nuovo.autore, nuovo.prezzo.ToString(), nuovo.codice, nuovo.quantita.ToString(), nuovo.tipo };
            var listrow = new ListViewItem(row);
            var listrow4 = new ListViewItem(row);
            listView1.Items.Add(listrow);
            MessageBox.Show("file caricato con successo");
        }

    

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            string nomeF = textBox14.Text;
            Class1.Salvasufile(ele, nomeF, num);
            MessageBox.Show("file salvato con successo");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point(289, 133);
            panel3.Location = new Point(289, 133);

            ele[num].nome = "mario";
            ele[num].codice = "vovo";
            ele[num].quantita = 777;
            ele[num].prezzo = 1.50M;
            ele[num].tipo = "giornale";
            ele[num].Data = DateTime.Now;
            num++;

            ele[num].nome = "marsio";
            ele[num].codice = "vovso";
            ele[num].quantita = 7772;
            ele[num].prezzo = 1.50M;
            ele[num].tipo = "rivista";
            ele[num].Data = DateTime.Now;
            num++;

            ele[num].nome = "marddfio";
            ele[num].codice = "vodfvo";
            ele[num].quantita = 73277;
            ele[num].prezzo = 132.50M;
            ele[num].tipo = "materiale";
            ele[num].Data = DateTime.Now;
            num++;

            ele[num].nome = "marssio";
            ele[num].codice = "vovssso";
            ele[num].quantita = 7772;
            ele[num].prezzo = 21.50M;
            ele[num].tipo = "libro";
            ele[num].Data = DateTime.Now;
            num++;
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.B || e.KeyCode == Keys.C || e.KeyCode == Keys.D || e.KeyCode == Keys.E || e.KeyCode == Keys.F || e.KeyCode == Keys.G || e.KeyCode == Keys.H || e.KeyCode == Keys.I || e.KeyCode == Keys.J || e.KeyCode == Keys.K || e.KeyCode == Keys.L || e.KeyCode == Keys.M || e.KeyCode == Keys.N || e.KeyCode == Keys.O || e.KeyCode == Keys.P || e.KeyCode == Keys.Q || e.KeyCode == Keys.R || e.KeyCode == Keys.S || e.KeyCode == Keys.T || e.KeyCode == Keys.U || e.KeyCode == Keys.V || e.KeyCode == Keys.W || e.KeyCode == Keys.X || e.KeyCode == Keys.Y || e.KeyCode == Keys.Z)
            {
                MessageBox.Show("Non puoi inserire lettere in questo campo");
                textBox4.Clear();
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;

        }
    }
}
