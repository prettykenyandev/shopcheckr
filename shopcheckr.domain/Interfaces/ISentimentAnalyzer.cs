using shopcheckr.domain.ValueObjects;

namespace shopcheckr.domain.Interfaces;
public interface ISentimentAnalyzer
{
    Task<Sentiment> AnalyzeAsync(string comment);
}
