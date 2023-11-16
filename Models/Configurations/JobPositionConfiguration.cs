using CompanyEmployeesWPF.Models.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployeesWPF.Models.Configurations
{
    public class JobPositionConfiguration : EntityTypeConfiguration<JobPosition>
    {
        public JobPositionConfiguration()
        {
            ToTable("dbo.JobPositions");

            Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);
        }

    }
}
