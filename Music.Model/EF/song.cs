namespace Music.Model.EF
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("song")]
    public partial class song
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public song()
        {
            comment_song = new HashSet<comment_song>();
            upload_song = new HashSet<upload_song>();
            singers = new HashSet<singer>();
        }

        [Key]
        public int song_id { get; set; }

        public int? album_id { get; set; }

        public int? genre_id { get; set; }

        [StringLength(50)]
        public string song_name { get; set; }

        [StringLength(250)]
        public string song_path { get; set; }

        [StringLength(3000)]
        public string song_lyric { get; set; }

        [StringLength(250)]
        public string song_image { get; set; }

        public int? song_view { get; set; }

        public int? song_viewed_day { get; set; }

        public int? song_viewed_week { get; set; }

        public int? song_viewed_month { get; set; }

        public int? song_download { get; set; }

        public int? song_downloaded_week { get; set; }

        public int? song_downloaded_month { get; set; }

        public virtual album album { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comment_song> comment_song { get; set; }

        public virtual genre genre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<upload_song> upload_song { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<singer> singers { get; set; }
    }
}