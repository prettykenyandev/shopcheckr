using shopcheckr.application.DTOs;
using shopcheckr.domain.Enums;

namespace shopcheckr.application.Queries.AnalyzeShopMentions;
public class AnalyzeShopMentionsResult
{
    public List<ShopMentionDto> Mentions { get; set; }
    public double TrustScore { get; set; }
    public RiskLevel RiskLevel { get; set; }
}

