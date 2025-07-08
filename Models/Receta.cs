using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuevaraExamenProg3.Models
{
    public class Receta
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ingredientes { get; set; }
        public int TiempoPreparacionMinutos { get; set; }
        public bool EsVegetariana { get; set; }
    }
}
