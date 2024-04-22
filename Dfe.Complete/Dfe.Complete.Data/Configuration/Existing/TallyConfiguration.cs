using System;
using System.Collections.Generic;
using Dfe.ManageFreeSchoolProjects.Data.Entities.Existing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dfe.ManageFreeSchoolProjects.Data.Configuration.Existing
{
	public partial class TallyConfiguration : IEntityTypeConfiguration< Tally>
	{
		public void Configure(EntityTypeBuilder<Tally> builder)
		{
            builder
				.HasNoKey()
                .ToTable("Tally", "dbo");

            builder.Property(e => e.Id).HasColumnName("ID");

		}
	}

}
