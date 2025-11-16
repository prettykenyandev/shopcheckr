using shopcheckr.domain.Entities;

namespace shopcheckr.domain.Interfaces;
public interface ITrustScoreCalculator
{
    TrustScore Calculate(List<ShopMention> mentions);
}
