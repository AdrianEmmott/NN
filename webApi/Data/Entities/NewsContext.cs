using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace webApi.Data.Entities
{
    public partial class NewsContext : DbContext
    {
        public NewsContext()
        {
        }

        public NewsContext(DbContextOptions<NewsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleTag> ArticleTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TestTable> TestTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost;user=SA;password='dog1Open£';database=News");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("articles");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasColumnName("author");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.HeaderImage).HasColumnName("headerImage");

                entity.Property(e => e.PublishDate)
                    .HasColumnType("datetime")
                    .HasColumnName("publishDate");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.SubTitle).HasColumnName("subTitle");

                entity.Property(e => e.Summary).HasColumnName("summary");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");

                entity.Property(e => e.Views).HasColumnName("views");
            });

            modelBuilder.Entity<ArticleTag>(entity =>
            {
                entity.HasKey(e => new { e.ArticleId, e.TagId })
                    .HasName("PK__articleT__10DC136B85EFE8FE");

                entity.ToTable("articleTags");

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.TagId).HasColumnName("tagId");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleTags)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__articleTa__artic__3E52440B");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ArticleTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__articleTa__tagId__3F466844");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tags");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ParentId).HasColumnName("parentId");

                entity.Property(e => e.ShowInNav).HasColumnName("showInNav");

                entity.Property(e => e.SortOrder).HasColumnName("sortOrder");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("fk_tags_parentId");
            });

            modelBuilder.Entity<TestTable>(entity =>
            {
                entity.ToTable("testTable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
