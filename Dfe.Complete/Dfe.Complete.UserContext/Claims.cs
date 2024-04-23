namespace Dfe.Complete.UserContext
{
	public abstract class Claims
	{
		public const string ClaimPrefix = "concerns-casework.";
		public const string CaseWorkerRoleClaim = $"caseworker";
		public const string TeamLeaderRoleClaim = $"teamleader";
		public const string AdminRoleClaim = $"admin";
	}
}
