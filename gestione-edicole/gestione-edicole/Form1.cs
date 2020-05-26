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
        struct articolo
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
        int num = 0;
        public Form1()
        {
            InitializeComponent();
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
            articolo nuovo;
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
    }
}
