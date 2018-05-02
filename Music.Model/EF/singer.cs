namespace Music.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("singer")]
    public partial class singer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public singer()
        {
            comment_singer = new HashSet<comment_singer>();
            songs = new HashSet<song>();
        }

        [Key]
        public int singer_id { get; set; }

        [StringLength(50)]
        public string singer_name { get; set; }

        [StringLength(50)]
        public string singer_nickname { get; set; }

        public bool? singer_sex { get; set; }

        [StringLength(50)]
        public string singer_country { get; set; }

        [StringLength(250)]
        public string singer_image { get; set; }

        [StringLength(250)]
        public string singer_cover_image { get; set; }

        public DateTime? singer_dateofbirth { get; set; }

        [StringLength(3000)]
        public string singer_description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comment_singer> comment_singer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<song> songs { get; set; }
    }
}