namespace Music.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SONG")]
    public partial class SONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SONG()
        {
            COMMENT_SONG = new HashSet<COMMENT_SONG>();
            UPLOAD_SONG = new HashSet<UPLOAD_SONG>();
            SINGERs = new HashSet<SINGER>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SONG_ID { get; set; }

        public int? ALBUM_ID { get; set; }

        public int? GENRE_ID { get; set; }

        [StringLength(50)]
        public string SONG_NAME { get; set; }

        [StringLength(250)]
        public string SONG_PATH { get; set; }

        [StringLength(3000)]
        public string SONG_LYRIC { get; set; }

        [StringLength(250)]
        public string SONG_IMAGE { get; set; }

        public int? SONG_VIEW { get; set; }

        public int? SONG_VIEWED_DAY { get; set; }

        public int? SONG_VIEWED_WEEK { get; set; }

        public int? SONG_VIEWED_MONTH { get; set; }

        public int? SONG_DOWNLOAD { get; set; }

        public int? SONG_DOWNLOADED_WEEK { get; set; }

        public int? SONG_DOWNLOADED_MONTH { get; set; }

        public virtual ALBUM ALBUM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMENT_SONG> COMMENT_SONG { get; set; }

        public virtual GENRE GENRE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UPLOAD_SONG> UPLOAD_SONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SINGER> SINGERs { get; set; }
    }
}
