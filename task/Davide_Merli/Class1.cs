using System;
using System.Collections.Generic;
using System.Text;

namespace task
{
    public class Class1
    {
        // metodo compatto
        public int Numero { get; set; }

        // metodo più lungo, ma con cui puoi fare operazioni particolari

        //private int numero;

        //public int Numero
        //{
        //    get { return numero; }
        //    set { numero = value; }
        //}

        public void Ciao()
        {
            Numero = 2;
            Console.WriteLine("Numero: " + Numero);
        }

        public static void Main()
        {
            Class1 c = new Class1();
            c.Ciao();
        }
    }
}