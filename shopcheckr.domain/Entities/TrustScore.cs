using shopcheckr.domain.Enums;

namespace shopcheckr.domain.Entities;
public class TrustScore
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public double Value { get; private set; } // 0–100
    public RiskLevel RiskLevel { get; private set; }

    public TrustScore(double value)
    {
        if (value < 0 || value > 100)
            throw new ArgumentOutOfRangeException(nameof(value), "Trust score must be between 0 and 100");

        Value = value;
        RiskLevel = CalculateRiskLevel(value);
    }

    private RiskLevel CalculateRiskLevel(double score) =>
            score switch
            {
                >= 80 => RiskLevel.Low,
                >= 50 => RiskLevel.Medium,
                _ => RiskLevel.High
            };

}
