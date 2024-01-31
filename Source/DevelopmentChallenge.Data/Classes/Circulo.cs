using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Resources;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : IFormaGeometrica
    {
        private readonly decimal _radio;

        public Circulo(decimal radio)
        {
            _radio = radio;
        }

        public string ObtenerNombre(int cantidad, int idioma)
        {
            var nombreSingular = idioma == Languages.Castellano ? "Círculo" : (idioma == Languages.Italiano ? "Cerchio" : "Circle");
            var nombrePlural = idioma == Languages.Castellano ? "Círculos" : (idioma == Languages.Italiano ? "Cerchi" : "Circles");

            return $"{cantidad} {(cantidad == 1 ? nombreSingular : nombrePlural)}";
        }

        public decimal CalcularArea()
        {
            return (decimal)Math.PI * (_radio / 2) * (_radio / 2);
        }

        public decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _radio;
        }
    }
}
