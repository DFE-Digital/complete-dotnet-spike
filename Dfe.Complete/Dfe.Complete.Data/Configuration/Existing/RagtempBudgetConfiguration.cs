using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class RagtempBudgetConfiguration : IEntityTypeConfiguration< RagtempBudget>
	{
		public void Configure(EntityTypeBuilder<RagtempBudget> builder)
		{
            builder
                .HasNoKey()
                .ToTable("RAGTEMP_BUDGET", "dbo");

            builder.Property(e => e.ConstructionCostsInclPassiveIctPlanningObligationsExclVatCostToDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Construction Costs (incl passive ICT / Planning Obligations) excl VAT Cost to date");
            builder.Property(e => e.ConstructionCostsInclPassiveIctPlanningObligationsExclVatForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Construction Costs (incl passive ICT / Planning Obligations) excl VAT Forecast");
            builder.Property(e => e.FfEExclVatCostToDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FF & E (excl VAT) Cost to date");
            builder.Property(e => e.FfEExclVatForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FF & E (excl VAT) Forecast");
            builder.Property(e => e.Fscode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FSCode");
            builder.Property(e => e.IctActivesExclVatCostToDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ICT Actives (excl VAT) Cost to date");
            builder.Property(e => e.IctActivesExclVatForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ICT Actives (excl VAT) Forecast");
            builder.Property(e => e.IctBroadbandExclVatCostToDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ICT Broadband (excl VAT) Cost to date");
            builder.Property(e => e.IctBroadbandExclVatForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ICT Broadband (excl VAT) Forecast");
            builder.Property(e => e.IctHardwareEquipmentExclVatCostToDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ICT Hardware Equipment (excl VAT) Cost to date");
            builder.Property(e => e.IctHardwareEquipmentExclVatForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ICT Hardware Equipment (excl VAT) Forecast");
            builder.Property(e => e.LegalFeesConstructionInclVatComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Legal fees - construction  (incl VAT) Comments");
            builder.Property(e => e.LegalFeesConstructionInclVatCostUptoDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Legal fees - construction  (incl VAT) Cost upto date");
            builder.Property(e => e.LegalFeesConstructionInclVatForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Legal fees - construction  (incl VAT) Forecast");
            builder.Property(e => e.PermanentBudgetRag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Permanent Budget RAG");
            builder.Property(e => e.PermanentConstructionCostsInclPassiveIctPlanningObligationsExclVatComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Permanent Construction Costs (incl passive ICT / Planning Obligations) excl VAT Comments");
            builder.Property(e => e.PermanentConstructionSubTotalComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Permanent Construction sub total comments");
            builder.Property(e => e.PermanentFfEExclVatComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Permanent FF & E (excl VAT) Comments");
            builder.Property(e => e.PermanentIctActivesExclVatComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Permanent  ICT Actives (excl VAT) Comments");
            builder.Property(e => e.PermanentIctBroadbandExclVatComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Permanent  ICT Broadband (excl VAT) Comments");
            builder.Property(e => e.PermanentIctDecantCostToDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Permanent ICT Decant Cost to date");
            builder.Property(e => e.PermanentIctDecantExclVatComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Permanent ICT Decant (excl VAT) Comments");
            builder.Property(e => e.PermanentIctDecantExclVatForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Permanent ICT Decant (excl VAT) forecast");
            builder.Property(e => e.PermanentIctHardwareEquipmentExclVatComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Permanent ICT Hardware Equipment (excl VAT) Comments");
            builder.Property(e => e.PermanentTaFeesInclVat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Permanent TA Fees (Incl VAT)");
            builder.Property(e => e.PermanentTaSurveysInclVatComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Permanent TA Surveys (Incl VAT Comments");
            builder.Property(e => e.TaFeesInclVatCostToDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TA Fees (Incl VAT) Cost to date");
            builder.Property(e => e.TaFeesInclVatForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TA Fees (Incl VAT) Forecast");
            builder.Property(e => e.TaSurveysInclVatCostToDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TA Surveys (Incl VAT) Cost to date");
            builder.Property(e => e.TaSurveysInclVatForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TA Surveys (Incl VAT) Forecast");
            builder.Property(e => e.TemporaryBudgetRag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary Budget RAG");
            builder.Property(e => e.TemporaryConstructionCostsInclPassiveIctPlanningObligationsExclVatComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary Construction Costs (incl passive ICT / Planning Obligations) excl VAT Comments");
            builder.Property(e => e.TemporaryConstructionCostsInclPassiveIctPlanningObligationsExclVatCostToDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary Construction Costs (incl passive ICT / Planning Obligations) excl VAT Cost to Date");
            builder.Property(e => e.TemporaryConstructionCostsInclPassiveIctPlanningObligationsExclVatForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary Construction Costs (incl passive ICT / Planning Obligations) excl VAT Forecast");
            builder.Property(e => e.TemporaryConstructionSubTotalComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary Construction sub total comments");
            builder.Property(e => e.TemporaryFfEExclVatComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary FF & E (excl VAT) Comments");
            builder.Property(e => e.TemporaryFfEExclVatCostToDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary FF & E (excl VAT) Cost to Date");
            builder.Property(e => e.TemporaryFfEExclVatForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary FF & E (excl VAT) Forecast");
            builder.Property(e => e.TemporaryIctActivesExclVatComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary  ICT Actives (excl VAT) Comments");
            builder.Property(e => e.TemporaryIctActivesExclVatCostToDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary  ICT Actives (excl VAT) Cost to date");
            builder.Property(e => e.TemporaryIctActivesExclVatForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary ICT Actives (excl VAT) Forecast");
            builder.Property(e => e.TemporaryIctBroadbandExclVatComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary  ICT Broadband (excl VAT) Comments");
            builder.Property(e => e.TemporaryIctBroadbandExclVatCostToDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary  ICT Broadband (excl VAT) Cost to date");
            builder.Property(e => e.TemporaryIctBroadbandExclVatForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary  ICT Broadband (excl VAT) Forecast");
            builder.Property(e => e.TemporaryIctDecantExclVatComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary  ICT Decant (excl VAT) Comments");
            builder.Property(e => e.TemporaryIctDecantExclVatCostToDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary  ICT Decant (excl VAT) Cost to date");
            builder.Property(e => e.TemporaryIctDecantExclVatForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary  ICT Decant (excl VAT) Forecast");
            builder.Property(e => e.TemporaryIctHardwareEquipmentExclVatComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary  ICT Hardware Equipment (excl VAT) Comments");
            builder.Property(e => e.TemporaryIctHardwareEquipmentExclVatCostToDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary  ICT Hardware Equipment (excl VAT) Cost to date");
            builder.Property(e => e.TemporaryIctHardwareEquipmentExclVatForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary  ICT Hardware Equipment (excl VAT) Forecast");
            builder.Property(e => e.TemporaryLegalFeesConstructionInclVatComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary Legal fees - construction  (incl VAT) Comments");
            builder.Property(e => e.TemporaryLegalFeesConstructionInclVatCostToDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary Legal fees - construction  (incl VAT) Cost to date");
            builder.Property(e => e.TemporaryLegalFeesConstructionInclVatForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary Legal fees - construction  (incl VAT) Forecast");
            builder.Property(e => e.TemporaryTaFeesInclVatCostToDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary TA Fees (Incl VAT) Cost to date");
            builder.Property(e => e.TemporaryTaFeesInclVatForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary TA Fees (Incl VAT) Forecast");
            builder.Property(e => e.TemporaryTaFeesInclVatForecastComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary TA Fees (Incl VAT) Forecast Comments");
            builder.Property(e => e.TemporaryTaSurveysInclVatComments)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary TA Surveys (Incl VAT) Comments ");
            builder.Property(e => e.TemporaryTaSurveysInclVatCostToDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary TA Surveys (Incl VAT) Cost to date");
            builder.Property(e => e.TemporaryTaSurveysInclVatForecast)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Temporary TA Surveys (Incl VAT) Forecast");

		}
	}

}
