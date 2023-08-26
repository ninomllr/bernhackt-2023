using thorstopper.Client.Data;

namespace thorstopper.Client.Services;


public interface IAIClassifierService
{
	public Task<int> GetAIRecommendation(string text);
}

public class AIClassifierService : IAIClassifierService
{
	public async Task<int> GetAIRecommendation(string text)
	{
		// How the prediction algorithm works: https://www.youtube.com/watch?v=dQw4w9WgXcQ
		var ai = new Ai(text);
		return ai.PredictScore();
	}
}