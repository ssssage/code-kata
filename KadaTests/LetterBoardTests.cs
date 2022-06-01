using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace KadaTests
{
    public class LetterBoardTests
	{
		[Fact]
		public void HighScoreWithoutDuplicateTest()
		{
			var service = new LeaderBoardService();

			var inputData = new List<InitialLeaderBoardResult>

			{
				new InitialLeaderBoardResult { Name = "Gango", Score = 13 },
				new InitialLeaderBoardResult { Name = "Mango", Score = 11 },
				new InitialLeaderBoardResult { Name = "Sango", Score = 9 },
				new InitialLeaderBoardResult { Name = "Rango", Score = 15 }
			};

			
			var actual = service.GenerateFinalLeaderBoardResult(inputData);

			var expected = new List<FinalLeaderBoardResult>
			{
			  new FinalLeaderBoardResult { InitialLeaderBoardResult = new InitialLeaderBoardResult  { Name = "Rango", Score = 15 }, Rank = 1  },
			  new FinalLeaderBoardResult { InitialLeaderBoardResult = new InitialLeaderBoardResult  { Name = "Gango", Score = 13 }, Rank = 2  },
              new FinalLeaderBoardResult { InitialLeaderBoardResult = new InitialLeaderBoardResult  { Name = "Mango", Score = 11 }, Rank = 3  },
              new FinalLeaderBoardResult { InitialLeaderBoardResult = new InitialLeaderBoardResult  { Name = "Sango", Score = 9 }, Rank = 4   }
              
            };

			
			actual.Should().BeEquivalentTo(expected);

		}


		[Fact]
		public void HighScoreWithDuplicateTest()
		{
			var service = new LeaderBoardService();

			var inputData = new List<InitialLeaderBoardResult>

			{
				new InitialLeaderBoardResult { Name = "Gango", Score = 13 },
				new InitialLeaderBoardResult { Name = "Mango", Score = 9 },
				new InitialLeaderBoardResult { Name = "Sango", Score = 9 },
				new InitialLeaderBoardResult { Name = "Rango", Score = 15 },
				new InitialLeaderBoardResult { Name = "Jango", Score = 5 }
			};


			var actual = service.GenerateFinalLeaderBoardResult(inputData);

			var expected = new List<FinalLeaderBoardResult>
			{
			  new FinalLeaderBoardResult { InitialLeaderBoardResult = new InitialLeaderBoardResult  { Name = "Rango", Score = 15 }, Rank = 1  },
			  new FinalLeaderBoardResult { InitialLeaderBoardResult = new InitialLeaderBoardResult  { Name = "Gango", Score = 13 }, Rank = 2  },
			  new FinalLeaderBoardResult { InitialLeaderBoardResult = new InitialLeaderBoardResult  { Name = "Mango", Score = 9 }, Rank = 3  },
			  new FinalLeaderBoardResult { InitialLeaderBoardResult = new InitialLeaderBoardResult  { Name = "Sango", Score = 9 }, Rank = 3   },
			  new FinalLeaderBoardResult { InitialLeaderBoardResult = new InitialLeaderBoardResult  { Name = "Jango", Score = 5 }, Rank = 5   }

			};


			actual.Should().BeEquivalentTo(expected);

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
			  return initialLeaderBoardResult
				.OrderByDescending(initialLeaderBoardResult => initialLeaderBoardResult.Score)
				.Select((initialLeaderBoardResult, index) => new FinalLeaderBoardResult { InitialLeaderBoardResult = initialLeaderBoardResult, Rank = index + 1});
			}
		}
	
}





