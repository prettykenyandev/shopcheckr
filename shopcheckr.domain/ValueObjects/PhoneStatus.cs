namespace shopcheckr.domain.ValueObjects;
public class PhoneStatus
{
    public bool IsReachableByCall { get; }
    public bool IsActiveOnWhatsApp { get; }

    public PhoneStatus(bool isReachableByCall, bool isActiveOnWhatsApp)
    {
        IsReachableByCall = isReachableByCall;
        IsActiveOnWhatsApp = isActiveOnWhatsApp;
    }

    public override bool Equals(object obj) =>
        obj is PhoneStatus other &&
        IsReachableByCall == other.IsReachableByCall &&
        IsActiveOnWhatsApp == other.IsActiveOnWhatsApp;

    public override int GetHashCode() => HashCode.Combine(IsReachableByCall, IsActiveOnWhatsApp);
}
