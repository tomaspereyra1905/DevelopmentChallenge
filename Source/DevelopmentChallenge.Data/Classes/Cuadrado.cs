using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Resources;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : IFormaGeometrica
    {
        private readonly decimal _lado;

        public Cuadrado(decimal lado)
        {
            _lado = lado;
        }

        public string ObtenerNombre(int cantidad, int idioma)
        {
            var nombreSingular = idioma == Languages.Castellano ? "Cuadrado" : (idioma == Languages.Italiano ? "Quadrato" : "Square");
            var nombrePlural = idioma == Languages.Castellano ? "Cuadrados" : (idioma == Languages.Italiano ? "Quadrati" : "Squares");

            return $"{cantidad} {(cantidad == 1 ? nombreSingular : nombrePlural)}";
        }

        public decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public decimal CalcularPerimetro()
        {
            return _lado * 4;
        }
    }
}
