namespace Music.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UPLOAD_ALBUM
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int USER_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ALBUM_ID { get; set; }

        public DateTime? UPLOAD_ALBUM_DATE { get; set; }

        public virtual ALBUM ALBUM { get; set; }

        public virtual USER USER { get; set; }
    }
}
