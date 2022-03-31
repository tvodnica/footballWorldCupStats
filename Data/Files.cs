using System;
using System.Collections.Generic;
using System.IO;

namespace Data
{
    public class Files
    {
        private const char DEL = ',';

        private const string CONFIGURATION_FILE_NAME = "Configuration file.txt";
        private static string FAVORITE_TEAM_FILE_NAME;
        private const string FAVORITE_PLAYERS_FILE_NAME = "Favorite players.txt";
        private const string PLAYERS_IMAGES_FILE_NAME = "Players images.txt";
        private const string TEAM_FILE_INFO = "Team file.txt";
        private const string SELECTED_PLAYER_INFO = "Selected player info.txt";
        private const string ALL_PLAYERS_FROM_CURRENT_MATCH = "All players from current match.txt";



        //---------- CONFIG FILE ----------------------
        public static void SaveConfigFile(string cup, string language, string dataSource, string screenResolution)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(CONFIGURATION_FILE_NAME))
                {
                    streamWriter.WriteLine(cup);
                    streamWriter.WriteLine(language);
                    streamWriter.WriteLine(dataSource);
                    streamWriter.WriteLine(screenResolution);
                    streamWriter.Close();
                }
            }
            catch (Exception)
            {
                throw new Exception("Greška prilikom spremanja konfiguracijske datoteke ");
            }

        }
        public static string[] LoadConfigFile()
        {
            string[] configFileData = new string[4];
            try
            {
                using (StreamReader streamReader = new StreamReader(CONFIGURATION_FILE_NAME))
                {

                    configFileData[0] = streamReader.ReadLine();
                    configFileData[1] = streamReader.ReadLine();
                    configFileData[2] = streamReader.ReadLine();
                    configFileData[3] = streamReader.ReadLine();
                    streamReader.Close();
                }
            }
            catch (Exception)
            {
                throw new Exception("Greška prilikom učitavanja konfiguracijske datoteke ");
            }
            return configFileData;
        }
        public static bool ConfigExists()
        {
            try
            {
                if (File.Exists(CONFIGURATION_FILE_NAME))
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                throw new Exception("Greška prilikom provjere postoji li konfiguracijska datoteka ");
            }

        }



        //---------- FAVORITE TEAM FILE ----------------------
        public static void SaveFavTeamFile(int teamId, string fifaCode)
        {
            try { FAVORITE_TEAM_FILE_NAME = GetData.GetFavTeamFileName(); }
            catch (Exception) { throw; }

            try
            {
                using (StreamWriter streamWriter = new StreamWriter(FAVORITE_TEAM_FILE_NAME))
                {
                    streamWriter.WriteLine(teamId);
                    streamWriter.WriteLine(fifaCode);
                    streamWriter.Close();
                }
            }
            catch (Exception)
            {
                throw new Exception("Greška prilikom spremanja konfiguracijske datoteke");
            }

        }
        public static string[] LoadFavTeamFile()
        {
            try { FAVORITE_TEAM_FILE_NAME = GetData.GetFavTeamFileName(); } catch (Exception) { throw; }

            string[] FavTeamFileData = new string[2];
            try
            {
                using (StreamReader streamReader = new StreamReader(FAVORITE_TEAM_FILE_NAME))
                {
                    FavTeamFileData[0] = streamReader.ReadLine();
                    FavTeamFileData[1] = streamReader.ReadLine();
                }
            }
            catch (Exception)
            {
                throw new Exception("Greška prilikom čitanja omiljenog tima iz datoteke");
            }

            return FavTeamFileData;
        }
        public static bool FavTeamFileExists()
        {
            try
            {
                FAVORITE_TEAM_FILE_NAME = GetData.GetFavTeamFileName();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            try
            {
                if (File.Exists(FAVORITE_TEAM_FILE_NAME))
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                throw new Exception("Greška prilikom provjere postoji li datoteka omiljenog tima ");
            }

        }




        //---------- FAVORITE PLAYERS FILE ----------------------
        public static void SaveFavPlayersFile(List<Player> selectedPlayers)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + FAVORITE_PLAYERS_FILE_NAME))
                {
                    foreach (var player in selectedPlayers)
                    {
                        streamWriter.WriteLine(
                            player.Name + DEL +
                            player.ShirtNumber + DEL +
                            player.Position + DEL +
                            player.Captain + DEL +
                            player.Image
                            );
                    }
                    streamWriter.Close();
                }
            }
            catch (Exception)
            {
                throw new Exception("Greška prilikom spremanja liste omiljenih igrača ");
            }
        }
        public static List<Player> LoadFavPlayersFile()
        {
            List<Player> players = new List<Player>();
            try
            {
                using (StreamReader streamReader = new StreamReader(FAVORITE_PLAYERS_FILE_NAME))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string[] lines = streamReader.ReadLine().Split(DEL);
                        Player player = new Player();
                        player.Name = lines[0];
                        player.ShirtNumber = int.Parse(lines[1]);
                        player.Position = lines[2];
                        player.Captain = lines[3] == "" ? false : true;
                        player.Image = lines[4];
                        players.Add(player);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Greška prilikom spremanja liste omiljenih igrača ");
            }

            return players;
        }
        public static bool FavPlayersExists()
        {
            if (File.Exists(FAVORITE_PLAYERS_FILE_NAME))
            {
                return true;
            }
            return false;
        }




        //---------- PLAYERS FROM CURRENT MATCH FILE -----------
        public static void SavePlayersFromCurrentMatch(List<Player> allPlayersFromCurrentMatch)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(ALL_PLAYERS_FROM_CURRENT_MATCH))
                {
                    foreach (var player in allPlayersFromCurrentMatch)
                    {
                        writer.Write(player.Image + DEL);
                        writer.Write(player.Name + DEL);
                        writer.Write(player.ShirtNumber.ToString() + DEL);
                        writer.Write(player.Position + DEL);
                        writer.Write(player.Captain.ToString() + DEL);
                        writer.Write(player.GoalsInThisMatch.ToString() + DEL);
                        writer.Write(player.YellowCardsInThisMatch.ToString() + DEL);
                        writer.WriteLine();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Greška prilikom spremanja datoteke igrača trenutne utakmice ");
            }
        }
        public static List<Player> LoadPlayersFromCurrentMatch()
        {
            List<Player> players = new List<Player>();
            try
            {
                using (StreamReader reader = new StreamReader(ALL_PLAYERS_FROM_CURRENT_MATCH))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] data = reader.ReadLine().Split(DEL);
                        Player player = new Player();
                        player.Image = data[0];
                        player.Name = data[1];
                        player.ShirtNumber = int.Parse(data[2]);
                        player.Position = data[3];
                        player.Captain = data[4] == "True" ? true : false;
                        player.GoalsInThisMatch = int.Parse(data[5]);
                        player.YellowCardsInThisMatch = int.Parse(data[6]);
                        players.Add(player);
                    }
                }
                return players;
            }
            catch (Exception)
            {
                throw new Exception("Greška prilikom dohvaćanja svih igrača trenutne utakmice ");
            }
        }




        //---------- SELECTED PLAYER FILE -----------
        public static void SaveSelectedPlayerFile(string player_name)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(SELECTED_PLAYER_INFO))
                {
                    writer.WriteLine(player_name);
                    writer.Close();
                }
            }
            catch (Exception)
            {
                throw new Exception("Greška prilikom spremanja datoteke odabranog igrača ");
            }
        }
        public static string LoadSelectedPlayerFile()
        {
            try
            {
                using (StreamReader reader = new StreamReader(SELECTED_PLAYER_INFO))
                {
                    string selectedPlayerName = reader.ReadLine();
                    return selectedPlayerName;
                }
            }
            catch (Exception)
            {
                throw new Exception("Greška prilikom dohvaćanja imena odabranog igrača ");
            }
        }




        //---------- PLAYERS IMAGES FILE ----------------------
        public static void SavePlayersImages(string playerName, string selectedPicture)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            try
            {
                if (PlayerImagesFileExists())
                {
                    dictionary = LoadPlayersImagesFile();
                    if (dictionary.ContainsKey(playerName))
                    {
                        dictionary[playerName] = selectedPicture;
                    }
                    else
                    {
                        dictionary.Add(playerName, selectedPicture);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Greška prilikom ažuriranja slike igrača u datoteci");
            }

            try
            {
                using (StreamWriter streamWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + PLAYERS_IMAGES_FILE_NAME))
                {
                    foreach (var item in dictionary)
                    {
                        streamWriter.WriteLine(item.Key + DEL + item.Value);
                    }

                }
            }
            catch (Exception)
            {
                throw new Exception("Greška prilikom upisa slike igrača u datoteku");
            }

        }
        internal static Dictionary<string, string> LoadPlayersImagesFile()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(PLAYERS_IMAGES_FILE_NAME))
                {
                    Dictionary<string, string> dicionary = new Dictionary<string, string>();

                    while (!streamReader.EndOfStream)
                    {
                        string[] lineData = streamReader.ReadLine().Split(DEL);
                        dicionary.Add(lineData[0], lineData[1]);
                    }
                    return dicionary;
                }
            }
            catch (Exception)
            {
                throw new Exception("Greška prilikom učitavanja slika igrača ");
            }

        }
        internal static bool PlayerImagesFileExists()
        {
            try
            {
                if (File.Exists(PLAYERS_IMAGES_FILE_NAME))
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw new Exception("Greška prilikom provjere postoji li datoteka sa slikama igrača ");
            }
        }



        //---------- TEAM INFO FILE ----------------------
        public static void SaveTeamFile4Info(Team team)
        {
            using (StreamWriter writer = new StreamWriter(TEAM_FILE_INFO))
            {
                try
                {
                    writer.WriteLine(team.FifaCode);
                }
                catch (Exception)
                {
                    throw new Exception("Greška prilikom zapisivanja datoteke odabranog tima");
                }
            }
        }
        public static string LoadTeamFile4Info()
        {
            if (!File.Exists(TEAM_FILE_INFO))
            {
                throw new Exception("404 - Datoteka o podacima odabranog tima ne postoji ");
            }

            try
            {
                using (StreamReader streamReader = new StreamReader(TEAM_FILE_INFO))
                {
                    string fifaCode = streamReader.ReadLine();
                    return fifaCode;
                }

            }
            catch (Exception)
            {
                throw new Exception("Greška prilikom čitanja datoteke odabranog tima ");
            }
        }



    }
}

