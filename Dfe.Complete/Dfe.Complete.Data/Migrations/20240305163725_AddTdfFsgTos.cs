using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dfe.ManageFreeSchoolProjects.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTdfFsgTos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
					EXEC ('CREATE FUNCTION [dbo].[tdf_FSG_TOS]  
                    (  
                     @TOS NVARCHAR(10)
                    )  
      
                    RETURNS TABLE  
                    AS  
                    RETURN  
                    (  
                     SELECT fp.*  
                     FROM [dbo].[Property] fp
                     WHERE fp.[TOS] = @TOS  
                    )
					')
            ");

            migrationBuilder.Sql(@"

                EXEC ('CREATE VIEW [dbo].[vw_MI_Template]

                    AS

                    ---------------------------------------------------------------------------------------------------------------------
                    SELECT 
                    [Free school name] = p.[Project Status.Current free school name],
                    [Project ID] = p.[Project Status.Project ID],
                    [Trust agreement to the department''s model articles of association Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.MAA Baseline date] AS DATE),103),
                    [Trust agreement to the department''s model articles of association Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.MAA Forecast date] AS DATE),103),
                    [Trust agreement to the department''s model articles of association Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.MAA Actual date of completion] AS DATE),103),
                    --[Trust agreement to the department''s model articles of association Link to saved document] = [FSG Pre Opening Milestones.MI107_Link to saved document],
                    [School admissions policy agreed Basline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.SAP Baseline date] AS DATE),103),
                    [School admissions policy agreed Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.SAP Forecast Date] AS DATE),103),
                    [School admissions policy agreed Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.SAP Actual date of completion] AS DATE),103),
                    --[School admissions policy agreed Link to saved document] = [FSG Pre Opening Milestones.MI105_Link to saved document],
                    [Trust agreement to the department''s model funding agreement document Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.MFAD  Baseline date] AS DATE),103),
                    [Trust agreement to the department''s model funding agreement document Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.MFAD Forecast date] AS DATE),103),
                    [Trust agreement to the department''s model funding agreement document Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.MFAD  Actual date of completion] AS DATE),103),
                    --[Trust agreement to the department''s model funding agreement document Link to saved document ] = [FSG Pre Opening Milestones.MI109_Link to saved document],
                    [Draft governance plans submitted Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.DGP  Baseline date] AS DATE),103),
                    [Draft governance plans submitted Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.DGP Forecast date] AS DATE),103),
                    [Draft governance plans submitted Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.DGP Actual date of completion] AS DATE),103),
                    --[Draft governance plans submitted Link to saved document]= [FSG Pre Opening Milestones.MI111_Link to saved document],
                    [Sutiable chair of governors appointed Baseline]= CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.CoGapp Baseline date] AS DATE),103),
                    [Sutiable chair of governors appointed Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.CoGapp Forecast date] AS DATE),103),
                    [Sutiable chair of governors appointed Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.CoGapp Actual date of completion] AS DATE),103),
                    --[Sutiable chair of governors appointed Link to saved document] = [FSG Pre Opening Milestones.MI113_Link to saved document],
                    [High-quality principal designate appointed Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.PDapp Baseline date] AS DATE),103),
                    [High-quality principal designate appointed Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.PDapp Forecast date] AS DATE),103),
                    [High-quality principal designate appointed Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.PDapp Actual date of completion] AS DATE),103),
                    --[High-quality principal designate appointed Link to saved document] = [FSG Pre Opening Milestones.MI115_Link to saved document],
                    [Section 9 letter sent to local authority Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.S9L Baseline date] AS DATE),103),
                    [Section 9 letter sent to local authority Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.S9L Forecast date] AS DATE),103),
                    [Section 9 letter sent to local authority Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.S9L Actual date of completion] AS DATE),103),
                    --[Section 9 letter sent to local authority Link to saved document] = [FSG Pre Opening Milestones.MI117_Link to saved document],
                    [Draft education brief submitted to Education Adviser Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.EdBr Baseline date] AS DATE),103),
                    [Draft education brief submitted to Education Adviser Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.EdBr Forecast date] AS DATE),103),
                    [Draft education brief submitted to Education Adviser Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.EdBr Actual date of completion] AS DATE),103),
                    --[Draft education brief submitted to Education Adviser Link to saved document] = [FSG Pre Opening Milestones.MI119_Link to saved document],
                    [Break even financial plan agreed Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.BEFP Baseline date] AS DATE),103),
                    [Break even financial plan agreed Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.BEFP Forecast date] AS DATE),103),
                    [Break even financial plan agreed Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.BEFP Actual date of completion] AS DATE),103),
                    --[Break even financial plan agreed Link to saved document] = [FSG Pre Opening Milestones.MI123_Link to saved document],
                    [Final governance plan agreed Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.FGPA Baseline date] AS DATE),103),
                    [Final governance plan agreed Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.FGPA Forecast date] AS DATE),103),
                    [Final governance plan agreed Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.FGPA Actual date of completion] AS DATE),103),
                    --[Final governance plan agreed Link to saved document] = [FSG Pre Opening Milestones.MI125_Link to saved document],
                    [Pre-FA checkpoint meeting completed successfully Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.PFACM Baseline date] AS DATE),103),
                    [Pre-FA checkpoint meeting completed successfully Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.PFACM Forecast date] AS DATE),103),
                    [Pre-FA checkpoint meeting completed successfully Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.PFACM Actual date of completion] AS DATE),103),
                    --[Pre-FA checkpoint meeting completed successfully Link to saved document] = [FSG Pre Opening Milestones.MI127_Link to saved document],
                    [Statutory consultation completed Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.SCC Baseline date] AS DATE),103),
                    [Statutory consultation completed Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.SCC Forecast date] AS DATE),103),
                    [Statutory consultation completed Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.SCC Actual date of completion] AS DATE),103),
                    --[Statutory consultation completed Link to saved document] = [FSG Pre Opening Milestones.MI129_Link to saved document],
                    [Evidence of applications which exceeds the schools break even number Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.AppEv Baseline date] AS DATE),103),
                    [Evidence of applications which exceeds the schools break even number Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.AppEv Forecast date] AS DATE),103),
                    [Evidence of applications which exceeds the schools break even number Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.AppEv Actual date of completion] AS DATE),103),
                    --[Evidence of applications which exceeds the schools break even number Link to saved document] = [FSG Pre Opening Milestones.MI121_Link to saved document],
                    [All suitability and DBS checks initiated and at least 3 completed Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.DBSI Baseline date] AS DATE),103),
                    [All suitability and DBS checks initiated and at least 3 completed Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.DBSI Forecast date] AS DATE),103),
                    [All suitability and DBS checks initiated and at least 3 completed Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.DBSI Actual date of completion] AS DATE),103),
                    --[All suitability and DBS checks initiated and at least 3 completed Link to saved document] = [FSG Pre Opening Milestones.MI133_Link to saved document],
                    [Funding Agreement signed Baseline] =CONVERT(VARCHAR(10),CAST(m. [FSG Pre Opening Milestones.FA Baseline date] AS DATE),103),
                    [Funding Agreement signed Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.FA Forecast date] AS DATE),103),
                    [Funding Agreement signed Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.FA Actual date of completion] AS DATE),103),
                    --[Funding Agreement signed Link to saved document] = [FSG Pre Opening Milestones.MI141_Link to saved document],
                    [Statutory consultation report provided to FSG Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.SCR Baseline date] AS DATE),103),
                    [Statutory consultation report provided to FSG Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.SCR Forecast date] AS DATE),103),
                    [Statutory consultation report provided to FSG Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.SCR Actual date of completion] AS DATE),103),
                    --[Statutory consultation report provided to FSG Link to saved document] = [FSG Pre Opening Milestones.MI131_Link to saved document],
                    [Impact assessment and equalities analysis completed Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.IAEA Baseline date] AS DATE),103),
                    [Impact assessment and equalities analysis completed Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.IAEA Forecast date] AS DATE),103),
                    [Impact assessment and equalities analysis completed Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.IAEA Actual date of completion] AS DATE),103),
                    --[Impact assessment and equalities analysis completed Link to saved document] = [FSG Pre Opening Milestones.MI135_Link to saved document],
                    [DfE EA content with education brief, assessment and tracking and safeguarding policy Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.EAPol Baseline date] AS DATE),103),
                    [DfE EA content with education brief, assessment and tracking and safeguarding policy Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.EAPol  Forecast date] AS DATE),103),
                    [DfE EA content with education brief, assessment and tracking and safeguarding policy Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.EAPol Actual date of completion] AS DATE),103),
                    --[DfE EA content with education brief, assessment and tracking and safeguarding policy Link to saved document] = [FSG Pre Opening Milestones.MI137_Link to saved document],
                    [Trust completes and returns the FSRDApp1 form (faith designated schools only) Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.FSRD Baseline date] AS DATE),103),
                    [Trust completes and returns the FSRDApp1 form (faith designated schools only) Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.FSRD Forecast date] AS DATE),103),
                    [Trust completes and returns the FSRDApp1 form (faith designated schools only) Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.FSRD Actual date of completion] AS DATE),103),
                    --[Trust completes and returns the FSRDApp1 form (faith designated schools only) Link to saved document] = [FSG Pre Opening Milestones.MI139_Link to saved document],
                    [Evidence of accepted place offers which exceeds the break even number Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.EAO Baseline date] AS DATE),103),
                    [Evidence of accepted place offers which exceeds the break even number Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.EAO Forecast date] AS DATE),103),
                    [Evidence of accepted place offers which exceeds the break even number Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.EAO Actual date of completion] AS DATE),103),
                    --[Evidence of accepted place offers which exceeds the break even number Link to saved document] = [FSG Pre Opening Milestones.MI143_Link to saved document],
                    [Final version of detailed curriculum plans submitted Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.FCP Baseline date] AS DATE),103),
                    [Final version of detailed curriculum plans submitted Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.FCP Forecast date] AS DATE),103),
                    [Final version of detailed curriculum plans submitted Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.FCP Actual date of completion] AS DATE),103),
                    --[Final version of detailed curriculum plans submitted Link to saved document] = [FSG Pre Opening Milestones.MI145_Link to saved document],
                    [Ofsted pre-registration inspection concludes the school is likely to meet all Edu Regs 2014 Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.OPR Baseline date] AS DATE),103),
                    [Ofsted pre-registration inspection concludes the school is likely to meet all Edu Regs 2014 Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.OPR Forecast date] AS DATE),103),
                    [Ofsted pre-registration inspection concludes the school is likely to meet all Edu Regs 2014 Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.OPR Actual date of completion] AS DATE),103),
                    --[Ofsted pre-registration inspection concludes the school is likely to meet all Edu Regs 2014 Link to saved document] = [FSG Pre Opening Milestones.MI147_Link to saved document],
                    [Readiness to Open Meeting and any follow-up actions complete Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.ROM Baseline date] AS DATE),103),
                    [Readiness to Open Meeting and any follow-up actions complete Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.ROM Forecast date] AS DATE),103),
                    [Readiness to Open Meeting and any follow-up actions complete Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.ROM Actual date of completion] AS DATE),103),
                    --[Readiness to Open Meeting and any follow-up actions complete Link to saved document] = [FSG Pre Opening Milestones.MI149_Link to saved document],
                    [Final revenue and funding financial plan agreed based on latest no of confirmed accepted place offers Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.FPA Baseline date] AS DATE),103),
                    [Final revenue and funding financial plan agreed based on latest no of confirmed accepted place offers Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.FPA Forecast date] AS DATE),103),
                    [Final revenue and funding financial plan agreed based on latest no of confirmed accepted place offers Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.FPA Actual date of completion] AS DATE),103),
                    --[Final revenue and funding financial plan agreed based on latest no of confirmed accepted place offers Link to saved document] = [FSG Pre Opening Milestones.MI151_Link to saved document],
                    [All DBS checks completed Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.DBSC Baseline date] AS DATE),103),
                    [All DBS checks completed Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.DBSC Forecast date] AS DATE),103),
                    [All DBS checks completed Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.DBSC Actual date of completion] AS DATE),103),
                    --[All DBS checks completed Link to saved document] = [FSG Pre Opening Milestones.MI153_Link to saved document],
                    [GIAS registration Baseline] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.GIAS Baseline date] AS DATE),103),
                    [GIAS registration Forecast] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.GIAS Forecast date] AS DATE),103),
                    [GIAS registration Actual] = CONVERT(VARCHAR(10),CAST(m.[FSG Pre Opening Milestones.GIAS Actual date of completion] AS DATE),103),
                    --[Edubase registration Link to saved document] = [FSG Pre Opening Milestones.MI155_Link to saved document],
                    [School opens] = CASE
                                         WHEN CONVERT(VARCHAR(10),CAST(p.[Project Status.Provisional opening date agreed with trust] AS DATE),103) = ''01/01/1900'' THEN ''''
                                                         WHEN CONVERT(VARCHAR(10),CAST(p.[Project Status.Provisional opening date agreed with trust] AS DATE),103) = ''01/01/1990'' THEN ''''
                                                         WHEN CONVERT(VARCHAR(10),CAST(p.[Project Status.Provisional opening date agreed with trust] AS DATE),103) = ''01/09/1900'' THEN ''''
                                                         ELSE CONVERT(VARCHAR(10),CAST(p.[Project Status.Provisional opening date agreed with trust] AS DATE),103)
                                                         END
                    FROM [dbo].[KPI] p
                    LEFT JOIN [dbo].[Milestones] m ON p.[RID] = m.[RID]
                    WHERE p.[Upper Status] = ''Pipeline''
					
					')
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP FUNCTION [dbo].[tdf_FSG_TOS] 
            ");

            migrationBuilder.Sql(@"
                DROP VIEW [dbo].[vw_MI_Template]
            ");

            
        }
    }
}
