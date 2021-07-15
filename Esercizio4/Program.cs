/*Gioco del lancio dei Dadi

Si chiede all'utente quanti dadi vuole lanciare.
L'utente inserisce un numero per provare ad indovinare la somma dei valori usciti dal lancio dei dadi.

Il computer lancia i dadi, quindi sorteggia i numeri (random tra 1 e 6).

Se la somma dei due numeri random è pari al numero scelto dall'utente, l'utente vince
Se l'utente vince, stampare 'hai vinto', altrimenti 'hai perso'.

Finita la partita, l'utente deve poter rigiocare.

Requisiti:
Verificare che l'utente inserisca un intero e che sia compreso tra i valori possibili/accettabili.
Se la verifica non va a buon fine, l'utente deve potere inserire nuovamente qualcosa.

Opzionale-> Creare un metodo per l'inserimento dei numeri e la verifica,
uno per il controllo della vittoria (da chiamare nel main).*/



using System;
using System.Collections.Generic;


namespace Esercizio4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nel gioco dei dadi!");
            char continua;

            do {
                int nd = 0;
                int num = 0;
                int tot = 0;
              
                Random rand = new Random();


                SceltaNumDadi(ref nd);
                SceltaNumero(ref num, ref nd);

                for (int i = 1; i <= nd; i++)
                {
                    LanciaDadi(ref rand, ref tot, ref i);
                }

                TotaleEstratto(ref tot, ref num);
                Verifica(ref tot, ref num);

                Console.WriteLine("\nContinuare? s/n");
                continua = Console.ReadKey().KeyChar;

            } while (continua == 's' || continua == 'S');
        }

        private static void Verifica(ref int tot, ref int num)
        {
            if(tot == num)
            {
                Console.WriteLine("\nComplimenti, hai vinto!");
            }else
            {
                Console.WriteLine("\nOh no, hai perso!");

            }
        }

        private static void TotaleEstratto(ref int tot, ref int num)
        {
            Console.WriteLine($"\nTu avevi scelto: {num}");
            Console.WriteLine($"\nLa somma è: {tot}");
        }

        private static void LanciaDadi(ref Random rand, ref int tot, ref int i)
        {
            Console.WriteLine("................");
            Console.WriteLine("\nSto mescolando i dadi");
            var result = rand.Next(1, 7);
            Console.WriteLine($"\nIl numero estratto con il {i}° dado è: {result}");
            tot += result;


        }


        private static void SceltaNumero(ref int num, ref int nd)
        {
            do
            {
                Console.WriteLine("\nQuale numero uscira?");
                while (!int.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine("\nInserisci un numero intero");
                   
                }
                if (num > nd || num < nd * 6)
                {
                    Console.WriteLine("Attenzione, è impossibile che esca questo numero!\n");
                }
            } while (num < nd || num > nd * 6);
        }

        private static void SceltaNumDadi(ref int nd)
        {
            do
            {
                Console.WriteLine("\nQuanti dadi vuoi lanciare? Minimo 2, Massimo 5.");
                while (!int.TryParse(Console.ReadLine(), out nd))
                {
                    Console.WriteLine("\nValore non accetabile. Inserisci un numero intero");
                }
            } while (nd <= 2 || nd >= 5);
        }
    }
}
