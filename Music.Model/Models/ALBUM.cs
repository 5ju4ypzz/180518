namespace Music.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ALBUM")]
    public partial class ALBUM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ALBUM()
        {
            COMMENT_ALBUM = new HashSet<COMMENT_ALBUM>();
            SONGs = new HashSet<SONG>();
            UPLOAD_ALBUM = new HashSet<UPLOAD_ALBUM>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ALBUM_ID { get; set; }

        public int? AUTHOR_ID { get; set; }

        [StringLength(50)]
        public string ALBUM_NAME { get; set; }

        public DateTime? ALBUM_CREATEDATE { get; set; }

        [StringLength(250)]
        public string ALBUM_IMAGE { get; set; }

        public int? ALBUM_VIEW { get; set; }

        public int? ALBUM_VIEWED_DAY { get; set; }

        public int? ALBUM_VIEWED_WEEK { get; set; }

        public int? ALBUM_VIEWED_MONTH { get; set; }

        public virtual AUTHOR AUTHOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMENT_ALBUM> COMMENT_ALBUM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SONG> SONGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UPLOAD_ALBUM> UPLOAD_ALBUM { get; set; }
    }
}
