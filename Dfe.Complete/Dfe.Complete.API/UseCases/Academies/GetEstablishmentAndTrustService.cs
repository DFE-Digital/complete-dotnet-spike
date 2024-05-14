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

            var establishment = establishmentTask.Result.FirstOrDefault();
            var trustLookup = trustTask.Result.ToDictionary(t => t.Ukprn);

            var result = new GetEstablishmentAndTrustResponse
            {
                Establishment = establishment,
                IncomingTrust = GetTrust(incomingTrustUkPrn, trustLookup),
                OutgoingTrust = GetTrust(outgoingTrustUkPrn, trustLookup),
            };

            return result;
        }

        private GetTrustResponse GetTrust(int? ukPrn, Dictionary<string, GetTrustResponse> trustLookup)
        {
            GetTrustResponse result = null;

            if (ukPrn.HasValue && trustLookup.ContainsKey(ukPrn.ToString()))
            {
                result = trustLookup[ukPrn.ToString()];
            }

            return result;
        }
    }
}
