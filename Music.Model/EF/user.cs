namespace Music.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("user")]
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            comment_song = new HashSet<comment_song>();
            playlists = new HashSet<playlist>();
            upload_song = new HashSet<upload_song>();
        }

        [Key]
        public int user_id { get; set; }

        [StringLength(100)]
        [DisplayName("Email")]
        [Required(ErrorMessage = "Mời nhập Email")]
        public string email { get; set; }

        [StringLength(32)]
        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mời nhập Mật khẩu")]
        public string password { get; set; }

        [StringLength(50)]
        [DisplayName("Họ và tên")]
        [Required(ErrorMessage = "Mời nhập Họ và Tên")]
        public string user_name { get; set; }

        [DisplayName("Ngày sinh")]
        public DateTime? user_dateofbirth { get; set; }

        [DisplayName("Giới tính")]
        public bool? user_sex { get; set; }

        [StringLength(100)]
        [DisplayName("Địa chỉ")]
        public string user_address { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("SĐT")]
        public decimal? user_phone { get; set; }

        [StringLength(250)]
        [DisplayName("Hình")]
        public string user_image { get; set; }

        [DisplayName("Trạng thái")]
        public bool? user_status { get; set; }

        [DisplayName("Quyền")]
        public bool? user_level { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comment_song> comment_song { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<playlist> playlists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<upload_song> upload_song { get; set; }
    }
}