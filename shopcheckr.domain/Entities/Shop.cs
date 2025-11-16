using shopcheckr.domain.Enums;

namespace shopcheckr.domain.Entities;
public class Shop
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Handle { get; private set; }
    public PlatformType Platform { get; private set; }
    public List<ShopMention> Mentions { get; private set; } = new();
    public TrustScore TrustScore { get; private set; }

    public Shop(string handle, PlatformType platform)
    {
        Handle = handle ?? throw new ArgumentNullException(nameof(handle));
        Platform = platform;
    }

    public void AddMention(ShopMention mention) => Mentions.Add(mention);

    public void SetTrustScore(TrustScore score) => TrustScore = score;
}
