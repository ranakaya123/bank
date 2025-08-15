namespace Bank.Domain.Enums;

public enum CreditCategory
{
    Individual = 0,
    Corporate = 1
}

public enum ApplicationStatus
{
    Draft,
    Submitted,
    UnderReview,
    Approved,
    Rejected,
    Cancelled
}

public enum RuleType
{
    AmountCalculation,
    TermCalculation,
    InterestCalculation,
    EligibilityCheck,
    MonthlyPaymentCalculation
}

public enum ApprovalStepType
{
    DocumentCheck,
    CreditScoreCheck,
    IncomeVerification,
    CollateralEvaluation,
    RiskAssessment,
    FinalApproval
}

public enum ApprovalStatus
{
    Pending,
    Approved,
    Rejected,
    RequiresMoreInfo
}
