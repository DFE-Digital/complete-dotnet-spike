using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks.PDG;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Tasks.PDG.StopPayments
{
    public static class StopPaymentBuilder
    {
        public static StopPaymentTask Build(Po po)
        {
            if (po == null)
            {
                return new StopPaymentTask();
            }

            return new StopPaymentTask()
            {
                PaymentStopped = po.ProjectDevelopmentGrantFundingPaymentsStopped,
                PaymentStoppedDate = po.ProjectDevelopmentGrantFundingDatePaymentsStopped,
            };
        }
    }
}
