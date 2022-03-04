using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Superheroes_administration_GHIYIG
{
    class HeroesManager
    {
        private Heroes[] heroes;

        public Heroes[] Heroes
        {
            get { return heroes; }
        }

        public HeroesManager(string filename)
        {
            StreamReader f = new StreamReader(filename);
            heroes = new Heroes[LineCounter(filename)];
            int i = 0;
            while(!f.EndOfStream)
            {
                heroes[i] = new Heroes(f.ReadLine());
                i++;
            }
            f.Close();
        }

        public void SaveToFile(string fname, string line)
        {
            StreamWriter f = new StreamWriter(fname, true);
            f.WriteLine(line);
            f.Close();

        }
        private int LineCounter(string filename)
        {
            int counter = 0;
            StreamReader f = new StreamReader(filename);
            while (!f.EndOfStream)
            {
                f.ReadLine();
                counter++;
            }
            f.Close();
            return counter;
        }
    }
}
