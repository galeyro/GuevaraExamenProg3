using GuevaraExamenProg3.Interfaces;
using GuevaraExamenProg3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuevaraExamenProg3.Services
{
    public class RecetaService : IRecetaService
    {
        public Task<List<string>> GetLogsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Receta>> GetRecetasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> GuardarRecetaAsync(Receta receta)
        {
            throw new NotImplementedException();
        }
    }
}
