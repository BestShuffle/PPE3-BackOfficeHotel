using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using IniParser;
using IniParser.Model;

namespace Balladins
{
    // Classe d'objet de base de données
    // Faite en Singleton
    class Database
    {
        bool connected;

        // Instance unique
        private static Database instance;

        private string host;
        private string databaseName;
        private string username;
        private string password;
        private SqlConnection connection;
        private SqlDataReader reader;
        private SqlCommand command;

        // Construit un objet de base de données
        public Database(string host, string databaseName, string username, string password)
        {
            this.host = host;
            this.databaseName = databaseName;
            this.username = username;
            this.password = password;
            connected = false;
            // Définition de la chaîne de connexion à la base de données
            connection = new SqlConnection();
            connection.ConnectionString = "SERVER=" + host + ";"
                                        + "Database=" + databaseName + ";"
                                        + "uid=" + username + ";"
                                        + "pwd=" + password;
        }

        // Fonction de création d'instance unique
        private static Database createInstance()
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            String ip = data["Database"]["ip"];
            String database = data["Database"]["database"];
            String user = data["Database"]["username"];
            String pass = data["Database"]["password"];
            return new Database(ip, database, user, pass);
        }

        // Fonction de récupération de l'instance unique
        public static Database getInstance()
        {
            if (instance == null)
            {
                instance = createInstance();
            }
            return instance;
        }

        // Fonction de connexion à la base de données
        public void connect()
        {
            if (isConnected())
            {
                disconnect();
            }
            connection.Open();
            command = new SqlCommand();

            connected = true;
        }

        // Fonction de déconnexion à la base de données
        public void disconnect()
        {
            connection.Close();

            try
            {
                reader.Close();
            }
            catch (Exception ex) { }

            setConnected(false);
        }

        // Fonction d'envoi de requête avec récupération des données renvoyées par le serveur
        public void execute(String request)
        {
            try
            {
                command.CommandText = request;
                command.Connection = connection;
                reader = command.ExecuteReader();
            }
            catch (SqlException ex)
            {
                BalladinsMethods.alert("Erreur lors de l'envoi de la requête :\n" + ex.ToString());
                disconnect();
            }
        }

        // Fonction d'envoi de requête sans récupération des données renvoyées par le serveur
        public void executeNonQuery(String request)
        {
            try
            {
                command.CommandText = request;
                command.Connection = this.connection;
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                BalladinsMethods.alert("Erreur lors de l'envoi de la requête :\n" + ex.ToString());
                disconnect();
            }
        }

        // Fonction d'envoi de requête avec retour de l'unique donnée
        public Object executeScalar(String request)
        {
            Object data = null;
            try
            {
                command.CommandText = request;
                command.Connection = this.connection;
                data = command.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                BalladinsMethods.alert("Erreur lors de l'envoi de la requête :\n" + ex.ToString());
                disconnect();
            }
            return data;
        }

        // Fonction de lecture du reader
        public bool read()
        {
            return reader.Read();
        }

        // Fonction de récupération des données, retourne null si la donnée n'est pas trouvée
        public Object getData(String dataName)
        {
            try
            {
                return reader[dataName];
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        // Fonction de récupération de l'adresse d'hôte
        public String getHost()
        {
            return host;
        }

        // Fonction de définition de l'adresse d'hôte
        public void setHost(String host)
        {
            this.host = host;
        }

        // Fonction de récupération du nom de la base de données
        public String getDatabaseName()
        {
            return databaseName;
        }

        // Fonction de définition du nom de la base de données
        public void setDatabaseName(String databaseName)
        {
            this.databaseName = databaseName;
        }

        // Fonction de récupération du nom d'utilisateur
        public String getUsername()
        {
            return username;
        }

        // Fonction de définition du nom d'utilisateur
        public void setUsername(String username)
        {
            this.username = username;
        }

        // Fonction de récupération du mot de passe
        public String getPassword()
        {
            return password;
        }

        // Fonction de définition du mot de passe
        public void setPassword(String password)
        {
            this.password = password;
        }

        // Fonction de récupération de la connexion
        public SqlConnection getConnection()
        {
            return connection;
        }

        // Fonction de définition de la connexion
        public void setConnection(SqlConnection connection)
        {
            this.connection = connection;
        }

        // Fonction de récupération du reader
        public SqlDataReader getReader()
        {
            return reader;
        }

        // Fonction de définition du reader
        public void setReader(SqlDataReader reader)
        {
            this.reader = reader;
        }

        // Fonction de récupération de l'état de la connexion
        public bool isConnected()
        {
            return connected;
        }

        // Fonction de définition d'état de la connexion
        public void setConnected(bool state)
        {
            this.connected = state;
        }
    }
}
