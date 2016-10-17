namespace DataLayer
{
	using DomainClasses;
	using System.Data.Entity;

	public class DBNewsdeskModel : DbContext
	{
		public DBNewsdeskModel()
			: base("name=DBNewsdeskModel")
		{
			Database.SetInitializer(new DBInitializer());
		}

		public virtual DbSet<Article> Articles { get; set; }

		public virtual DbSet<Author> Authors { get; set; }

		public virtual DbSet<Category> Categories { get; set; }

		public virtual DbSet<Subscriber> Subscribers { get; set; }

		public virtual DbSet<Mail> NotDeliveredMail { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Subscriber>().ToTable("Subscribers");
			modelBuilder.Entity<Category>()
			.HasMany(e => e.Subscribers)
			.WithMany(e => e.Categories).
			Map(
				m =>
				{
					m.MapLeftKey("CategoryId");
					m.MapRightKey("SubscriberId");
					m.ToTable("SubscriberCategories");
				});
			modelBuilder.Entity<Article>()
			.HasMany(e => e.Authors)
			.WithMany(e => e.Articles).
			Map(
				m =>
				{
					m.MapLeftKey("ArticleId");
					m.MapRightKey("AuthorId");
					m.ToTable("AuthorsToArticle");
				});


			
			modelBuilder.Entity<Article>()
			.HasMany(e => e.Categories)
			.WithMany(e => e.Articles).
			Map(
				m =>
				{
					m.MapLeftKey("ArticleId");
					m.MapRightKey("CategoryId");
					m.ToTable("ArticleCategory");
				});


			modelBuilder.Entity<Mail>()
				.HasMany(e => e.Emails)
				.WithMany(e =>e.Emails).
				Map(
				m =>
				{
					m.MapLeftKey("EmailId");
					m.MapRightKey("AuthorId");
					m.ToTable("AuthorToEmail");
				});

			

		}
	}
}