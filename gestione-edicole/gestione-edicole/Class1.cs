using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
