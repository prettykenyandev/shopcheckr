using shopcheckr.domain.ValueObjects;

namespace shopcheckr.application.DTOs;
public class ShopMentionDto
{
    public string Comment { get; set; }
    public Sentiment Sentiment { get; set; }
    public DateTime Timestamp { get; set; }
    public string SourceVideoUrl { get; set; }
}

