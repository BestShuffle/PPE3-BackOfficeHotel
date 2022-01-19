using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Balladins
{
    // Classe passerelle contenant les méthodes principales
    class BalladinsMethods
    {
        // Fonction de vérification de champ d'identifiant
        public static Boolean verifIdField(ref String text)
        {
            replaceQuotes(ref text);

            /** Si le champ ne contient que des lettres et nombres et
                que le champ n'est ni vide ni rempli d'espaces **/
            if (Regex.IsMatch(text, @"^+[a-zA-Z0-9]+$"))
            {
                return true;
            }
            return false;
        }

        // Fonction de vérification de champ contenant uniquement des chiffres
        public static Boolean verifIntField(String text)
        {
            if (Regex.IsMatch(text, @"^[0-9]+$"))
            {
                return true;
            }
            return false;
        }

        // Fonction de vérification de champ de texte
        public static void correctTextField(ref String text)
        {
            if (text.Length > 1)
            {
                replaceFirstSpaces(ref text);
                replaceQuotes(ref text);
            }
        }

        // Fonction de suppression de premiers espaces d'une chaîne de caractères
        private static void replaceFirstSpaces(ref string text)
        {
            // Si le premier caractère est un espace on le supprime
            while (text[0] == ' ')
            {
                text = text.Substring(1, text.Length - 1);
            }
        }

        // Fonction remplaçant les quotes par des doubles quote pour éviter les bugs / injections
        private static void replaceQuotes(ref String text)
        {
            // Si le champ contient des apostrophes on les remplaces pour éviter des bugs ou injections
            if (text.Contains("'"))
            {
                text = text.Replace("'", "''");
            }
        }

        // Fonction de message d'alerte avec un titre par défaut
        public static void alert(String text)
        {
            alert("Balladins", text);
        }

        // Fonction de message d'alerte
        public static void alert(String title, String text)
        {
            MessageBox.Show(text, title);
        }

        // Fonction de confirmation avec un titre par défaut
        public static bool confirm(String text)
        {
            return confirm("Balladins", text);
        }

        // Fonction de confirmation
        public static bool confirm(String title, String text)
        {
            return MessageBox.Show(text, title, MessageBoxButtons.YesNoCancel) == DialogResult.Yes;
        }

        // Fonction de vérification de la validité des paramètres de connexions utilisateurs
        public static bool validConnexion(int id, string mdp)
        {
            bool valid = false;
            Globals.db.connect();
            Globals.db.execute("SELECT idH, mdp FROM hotel WHERE idH = '" + id + "' ");
            Globals.db.read();
            string data = (string) Globals.db.getData("mdp");
            if (data != null)
            {
                if (mdp == data)
                {
                    valid = true;
                    BalladinsDbMethods.loadHotel(id); 
                }
            }
            Globals.db.disconnect();

            return valid;
        }

        // Génère un nombre aléatoire entre 0 et 9999 sous format String (pour garder le 0 de départ)
        public static String generateCode()
        {
            return new Random().Next(0, 9999).ToString("D4");
        }
    }
}
