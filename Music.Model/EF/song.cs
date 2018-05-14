namespace Music.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
            genres = new HashSet<genre>();
            playlists = new HashSet<playlist>();
        }

        [Key]
        public int song_id { get; set; }

        [DisplayName("Album")]
        public int album_id { get; set; }

        [DisplayName("Ca sĩ")]
        public int singer_id { get; set; }

        [DisplayName("Tác giả")]
        public int author_id { get; set; }

        [StringLength(50)]
        [DisplayName("Tên bài hát")]
        public string song_name { get; set; }

        [StringLength(250)]
        [DisplayName("Đường dẫn bài hát")]
        public string song_path { get; set; }

        [StringLength(3000)]
        [DisplayName("Lời bài hát")]
        public string song_lyric { get; set; }

        [DisplayName("Tổng lượt xem")]
        public int? song_view { get; set; }

        [DisplayName("Xem ngày")]
        public int? song_viewed_day { get; set; }

        [DisplayName("Xem tuần")]
        public int? song_viewed_week { get; set; }

        [DisplayName("Xem tháng")]
        public int? song_viewed_month { get; set; }

        [DisplayName("Tổng lượt tải")]
        public int? song_download { get; set; }

        [DisplayName("Tải tuần")]
        public int? song_downloaded_week { get; set; }

        [DisplayName("Tải tháng")]
        public int? song_downloaded_month { get; set; }

        [DisplayName("Ngày cập nhật")]
        public DateTime? song_datemodify { get; set; }

        public virtual album album { get; set; }

        public virtual author author { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comment_song> comment_song { get; set; }

        public virtual singer singer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<upload_song> upload_song { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<genre> genres { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<playlist> playlists { get; set; }
    }
}