namespace Music.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COMMENT_ALBUM
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int USER_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ALBUM_ID { get; set; }

        [StringLength(250)]
        public string COMMENT_ALBUM_CONTENT { get; set; }

        public DateTime? COMMENT_ALBUM_CREATEDATE { get; set; }

        public virtual ALBUM ALBUM { get; set; }

        public virtual USER USER { get; set; }
    }
}
