﻿namespace Music.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class comment_song
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int song_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int user_id { get; set; }

        [StringLength(250)]
        [DisplayName("Nội dụng bình luận")]
        public string comment_song_content { get; set; }

        [DisplayName("Ngày bình luận")]
        public DateTime? comment_song_createdate { get; set; }

        public virtual song song { get; set; }

        public virtual user user { get; set; }
    }
}