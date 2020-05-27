using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gestione_edicole
{
    class Class1
    {

        static public int Max(Form1.articolo[] ele, int num)
        {
            if (num == 0)
                return -1;
            int x = default;
            int max = default;
            while (x < num)
            {
                if (ele[x].prezzo < max)
                {
                    max = x;
                }
                x++;
            }
            return max;
        }

        static public int Min(Form1.articolo[] ele, int num)
        {
            if (num == 0)
                return -1;
            int x = default;
            int min = default;
            while (x < num)
            {
                if (ele[x].prezzo > min)
                {
                    min = x;
                }
                x++;
            }
            return min;
        }

        static public decimal Media(Form1.articolo[] ele, int num)
        {
            if (num == 0)
                return -1;
            decimal somma = 0;
            int x = default;
            while (x < num)
            {
                somma += ele[x].prezzo;
                x++;
            }
            somma = somma / num;
            return somma;
        }

        public static void ordinatipo(Form1.articolo[] elep, int num)   //ordina per tipo
        {
            Form1.articolo temp = default(Form1.articolo);
            int x = 0;
            int y = 0;
            while (x < num)
            {
                y = x + 1;
                while (y < num)
                {
                    if (string.Compare(elep[x].tipo, elep[y].tipo) > 0)
                    {
                        temp = elep[x];
                        elep[x] = elep[y];
                        elep[y] = temp;
                    }
                    y++;
                }
                x++;
            }
        }

        public static void ordinaprezzo(Form1.articolo[] elep, int num)        //ordina per prezzo
        {
            Form1.articolo temp = default(Form1.articolo);
            int x = 0;
            int y = 0;
            while (x < num)
            {
                y = x + 1;
                while (y < num)
                {
                    if (elep[x].prezzo > elep[y].prezzo)
                    {
                        temp = elep[x];
                        elep[x] = elep[y];
                        elep[y] = temp;
                    }
                    y++;
                }
                x++;
            }

        }
        //cerca la posizione nel vettore
        public static int cercaPos(Form1.articolo[] elep, int num, string codice)
        {
            int x = default(int);
            int pos = default(int);
            while (x < num)
            {
                if (string.Compare(elep[x].codice, codice) == 0)
                {
                    pos = x;
                }
                x++;
            }
            return pos;
        }

        public static bool elimina(Form1.articolo[] elep, ref int num, string codice)
        {
            
            int x = default(int);
            
            while (x < num)
            {

                if (codice == elep[x].nome)
                {
                    elep[x] = elep[num];
                    num--;
                    return true;
                    
                }
                x++;
            }
            return false;
            
        }

        public static int cerca(Form1.articolo[] elep, int num, string codice)
        {
            int x = default(int);
            int pos = default(int);
            while (x < num)
            {
                if (string.Compare(elep[x].codice, codice) == 0)
                {
                    pos = x;
                }
                x++;
            }
            return pos;
        }

        public static void LeggiDaFile(Form1.articolo[] elep, ref int num, string nomefile)    //Leggi da file
        {
            Form1.articolo newprod = default(Form1.articolo);
            StreamReader miofile;
            miofile = new StreamReader(nomefile);
            while (miofile.EndOfStream == false)
            {
                newprod.nome = miofile.ReadLine();
                newprod.autore = miofile.ReadLine();
                newprod.prezzo = decimal.Parse(miofile.ReadLine());
                newprod.codice = miofile.ReadLine();
                newprod.quantita = int.Parse(miofile.ReadLine());
                newprod.tipo = miofile.ReadLine();
                elep[num] = newprod;
                num++;
            }
            miofile.Close();
        }

        public static void Salvasufile(Form1.articolo[] elep, string nomefile, int num)    //salva su file
        {
            StreamWriter miofile;
            miofile = new StreamWriter(nomefile);
            int x = 0;
            while (x < num)
            {
                miofile.WriteLine(elep[x].nome);
                miofile.WriteLine(elep[x].autore);
                miofile.WriteLine(elep[x].prezzo);
                miofile.WriteLine(elep[x].codice);
                miofile.WriteLine(elep[x].quantita);
                miofile.WriteLine(elep[x].tipo);
                x++;
            }
            miofile.Close();
        }

        public static void Filtra(Form1.articolo[] e, Form1.articolo[] ef, int num, ref int numf, string filtro)
        {
            int x = 0;
            while (x < num)
            {
                if (e[x].tipo == filtro)
                {
                    ef[numf] = e[x];
                    numf++;
                }
                x++;
            }
        }
    }
}
