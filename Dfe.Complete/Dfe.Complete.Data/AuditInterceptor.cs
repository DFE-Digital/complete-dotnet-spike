using Dfe.ManageFreeSchoolProjects.API.Contracts.Http;
using Dfe.ManageFreeSchoolProjects.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Dfe.ManageFreeSchoolProjects.Data
{
    public class AuditInterceptor : SaveChangesInterceptor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuditInterceptor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            var context = eventData.Context as MfspContext;

            SetAuditProperties(context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var context = eventData.Context as MfspContext;

            SetAuditProperties(context);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void SetAuditProperties(MfspContext context)
        {
            var entities = context.ChangeTracker.Entries<IAuditable>().ToList();

            if (!entities.Any())
            {
                return;
            }

            var hasUserContextHeader = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue(HttpHeaderConstants.UserContextName, out var userContextNameHeader);

            if (!hasUserContextHeader)
            {
                return;
            }

            int? updatedByUserId = context.Users
                .Where(u => u.Email == userContextNameHeader.ToString())
                .Select(u => (int?)u.Id)
                .FirstOrDefault();

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added || entity.State == EntityState.Modified)
                {
                    entity.Entity.UpdatedByUserId = updatedByUserId;
                }
            }
        }
    }
}
