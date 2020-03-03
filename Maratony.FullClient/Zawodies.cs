namespace Maratony.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Zawodies
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zawodies()
        {
            Biegaczs = new HashSet<Biegaczs>();
        }

        public long ID { get; set; }

        public string Miejsce { get; set; }

        public DateTime Data { get; set; }

        public double Dystans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biegaczs> Biegaczs { get; set; }
    }
}
