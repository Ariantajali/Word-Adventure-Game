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
    class Game2_DataAcsess
    {
        const string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Resources\Database1.accdb;";
        public int lvlnum;
        public string[] GetLettersForLevel(int levelNumber)
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                
                connection.Open();
                string[] letters = new string[10];
                if (levelNumber == 0 || levelNumber == 1)
                {
                    lvlnum = 1;
                }
                else if (levelNumber==2)
                {
                    lvlnum = 2;
                }
                else if (levelNumber == 3 || levelNumber == 4)
                {
                    lvlnum = 3;
                }
                string query = "SELECT Word1, Word2, Word3, Word4, Word5, Word6, Word7, Word8, Word9, Word10 FROM Word_Game2 WHERE Level = ?";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("?", lvlnum);

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        letters[0] = reader.GetString(0);
                        letters[1] = reader.GetString(1);
                        letters[2] = reader.GetString(2);
                        letters[3] = reader.GetString(3);
                        letters[4] = reader.GetString(4);
                        letters[5] = reader.GetString(5);
                        letters[6] = reader.GetString(6);
                        letters[7] = reader.GetString(7);
                        letters[8] = reader.GetString(8);
                        letters[9] = reader.GetString(9);

                    }
                }
                return letters;
            }


        }
        public string[] GetWordsForLevel(int levelNumber)
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                if (levelNumber == 1)
                {
                    lvlnum = 1;
                }
                else if (levelNumber == 2)
                {
                    lvlnum = 2;
                }
                else if (levelNumber == 4)
                {
                    lvlnum = 3;
                }
                connection.Open();
                string[] Word = new string[5];
                string query = "SELECT LevelWord1 FROM Words_Game2 WHERE LevelNum = ?";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("?", lvlnum);

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Word[0] = reader.GetString(0);
                    }
                }
                return Word;
            }


        }
        public int selectlevel()
        {
            const string levelProgressFilePath = "level_progress_game2.txt";
            int currentLevel = 1;

            // Check if the level progress file exists
            if (File.Exists(levelProgressFilePath))
            {
                // Read the level value from the file
                string levelString = File.ReadAllText(levelProgressFilePath);
                int.TryParse(levelString, out currentLevel);
            }
            else
            {
                // Create the level progress file and set the initial level value
                
                File.WriteAllText(levelProgressFilePath, currentLevel.ToString());

            }
            return currentLevel;

        }
        public void CheckAndCreateFile()
        {
            string filePath = "level_True_game2.txt";

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
            using (StreamWriter writer = new StreamWriter("level_True_game2.txt"))
            {
                for (int i = 1; i <= currentLevel; i++)
                    writer.WriteLine(i.ToString());

            }
        }
        public int GetTrueLevel(int level)
        {
            int status;
            using (StreamReader reader = new StreamReader("level_True_game2.txt"))
            {
                string fileContent = reader.ReadToEnd(); // Read the entire content of the file

                // Check if the fileContent contains a specific number
                if (fileContent.Contains(level.ToString()))
                {
                    // Do something if the number is found

                    status = 1;
                }
                else
                {
                    // Do something if the number is not found

                    status = 0;
                }
                return status;
            }

        }
        public void AddLevel(int Level)
        {
            string CoinFilePath = "level_progress_game2.txt";
            File.WriteAllText(CoinFilePath, Level.ToString());
        }
    }
}

