namespace Music.Model.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MSDbContext : DbContext
    {
        public MSDbContext()
            : base("name=MSDbContext")
        {
        }

        public virtual DbSet<ALBUM> ALBUMs { get; set; }
        public virtual DbSet<AUTHOR> AUTHORs { get; set; }
        public virtual DbSet<COMMENT_ALBUM> COMMENT_ALBUM { get; set; }
        public virtual DbSet<COMMENT_SINGER> COMMENT_SINGER { get; set; }
        public virtual DbSet<COMMENT_SONG> COMMENT_SONG { get; set; }
        public virtual DbSet<GENRE> GENREs { get; set; }
        public virtual DbSet<SINGER> SINGERs { get; set; }
        public virtual DbSet<SONG> SONGs { get; set; }
        public virtual DbSet<UPLOAD_ALBUM> UPLOAD_ALBUM { get; set; }
        public virtual DbSet<UPLOAD_SONG> UPLOAD_SONG { get; set; }
        public virtual DbSet<USER> USERs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ALBUM>()
                .HasMany(e => e.COMMENT_ALBUM)
                .WithRequired(e => e.ALBUM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ALBUM>()
                .HasMany(e => e.UPLOAD_ALBUM)
                .WithRequired(e => e.ALBUM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COMMENT_SINGER>()
                .Property(e => e.COMMENT_SINGER_CREATEDATE)
                .IsFixedLength();

            modelBuilder.Entity<SINGER>()
                .HasMany(e => e.COMMENT_SINGER)
                .WithRequired(e => e.SINGER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SINGER>()
                .HasMany(e => e.SONGs)
                .WithMany(e => e.SINGERs)
                .Map(m => m.ToTable("SONG_SINGER").MapLeftKey("SINGER_ID").MapRightKey("SONG_ID"));

            modelBuilder.Entity<SONG>()
                .HasMany(e => e.COMMENT_SONG)
                .WithRequired(e => e.SONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SONG>()
                .HasMany(e => e.UPLOAD_SONG)
                .WithRequired(e => e.SONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.USER_PHONE)
                .HasPrecision(20, 0);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.COMMENT_ALBUM)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.UPLOAD_ALBUM)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.UPLOAD_SONG)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);
        }
    }
}
