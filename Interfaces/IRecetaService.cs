using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuevaraExamenProg3.Models;

namespace GuevaraExamenProg3.Interfaces
{
    public interface IRecetaService
    {
        Task<List<Receta>> GetRecetasAsync();
        Task<bool> GuardarRecetaAsync(Receta receta);
        Task<List<string>> GetLogsAsync();
    }
}
