using Microsoft.EntityFrameworkCore;
using Task_Tracker_API.Domain;

namespace Task_Tracker_API.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

	public DbSet<BaseTask> Tasks { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<BaseTask>()
			.HasDiscriminator<string>("TaskType")
			.HasValue<BugReportTask>("Bug")
			.HasValue<FeatureRequestTask>("Feature");
	}
}