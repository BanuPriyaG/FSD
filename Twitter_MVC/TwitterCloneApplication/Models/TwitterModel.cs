namespace TwitterCloneApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TwitterModel : DbContext
    {
        public TwitterModel()
            : base("name=TwitterModel")
        {
        }

        public virtual DbSet<Following> Followings { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Tweet> Tweets { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Following>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<Following>()
                .Property(e => e.following_id)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.fullName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Followings)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Tweets)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tweet>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<Tweet>()
                .Property(e => e.message)
                .IsUnicode(false);
        }
    }
}
