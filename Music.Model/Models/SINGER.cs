namespace Music.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SINGER")]
    public partial class SINGER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SINGER()
        {
            COMMENT_SINGER = new HashSet<COMMENT_SINGER>();
            SONGs = new HashSet<SONG>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SINGER_ID { get; set; }

        [StringLength(50)]
        public string SINGER_NAME { get; set; }

        [StringLength(50)]
        public string SINGER_NICKNAME { get; set; }

        public bool? SINGER_SEX { get; set; }

        [StringLength(50)]
        public string SINGER_COUNTRY { get; set; }

        [StringLength(250)]
        public string SINGER_IMAGE { get; set; }

        [StringLength(250)]
        public string SINGER_COVER_IMAGE { get; set; }

        public DateTime? SINGER_DATEOFBIRTH { get; set; }

        [StringLength(3000)]
        public string SINGER_DESCRIPTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMENT_SINGER> COMMENT_SINGER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SONG> SONGs { get; set; }
    }
}
