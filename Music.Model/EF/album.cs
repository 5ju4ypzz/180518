namespace Music.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("album")]
    public partial class album
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public album()
        {
            songs = new HashSet<song>();
        }

        [Key]
        [DisplayName("Album")]
        public int album_id { get; set; }

        public int singer_id { get; set; }

        [StringLength(50)]
        [DisplayName("Tên Album")]
        [Required(ErrorMessage = "Mời nhập tên Album!")]
        public string album_name { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime? album_createdate { get; set; }

        [StringLength(250)]
        [DisplayName("Hình")]
        public string album_image { get; set; }

        [DisplayName("Tổng lượt xem")]
        public int? album_view { get; set; }

        [DisplayName("Xem ngày")]
        public int? album_viewed_day { get; set; }

        [DisplayName("Xem tuần")]
        public int? album_viewed_week { get; set; }

        [DisplayName("Xem tháng")]
        public int? album_viewed_month { get; set; }

        public virtual singer singer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<song> songs { get; set; }
    }
}