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


            //var inputData = new List<InitialLeaderBoardResult>

            //{
            //    new InitialLeaderBoardResult { Name = "Gango", Score = 13 },
            //    new InitialLeaderBoardResult { Name = "Mango", Score = 9 },
            //    new InitialLeaderBoardResult { Name = "Sango", Score = 9 },
            //    new InitialLeaderBoardResult { Name = "Rango", Score = 15 },
            //    new InitialLeaderBoardResult { Name = "Jango", Score = 5 }
            //};

            //LeaderBoardService leaderBoardService = new LeaderBoardService();


            //foreach (var item in leaderBoardService.GenerateFinalLeaderBoardResult(inputData))
            //{
            //    Console.WriteLine($"Name: {item.InitialLeaderBoardResult.Name}, Score: {item.InitialLeaderBoardResult.Score}, Rank:{item.Rank}");
            //}

            
        }

       
    }


    //public class InitialLeaderBoardResult

    //{
    //    public string Name { get; set; }
    //    public int Score { get; set; }
    //}
    public class InitialLeaderBoardResult<T> where T : IComparable<T>

    {
        public string Name { get; set; }
        public T Score { get; set; }
    }

    //public class FinalLeaderBoardResult

    //{
    //    public InitialLeaderBoardResult InitialLeaderBoardResult { get; set; }
    //    public int Rank { get; set; }
    //}

    public class FinalLeaderBoardResult<T> where T : IComparable<T>
    {
        public InitialLeaderBoardResult<T> InitialLeaderBoardResult { get; set; }
        public int Rank { get; set; }
    }

    //public class LeaderBoardService

    //{
    //    public IEnumerable<FinalLeaderBoardResult> GenerateFinalLeaderBoardResult(List<InitialLeaderBoardResult> initialLeaderBoardResult)
    //    {
    //        //return initialLeaderBoardResult
    //        //  .OrderByDescending(initialLeaderBoardResult => initialLeaderBoardResult.Score)
    //        //  .Select((initialLeaderBoardResult, index) => new FinalLeaderBoardResult { InitialLeaderBoardResult = initialLeaderBoardResult, Rank = index + 1 });

    //        var sortedInitialLeaderBoardResult = initialLeaderBoardResult.OrderByDescending(initialLeaderBoardResult => initialLeaderBoardResult.Score);

    //        var finalBoardResult = new List<FinalLeaderBoardResult>();

    //        int MoveNext = 0;

    //        int? lastScore = null;

    //        int lastRank = 0;

    //        foreach (var boardResult in sortedInitialLeaderBoardResult)
    //        {
    //            MoveNext++;

    //            var rank = boardResult.Score != lastScore ? MoveNext : lastRank;

    //            var entry = new FinalLeaderBoardResult { InitialLeaderBoardResult = boardResult, Rank = rank };

    //            finalBoardResult.Add(entry);

    //            lastScore = boardResult.Score;
    //            lastRank = rank;
    //        }
    //        return finalBoardResult;

    //    }
    //}

    
   
    public class LeaderBoardService
    {
            private bool IsLowScoreBest { get; set; }

            private LeaderBoardService() { }

            public static LeaderBoardService ForLowScoreBest()
            {
                return new LeaderBoardService { IsLowScoreBest = true };
            }

            public static LeaderBoardService ForHighScoreBest()
            {
                return new LeaderBoardService { IsLowScoreBest = false };
            }

            public IEnumerable<FinalLeaderBoardResult<T>> GenerateLeaderboarEntries<T>(List<InitialLeaderBoardResult<T>> results) where T : IComparable<T>
            {
                var sortedResults = SortResults(results);

                var entries = new List<FinalLeaderBoardResult<T>>();

                int count = 0;
                T previousScore = default;
                int previousRank = 0;

                foreach (var result in sortedResults)
                {
                    count++;

                    var rank = previousScore is null || !result.Score.Equals(previousScore) ? count : previousRank;
                    var entry = new FinalLeaderBoardResult<T> { InitialLeaderBoardResult = result, Rank = rank };
                    entries.Add(entry);

                    previousScore = result.Score;
                    previousRank = rank;
                }

                return entries;
            }

            private IOrderedEnumerable<InitialLeaderBoardResult<T>> SortResults<T>(List<InitialLeaderBoardResult<T>> results) where T : IComparable<T>
            {
                return IsLowScoreBest ? results.OrderBy(result => result.Score) : results.OrderByDescending(result => result.Score);
            }
        }
    
}
