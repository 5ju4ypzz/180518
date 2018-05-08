namespace Music.Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MusicDbContext : DbContext
    {
        public MusicDbContext()
            : base("name=MusicDbContext")
        {
        }

        public virtual DbSet<album> albums { get; set; }
        public virtual DbSet<author> authors { get; set; }
        public virtual DbSet<comment_album> comment_album { get; set; }
        public virtual DbSet<comment_singer> comment_singer { get; set; }
        public virtual DbSet<comment_song> comment_song { get; set; }
        public virtual DbSet<genre> genres { get; set; }
        public virtual DbSet<singer> singers { get; set; }
        public virtual DbSet<song> songs { get; set; }
        public virtual DbSet<upload_album> upload_album { get; set; }
        public virtual DbSet<upload_song> upload_song { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<album>()
                .HasMany(e => e.comment_album)
                .WithRequired(e => e.album)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<album>()
                .HasMany(e => e.upload_album)
                .WithRequired(e => e.album)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<author>()
                .Property(e => e.author_createdate)
                .IsFixedLength();

            modelBuilder.Entity<comment_album>()
                .Property(e => e.comment_album_createdate)
                .IsFixedLength();

            modelBuilder.Entity<comment_singer>()
                .Property(e => e.comment_singer_createdate)
                .IsFixedLength();

            modelBuilder.Entity<comment_song>()
                .Property(e => e.comment_song_createdate)
                .IsFixedLength();

            modelBuilder.Entity<genre>()
                .Property(e => e.genre_createdate)
                .IsFixedLength();

            modelBuilder.Entity<singer>()
                .HasMany(e => e.comment_singer)
                .WithRequired(e => e.singer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<singer>()
                .HasMany(e => e.songs)
                .WithMany(e => e.singers)
                .Map(m => m.ToTable("song_singer").MapLeftKey("singer_id").MapRightKey("song_id"));

            modelBuilder.Entity<song>()
                .HasMany(e => e.comment_song)
                .WithRequired(e => e.song)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<song>()
                .HasMany(e => e.upload_song)
                .WithRequired(e => e.song)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<upload_album>()
                .Property(e => e.upload_album_date)
                .IsFixedLength();

            modelBuilder.Entity<upload_song>()
                .Property(e => e.upload_song_date)
                .IsFixedLength();

            modelBuilder.Entity<user>()
                .Property(e => e.user_phone)
                .HasPrecision(20, 0);

            modelBuilder.Entity<user>()
                .Property(e => e.user_createdate)
                .IsFixedLength();

            modelBuilder.Entity<user>()
                .HasMany(e => e.comment_album)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.upload_album)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.upload_song)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);
        }
    }
}
