namespace Maratony.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Biegaczs
    {
        public long ID { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public TimeSpan Czas { get; set; }

        public long Bieg { get; set; }

        public long? Zawody_ID { get; set; }

        public virtual Zawodies Zawodies { get; set; }
    }
}
