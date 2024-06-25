using DocumentFormat.OpenXml.Drawing.Charts;
using System.Runtime.CompilerServices;

namespace Dfe.Complete.API.UseCases.Academies
{
    public interface IGetEstablishmentAndTrustService
    {
        public Task<GetEstablishmentAndTrustResponse> Execute(int urn, int? incomingTrustUkPrn, int? outgoingTrustUkPrn);
        public Task<GetMultipleEstablishmentAndTrustResponse> Execute(
            List<int> urns,
            List<int?> incomingTrustUkPrns,
            List<int?> outgoingTrustUkPrns);
    }

    public record GetEstablishmentAndTrustResponse
    {
        public GetEstablishmentResponse Establishment { get; set; }
        public GetTrustResponse IncomingTrust { get; set; }
        public GetTrustResponse OutgoingTrust { get; set; }
    }

    public record GetMultipleEstablishmentAndTrustResponse
    {
        public Dictionary<string, GetEstablishmentResponse> Establishments { get; set; }
        public Dictionary<string, GetTrustResponse> Trusts { get; set; }
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
            var ukPrns = CombineUkPrns(new List<int?> { incomingTrustUkPrn }, new List<int?> { outgoingTrustUkPrn });

            var establishmentTask = GetEstablishmentList([urn]);
            var trustTask = GetTrustList(ukPrns.ToArray());

            await Task.WhenAll(trustTask, establishmentTask);

            var establishmentLookup = establishmentTask.Result;
            var trustLookup = trustTask.Result;

            var result = new GetEstablishmentAndTrustResponse
            {
                Establishment = GetEstablishment(urn, establishmentLookup),
                IncomingTrust = GetTrust(incomingTrustUkPrn, trustLookup),
                OutgoingTrust = GetTrust(outgoingTrustUkPrn, trustLookup),
            };

            return result;
        }

        public async Task<GetMultipleEstablishmentAndTrustResponse> Execute(
            List<int> urns,
            List<int?> incomingTrustUkPrns,
            List<int?> outgoingTrustUkPrns)
        {
            var trustUkPrns = CombineUkPrns(incomingTrustUkPrns, outgoingTrustUkPrns);

            var establishmentLookupTask = GetEstablishmentList(urns.ToArray());
            var trustLookupTask = GetTrustList(trustUkPrns.ToArray());

            await Task.WhenAll(establishmentLookupTask, trustLookupTask);

            var result = new GetMultipleEstablishmentAndTrustResponse
            {
                Establishments = establishmentLookupTask.Result,
                Trusts = trustLookupTask.Result
            };

            return result;
        }

        private static List<int> CombineUkPrns(List<int?> incomingTrustUkPrns, List<int?> outgoingTrustUkPrns)
        {
            var ukPrns = new List<int>();

            incomingTrustUkPrns.ForEach(ukPrn =>
            {
                if (ukPrn.HasValue)
                {
                    ukPrns.Add(ukPrn.Value);
                }
            });

            outgoingTrustUkPrns.ForEach(ukPrn =>
            {
                if (ukPrn.HasValue)
                {
                    ukPrns.Add(ukPrn.Value);
                }
            });

            return ukPrns;
        }

        private async Task<Dictionary<string, GetEstablishmentResponse>> GetEstablishmentList(int[] urns)
        {
            var establishments = await _getEstablishmentsBulkService.Execute(urns);

            var result = establishments.ToDictionary(e => e.Urn);

            return result;
        }

        private async Task<Dictionary<string, GetTrustResponse>> GetTrustList(int[] ukPrns)
        {
            var trusts = await _getTrustsBulkService.Execute(ukPrns.ToArray());

            var result = trusts.ToDictionary(t => t.Ukprn);

            return result;
        }

        private GetEstablishmentResponse GetEstablishment(int urn, Dictionary<string, GetEstablishmentResponse> establishmentLookup)
        {
            GetEstablishmentResponse result;

            if (establishmentLookup.ContainsKey(urn.ToString()))
            {
                result = establishmentLookup[urn.ToString()];
            }
            else
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
