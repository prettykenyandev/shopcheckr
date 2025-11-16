using shopcheckr.domain.Enums;
using shopcheckr.domain.Interfaces;
using shopcheckr.domain.ValueObjects;

namespace shopcheckr.infrastructure.Services.SentimentAnalysis;

public class SentimentAnalyzer : ISentimentAnalyzer
{
    public async Task<Sentiment> AnalyzeAsync(string comment)
    {
        await Task.Delay(100); // Simulated latency
        var label = comment.Contains("scam", StringComparison.OrdinalIgnoreCase)
            ? SentimentLabel.Negative
            : SentimentLabel.Positive;
        var confidence = label == SentimentLabel.Negative ? 0.9 : 0.7;

        return new Sentiment(label, confidence);
    }
}
