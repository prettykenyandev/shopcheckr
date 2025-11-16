using shopcheckr.domain.Enums;

namespace shopcheckr.domain.ValueObjects;
public class Sentiment
{
    public SentimentLabel Label { get; }
    public double Confidence { get; }

    public Sentiment(SentimentLabel label, double confidence)
    {
        if (confidence < 0 || confidence > 1)
            throw new ArgumentOutOfRangeException(nameof(confidence), "Confidence must be between 0 and 1");

        Label = label;
        Confidence = confidence;
    }

    public override bool Equals(object obj) =>
        obj is Sentiment other &&
        Label == other.Label &&
        Confidence.Equals(other.Confidence);

    public override int GetHashCode() => HashCode.Combine(Label, Confidence);
}
