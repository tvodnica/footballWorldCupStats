using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;

namespace Data
{
    public class GetData
    {
        private const string MALE_ALL_MATCHES_REMOTE = "https://world-cup-json-2018.herokuapp.com/matches";
        private const string FEMALE_ALL_MATCHES_REMOTE = "http://worldcup.sfg.io/matches";
        private const string MALE_MATCHES_REMOTE = "https://world-cup-json-2018.herokuapp.com/matches/country?fifa_code=";
        private const string FEMALE_MATCHES_REMOTE = "http://worldcup.sfg.io/matches/country?fifa_code=";
        private const string MALE_TEAMS_REMOTE = "https://world-cup-json-2018.herokuapp.com/teams/results";
        private const string FEMALE_TEAMS_REMOTE = "http://worldcup.sfg.io/teams/results";

        private const string MALE_MATCHES_LOCAL = @"\worldcup.sfg.io\men\matches.json";
        private const string FEMALE_MATCHES_LOCAL = @"\worldcup.sfg.io\women\matches.json";
        private const string MALE_TEAMS_LOCAL = @"\worldcup.sfg.io\men\results.json";
        private const string FEMALE_TEAMS_LOCAL = @"\worldcup.sfg.io\women\results.json";

        private const string FAVORITE_MALE_TEAM_FILE_NAME = "Favorite male team.txt";
        private const string FAVORITE_FEMALE_TEAM_FILE_NAME = "Favorite female team.txt";

        private static string TEAM_PATH;
        private static string MATCH_PATH;
        private static string ALL_MATCHES_PATH;

        private static string FavTeamFifaCode = null;

        private static string cupMale = "m";
        private static string cupFemale = "f";
        private static string dsLocal = "local";
        private static string dsRemote = "remote";

        private static string language;
        private static string EN = "en";
        private static string HR = "hr";


        //OTHER
        private static void SetCupAndDataSource()
        {
            string cup = Files.LoadConfigFile()[0];
            string dataSource = Files.LoadConfigFile()[2];

            if (cup == cupMale && dataSource == dsLocal)
            {
                TEAM_PATH = MALE_TEAMS_LOCAL;
                MATCH_PATH = MALE_MATCHES_LOCAL;
                ALL_MATCHES_PATH = MALE_MATCHES_LOCAL;
            }
            else if (cup == cupMale && dataSource == dsRemote)
            {
                TEAM_PATH = MALE_TEAMS_REMOTE;
                MATCH_PATH = MALE_MATCHES_REMOTE;
                ALL_MATCHES_PATH = MALE_ALL_MATCHES_REMOTE;
            }
            else if (cup == cupFemale && dataSource == dsLocal)
            {
                TEAM_PATH = FEMALE_TEAMS_LOCAL;
                MATCH_PATH = FEMALE_MATCHES_LOCAL;
                ALL_MATCHES_PATH = FEMALE_MATCHES_LOCAL;
            }
            else if (cup == cupFemale && dataSource == dsRemote)
            {
                TEAM_PATH = FEMALE_TEAMS_REMOTE;
                MATCH_PATH = FEMALE_MATCHES_REMOTE;
                ALL_MATCHES_PATH = FEMALE_ALL_MATCHES_REMOTE;
            }
        }
        public static string GetLanguage()
        {
            return Files.LoadConfigFile()[1];
        }
        public static CultureInfo GetCulture()
        {
            try
            {
                language = Data.GetData.GetLanguage();
            }
            catch (Exception)
            {
                throw new Exception("Greška prilikom dohvaćanja jezika za postavljanje kulture");
            }

            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(HR);

            CultureInfo ciEN = new CultureInfo(EN);
            CultureInfo ciHR = new CultureInfo(HR);

            return Thread.CurrentThread.CurrentUICulture = language == EN ? ciEN : ciHR;
        }

