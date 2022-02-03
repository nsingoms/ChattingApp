namespace ChattingApp.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) 
            : base(options, operationalStoreOptions)
        {
        }
        public DbSet<ChatMessage> ChatMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ChatMessage>(entity =>
            {
                entity.HasOne(d => d.FromUser)
                      .WithMany(p => p.ChatMessagesFromUsers)
                      .HasForeignKey(f => f.FromUserId)
                      .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.ToUser)
                      .WithMany(p => p.ChatMessagesToUsers)
                      .HasForeignKey(f => f.ToUserId)
                      .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}