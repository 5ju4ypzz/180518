namespace Music.Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RunNow : DbContext
    {
        public RunNow()
            : base("name=RunNowEntities")
        {
        }

        public virtual DbSet<album> albums { get; set; }
        public virtual DbSet<author> authors { get; set; }
        public virtual DbSet<comment_song> comment_song { get; set; }
        public virtual DbSet<genre> genres { get; set; }
        public virtual DbSet<playlist> playlists { get; set; }
        public virtual DbSet<singer> singers { get; set; }
        public virtual DbSet<song> songs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<upload_song> upload_song { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<album>()
                .HasMany(e => e.songs)
                .WithRequired(e => e.album)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<author>()
                .HasMany(e => e.songs)
                .WithRequired(e => e.author)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<genre>()
                .HasMany(e => e.songs)
                .WithMany(e => e.genres)
                .Map(m => m.ToTable("genre_song").MapLeftKey("genre_id").MapRightKey("song_id"));

            modelBuilder.Entity<playlist>()
                .HasMany(e => e.songs)
                .WithMany(e => e.playlists)
                .Map(m => m.ToTable("playlist_song").MapLeftKey("playlist_id").MapRightKey("song_id"));

            modelBuilder.Entity<singer>()
                .HasMany(e => e.albums)
                .WithRequired(e => e.singer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<singer>()
                .HasMany(e => e.songs)
                .WithRequired(e => e.singer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<song>()
                .HasMany(e => e.comment_song)
                .WithRequired(e => e.song)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<song>()
                .HasMany(e => e.upload_song)
                .WithRequired(e => e.song)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .Property(e => e.user_phone)
                .HasPrecision(20, 0);

            modelBuilder.Entity<user>()
                .HasMany(e => e.comment_song)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.playlists)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.upload_song)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);
        }
    }
}
