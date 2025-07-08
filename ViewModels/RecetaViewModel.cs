using GuevaraExamenProg3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuevaraExamenProg3.ViewModels
{
    public class RecetaViewModel
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

        private async Task GuardarRecetaAsync()
        {
            throw new NotImplementedException();
        }

        private async Task GetLogsAsync()
        {
            throw new NotImplementedException();
        }

        private async Task GetRecetasAsync()
        {
            throw new NotImplementedException();
        }
    }
}
