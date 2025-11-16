using shopcheckr.domain.Entities;
using shopcheckr.domain.Enums;

namespace shopcheckr.domain.Interfaces;
public interface IShopScraper
{
    Task<List<ShopMention>> GetMentionsAsync(string shopHandle, PlatformType platform);
}
