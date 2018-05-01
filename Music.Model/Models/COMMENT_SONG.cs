namespace Music.Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COMMENT_SONG
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int USER_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SONG_ID { get; set; }

        [StringLength(250)]
        public string COMMENT_SONG_CONTENT { get; set; }

        public DateTime? COMMENT_SONG_CREATEDATE { get; set; }

        public virtual SONG SONG { get; set; }
    }
}
