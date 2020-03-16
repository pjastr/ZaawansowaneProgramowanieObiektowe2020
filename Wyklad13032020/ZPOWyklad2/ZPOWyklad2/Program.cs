using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPOWyklad2
{
    class Program
    {
        static void Main(string[] args)
        {
            ISport os= new Osoba();
            os.Graj();
            Console.ReadKey();

        }
    }

    interface ISport
    {
        void Graj();
    }

    class Osoba : ISport
    {
        public void Graj() //niejawna
        {
            Console.WriteLine("Niejawna");
        }

        void ISport.Graj() //jawna
        {
            Console.WriteLine("jawna");
        }
    }
}