        //FAVORITE
        internal static string GetFavTeamFileName()
        {
            SetCupAndDataSource();

            if (TEAM_PATH == MALE_TEAMS_LOCAL || TEAM_PATH == MALE_TEAMS_REMOTE)
            {
                return FAVORITE_MALE_TEAM_FILE_NAME;
            }
            else if (TEAM_PATH == FEMALE_TEAMS_LOCAL || TEAM_PATH == FEMALE_TEAMS_REMOTE)
            {
                return FAVORITE_FEMALE_TEAM_FILE_NAME;
            }
            else
            {
                throw new Exception("Greška u dohvaćanju prvenstva pri spremanju ");
            }
        }
        public static List<Match> GetMatchesOfFavoriteTeam()
        {
            try { FavTeamFifaCode = Files.LoadFavTeamFile()[1]; }
            catch { throw new Exception("Greška pri učitavanju datoteke omiljenog tima"); }

            List<Match> favTeamMatches = new List<Match>();

            if (Files.LoadConfigFile()[2] == dsRemote)
            {
                RestClient restClient = new RestClient(MATCH_PATH + FavTeamFifaCode);
                var result = restClient.Execute(new RestRequest(), Method.GET);
                favTeamMatches = JsonConvert.DeserializeObject<List<Match>>(result.Content);
            }
            else if (Files.LoadConfigFile()[2] == dsLocal)
            {
                string data = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + MATCH_PATH);

                List<Match> matches = JsonConvert.DeserializeObject<List<Match>>(data);

                foreach (var match in matches)
                {
                    if (match.AwayTeam.Code == FavTeamFifaCode || match.HomeTeam.Code == FavTeamFifaCode)
                    {
                        favTeamMatches.Add(match);
                    }
                }
            }

            return favTeamMatches;
        }
        public static List<Player> GetPlayersOfFavoriteTeam()
        {
            List<Match> matches = GetMatchesOfFavoriteTeam();

            List<Player> players = new List<Player>();
            if (matches[0].HomeTeam.Code == FavTeamFifaCode)
            {
                foreach (var player in matches[0].HomeTeamStatistics.StartingEleven)
                {
                    player.Goals = 0;
                    player.YellowCards = 0;
                    player.Image = GetPlayerImage(player.Name);
                    players.Add(player);
                }
                foreach (var player in matches[0].HomeTeamStatistics.Substitutes)
                {
                    player.Goals = 0;
                    player.YellowCards = 0;
                    player.Image = GetPlayerImage(player.Name);
                    players.Add(player);
                }
            }
            else if (matches[0].AwayTeam.Code == FavTeamFifaCode)
            {
                foreach (var player in matches[0].AwayTeamStatistics.StartingEleven)
                {
                    player.Goals = 0;
                    player.YellowCards = 0;
                    player.Image = GetPlayerImage(player.Name);
                    players.Add(player);
                }
                foreach (var player in matches[0].AwayTeamStatistics.Substitutes)
                {
                    player.Goals = 0;
                    player.YellowCards = 0;
                    player.Image = GetPlayerImage(player.Name);
                    players.Add(player);
                }

            }
            else
            {
                throw new Exception("Omiljeni tim nije ni jedan od dohvaćenih");
            }

            foreach (var player in players)
            {
                foreach (var match in matches)
                {
                    foreach (var homeTeamEvent in match.HomeTeamEvents)
                    {
                        if (homeTeamEvent.Player == player.Name)
                        {
                            if (homeTeamEvent.TypeOfEvent == "goal")
                            {
                                player.Goals++;
                            }
                            if (homeTeamEvent.TypeOfEvent == "yellow-card")
                            {
                                player.YellowCards++;
                            }
                        }
                    }
                }
            }
            foreach (var player in players)
            {
                foreach (var match in matches)
                {
                    foreach (var awayTeamEvent in match.AwayTeamEvents)
                    {
                        if (awayTeamEvent.Player == player.Name)
                        {
                            if (awayTeamEvent.TypeOfEvent == "goal")
                            {
                                player.Goals++;
                            }
                            if (awayTeamEvent.TypeOfEvent == "yellow-card")
                            {
                                player.YellowCards++;
                            }
                        }
                    }
                }
            }

            return players;

        }

