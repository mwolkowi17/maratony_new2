using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maratony.Data
{
    public class MaratonyModel
    {
        private ObservableCollection<Zawody> listaZawodow;
        private ObservableCollection<Biegacz> listaBiegaczy;


        public MaratonyModel()
        {
            using (Model1 context = new Model1()) { 

            {


                this.listaZawodow = new ObservableCollection<Zawody>();
                this.listaBiegaczy = new ObservableCollection<Biegacz>();
                    foreach (var n in context.Zawodies)
                    {
                        listaZawodow.Add(n);
                    }
                    foreach (var m in context.Biegaczs)
                    {
                        listaBiegaczy.Add(m);
                    }
                }
            }
        }

        public ObservableCollection<Zawody> ListaZawodow
        {
            get { return listaZawodow; }
        }

        public ObservableCollection<Biegacz> ListaBiegaczy
        {
            get { return listaBiegaczy; }
        }

        public Zawody DodajZawody(string miejsce, DateTime data, double dystans)
        {
            Zawody z = new Zawody() { Miejsce = miejsce, Data = data, Dystans = dystans };
            this.listaZawodow.Add(z);
            return z;
        }

        public Biegacz DodajBiegacza(long zawodyId, string imie, string nazwisko)
        {

            using (Model1 context = new Model1()) { 
                Zawody zawody = listaZawodow.Where(z => (z.ID == zawodyId)).FirstOrDefault();

                /*Zawody zawody = (from Zawody item in listaZawodow
                                 where item.ID == zawodyId
                                 select item).First(); //może tak?*/

                Biegacz b = new Biegacz() { Imie = imie, Nazwisko = nazwisko };

                this.listaBiegaczy.Add(b);
                b.Bieg = zawody.ID; // tu było zawody (samo)
                
                zawody.Biegacze.Add(b);
               


                return b;
            }
        }

        public void ZapiszDoBazy()
        {
            using (Model1 context=new Model1())
            {
                List<Biegacz> ZawartoscBazy= new List<Biegacz>();
                foreach(var n in context.Biegaczs)
                {
                    ZawartoscBazy.Add(n);
                }
                context.Biegaczs.Add(listaBiegaczy.Last());
                
                context.SaveChanges();



                /*foreach(var m in listaBiegaczy)
                {
                    if (ZawartoscBazy.Contains(m))
                    {
                        context.Biegaczs.Add(m);
                        context.SaveChanges();
                    }
                }*/
                

            }
        }

    }


}

