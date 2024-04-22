using System.Text.Json.Serialization;

namespace Dfe.ManageFreeSchoolProjects.API.Contracts.ResponseModels
{
    public class ApiSingleResponseV2<TResponse> where TResponse : class
    {
        [JsonPropertyName("data")]
        public TResponse Data { get; set; }

        public ApiSingleResponseV2() => Data = null;
        public ApiSingleResponseV2(TResponse data) => Data = data;
    }
}