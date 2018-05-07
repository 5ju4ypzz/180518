namespace Music.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            comment_album = new HashSet<comment_album>();
            upload_album = new HashSet<upload_album>();
            upload_song = new HashSet<upload_song>();
        }

        [Key]
        public int user_id { get; set; }

        [StringLength(100)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [StringLength(32)]
        [Display(Name = "Mật khẩu")]
        public string password { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ tên")]
        public string user_name { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime? user_dateofbirth { get; set; }

        [Display(Name = "Giới tính")]
        public bool? user_sex { get; set; }

        [StringLength(100)]
        [Display(Name = "Địa chỉ")]
        public string user_address { get; set; }

        [Column(TypeName = "numeric")]
        [Display(Name = "Số điện thoại")]
        public decimal? user_phone { get; set; }

        [StringLength(250)]
        [Display(Name = "Hình đại diện")]
        public string user_image { get; set; }

        public int? user_level { get; set; }

        public bool? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comment_album> comment_album { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<upload_album> upload_album { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<upload_song> upload_song { get; set; }
    }
}
