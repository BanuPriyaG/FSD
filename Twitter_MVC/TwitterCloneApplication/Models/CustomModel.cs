namespace TwitterCloneApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CustomModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        [Key]
        [Column("_user_id")]
        [StringLength(25)]
        public string C_user_id { get; set; }

        [Column("_password")]
        [Required]
        [StringLength(50)]
        public string C_password { get; set; }

        [Column("_message")]
        [Required]
        [StringLength(140)]
        public string C_message { get; set; }
        public DateTime created { get; set; }

        [Required]
        [StringLength(30)]
        public string fullName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tweet> Tweets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tweet> Tweets1 { get; set; }
    }
}

