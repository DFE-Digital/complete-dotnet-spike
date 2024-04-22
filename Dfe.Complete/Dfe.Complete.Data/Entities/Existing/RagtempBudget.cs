using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public partial class MfspContext : DbContext
    {
        public virtual DbSet<Entities.Existing.RagtempBudget> RagtempBudget { get; set; }
    }
}

namespace Dfe.ManageFreeSchoolProjects.Data.Entities.Existing
{
    public partial class RagtempBudget
    {
        public string Fscode { get; set; }

        public string PermanentBudgetRag { get; set; }

        public string TemporaryBudgetRag { get; set; }

        public string ConstructionCostsInclPassiveIctPlanningObligationsExclVatCostToDate { get; set; }

        public string ConstructionCostsInclPassiveIctPlanningObligationsExclVatForecast { get; set; }

        public string PermanentConstructionCostsInclPassiveIctPlanningObligationsExclVatComments { get; set; }

        public string TemporaryConstructionCostsInclPassiveIctPlanningObligationsExclVatCostToDate { get; set; }

        public string TemporaryConstructionCostsInclPassiveIctPlanningObligationsExclVatForecast { get; set; }

        public string TemporaryConstructionCostsInclPassiveIctPlanningObligationsExclVatComments { get; set; }

        public string TaFeesInclVatCostToDate { get; set; }

        public string TaFeesInclVatForecast { get; set; }

        public string PermanentTaFeesInclVat { get; set; }

        public string TemporaryTaFeesInclVatCostToDate { get; set; }

        public string TemporaryTaFeesInclVatForecast { get; set; }

        public string TemporaryTaFeesInclVatForecastComments { get; set; }

        public string TaSurveysInclVatCostToDate { get; set; }

        public string TaSurveysInclVatForecast { get; set; }

        public string PermanentTaSurveysInclVatComments { get; set; }

        public string TemporaryTaSurveysInclVatCostToDate { get; set; }

        public string TemporaryTaSurveysInclVatForecast { get; set; }

        public string TemporaryTaSurveysInclVatComments { get; set; }

        public string LegalFeesConstructionInclVatCostUptoDate { get; set; }

        public string LegalFeesConstructionInclVatForecast { get; set; }

        public string LegalFeesConstructionInclVatComments { get; set; }

        public string TemporaryLegalFeesConstructionInclVatCostToDate { get; set; }

        public string TemporaryLegalFeesConstructionInclVatForecast { get; set; }

        public string TemporaryLegalFeesConstructionInclVatComments { get; set; }

        public string PermanentConstructionSubTotalComments { get; set; }

        public string TemporaryConstructionSubTotalComments { get; set; }

        public string FfEExclVatCostToDate { get; set; }

        public string FfEExclVatForecast { get; set; }

        public string PermanentFfEExclVatComments { get; set; }

        public string TemporaryFfEExclVatCostToDate { get; set; }

        public string TemporaryFfEExclVatForecast { get; set; }

        public string TemporaryFfEExclVatComments { get; set; }

        public string IctHardwareEquipmentExclVatCostToDate { get; set; }

        public string IctHardwareEquipmentExclVatForecast { get; set; }

        public string PermanentIctHardwareEquipmentExclVatComments { get; set; }

        public string TemporaryIctHardwareEquipmentExclVatCostToDate { get; set; }

        public string TemporaryIctHardwareEquipmentExclVatForecast { get; set; }

        public string TemporaryIctHardwareEquipmentExclVatComments { get; set; }

        public string IctActivesExclVatCostToDate { get; set; }

        public string IctActivesExclVatForecast { get; set; }

        public string PermanentIctActivesExclVatComments { get; set; }

        public string TemporaryIctActivesExclVatCostToDate { get; set; }

        public string TemporaryIctActivesExclVatForecast { get; set; }

        public string TemporaryIctActivesExclVatComments { get; set; }

        public string IctBroadbandExclVatCostToDate { get; set; }

        public string IctBroadbandExclVatForecast { get; set; }

        public string PermanentIctBroadbandExclVatComments { get; set; }

        public string TemporaryIctBroadbandExclVatCostToDate { get; set; }

        public string TemporaryIctBroadbandExclVatForecast { get; set; }

        public string TemporaryIctBroadbandExclVatComments { get; set; }

        public string PermanentIctDecantCostToDate { get; set; }

        public string PermanentIctDecantExclVatForecast { get; set; }

        public string PermanentIctDecantExclVatComments { get; set; }

        public string TemporaryIctDecantExclVatCostToDate { get; set; }

        public string TemporaryIctDecantExclVatForecast { get; set; }

        public string TemporaryIctDecantExclVatComments { get; set; }
    }
}