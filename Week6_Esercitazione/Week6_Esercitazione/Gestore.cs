using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Esercitazione.Models;
using Week6_Esercitazione.Repository;

namespace Week6_Esercitazione
{
    class Gestore
    {
        static IRepository<Cliente> repoCliente = new RepositoryCliente();
        static IRepository<Polizza> repoPolizza = new RepositoryPolizza();
        internal static bool SchermoMenu()
        {
            Console.WriteLine("Benvenuto");
            Console.WriteLine("1. Aggiungi cliente");
            Console.WriteLine("2. Aggiungi polizza");
            Console.WriteLine("3. Visualizza dati");
            Console.WriteLine("4. Per uscire");
            int scelta = VerificaInput(4);
            Console.Clear();
            return Scelta(scelta);
        }
        private static bool Scelta(int scelta)
        {
            bool continua = true;
            switch (scelta)
            {
                case 1:
                    AggiungiCliente();
                    break;
                case 2:
                    AggiungiPolizza();
                    break;
                case 3:
                    Stampa();
                    break;
                default:
                    continua = false;
                    Console.WriteLine("Arrivederci");
                    break;
            }
            return continua;
        }

        private static void AggiungiPolizza()
        {
            Polizza polizza;
            Console.WriteLine("Che tipo di polizza?\n" +
                "1 - Sulla vita\n" +
                "2 - Furto\n" +
                "3 - RC\n");
            int tipoPolizza = VerificaInput(3);
            Console.WriteLine("Immetti il numero: ");
            string codice = Console.ReadLine();
            Console.WriteLine("Immetti data stipula: ");
            DateTime dt=DateTime.Now;
            DateTime.TryParse(Console.ReadLine(), out dt);
            Console.WriteLine("Imetti l'importo assicurato: ");
            string importo = Console.ReadLine();
            Console.WriteLine("Imetti la rata mensile: ");
            string rm = Console.ReadLine();
            if (tipoPolizza == 1)
            {
                Console.WriteLine("Imetti l'eta' dell'assicurato: ");
                string anni = Console.ReadLine();
                polizza = new PolizzaVita()
                {
                    Numero = Int32.Parse(codice),
                    DataStipula = dt,
                    ImportoAssicurato = float.Parse(importo),
                    RataMensile = float.Parse(rm),
                    AnniAssicurato =Int32.Parse(anni)
                };
            }else if (tipoPolizza == 2)
            {
                Console.WriteLine("Imetti la percentuale coperta: ");
                string per = Console.ReadLine();
                polizza = new PolizzaFurto()
                {
                    Numero = Int32.Parse(codice),
                    DataStipula = dt,
                    ImportoAssicurato = float.Parse(importo),
                    RataMensile = float.Parse(rm),
                    PercentualeCoperta = Int32.Parse(per)
                };
            }
            else
            {
                Console.WriteLine("Imetti la targa: ");
                string targa = Console.ReadLine();
                Console.WriteLine("Imetti la cilindrata: ");
                string cilindrata = Console.ReadLine();
                polizza = new PolizzaRCAuto()
                {
                    Numero = Int32.Parse(codice),
                    DataStipula = dt,
                    ImportoAssicurato = float.Parse(importo),
                    RataMensile = float.Parse(rm),
                    Targa=targa,
                    Cilindrata=Int32.Parse(cilindrata)
                };
            }
            var clienti=repoCliente.GetAll();
            string CF=0;
            if (clienti.Count != 0)
            {
                foreach (var item in clienti)
                {
                    Console.WriteLine(item);
                }
                int scelta=VerificaInput(clienti.Count);
            }
            polizza.CodiceFiscale = "NON HO FINITO LS VERIFY";
        }

        private static void AggiungiCliente()
        {
            Console.WriteLine("Immetti il CF: ");
            string CF = Console.ReadLine();
            Console.WriteLine("Immetti il nome: ");
            string Nomes = Console.ReadLine();
            Console.WriteLine("Imetti il cognome: ");
            string cognome = Console.ReadLine();
            Console.WriteLine("Imetti l'indirizzo: ");
            string indirizzo = Console.ReadLine();
            Cliente cliente = new Cliente()
            {
                CodiceFiscale = CF,
                Nome = Nomes,
                Cognome = cognome,
                Indirizzo = indirizzo
            };
        }

        private static void Stampa()
        {
            Console.WriteLine("In stampa: \n");
            var polizza = repoPolizza.GetAll();
            if (polizza.Count != 0)
            {
                foreach (var item in polizza)
                {
                    Console.WriteLine(item);
                    Console.WriteLine(item.Cliente);
                }
            }
        }
        private static decimal VerificaInput()
        {
            bool verifica = Decimal.TryParse(Console.ReadLine(), out decimal prezzo);
            while (!verifica || prezzo < 0)
            {
                verifica = Decimal.TryParse(Console.ReadLine(), out prezzo);
            }
            return prezzo;
        }
        public static int VerificaInput(int sceltaMax)
        {
            Console.Write("Scelta: ");
            bool verifica = Int32.TryParse(Console.ReadLine(), out int scelta);
            while (scelta > sceltaMax || scelta < 0 || verifica == false)
            {
                Console.WriteLine("Inserisci un valore corretto");
                verifica = Int32.TryParse(Console.ReadLine(), out scelta);
            }
            return scelta;
        }
    }
}
