
[Fact]
public void HighScoreWithoutDuplicateTest()
{
	var inputData = new List<Result>
	{
		new Result { Name = "Gango", Score = 13 },
		new Result { Name = "Mango", Score = 11 },
		new Result { Name = "Sango", Score = 9 },
		new Result { Name = "Rango", Score = 15 }
	};
	
	var expected = new List<LeaderBoardData>
	{
	  new LeaderBoardData { Result { Name = "Gango", Score = 13 }, Rank = 2 }, 
	  new LeaderBoardData { Result { Name = "Mango", Score = 11 }, Rank = 3 },
      new LeaderBoardData { Result { Name = "Sango", Score = 9 }, Rank = 4  },
      new LeaderBoardData { Result { Name = "Rango", Score = 15 }, Rank = 1 }
	};
	
	var service = new LeaderBoardService();
	var actual = service.GenerateLeaderBoardData(inputData);

	actual.Should().BeEquivalentTo(expected);
}
	
public class Result
{
	public string Name { get; set; }
	public int Score { get; set; }
}

public class LeaderBoardData
{
	public Result Result { get; set; }
	public int Rank { get; set; }
}

public class LeaderBoardService
{
	public IEnumerable<LeaderBoardData> GenerateLeaderBoardData(List<Result> inputData)
	{

	}
}
