namespace Music.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("singer")]
    public partial class singer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public singer()
        {
            albums = new HashSet<album>();
            songs = new HashSet<song>();
        }

        [Key]
        [DisplayName("Ca sĩ")]
        public int singer_id { get; set; }

        [StringLength(50)]
        [DisplayName("Tên Ca sĩ")]
        public string singer_name { get; set; }

        [StringLength(50)]
        [DisplayName("Nghệ danh")]
        public string singer_nickname { get; set; }

        [DisplayName("Giới tính")]
        public bool? singer_sex { get; set; }

        [StringLength(50)]
        [DisplayName("Quốc gia")]
        public string singer_country { get; set; }

        [StringLength(250)]
        [DisplayName("Hình")]
        public string singer_image { get; set; }

        [StringLength(250)]
        [DisplayName("Hình bìa")]
        public string singer_cover_image { get; set; }

        [DisplayName("Sinh nhật")]
        public DateTime? singer_dateofbirth { get; set; }

        [StringLength(3000)]
        [DisplayName("Tiểu sử")]
        public string singer_description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<album> albums { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<song> songs { get; set; }
    }
}