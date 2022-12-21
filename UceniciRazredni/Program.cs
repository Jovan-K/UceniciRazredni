using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UceniciRazredni
{
    class Osoba
    {
        string ime, prezime, jmbg;

        public Osoba() { }

        public Osoba(string ime, string prezime, string jmbg)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.jmbg = jmbg;
        }

        public string Ime { get { return ime; } set { ime = value; } }
        public string Prezime { get { return prezime; } set { prezime = value; } }
        public string Jmbg { get { return jmbg; } set { jmbg = value; } }

    }

    class Razredni : Osoba 
    {
        int razred, odeljenje;
        
        public Razredni () : base() { }

        public Razredni(int razred, int odeljenje, string ime, string prezime, string jmbg) : base(ime, prezime, jmbg) 
        {
            this.razred = razred;
            this.odeljenje = odeljenje;        
        }

        public int Razred { get { return razred; } set { razred = value; } }
        public int Odeljenje { get { return odeljenje; } set { odeljenje = value; } }

    }

    class Ucenik : Osoba 
    {
        public static int MAXNeopravdani;

        int razred, odeljenje;
        int opravdani, neopravdani;

        public Ucenik() : base() { }

        public Ucenik(int razred, int odeljenje, int opravdani, int neopravdani, string ime, string prezime, string jmbg) : base(ime, prezime, jmbg)
        {
            this.razred = razred;
            this.odeljenje = odeljenje;
            this.opravdani = opravdani;
            this.neopravdani = neopravdani;
        }

        public int Razred { get { return razred; } set { razred = value; } }
        public int Odeljenje { get { return odeljenje; } set { odeljenje = value; } }

        public int Opravdani { get { return opravdani; } set { opravdani = value; } }
        public int Neopravdani { get { return neopravdani; } set { neopravdani = value; } }


        public bool Ukor()
        {
            if(this.neopravdani > MAXNeopravdani)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool JeRazredni(Razredni raz)
        {
            if(this.razred == raz.Razred && this.odeljenje == raz.Odeljenje)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(Ucenik a, Ucenik b)
        {
            return a.odeljenje == b.odeljenje;
        }

        public static  bool operator !=(Ucenik a, Ucenik b)
        {
            return a.odeljenje != b.odeljenje;
        }

    }

    internal class Program
    {
        static void UnosUcenika(Ucenik uc, int razred, int odeljenje)
        {
            Console.WriteLine("\nUnos ucenika:");

            uc.Razred = razred;
            uc.Odeljenje = odeljenje;
            Console.WriteLine("Unesi ime ucenika");
            uc.Ime = Console.ReadLine();
            Console.WriteLine("Unesi prezime ucenika");
            uc.Prezime = Console.ReadLine();
            Console.WriteLine("Unesi jmbg ucenika");
            uc.Jmbg = Console.ReadLine();
            Console.WriteLine("Unesi broj opravdanih");
            uc.Opravdani = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Unesi broj neopravdanih");
            uc.Neopravdani = Convert.ToInt32(Console.ReadLine());
        }

        static void UnosStaresine(Razredni raz, int razred, int odeljenje)
        {
            Console.WriteLine("\nUnos razrednog staresine:");

            raz.Razred = razred;
            raz.Odeljenje = odeljenje;
            Console.WriteLine("Unesi ime staresine");
            raz.Ime = Console.ReadLine();
            Console.WriteLine("Unesi prezime staresine");
            raz.Prezime = Console.ReadLine();
            Console.WriteLine("Unesi jmbg staresine");
            raz.Jmbg = Console.ReadLine();
        }

        static void Main(string[] args)
        {
            int razred, odeljenje, n;
            try
            {
                Console.WriteLine("Unesi maksimalni broj neopravdanih pre ukora:");
                Ucenik.MAXNeopravdani = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Unesi broj ucenika");
                n = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Unesi razred");
                razred = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Unesi odeljenje");
                odeljenje = Convert.ToInt32(Console.ReadLine());

                Razredni razredni = new Razredni();
                UnosStaresine(razredni, razred, odeljenje);

                Ucenik[] ucenici = new Ucenik[n];
                for (int i = 0; i < n; i++)
                {
                    ucenici[i] = new Ucenik();
                    UnosUcenika(ucenici[i], razred, odeljenje);
                }

                Console.WriteLine("\nPrikaz ucenika: ");

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("\n" + ucenici[i].Ime + " " + ucenici[i].Prezime + "\nJMBG: " + ucenici[i].Jmbg + "\nIzostanci: " + Convert.ToString(ucenici[i].Neopravdani + ucenici[i].Opravdani) + "\nDa li dobija ukor?: " + ucenici[i].Ukor());
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Greska u formatu podatka\n" + ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Podatak je izvan dozvoljenog opsega\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Doslo je do neke greske\n" + ex.Message);
            }
            Console.ReadLine();
        }

    }
}
