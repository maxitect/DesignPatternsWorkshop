namespace DesignPatternsWorkshop.Application.Commands;

public interface IPurchaseCommand
{
    /// <summary>
    /// Applies the effects of the command.
    /// </summary>
    public void Execute();
    /// <summary>
    /// Reverts the effects of the command.
    /// </summary>
    public void Revert();
}
