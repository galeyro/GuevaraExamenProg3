using GuevaraExamenProg3.Interfaces;
using GuevaraExamenProg3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GuevaraExamenProg3.ViewModels
{
    public class RecetaViewModel : INotifyPropertyChanged
    {
        private readonly IRecetaService _recetaService;

        public Command GetRecetasCommand { get; }
        public Command GetLogsCommand { get; }
        public Command GuardarRecetaCommand { get; }

        public RecetaViewModel(IRecetaService recetaService)
        {
            _recetaService = recetaService;
            GetRecetasCommand = new Command(async () => await GetRecetasAsync());
            GetLogsCommand = new Command(async () => await GetLogsAsync());
            GuardarRecetaCommand = new Command(async () => await GuardarRecetaAsync());

        }
        //Guardar las listas
        public ObservableCollection<Receta> Recetas { get; set; } = new();
        public ObservableCollection<string> Logs { get; set; } = new();

        //Getters y Setters
        private string _nombre;
        public string nombre
        {
            get => _nombre;
            set { _nombre= value; OnPropertyChanged(); }
        }

        private string _ingredientes;
        public string ingredientes
        {
            get => _ingredientes;
            set { _ingredientes = value; OnPropertyChanged(); }
        }

        private int _tiempoPreparacionMinutos;
        public int tiempoPreparacionMinutos
        {
            get => _tiempoPreparacionMinutos;
            set { _tiempoPreparacionMinutos = value; OnPropertyChanged(); }
        }

        private bool _esVegetariana;
        public bool esVegetariana
        {
            get => _esVegetariana;
            set { _esVegetariana = value; OnPropertyChanged(); }
        }

        private string _mensajeRespuesta;
        public string mensajeRespuesta
        {
            get => _mensajeRespuesta;
            set { _mensajeRespuesta = value; OnPropertyChanged(); }
        }


        //metodos
        private async Task GuardarRecetaAsync()
        {
            var receta = new Receta
            {
                Nombre = this.nombre,
                Ingredientes = this.ingredientes,
                TiempoPreparacionMinutos = this.tiempoPreparacionMinutos,
                EsVegetariana = this.esVegetariana
            };

            bool resultado = await _recetaService.GuardarRecetaAsync(receta);

            if (resultado)
            {
                //mensaje exito
                mensajeRespuesta = "Exito: Se guardo correctamente";

                //resetear valores
                nombre = ingredientes = string.Empty;
                tiempoPreparacionMinutos = 0;
                esVegetariana = false;
            } else
            {
                //mensaje error
                mensajeRespuesta = "Error: El tiempo de preparación no puede superar 180 minutos (excepto si EsVegetariana)";
            }
        }

        private async Task GetRecetasAsync()
        {
            var lista = await _recetaService.GetRecetasAsync();

            Recetas.Clear();
            foreach (var rec in lista)
            {
                Recetas.Add(rec);
            }
        }

        private async Task GetLogsAsync()
        {
            var lista = await _recetaService.GetLogsAsync();

            Logs.Clear();
            foreach(var log in lista)
            {
                Logs.Add(log);
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
