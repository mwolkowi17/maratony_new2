using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maratony.Data
{
    public class Zawody
    {
        private static long nextId = 0;

        public Zawody()
        {

            this.ZawodyID = System.Threading.Interlocked.Increment(ref nextId); //było samo ID
            Biegacze = new List<Biegacz>(); 
        }

        public string Miejsce
        {
            get;
            set;
            
            
        }

        public System.DateTime Data
        {
            get;
            set;
            
        }

        public double Dystans
        {
            get;
            set;
            
        }

        public long ZawodyID //było samo ID
        {
            get;
            set;
            
        }
        public List<Biegacz> Biegacze
        {
            get;
            set;

        }
    }
}