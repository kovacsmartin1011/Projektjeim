using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komplex_beadando
{
    internal class Program
    {
        Program()
        {
            string[] n  = Console.ReadLine().Split(' ');
            int tel = int.Parse(n[0]);
            int nap = int.Parse(n[1]);

            if(tel < 1 || tel > 1000 || nap < 1 || nap > 1000)
            {
                Environment.Exit(0);
            }

            int[,] hom  = new int[tel, nap];
            for (int i = 0; i < tel; i++)
            {
                string[] sorok = Console.ReadLine().Split(' ');
                for (int j = 0; j < nap; j++)
                {
                    hom[i, j] = int.Parse(sorok[j]);
                    if (int.Parse(sorok[j]) > 50 || int.Parse(sorok[j]) < -50)
                    {
                        Environment.Exit(0);
                    }
                }
            }

            int maxKul = maxKulF(hom, tel, nap).Max();
            List<int> telList = new List<int>();
            for(int i = 0; i < tel; i++)
            {
                if (maxKulF(hom, tel, nap)[i] == maxKul)
                {
                    telList.Add(i);
                }
            }
            int telListDb = telList.Count;
            Console.Write(telListDb);
            foreach(int e in telList)
            {
                Console.Write(" " + string.Join(" ", e + 1));
            }
        }

        public static int[] maxKulF(int[,] hom, int tel, int nap)
        {
            int[] maxKulT = new int[tel];

            for (int i = 0; i < tel; i++)
            {
                int maxHom = int.MinValue;
                int minHom = int.MaxValue;

                for (int j = 0; j < nap; j++)
                {
                    maxHom = Math.Max(maxHom, hom[i, j]);
                    minHom = Math.Min(minHom, hom[i, j]);
                }

                maxKulT[i] = maxHom - minHom;
            }

            return maxKulT;
        }
        static void Main(string[] args)
        {
            new Program();
            Console.ReadKey();
        }
    }
}
