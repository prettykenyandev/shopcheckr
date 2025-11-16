using Microsoft.Extensions.DependencyInjection;
using shopcheckr.domain.Interfaces;
using shopcheckr.infrastructure.Platforms.TikTok;
using shopcheckr.infrastructure.Services.SentimentAnalysis;
using shopcheckr.infrastructure.Services.TrustScoring;

namespace shopcheckr.infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IShopScraper, TikTokScraper>();
        services.AddScoped<ISentimentAnalyzer, SentimentAnalyzer>();
        services.AddScoped<ITrustScoreCalculator, TrustScoreCalculator>();

        return services;
    }

}
