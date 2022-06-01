using System;
using System.Collections.Generic;
using System.Linq;

namespace Codam
{
    class Program
    {
        static void Main(string[] args)
        {

            //var inputData = new List<InitialLeaderBoardResult>

            //{
            //    new InitialLeaderBoardResult { Name = "Gango", Score = 13 },
            //    new InitialLeaderBoardResult { Name = "Mango", Score = 11 },
            //    new InitialLeaderBoardResult { Name = "Sango", Score = 9 },
            //    new InitialLeaderBoardResult { Name = "Rango", Score = 15 }
            //};


            var inputData = new List<InitialLeaderBoardResult>

            {
                new InitialLeaderBoardResult { Name = "Gango", Score = 13 },
                new InitialLeaderBoardResult { Name = "Mango", Score = 9 },
                new InitialLeaderBoardResult { Name = "Sango", Score = 9 },
                new InitialLeaderBoardResult { Name = "Rango", Score = 15 },
                new InitialLeaderBoardResult { Name = "Jango", Score = 5 }
            };

            LeaderBoardService leaderBoardService = new LeaderBoardService();



            foreach (var item in leaderBoardService.GenerateFinalLeaderBoardResult(inputData))
            {
                Console.WriteLine($"Name: {item.InitialLeaderBoardResult.Name}, Score: {item.InitialLeaderBoardResult.Score}, Rank:{item.Rank}");
            }


        }
    }

   
    public class InitialLeaderBoardResult

    {
        public string Name { get; set; }
        public int Score { get; set; }
    }

    public class FinalLeaderBoardResult

    {
        public InitialLeaderBoardResult InitialLeaderBoardResult { get; set; }
        public int Rank { get; set; }
    }

    public class LeaderBoardService

    {
        public IEnumerable<FinalLeaderBoardResult> GenerateFinalLeaderBoardResult(List<InitialLeaderBoardResult> initialLeaderBoardResult)
        {
            //return initialLeaderBoardResult
            //  .OrderByDescending(initialLeaderBoardResult => initialLeaderBoardResult.Score)
            //  .Select((initialLeaderBoardResult, index) => new FinalLeaderBoardResult { InitialLeaderBoardResult = initialLeaderBoardResult, Rank = index + 1 });

            var sortedInitialLeaderBoardResult = initialLeaderBoardResult.OrderByDescending(initialLeaderBoardResult => initialLeaderBoardResult.Score);
           
            var finalResult = new List<FinalLeaderBoardResult>();

            int MoveNext = 0;

            int? lastScore = null;

            int lastRank = 0;

            foreach (var result in sortedInitialLeaderBoardResult)
            {
                MoveNext++;

                var rank = result.Score != lastScore ? MoveNext : lastRank;

                var entry = new FinalLeaderBoardResult { InitialLeaderBoardResult = result, Rank = rank };

                finalResult.Add(entry);

                lastScore = result.Score;
                lastRank = rank;
            }
            return finalResult;

        }
    }

}
