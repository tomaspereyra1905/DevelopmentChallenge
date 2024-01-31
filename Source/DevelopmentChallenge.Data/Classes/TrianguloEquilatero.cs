using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Resources;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrianguloEquilatero : IFormaGeometrica
    {
        private readonly decimal _lado;

        public TrianguloEquilatero(decimal lado)
        {
           _lado = lado;
        }

        public string ObtenerNombre(int cantidad, int idioma)
        {
            var nombreSingular = idioma == Languages.Castellano ? "Triángulo" : (idioma == Languages.Italiano ? "Triangolo" : "Triangle");
            var nombrePlural = idioma == Languages.Castellano ? "Triángulos" : (idioma == Languages.Italiano ? "Triangoli" : "Triangles");

            return $"{cantidad} {(cantidad == 1 ? nombreSingular : nombrePlural)}";
        }

        public decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public decimal CalcularPerimetro()
        {
            return _lado * 3;
        }
    }
}
