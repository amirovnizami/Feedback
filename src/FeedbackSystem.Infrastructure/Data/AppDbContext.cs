using FeedbackSystem.Core.BranchAggregaet.Specifications;
using FeedbackSystem.Core.CategoryAggregate;
using FeedbackSystem.Core.CommentAggregate;
using FeedbackSystem.Core.StatusAgrregate;
using FeedbackSystem.Core.UsersAggregate;

public class AppDbContext : DbContext
{
  private readonly IDomainEventDispatcher? _dispatcher;

  public AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher? dispatcher)
    : base(options)
  {
    _dispatcher = dispatcher;
  }

  public DbSet<Branch> Branches => Set<Branch>();

  public DbSet<Category> Categories => Set<Category>();
  public DbSet<Status> Statuses => Set<Status>();
  public DbSet<Feedback> Feedbacks => Set<Feedback>();
  public DbSet<User> Users => Set<User>();
  public DbSet<Comment> Comments => Set<Comment>();
  public DbSet<FileEntity> UploadFiles => Set<FileEntity>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Category>()
      .HasMany(c => c.Branches)
      .WithOne(b => b.Category)
      .HasForeignKey(b => b.CategoryId)
      .OnDelete(DeleteBehavior.Cascade);
    modelBuilder.Entity<Feedback>()
      .HasMany(f => f.Comments)
      .WithOne(c => c.Feedback)
      .HasForeignKey(c => c.FeedbackId)
      .OnDelete(DeleteBehavior.Cascade);
    modelBuilder.Entity<Feedback>()
      .HasOne(f => f.Status)
      .WithMany(s => s.Feedbacks)
      .HasForeignKey(f => f.StatusId)
      .OnDelete(DeleteBehavior.NoAction); 

    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    if (_dispatcher == null) return result;

    var entitiesWithEvents = ChangeTracker.Entries<HasDomainEventsBase>()
      .Select(e => e.Entity)
      .Where(e => e.DomainEvents.Any())
      .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

    return result;
  }

  public override int SaveChanges() =>
    SaveChangesAsync().GetAwaiter().GetResult();
}
