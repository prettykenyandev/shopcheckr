using shopcheckr.domain.Entities;
using shopcheckr.domain.Enums;
using shopcheckr.domain.Interfaces;

namespace shopcheckr.infrastructure.Services.TrustScoring;

public class TrustScoreCalculator : ITrustScoreCalculator
{
    public TrustScore Calculate(List<ShopMention> mentions)
    {
        if (mentions.Count == 0) return new TrustScore(0);

        var negativeCount = mentions.Count(m => m.Sentiment?.Label == SentimentLabel.Negative);
        var score = 100 - ((double)negativeCount / mentions.Count * 100);
        return new TrustScore(score);
    }
}

