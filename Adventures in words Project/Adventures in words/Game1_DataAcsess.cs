using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.OleDb;
using System.IO;

namespace Adventures_in_words
{
    class Game1_DataAcsess
    {
        const string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Resources\Database1.accdb;";
        public bool[] levelCompletionStatus1 = new bool[24];
        public int ExtractCoin()
        {
            int coin = 250; 

            string CoinFilePath = "Coin.txt";

            if (File.Exists(CoinFilePath))
            {
                
                string coinString = File.ReadAllText(CoinFilePath);
                int.TryParse(coinString, out coin);
            }
            else
            {
                
                File.WriteAllText(CoinFilePath, coin.ToString());
            }

            return coin;
        }
        public void SaveCoin(int coin)
        {
            string CoinFilePath = "Coin.txt";
            File.WriteAllText(CoinFilePath, coin.ToString());
        }


        public string[] GetLettersForLevel(int levelNumber)
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();
                string[] letters = new string[4];
                string query = "SELECT Word1, Word2, Word3, Word4 FROM Word_Game1 WHERE Level = ?";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("?", levelNumber);

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        
                        letters[0] = reader.GetString(0);
                        letters[1] = reader.GetString(1);
                        letters[2] = reader.GetString(2);
                        letters[3] = reader.GetString(3);
                    }
                }
                return letters;
            }
            
            
        }
        public string[] GetWordsForLevel(int levelNumber)
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();
                string[] Word = new string[5];
                string query = "SELECT LevelWord1, LevelWord2, LevelWord3, LevelWord4, LevelWord5 FROM Words_Game1 WHERE LevelNum = ?";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("?", levelNumber);

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Word[0] = reader.GetString(0);
                        Word[1] = reader.GetString(1);
                        Word[2] = reader.GetString(2);
                        Word[3] = reader.GetString(3);
                        Word[4] = reader.GetString(4);
                    }
                }
                return Word;
            }

            
        }
        public int selectlevel()
        {
            const string levelProgressFilePath = "level_progress.txt";
            int currentLevel = 1;

           
            if (File.Exists(levelProgressFilePath))
            {
                
                string levelString = File.ReadAllText(levelProgressFilePath);
                int.TryParse(levelString, out currentLevel);
            }
            else
            {

                File.WriteAllText(levelProgressFilePath, currentLevel.ToString());

            }
            return currentLevel;

        }
        public void CheckAndCreateFile()
        {
            string filePath = "level_True.txt";

            if (!File.Exists(filePath))
            {
                try
                {
                    using (StreamWriter sw = File.CreateText(filePath))
                    {
                        
                    }

                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Create file: " + ex.Message);
                }
            }
        }
        public void SetTrueLevel(int level)
        {
            int currentLevel = level;
            using (StreamWriter writer = new StreamWriter("level_True.txt"))
            {
                for(int i=1;i<=currentLevel;i++)
                writer.WriteLine(i.ToString());
                
            }
        }
        public int GetTrueLevel(int level)
        {
            int status;
            using (StreamReader reader = new StreamReader("level_True.txt"))
            {
                string fileContent = reader.ReadToEnd(); 

               
                if (fileContent.Contains(level.ToString()))
                {
                    
                    
                    status = 1;
                }
                else
                {
                   
                    
                    status = 0;
                }
                return status;
            }

        }
        public void AddLevel(int Level)
        {
            string CoinFilePath = "level_progress.txt";
            File.WriteAllText(CoinFilePath, Level.ToString());
        }


    }
}
