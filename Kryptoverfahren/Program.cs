using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace Kryptoverfahren
{
    public class Entscheidung
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Möchtest du die Caeser Verschlüsselung benutzen? [y|n]");
            string ant = Console.ReadLine();
            if (ant == "y" || ant == "n")
            {
                if (ant == "y")
                {
                    Caeser();
                }
                else if (ant == "n")
                {
                    Console.WriteLine("Gut, dann gehen ich davon aus, dass Sie die Vignère Verschlüsselungsart benutzen wollen.");
                    Vignere();
                }
                else
                {
                    Console.WriteLine("ungültige Eingabe");
                    Environment.Exit(0);
                }                  
            }
        }

        static void Vignere()
        {
            Console.WriteLine("Möchten Sie eine Verschlüsselung[1] oder eine Entschlüsselung[2] vornhemen?");
            string eingabe = Console.ReadLine();
            int auswahl = Convert.ToInt32(eingabe);

            if (auswahl == 1 || auswahl == 2)
            {
                if (auswahl == 1) 
                {
                    // Eingabe des Klartexts und Schlüssels
                    Console.Write("Geben Sie den Klartext ein: ");
                    string plaintext = Console.ReadLine().ToUpper();
                    Console.Write("Geben Sie den Schlüssel ein: ");
                    string key = Console.ReadLine().ToUpper();

                    // Verschlüsselung des Klartexts
                    string ciphertext = Encrypt(plaintext, key);
                    Console.WriteLine($"Verschlüsselter Text: {ciphertext}");
                }
                else if (auswahl == 2)
                {
                    // Eingabe des Klartexts und Schlüssels
                    Console.Write("Geben Sie den Klartext ein: ");
                    string plaintext = Console.ReadLine().ToUpper();
                    Console.Write("Geben Sie den Schlüssel ein: ");
                    string key = Console.ReadLine().ToUpper();

                    // Entschlüsselung des verschlüsselten Texts
                    string decryptedText = Decrypt(plaintext, key);
                    Console.WriteLine($"Entschlüsselter Text: {decryptedText}");
                }
            }
            else 
            {
                Console.WriteLine("ungültige Eingabe");
                Environment.Exit(0); 
            }
        }


        static void Caeser()
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
        }

        static void Abcd(string verschlüsselterText, int schlüssel)
        {
            char[] arr = new char[26];

            for (int i = 0; i < 26; i++)
            {
                arr[i] = (char)('a' + i);
            }
        }

        static string Verschlüsselung(string klartext, int schlüssel)
        {
            char[] klartextArray = klartext.ToCharArray();

            for (int i = 0; i < klartextArray.Length; i++)
            {
                char originalChar = klartextArray[i];
               // Console.WriteLine(originalChar + " - Ascii: " + ((int)originalChar));

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

        static string Encrypt(string plaintext, string key)
        {
            string ciphertext = "";
            for (int i = 0, j = 0; i < plaintext.Length; i++)
            {
                char currentChar = plaintext[i];
                if (char.IsLetter(currentChar))
                {
                    // Verschlüsselung nur für Buchstaben
                    char encryptedChar = (char)((currentChar + key[j]) % 26 + 'a');
                    ciphertext += encryptedChar;
                     // Console.WriteLine(currentChar + " - Ascii: " + ((int)currentChar));
                    j = (j + 1) % key.Length; // Weiter zum nächsten Buchstaben im Schlüssel
                }
                else
                {
                    // Nicht-Buchstaben bleiben unverändert
                    ciphertext += currentChar;
                }
            }
            return ciphertext;
        }

        static string Decrypt(string ciphertext, string key)
        {
            string decryptedText = "";
            for (int i = 0, j = 0; i < ciphertext.Length; i++)
            {
                char currentChar = ciphertext[i];
                if (char.IsLetter(currentChar))
                {
                    // Entschlüsselung nur für Buchstaben
                    char decryptedChar = (char)((currentChar - key[j] + 26) % 26 + 'a');
                    decryptedText += decryptedChar;
                    j = (j + 1) % key.Length; // Weiter zum nächsten Buchstaben im Schlüssel
                }
                else
                {
                    // Nicht-Buchstaben bleiben unverändert
                    decryptedText += currentChar;
                }
            }
            return decryptedText;
        }
    }


}