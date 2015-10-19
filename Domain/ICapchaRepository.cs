namespace Domain
{
    public interface ICapchaRepository
    {
        int FunctionA { get; }
        int FunctionB { get; }
        int CurrentX { get; set; }
    }
}