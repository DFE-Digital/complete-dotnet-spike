namespace Dfe.Complete.API.UseCases.Academies
{
    public interface IGetEstablishmentAndTrustService
    {
        public Task<GetEstablishmentAndTrustResponse> Execute(int urn, int? incomingTrustUkPrn, int? outgoingTrustUkPrn);
    }

    public record GetEstablishmentAndTrustResponse
    {
        public GetEstablishmentResponse Establishment { get; set; }
        public GetTrustResponse IncomingTrust { get; set; }
        public GetTrustResponse OutgoingTrust { get; set; }
    }

    public class GetEstablishmentAndTrustService : IGetEstablishmentAndTrustService
    {
        private readonly IGetTrustsBulkService _getTrustsBulkService;
        private readonly IGetEstablishmentsBulkService _getEstablishmentsBulkService;

        public GetEstablishmentAndTrustService(
            IGetTrustsBulkService getTrustsBulkService,
            IGetEstablishmentsBulkService getEstablishmentsBulkService)
        {
            _getTrustsBulkService = getTrustsBulkService;
            _getEstablishmentsBulkService = getEstablishmentsBulkService;
        }

        public async Task<GetEstablishmentAndTrustResponse> Execute(int urn, int? incomingTrustUkPrn, int? outgoingTrustUkPrn)
        {
            var ukPrns = new List<int>();

            if (incomingTrustUkPrn.HasValue)
            {
                ukPrns.Add(incomingTrustUkPrn.Value);
            }

            if (outgoingTrustUkPrn.HasValue)
            {
                ukPrns.Add(outgoingTrustUkPrn.Value);
            }

            var trustTask = _getTrustsBulkService.Execute(ukPrns.ToArray());
            var establishmentTask = _getEstablishmentsBulkService.Execute([urn]);

            await Task.WhenAll(trustTask, establishmentTask);

            var establishments = establishmentTask.Result;
            var trustLookup = trustTask.Result.ToDictionary(t => t.Ukprn);

            var result = new GetEstablishmentAndTrustResponse
            {
                Establishment = GetEstablishment(urn, establishments),
                IncomingTrust = GetTrust(incomingTrustUkPrn, trustLookup),
                OutgoingTrust = GetTrust(outgoingTrustUkPrn, trustLookup),
            };

            return result;
        }

        private GetEstablishmentResponse GetEstablishment(int urn, List<GetEstablishmentResponse> establishments)
        {
            var result = establishments.FirstOrDefault();

            if (result == null)
            {
                result = new GetEstablishmentResponse()
                {
                    Urn = urn.ToString(),
                    Name = urn.ToString(),
                };
            }

            return result;
        }

        private GetTrustResponse GetTrust(int? ukPrn, Dictionary<string, GetTrustResponse> trustLookup)
        {
            GetTrustResponse result;

            if (ukPrn.HasValue && trustLookup.ContainsKey(ukPrn.ToString()))
            {
                result = trustLookup[ukPrn.ToString()];
            }
            else
            {
                // If the trust cannot be found then then set the UK PRN that we tried to find
                // Unlikely this happens, but has happened in the past when mistakes are made on GIAS
                result = new GetTrustResponse()
                {
                    Ukprn = ukPrn?.ToString(),
                    Name = ukPrn?.ToString(),
                };
            }

            return result;
        }
    }
}
