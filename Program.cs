using System;

namespace Kryptoverfahren
{
    internal class Program
    {
        //int min = 1, max = 26;
        static void Abcd(string verschlüsselterText, int schlüssel)
        {
            char[] arr = new char[26];

            for (int i = 0; i < 26; i++)
            {
                arr[i] = (char)('a' + i);
            }
        }

        static void Main(string[] args)
        {
          auswahl();
        }

        static int auswahl()
        {
            int min = 1, max = 25;

            Console.WriteLine("Möchten Sie eine Verschlüssselung[1] oder eine Entschlüsselung[2] vornehmen?");
            string eingabe = Console.ReadLine();
            int auswahl = Convert.ToInt32(eingabe);

            if (auswahl == 1 || auswahl == 2)
            {
                string klartext = "";
                int schlüssel = 0;

                if (auswahl == 1)
                {
                    
                    // Klartext?
                    Console.WriteLine("Geben Sie Ihren Klartext ein: ");
                     klartext = Console.ReadLine();
                    Console.WriteLine("Geben Sie eine Zahl zwischen " + min + " und " + max + " ein: ");
                     schlüssel = Convert.ToInt32(Console.ReadLine());

                    /* Verschlüsselung 
                    string verschlüsselterText = Verschlüsselung(klartext, schlüssel);
                    Console.WriteLine($"Verschlüsselter Text: {verschlüsselterText}");
                    */
                    string resultat = Verschlüsselung(klartext, schlüssel);
                    Console.WriteLine(resultat);
                    
                }
                else if (auswahl == 2)
                {
                    // Verschlüsselter Text...
                    Console.WriteLine("Geben Sie Ihren verschlüsselten Text ein: ");
                    string verschlüsselterText = Console.ReadLine();
                    Console.WriteLine("Geben Sie eine Zahl zwischen 1 und 26 ein: ");
                    schlüssel = Convert.ToInt32(Console.ReadLine());

                    // Entschlüsselung
                    Abcd(verschlüsselterText, schlüssel);

                    Console.WriteLine(Entschlüsselung(verschlüsselterText, schlüssel));
                }
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe");
            }

            return auswahl;

        }


        static string Verschlüsselung(string klartext, int schlüssel)
        {
            char[] klartextArray = klartext.ToCharArray();

            for (int i = 0; i < klartextArray.Length; i++)
            {
                char originalChar = klartextArray[i];
                Console.WriteLine(originalChar + " - Ascii: " + ((int) originalChar));

                if (originalChar >= 'a' && originalChar <= 'z')
                {
                    char verschlüsselterChar = (char)(((originalChar - 'a' + schlüssel) % 26) + 'a');
                    klartextArray[i] = verschlüsselterChar;
                }
            }

            return new string(klartextArray);
        }

        static string Entschlüsselung(string verschlüsselterText, int schlüssel)
        {
            // Logik für die Entschlüsselung hier implementieren
            // Beispiel: Caesar-Entschlüsselung
            char[] verschlüsselterTextArray = verschlüsselterText.ToCharArray();

            for (int i = 0; i < verschlüsselterTextArray.Length; i++)
            {
                char originalChar = verschlüsselterTextArray[i];

                if (originalChar >= 'a' && originalChar <= 'z')
                {
                    char entschlüsselterChar = (char)(((originalChar - 'a' - schlüssel + 26) % 26) + 'a');
                    verschlüsselterTextArray[i] = entschlüsselterChar;
                }
            }

            return new string(verschlüsselterTextArray);
        }

    }



    }


