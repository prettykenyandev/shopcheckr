using System.ComponentModel.DataAnnotations;

namespace shopcheckr.domain.Enums;

public enum RiskLevel
{
    [Display(Name = "High Risk")]
    High = 0,

    [Display(Name = "Medium Risk")]
    Medium = 1,

    [Display(Name = "Low Risk")]
    Low = 2
}

