namespace Music.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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
        public string email { get; set; }

        [StringLength(32)]
        public string password { get; set; }

        [StringLength(50)]
        public string user_name { get; set; }

        public DateTime? user_dateofbirth { get; set; }

        public bool? user_sex { get; set; }

        [StringLength(100)]
        public string user_address { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? user_phone { get; set; }

        [StringLength(250)]
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