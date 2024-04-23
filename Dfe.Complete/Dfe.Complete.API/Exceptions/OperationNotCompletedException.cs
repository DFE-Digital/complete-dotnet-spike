namespace Dfe.Complete.API.Exceptions;

public class OperationNotCompletedException : Exception
{
	public OperationNotCompletedException(string message) : base(message)
	{

	}
}