using Maratony.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Maratony.UI.ViewModel
{
    public class MaintenanceFormViewModel: INotifyPropertyChanged
    {

        private MaratonyModel model = new MaratonyModel();

        public MaintenanceFormViewModel()
        {
            Task.Run(() => Init());
        }
        public MaintenanceFormViewModel(bool init)
        {
            // Konstruktor uzywany w testach jednostkowych
            if (init)
                Init();
        }

        internal void Init()
        {
            this.PrzykladoweDane();
            this.OdswiezZawody();
            this.SaveCommand = new RelayCommand(
                action => this.DodajBiegacza(),
                enable => this.CzyMoznaDodacBiegacza());
            this.ClearCommand = new RelayCommand(
                action => this.WyczyscWybraneZawody(),
                enable => this.CzyMoznaDodacBiegacza());
        }

        private void OdswiezZawody()
        {
            // this.Zawody -> wywoluje Zawody.set{...} oraz OnPropertyChanged
            this.Zawody = model.ListaZawodow;
        }
        internal void PrzykladoweDane()
        {
           // model.DodajZawody("Kraków", new DateTime(2016, 1, 10), 11.6);
           // model.DodajZawody("Warszawa", new DateTime(2016, 1, 23), 6);
           // model.DodajBiegacza(model.ListaZawodow[0].ID, "Młody", "Bóg");
           // model.DodajBiegacza(model.ListaZawodow[1].ID, "Jan", "Kowalski");
           // model.DodajBiegacza(model.ListaZawodow[1].ID, "Adam", "Nowak");
        }


        private IEnumerable<Zawody> zawody;


        public IEnumerable<Zawody> Zawody
        {
            get
            {
                return this.zawody;
            }
            set
            {
                this.zawody = value;
                this.OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]
            string propertyName = "")
        {
            /*
                var handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            */
            // C# 6.0:
            this.PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(propertyName));
        }

        private Zawody wybraneZawody;
        public Zawody WybraneZawody
        {
            get
            {
                return this.wybraneZawody;
            }
            set
            {
                this.wybraneZawody = value;
                this.OnPropertyChanged();
                this.OdswiezBiegaczy();  // dodane ponizej
            }
        }
        private IEnumerable<Biegacz> biegacze;
        public IEnumerable<Biegacz> Biegacze
        {
            get
            {
                return this.biegacze;
            }
            set
            {
                this.biegacze = value;
                OnPropertyChanged();
            }
        }

        private void OdswiezBiegaczy()
        {
            this.Biegacze = null;
            this.Biegacze = this.WybraneZawody?.Biegacze;
        }

        public void DodajBiegacza()
        {
            if (WybraneZawody != null)
            {
                model.DodajBiegacza(this.WybraneZawody.ID, "Nowy", "Biegacz");
                this.OdswiezBiegaczy();
            }
        }

        public bool CzyMoznaDodacBiegacza()
        {
            return (this.WybraneZawody != null);
        }

        public ICommand SaveCommand { get; private set; }

        private void WyczyscWybraneZawody()
        {
            this.WybraneZawody = null;
        }

        public ICommand ClearCommand { get; private set; }

        public void SaveBase()
        {
            model.ZapiszDoBazy();
        }






    }
}
