using System;

public class Ai
{
	private Random rnd;

	public Ai(string text)
	{
		// Please stop looking... There is no real AI here ;-)
		rnd = new Random();
	}

	public int PredictScore()
	{
		var num = rnd.Next(1, 11);
		return num;
	}

}