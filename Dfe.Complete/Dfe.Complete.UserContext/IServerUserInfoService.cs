using Microsoft.AspNetCore.Http;

namespace Dfe.Complete.UserContext;

public interface IServerUserInfoService
{
	void ReceiveRequestHeaders(IHeaderDictionary headers);
	UserInfo? UserInfo { get; }
}