using EmployeeProject.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeProject.Repositories.Config
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmployeeId);

            

            builder.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(e => e.IdNumber)
                .HasMaxLength(11)
                .IsRequired();
                

            builder.HasOne(e => e.Senior)
                .WithMany()
                .HasForeignKey(e => e.SeniorId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }

}