        //ALL
        public static List<Team> GetAllTeams()
        {
            List<Team> teams = new List<Team>();

            SetCupAndDataSource();
            if (Files.LoadConfigFile()[2] == dsRemote)
            {
                RestClient restClient = new RestClient(TEAM_PATH);
                var result = restClient.Execute<Team>(new RestRequest(), Method.GET);
                teams = JsonConvert.DeserializeObject<List<Team>>(result.Content);
                Console.WriteLine(result.Content);

            }
            else if (Files.LoadConfigFile()[2] == dsLocal)
            {
                string data = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + TEAM_PATH);
                teams = JsonConvert.DeserializeObject<List<Team>>(data);
                Console.WriteLine(data);
            }

            return teams;
        }
        public static List<Match> GetAllMatches()
        {
            List<Match> matches = new List<Match>();

            SetCupAndDataSource();
            if (Files.LoadConfigFile()[2] == dsRemote)
            {
                RestClient restClient = new RestClient(ALL_MATCHES_PATH);
                var result = restClient.Execute<Match>(new RestRequest(), Method.GET);
                matches = JsonConvert.DeserializeObject<List<Match>>(result.Content);
                Console.WriteLine(result.Content);

            }
            else if (Files.LoadConfigFile()[2] == dsLocal)
            {
                string data = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + ALL_MATCHES_PATH);
                matches = JsonConvert.DeserializeObject<List<Match>>(data);
                Console.WriteLine(data);
            }

            return matches;
        }

        //SPECIFIC
        public static List<Team> GetTeamsPlayedAgainst(string fifaCode)
        {
            List<Team> allTeams = GetAllTeams();
            List<Team> teamsPlayedAgainst = new List<Team>();
            List<Match> allMatches = GetAllMatches();

            foreach (var match in allMatches)
            {
                if (fifaCode == match.HomeTeam.Code)
                {
                    foreach (var team in allTeams)
                    {
                        if (match.AwayTeam.Code == team.FifaCode)
                        {
                            teamsPlayedAgainst.Add(team);
                        }
                    }
                }
                if (fifaCode == match.AwayTeam.Code)
                {
                    foreach (var team in allTeams)
                    {
                        if (match.HomeTeam.Code == team.FifaCode)
                        {
                            teamsPlayedAgainst.Add(team);
                        }
                    }
                }
            }

            return teamsPlayedAgainst;
        }
        public static Match GetMatch(Team teamFav, Team teamAgainst)
        {
            List<Match> allMatches = GetAllMatches();
            try
            {
                foreach (var match in allMatches)
                {
                    if (match.HomeTeam.Code == teamFav.FifaCode && match.AwayTeam.Code == teamAgainst.FifaCode
                        || match.AwayTeam.Code == teamFav.FifaCode && match.HomeTeam.Code == teamAgainst.FifaCode)
                    {
                        return match;
                    }
                }
                throw new Exception("Match not found");
            }
            catch (Exception)
            {
                throw new Exception("Greška pri dohvaćanju utakmice");
            }

        }
        public static Team GetTeamByFifaCode(string teamFifaCode)
        {
            List<Team> allTeams = GetAllTeams();
            foreach (var team in allTeams)
            {
                if (team.FifaCode == teamFifaCode)
                {
                    return team;
                }
            }
            throw new Exception("404 - Cannot find a team with requested FIFA code ");
        }
        public static List<Player> GetPlayersFromMatch(Match selectedMatch)
        {
            List<Player> players = new List<Player>();

            //Home
            foreach (var player in selectedMatch.HomeTeamStatistics.StartingEleven)
            {
                players.Add(player);
            }
            foreach (var player in selectedMatch.HomeTeamStatistics.Substitutes)
            {
                players.Add(player);
            }

            //Away
            foreach (var player in selectedMatch.AwayTeamStatistics.StartingEleven)
            {
                players.Add(player);
            }
            foreach (var player in selectedMatch.AwayTeamStatistics.Substitutes)
            {
                players.Add(player);
            }

            return players;
        }
        private static string GetPlayerImage(string name)
        {
            if (!Files.PlayerImagesFileExists())
            {
                return "";
            }
            Dictionary<string, string> playersImages = Files.LoadPlayersImagesFile();
            if (!playersImages.TryGetValue(name, out string image))
            {
                return "";
            }

            return image;
        }


    }
}
