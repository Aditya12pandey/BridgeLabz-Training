using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IPLAnalyzer
{
    class IPLCensorshipAnalyzer
    {
        static void Main(string[] args)
        {
            string jsonInputPath = "ipl_input.json";
            string csvInputPath = "ipl_input.csv";

            string jsonOutputPath = "ipl_censored.json";
            string csvOutputPath = "ipl_censored.csv";

            // Process JSON
            List<IplMatch> jsonMatches = ReadJson(jsonInputPath);
            ApplyCensorship(jsonMatches);
            WriteJson(jsonOutputPath, jsonMatches);

            // Process CSV
            List<IplMatch> csvMatches = ReadCsv(csvInputPath);
            ApplyCensorship(csvMatches);
            WriteCsv(csvOutputPath, csvMatches);

            Console.WriteLine("Censorship completed successfully.");
        }


        static List<IplMatch> ReadJson(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<IplMatch>>(json);
        }

        static void WriteJson(string path, List<IplMatch> matches)
        {
            string json = JsonConvert.SerializeObject(matches, Formatting.Indented);
            File.WriteAllText(path, json);
        }


        static List<IplMatch> ReadCsv(string path)
        {
            List<IplMatch> matches = new List<IplMatch>();
            string[] lines = File.ReadAllLines(path);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');

                matches.Add(new IplMatch
                {
                    MatchId = int.Parse(parts[0]),
                    Team1 = parts[1],
                    Team2 = parts[2],
                    ScoreTeam1 = int.Parse(parts[3]),
                    ScoreTeam2 = int.Parse(parts[4]),
                    Winner = parts[5],
                    PlayerOfMatch = parts[6]
                });
            }
            return matches;
        }

        static void WriteCsv(string path, List<IplMatch> matches)
        {
            using StreamWriter writer = new StreamWriter(path);
            writer.WriteLine("match_id,team1,team2,score_team1,score_team2,winner,player_of_match");

            foreach (var m in matches)
            {
                writer.WriteLine($"{m.MatchId},{m.Team1},{m.Team2},{m.ScoreTeam1},{m.ScoreTeam2},{m.Winner},{m.PlayerOfMatch}");
            }
        }


        static void ApplyCensorship(List<IplMatch> matches)
        {
            foreach (var match in matches)
            {
                match.Team1 = MaskTeamName(match.Team1);
                match.Team2 = MaskTeamName(match.Team2);
                match.Winner = MaskTeamName(match.Winner);
                match.PlayerOfMatch = "REDACTED";

                match.Score = new Dictionary<string, int>
                {
                    { match.Team1, match.ScoreTeam1 },
                    { match.Team2, match.ScoreTeam2 }
                };
            }
        }

        static string MaskTeamName(string teamName)
        {
            string[] parts = teamName.Split(' ');

            if (parts.Length == 1)
                return "***";

            parts[1] = "***";
            return string.Join(" ", parts);
        }
    }


    class IplMatch
    {
        [JsonProperty("match_id")]
        public int MatchId { get; set; }

        [JsonProperty("team1")]
        public string Team1 { get; set; }

        [JsonProperty("team2")]
        public string Team2 { get; set; }

        [JsonIgnore]
        public int ScoreTeam1 { get; set; }

        [JsonIgnore]
        public int ScoreTeam2 { get; set; }

        [JsonProperty("score")]
        public Dictionary<string, int> Score { get; set; }

        [JsonProperty("winner")]
        public string Winner { get; set; }

        [JsonProperty("player_of_match")]
        public string PlayerOfMatch { get; set; }
    }
}
