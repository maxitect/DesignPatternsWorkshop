namespace DesignPatternsWorkshop.Application.Commands;

public interface IPurchaseCommand
{
    /// <summary>
    /// Applies the command to the given transaction, leaving it in the Undo stack for later action.
    /// </summary>
    public void Execute();
    /// <summary>
    /// Removes the command from the transation, leaving it in the Redo stack for later action.
    /// </summary>
    public void Undo();
}
