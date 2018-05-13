namespace Music.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("playlist")]
    public partial class playlist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public playlist()
        {
            songs = new HashSet<song>();
        }

        [Key]
        public int playlist_id { get; set; }

        public int user_id { get; set; }

        [StringLength(150)]
        [DisplayName("Tên Playlist")]
        public string playlist_name { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime? playlist_createdate { get; set; }

        public virtual user user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<song> songs { get; set; }
    }
}