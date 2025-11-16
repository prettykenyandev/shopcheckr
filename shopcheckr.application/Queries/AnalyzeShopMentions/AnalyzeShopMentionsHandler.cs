using MediatR;
using shopcheckr.application.DTOs;
using shopcheckr.domain.Interfaces;

namespace shopcheckr.application.Queries.AnalyzeShopMentions;

public class AnalyzeShopMentionsHandler : IRequestHandler<AnalyzeShopMentionsQuery, AnalyzeShopMentionsResult>
{
    private readonly IShopScraper _scraper;
    private readonly ISentimentAnalyzer _analyzer;
    private readonly ITrustScoreCalculator _scoreCalculator;

    public AnalyzeShopMentionsHandler(
        IShopScraper scraper,
        ISentimentAnalyzer analyzer,
        ITrustScoreCalculator scoreCalculator)
    {
        _scraper = scraper;
        _analyzer = analyzer;
        _scoreCalculator = scoreCalculator;
    }

    public async Task<AnalyzeShopMentionsResult> Handle(AnalyzeShopMentionsQuery request, CancellationToken cancellationToken)
    {
        var rawMentions = await _scraper.GetMentionsAsync(request.ShopHandle, request.Platform);

        var enrichedMentions = new List<ShopMentionDto>();
        foreach (var mention in rawMentions)
        {
            var sentiment = await _analyzer.AnalyzeAsync(mention.Comment);
            enrichedMentions.Add(new ShopMentionDto
            {
                Comment = mention.Comment,
                Sentiment = sentiment,
                Timestamp = mention.Timestamp,
                SourceVideoUrl = mention.SourceVideoUrl
            });
        }

        var trustScore = _scoreCalculator.Calculate(rawMentions);

        return new AnalyzeShopMentionsResult
        {
            Mentions = enrichedMentions,
            TrustScore = trustScore.Value,
            RiskLevel = trustScore.RiskLevel
        };
    }
}

