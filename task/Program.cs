using model;
using model.deck;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace task
{
    class Program
    {
        public static void Main()
        {
            Table table = new Table(new Deck(), 4);
            var p = table.CurrentPlayer;
            var list = table.Players;
            var pDx = list.GetNextOf(p);
            var pSx = list.GetPrevOf(p);
            var l = new Logics(table);
            Console.WriteLine("lista giocatori" );
            list.ForEach(p => Console.WriteLine(p.Name));
            Console.WriteLine("lista target" );
            l.GetTargets().ToList().ForEach(p => Console.WriteLine(p.Name));
            Console.WriteLine("pdx" + pDx.Name);
            Console.WriteLine("psx" + pSx.Name);
        }
    }
}
