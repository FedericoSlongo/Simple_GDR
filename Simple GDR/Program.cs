using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_GDR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool lingua_valida = false;
            string lingua;

            //language selection
            Console.Write("Insert what language you'll like the app to use (English or Italian): ");
            do
            {
                lingua = Console.ReadLine().ToLower();
                switch (lingua)
                {
                    case "english":
                        Console.Clear();
                        eng();
                        break;
                    case "en":
                        Console.Clear();
                        eng();
                        break;
                    case "e":
                        Console.Clear();
                        eng();
                        break;
                    case "italian":
                        Console.Clear();
                        ita();
                        lingua_valida = true;
                        break;
                    case "it":
                        Console.Clear();
                        ita();
                        break;
                    case "i":
                        Console.Clear();
                        ita();
                        lingua_valida = true;
                        break;
                    default:
                        lingua_valida = false;
                        Console.WriteLine("The language isn't valid");
                        break;
                }
            } while (!lingua_valida);

            Console.ReadKey();
        }

        static void ita()
        {
            bool vince_mostro = false, vince_eroe = false, tipo_di_erore_valido = false, primo_ciclo = true;
            int vita_mostro = 10, vita_eroe = 10, numero_casuale, tipo_di_mostro, vita_rigen_poz;
            string tipo_di_eroe, lang = "ita";
            Random r = new Random();

            while (!tipo_di_erore_valido)
            {
                Console.WriteLine("Inserire il tipo di eroe si puo scegliere tra Guerriero (20hp), Mago (8), Ladro (10), Arciere (15hp)");
                tipo_di_eroe = Console.ReadLine().ToLower();
                switch (tipo_di_eroe)
                {
                    case "guerriero":
                        tipo_di_erore_valido = true;
                        vita_eroe = 20;
                        break;
                    case "mago":
                        tipo_di_erore_valido = true;
                        vita_eroe = 8;
                        break;
                    case "ladro":
                        tipo_di_erore_valido = true;
                        vita_eroe = 10;
                        break;
                    case "arciere":
                        tipo_di_erore_valido = true;
                        vita_eroe = 15;
                        break;
                    default:
                        Console.WriteLine($"{tipo_di_eroe} non è un eroe valido per farvore scegli tra li eroi validi");
                        break;
                }
            }

            Console.Clear();

            vita_rigen_poz = vita_eroe;

            tipo_di_mostro = r.Next(0, 3);

            switch (tipo_di_mostro)
            {
                case 0:
                    Console.WriteLine("Incontri un Goblin");
                    vita_mostro = 5;
                    break;
                case 1:
                    Console.WriteLine("Incontri uno Scheletro");
                    vita_mostro = 10;
                    break;
                case 2:
                    Console.WriteLine("Incontri un Drago");
                    vita_mostro = 20;
                    break;
                default:
                    Console.WriteLine("Un errore catastrofico, il numero non è valido");
                    break;
            }

            while (vince_eroe || !vince_mostro)
            {
                if (vita_mostro < 0)
                {
                    Console.WriteLine($"Il mostro è morto a te rimane {vita_eroe} vita");
                    vince_eroe = true;
                    break;
                }
                if (vita_eroe < 0)
                {
                    Console.WriteLine($"Il mostro ti ha sconfito (il programma ti odia proprio), la vita che rimaneva al mostro e {vita_mostro}");
                    vince_mostro = true;
                    break;
                }

                if (primo_ciclo)
                {
                    primo_ciclo = false;
                }
                else
                {
                    if (r.Next(101) < 5)
                    {
                        vita_eroe = pozione(vita_eroe, vita_rigen_poz, lang);
                    }
                }
                Console.WriteLine($"Tu hai {vita_eroe}, il mostro ha {vita_mostro}");
                numero_casuale = r.Next(1, 7);

                numero_casuale = critical_damage(lang, r, numero_casuale);

                Console.WriteLine($"Tu hai fatto {numero_casuale}");
                vita_mostro -= numero_casuale;
                numero_casuale = r.Next(1, 7);
                if (r.Next(101) < 10)
                {
                    Console.WriteLine("Il mostro fatto un danno critico");
                    numero_casuale *= 2;
                }
                Console.WriteLine($"Il mostro ti ha fatto {numero_casuale}");
                vita_eroe -= numero_casuale;
            }
        }

        static int pozione(int vita_eroe, int vita_rigen_poz, string lang)
        {
            if (lang == "en")
            {
                if (vita_eroe == vita_rigen_poz)
                {
                    Console.WriteLine("You found a regeneration potion, but you arledy have full healt");
                    return vita_rigen_poz;
                }
                else
                {
                    Console.WriteLine("You found a regeneration potion and you have all you're hearts back");
                    vita_eroe = vita_rigen_poz;
                    return vita_rigen_poz;
                }
            }
            else
            {
                if (vita_eroe == vita_rigen_poz)
                {
                    Console.WriteLine("Hai trovato una pozione di rigenerazione ma hai gia la vita al massimo");
                    return vita_eroe;
                }
                else
                {
                    Console.WriteLine("Hai trovato una pozione che ti rigenera la vita");
                    vita_eroe = vita_rigen_poz;
                    return vita_rigen_poz;
                }
            }
        }

        static int critical_damage(string lang, Random r, int numero_casuale)
        {
            if (lang == "ita") {
                if (r.Next(101) < 10)
                {
                    Console.WriteLine("Hai fatto un danno critico");
                    numero_casuale *= 2;
                }
            } else {
                if (r.Next(101) < 10)
                {
                    Console.WriteLine("You have done critical damage");
                    numero_casuale *= 2;
                }
            }
            return numero_casuale;
        }



        static void eng()
        {
            bool vince_mostro = false, vince_eroe = false, tipo_di_erore_valido = false, primo_ciclo = true;
            int vita_mostro = 10, vita_eroe = 10, numero_casuale, tipo_di_mostro, vita_rigen_poz;
            string tipo_di_eroe, lang = "en";
            Random r = new Random();

            while (!tipo_di_erore_valido)
            {
                Console.WriteLine("Insert the type of hero you wanna be between Warrior (20hp), Wizard (8), Thief (10), Archer (15hp)");
                tipo_di_eroe = Console.ReadLine().ToLower();
                switch (tipo_di_eroe)
                {
                    case "warrior":
                        tipo_di_erore_valido = true;
                        vita_eroe = 20;
                        break;
                    case "wizard":
                        tipo_di_erore_valido = true;
                        vita_eroe = 8;
                        break;
                    case "thief":
                        tipo_di_erore_valido = true;
                        vita_eroe = 10;
                        break;
                    case "archer":
                        tipo_di_erore_valido = true;
                        vita_eroe = 15;
                        break;
                    default:
                        Console.WriteLine($"{tipo_di_eroe} it's not a valid type, please select between valid heroes");
                        break;
                }
            }

            Console.Clear();

            vita_rigen_poz = vita_eroe;

            tipo_di_mostro = r.Next(0, 3);

            switch (tipo_di_mostro)
            {
                case 0:
                    Console.WriteLine("You encounter a Goblin");
                    vita_mostro = 5;
                    break;
                case 1:
                    Console.WriteLine("You encounter a scheleton");
                    vita_mostro = 10;
                    break;
                case 2:
                    Console.WriteLine("You encounter a dragon");
                    vita_mostro = 20;
                    break;
                default:
                    Console.WriteLine("Un errore catastrofico, il numero non è valido");
                    break;
            }

            while (vince_eroe || !vince_mostro)
            {
                if (vita_mostro < 0)
                {
                    Console.WriteLine($"The monster died you had {vita_eroe} heart left");
                    vince_eroe = true;
                    break;
                }
                if (vita_eroe < 0)
                {
                    Console.WriteLine($"The monster defeat you (the program really hates you), the life remeaning to the monster was {vita_mostro}");
                    vince_mostro = true;
                    break;
                }

                if (primo_ciclo)
                {
                    primo_ciclo = false;
                }
                else
                {
                    if (r.Next(101) < 5)
                    {
                        vita_eroe = pozione(vita_eroe, vita_rigen_poz, lang);
                    }
                }
                Console.WriteLine($"You have {vita_eroe}, the monster has {vita_mostro}");
                numero_casuale = r.Next(1, 7);

                numero_casuale = critical_damage(lang, r, numero_casuale);

                Console.WriteLine($"You did {numero_casuale}");
                vita_mostro -= numero_casuale;
                numero_casuale = r.Next(1, 7);
                if (r.Next(101) < 10)
                {
                    Console.WriteLine("The monster did a critical damage");
                    numero_casuale *= 2;
                }
                Console.WriteLine($"The monster did {numero_casuale}");
                vita_eroe -= numero_casuale;
            }
        }
    }
}
