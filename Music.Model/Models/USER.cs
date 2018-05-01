namespace Music.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USER")]
    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            COMMENT_ALBUM = new HashSet<COMMENT_ALBUM>();
            UPLOAD_ALBUM = new HashSet<UPLOAD_ALBUM>();
            UPLOAD_SONG = new HashSet<UPLOAD_SONG>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int USER_ID { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        [StringLength(32)]
        public string PASSWORD { get; set; }

        [StringLength(50)]
        public string USER_NAME { get; set; }

        public DateTime? USER_DATEOFBIRTH { get; set; }

        public bool? USER_SEX { get; set; }

        [StringLength(100)]
        public string USER_ADDRESS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? USER_PHONE { get; set; }

        [StringLength(250)]
        public string USER_IMAGE { get; set; }

        public int? USER_LEVEL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMENT_ALBUM> COMMENT_ALBUM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UPLOAD_ALBUM> UPLOAD_ALBUM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UPLOAD_SONG> UPLOAD_SONG { get; set; }
    }
}
