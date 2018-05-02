namespace Music.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("album")]
    public partial class album
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public album()
        {
            comment_album = new HashSet<comment_album>();
            songs = new HashSet<song>();
            upload_album = new HashSet<upload_album>();
        }

        [Key]
        public int album_id { get; set; }

        public int? author_id { get; set; }

        [StringLength(50)]
        public string album_name { get; set; }

        public DateTime? album_createdate { get; set; }

        [StringLength(250)]
        public string album_image { get; set; }

        public int? album_view { get; set; }

        public int? album_viewed_day { get; set; }

        public int? album_viewed_week { get; set; }

        public int? album_viewed_month { get; set; }

        public virtual author author { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comment_album> comment_album { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<song> songs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<upload_album> upload_album { get; set; }
    }
}