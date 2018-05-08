//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Music.Model.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class song
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public song()
        {
            this.comment_song = new HashSet<comment_song>();
            this.upload_song = new HashSet<upload_song>();
            this.singers = new HashSet<singer>();
        }
    
        public int song_id { get; set; }
        public Nullable<int> album_id { get; set; }
        public Nullable<int> genre_id { get; set; }
        public string song_name { get; set; }
        public string song_path { get; set; }
        public string song_lyric { get; set; }
        public string song_image { get; set; }
        public Nullable<int> song_view { get; set; }
        public Nullable<int> song_viewed_day { get; set; }
        public Nullable<int> song_viewed_week { get; set; }
        public Nullable<int> song_viewed_month { get; set; }
        public Nullable<int> song_download { get; set; }
        public Nullable<int> song_downloaded_week { get; set; }
        public Nullable<int> song_downloaded_month { get; set; }
        public Nullable<System.DateTime> song_createdate { get; set; }
    
        public virtual album album { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comment_song> comment_song { get; set; }
        public virtual genre genre { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<upload_song> upload_song { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<singer> singers { get; set; }
    }
}
