using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Interfaces
{
    public interface IFormaGeometrica
    {
        string ObtenerNombre(int cantidad, int idioma);
        decimal CalcularArea();
        decimal CalcularPerimetro();
    }
}
