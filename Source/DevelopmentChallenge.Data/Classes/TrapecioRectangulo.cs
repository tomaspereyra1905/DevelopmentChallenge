using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Resources;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrapecioRectangulo : IFormaGeometrica
    {
        private readonly decimal _baseMayor;
        private readonly decimal _baseMenor;
        private readonly decimal _altura;

        public TrapecioRectangulo(decimal baseMayor, decimal baseMenor, decimal altura)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
        }
        public string ObtenerNombre(int cantidad, int idioma)
        {
            var nombreSingular = idioma == Languages.Castellano ? "Trapecio/Rectángulo" : (idioma == Languages.Italiano ? "Trapezio/Rettangolo" : "Trapezoid/Rectangle");
            var nombrePlural = idioma == Languages.Castellano ? "Trapecios/Rectángulos" : (idioma == Languages.Italiano ? "Trapezi/Rettangoli" : "Trapezoids/Rectangles");

            return $"{cantidad} {(cantidad == 1 ? nombreSingular : nombrePlural)}";
        }

        public decimal CalcularArea()
        {
            return ((_baseMayor + _baseMenor) / 2) * _altura;
        }

        public decimal CalcularPerimetro()
        {
            return _baseMayor + _baseMenor + 2 * Convert.ToDecimal(Math.Sqrt(Math.Pow((double)((_baseMayor - _baseMenor) / 2), 2) + Math.Pow((double)_altura, 2)));
        }
    }
}
