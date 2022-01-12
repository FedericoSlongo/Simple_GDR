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
            bool vince_mostro = false, vince_eroe = false, tipo_di_erore_valido = false, primo_ciclo = true;
            int vita_mostro = 10, vita_eroe = 10, numero_casuale, tipo_di_mostro, vita_rigen_poz;
            string tipo_di_eroe;
            Random r = new Random();

            while (!tipo_di_erore_valido)
            {
                Console.WriteLine("Inserire il tipo di erore si puo scegliere tra Guerriero (20hp), Mago (8), Ladro (10), Arciere (15hp)");
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
                        if (vita_eroe == vita_rigen_poz)
                        {
                            Console.WriteLine("Hai trovato una pozione di rigenerazione ma hai gia la vita al massimo");
                        }
                        else
                        {
                            Console.WriteLine("Hai trovato una pozione che ti rigenera la vita");
                            vita_eroe = vita_rigen_poz;
                        }
                    }
                }
                Console.WriteLine($"Tu hai {vita_eroe}, il mostro ha {vita_mostro}");
                numero_casuale = r.Next(1, 7);
                if (r.Next(101) < 10)
                {
                    Console.WriteLine("Hai fatto un danno critico");
                    numero_casuale *= 2;
                }
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


            Console.ReadKey();
        }
    }
}
