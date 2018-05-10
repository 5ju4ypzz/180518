namespace Music.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class comment_album
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int user_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int album_id { get; set; }

        [StringLength(250)]
        public string comment_album_content { get; set; }

        public DateTime? comment_album_createdate { get; set; }

        public virtual album album { get; set; }

        public virtual user user { get; set; }
    }
}
