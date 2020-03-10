using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maratony.Data
{
    public class Biegacz
    {
        private static long nextId = 0;

        public Biegacz()
        {

            this.BiegaczID = System.Threading.Interlocked.Increment(ref nextId); //było samo ID
        }

        public string Imie
        {
            get;
            set;
            
        }

        public string Nazwisko
        {
            get;
            set;
            
        }

        public System.TimeSpan Czas
        {
            get;
            set;
            
        }

        public long BiegaczID //było samo ID
        {
            get;
            set;
            
        }
        
        public long ZawodyID { get; set; }

       /*public Zawody Bieg // było Zawody Bieg
        {
            get;
            set;
            
        }*/
       
       
    }
}