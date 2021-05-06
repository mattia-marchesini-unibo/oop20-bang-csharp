using System;
using System.Collections.Generic;
using System.Text;

namespace task.Davide_Merli
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
            // I'm just here to test stuff, please don't mind me
        }

    }
}