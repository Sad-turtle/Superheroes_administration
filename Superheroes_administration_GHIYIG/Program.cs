using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Superheroes_administration_GHIYIG
{
    class Program
    {
        static void AllHeroes(Heroes[] h)
        {
            for (int i = 0; i < h.Length; i++)
            {
                Console.WriteLine(h[i].Display());
            }
        }
        static int WhichHero(Heroes[] h, string name)
        {
            int i = 0;
            while (i < h.Length && h[i].SuperName != name)
            {
                i++;
            }
            if (i < h.Length)
            {
                return i;
            }
            else
            {
                return -1;
            }
        }

        static string SearchSuperpowerBySupername(Heroes[] h, string supername)
        {
            int i = 0;
            while (i < h.Length && h[i].SuperName != supername)
            {
                i++;
            }
            if (i < h.Length)
            {
                return h[i].UniquePower;
            }
            else
            {
                return "There is no such hero!";

            }
        }
        static void DistributionInCity(Heroes[] h, string city)
        {
            int herocounter = 0;
            for (int i = 0; i < h.Length; i++)
            {
                
                if (h[i].City == city)
                {
                    herocounter++;
                }

            }
            Console.WriteLine($"There are {herocounter} heroes in {city}");
        }

        static void ListHeroesInCity(Heroes[] h, string city)
        {
            for (int i = 0; i < h.Length; i++)
            {
                if (h[i].City == city)
                {
                    Console.WriteLine(h[i].Display());
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("File name: ");
            string filename = Console.ReadLine();
            

            int menu;
            do
            {
                HeroesManager hm = new HeroesManager(filename);
                Console.WriteLine("1 - List all heroes");
                Console.WriteLine("2 - Modify the hero's side");
                Console.WriteLine("3 - Modify the hero's city");
                Console.WriteLine("4 - Search for the superpower by super name");
                Console.WriteLine("5 - Distribution of heroes in cities");
                Console.WriteLine("6 - List heroes of one specific city");
                Console.WriteLine("7 - Register new superhero");

                Console.WriteLine("0 - Quit");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        AllHeroes(hm.Heroes);
                        break;
                    case 2:
                        Console.WriteLine("Give super name of hero who changed his side : ");
                        string supername = Console.ReadLine();
                        int index = WhichHero(hm.Heroes, supername);
                        if (index != -1)
                        {
                            
                            Console.WriteLine("He/she became evil or good?");
                            string new_side = Console.ReadLine();
                            if (new_side == "evil" || new_side == "good")
                            {
                                hm.Heroes[index].Side = new_side;
                            }
                            else
                            {
                                Console.WriteLine("it is wrong side, so hero's data remains same");

                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("This hero couldn't be found, maybe you've entered wrong supername?");

                        }
                        break;
                    case 3:
                        Console.WriteLine("Give super name of hero who changed city :");
                        string supname = Console.ReadLine();
                        int i = WhichHero(hm.Heroes, supname);
                        if (i != -1)
                        {
                            Console.WriteLine("New City:");
                            string new_city = Console.ReadLine();
                            hm.Heroes[i].City = new_city;
                        }
                        else
                        {
                            Console.WriteLine("This hero couldn't be found, maybe you've entered wrong supername?");

                        }
                        break;
                    case 4:
                        Console.WriteLine("Write super name of hero: ");
                        string sprname = Console.ReadLine();
                        Console.WriteLine($" Superpower of hero {sprname}: " + SearchSuperpowerBySupername(hm.Heroes, sprname));
                        break;
                    case 5:
                        Console.WriteLine("Distribution of heroes in cities:");
                        // Need to display each city only once, so I used this code below
                        for(int inx=0; inx< hm.Heroes.Length; inx++)
                        {
                            bool isDuplicate = false;
                            for(int j =0; j<inx; j++) 
                            {
                                if(hm.Heroes[inx].City==hm.Heroes[j].City)
                                {
                                    isDuplicate = true;
                                    break;
                                }
                            }
                            if (!isDuplicate)
                            {
                                DistributionInCity(hm.Heroes, hm.Heroes[inx].City);
                            }

                        }
                        break;
                    case 6:
                        Console.WriteLine("Name of the city: ");
                        string cityname = Console.ReadLine();
                        ListHeroesInCity(hm.Heroes, cityname);
                        break;
                    case 7:
                        Console.WriteLine("Write the true name of the new hero: ");
                        string truename = Console.ReadLine();
                        Console.WriteLine("Write the super name of the new hero: ");
                        string superName = Console.ReadLine();
                        Console.WriteLine("Write the year of birth of the new hero: ");
                        int yearofbirth = int.Parse(Console.ReadLine());
                        bool rightside = false;
                        string side = "";
                        do
                        {
                            Console.WriteLine("Write the side of the new hero (evil or good): ");
                            side = Console.ReadLine();
                            if (side == "evil" || side == "good")
                            {
                                rightside = true;
                            }
                            else
                            {
                                Console.WriteLine("You have entered wrong Side of hero, it should be either 'good' or 'evil'");
                            }
                        } while (!rightside);
      
                
                bool rightformat = false;
                        string powerclass= "";
                        do
                        {
                            Console.WriteLine("Write the power class of the new hero (Intelligence, Agility or Strength): ");
                            powerclass = Console.ReadLine();
                            if (powerclass == "Agility" || powerclass == "Intelligence" || powerclass == "Strength")
                            {
                                rightformat = true;
                            }
                            else
                            {
                                Console.WriteLine("You have entered wrong Power Class, it should be one of the following: Strength, Agility or Intelligence");
                            }
                        } while (!rightformat);

                        Console.WriteLine("Write the unique power of the new hero: ");
                        string uniquepower = Console.ReadLine();
                        Console.WriteLine("Write the city of the new hero: ");
                        string City = Console.ReadLine();
                        string new_hero = truename + "*" + superName + "*" + yearofbirth + "*" + side + "*" + powerclass + "*" + uniquepower + "*" + City + "*";
                        hm.SaveToFile(filename, new_hero);
                        break;
                }

            } while (menu != 0);
            
        }
    }
}

