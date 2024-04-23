using Ardalis.GuardClauses;

namespace Dfe.Complete.Logging;

public record CorrelationContext() : ICorrelationContext
{
	public string CorrelationId { get; private set; }
	public void SetContext(string correlationId)
	{
		this.CorrelationId = Guard.Against.NullOrWhiteSpace(correlationId, nameof(correlationId));
	}

	public string HeaderKey { get => "x-correlation-id"; }
}