using EduPlatform.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPlatform.API.Data.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        // Primary Key
        builder.HasKey(c => c.Id);

        // Properties
        builder.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Description)
            .HasMaxLength(2000);

        builder.Property(c => c.Price)
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0);

        builder.Property(c => c.InstructorName)
            .IsRequired()
            .HasMaxLength(150);
        builder.Property(c => c.Level)
            .HasConversion<string>();  // DB'de "Beginner", "Intermediate", "Advanced" olarak saklanır
        // Shadow Properties — entity'de yok ama DB'de var
        builder.Property<DateTime>("CreatedAt");
        builder.Property<DateTime?>("UpdatedAt");

        // Global Query Filter — soft-delete
        // Bu filter tüm Course sorgularına otomatik eklenir
        builder.HasQueryFilter(c => !c.IsDeleted);

        // İlişki: Course → Category (Many-to-One)
        builder.HasOne(c => c.Category)
            .WithMany(cat => cat.Courses)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        // Restrict → Category silinince Course'lar da silinmez (foreign key hatasıyla önlenir)
    }
}
