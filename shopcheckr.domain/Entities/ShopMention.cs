using shopcheckr.domain.ValueObjects;

namespace shopcheckr.domain.Entities;
public class ShopMention
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Comment { get; private set; }
    public Sentiment Sentiment { get; private set; }
    public DateTime Timestamp { get; private set; }
    public string SourceVideoUrl { get; private set; }

    public ShopMention(string comment, Sentiment sentiment, DateTime timestamp, string sourceVideoUrl)
    {
        Comment = comment;
        Sentiment = sentiment;
        Timestamp = timestamp;
        SourceVideoUrl = sourceVideoUrl;
    }
}
