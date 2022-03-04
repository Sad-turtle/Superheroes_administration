using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Superheroes_administration_GHIYIG
{
    class Heroes
    {
        private string powerclass;
        private string side;

        public string TrueName { get; set; }
        public string SuperName { get; set; }
        public int YearOfBirth { get; set; }
        public string Side 
        {
            get
            {
                return side;
            }
            set
            {
                if (value == "good" || value == "evil")
                {
                    side = value;
                }


            }
        }
        public string PowerClass
        {
            get
            {
                return powerclass;
            }
            set
            {
                if (value == "Agility" || value == "Intelligence" || value == "Strength")
                {
                    powerclass = value;
                }
            }
        }
        public string UniquePower { get; set; }
        public string City { get; set; }


        public Heroes(string line)
        {

            int i;
            i = line.IndexOf("*");
            this.TrueName = line.Substring(0, i);
            line = line.Remove(0, i + 1);
            i = line.IndexOf("*");
            this.SuperName = line.Substring(0, i);
            line = line.Remove(0, i + 1);
            i = line.IndexOf("*");
            this.YearOfBirth = int.Parse(line.Substring(0, i));
            line = line.Remove(0, i + 1);
            i = line.IndexOf("*");
            this.Side = line.Substring(0, i);
            line = line.Remove(0, i + 1);
            i = line.IndexOf("*");
            this.PowerClass = line.Substring(0, i);
            line = line.Remove(0, i + 1);
            i = line.IndexOf("*");
            this.UniquePower = line.Substring(0, i);
            line = line.Remove(0, i + 1);
            i = line.IndexOf("*");
            this.City = line.Substring(0, i);
              
        }


        public string Display()
        {
            return $"Hero's true name: {TrueName}\n" +
                $"Hero's 'super' name: {SuperName}\n" +
                $"Year of birth: {YearOfBirth} \n" +
                $"Side: {Side}\n" +
                $"Power Class: {PowerClass}\n" +
                $"Unique power: {UniquePower}\n" +
                $"City: {City}\n";
        }

    }
}
