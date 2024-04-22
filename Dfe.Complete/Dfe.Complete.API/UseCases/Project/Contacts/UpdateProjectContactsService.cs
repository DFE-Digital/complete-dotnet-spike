using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Contacts;
using Dfe.ManageFreeSchoolProjects.API.Contracts.Project.Tasks;
using Dfe.ManageFreeSchoolProjects.API.Exceptions;
using Dfe.ManageFreeSchoolProjects.Data;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ManageFreeSchoolProjects.API.UseCases.Project.Contacts;

public interface IUpdateProjectContactsService
{
    Task Execute(string projectId , UpdateContactsRequest request);
}

public class UpdateProjectContactsService : IUpdateProjectContactsService
{
    private readonly MfspContext _context;

    public UpdateProjectContactsService(MfspContext context)
    {
        _context = context;
    }

    public async Task Execute(string projectId, UpdateContactsRequest request)
    {
        var dbProject = await _context.Kpi.FirstOrDefaultAsync(x => x.ProjectStatusProjectId == projectId);

        if (dbProject == null)
        {
            throw new NotFoundException($"Project with id {projectId} not found");
        }

        var updateRequest = new UpdateContactsRequest()
        {
            Contacts = request.Contacts
        };

        dbProject.KeyContactsChairOfGovernorsName = updateRequest.Contacts.ChairOfGovernorsName ?? dbProject.KeyContactsChairOfGovernorsName;
        dbProject.KeyContactsChairOfGovernorsEmail = updateRequest.Contacts.ChairOfGovernorsEmail ?? dbProject.KeyContactsChairOfGovernorsEmail;
        dbProject.KeyContactsChairOfGovernorsMat = updateRequest.Contacts.SchoolChairOfGovernorsName ?? dbProject.KeyContactsChairOfGovernorsMat;
        dbProject.KeyContactsChairOfGovernorsMatEmail = updateRequest.Contacts.SchoolChairOfGovernorsEmail ?? dbProject.KeyContactsChairOfGovernorsMatEmail;
        
        await _context.SaveChangesAsync();
    }
    
}