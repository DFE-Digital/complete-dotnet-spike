using Microsoft.AspNetCore.Http;

namespace Dfe.ManageFreeSchoolProjects.UserContext;

public interface IServerUserInfoService
{
	void ReceiveRequestHeaders(IHeaderDictionary headers);
	UserInfo? UserInfo { get; }
}