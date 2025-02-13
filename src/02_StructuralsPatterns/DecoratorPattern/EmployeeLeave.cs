namespace DecoratorPattern;

// Abstract Component
public interface ILeaveCalculator
{
    int CalculateLeaveDays();
}

// Concrete Component
public class BaseLeave : ILeaveCalculator
{
    public int BaseLeaveDays { get; private set; }

    public BaseLeave(int baseLeaveDays)
    {
        BaseLeaveDays = baseLeaveDays;
    }

    public int CalculateLeaveDays()
    {
        return BaseLeaveDays;
    }
}

// Abstract Decorator
public abstract class LeaveDecorator : ILeaveCalculator
{
    // Decorated
    protected readonly ILeaveCalculator leaveCalculator;

    protected LeaveDecorator(ILeaveCalculator leaveCalculator)
    {
        this.leaveCalculator = leaveCalculator;
    }

    public abstract int CalculateLeaveDays();
}

// Concrete Decorator
// Dodanie dni za staż pracy
public class SeniorityLeaveDecorator : LeaveDecorator, ILeaveCalculator
{
    public int SeniorityYears { get; private set; }

    public SeniorityLeaveDecorator(ILeaveCalculator leaveCalculator, int seniorityYears) 
        : base(leaveCalculator)
    {        
        SeniorityYears = seniorityYears;
    }

    public override int CalculateLeaveDays()
    {
        if (SeniorityYears >= 5)
        {
            return leaveCalculator.CalculateLeaveDays() + 5;
        }
        else
            return leaveCalculator.CalculateLeaveDays();
    }
}

// Concrete Decorator
// Dodanie dni za ukończone szkolenia
public class CompletedTrainingLeaveDecorator : LeaveDecorator, ILeaveCalculator
{    
    public bool HasCompletedTraining { get; private set; }

    public CompletedTrainingLeaveDecorator(ILeaveCalculator leaveCalculator, bool hasCompletedTraining)
         :base(leaveCalculator)
    {
        HasCompletedTraining = hasCompletedTraining;
    }

    public override int CalculateLeaveDays()
    {
        if (HasCompletedTraining)
        {
            return leaveCalculator.CalculateLeaveDays() + 3;
        }
        else
            return leaveCalculator.CalculateLeaveDays();

    }
}

// Concrete Decorator
// Dodanie dni za specjalne świadczenia
public class SpecialBenefitsLeaveDecorator : LeaveDecorator, ILeaveCalculator
{
    public bool HasSpecialBenefits { get; private set; }

    public SpecialBenefitsLeaveDecorator(ILeaveCalculator leaveCalculator, bool hasSpecialBenefits) : base(leaveCalculator)
    {
        HasSpecialBenefits = hasSpecialBenefits;
    }

    public override int CalculateLeaveDays()
    {
        if (HasSpecialBenefits)
        {
            return leaveCalculator.CalculateLeaveDays() + 2;
        }

        else
            return leaveCalculator.CalculateLeaveDays();
    }
}

