using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Resources;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            var formas = new List<IFormaGeometrica>();
            var formaGeometricaPrincipal = new FormaGeometricaMain(formas);

            Assert.That(formaGeometricaPrincipal.Imprimir(1), Is.EqualTo("<h1>Lista vacía de formas!</h1>"));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            var formas = new List<IFormaGeometrica>();
            var formaGeometricaPrincipal = new FormaGeometricaMain(formas);

            Assert.That(formaGeometricaPrincipal.Imprimir(2), Is.EqualTo("<h1>Empty list of shapes!</h1>"));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrado = new Cuadrado(5);
            var formas = new List<IFormaGeometrica> { cuadrado };
            var formaGeometricaPrincipal = new FormaGeometricaMain(formas);

            var resumen = formaGeometricaPrincipal.Imprimir(Languages.Castellano);

            Assert.That(resumen, Is.EqualTo("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25"));
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };
            var formaGeometricaPrincipal = new FormaGeometricaMain(cuadrados);

            var resumen = formaGeometricaPrincipal.Imprimir(Languages.Ingles);

            Assert.That(resumen, Is.EqualTo("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35"));
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };
            var formaGeometricaPrincipal = new FormaGeometricaMain(formas);

            var resumen = formaGeometricaPrincipal.Imprimir(Languages.Ingles);
            Assert.That(resumen, Is.EqualTo(
                                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65"));
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };
            var formaGeometricaPrincipal = new FormaGeometricaMain(formas);

            var resumen = formaGeometricaPrincipal.Imprimir(Languages.Castellano);

            Assert.That(resumen, Is.EqualTo(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65"));
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellanoYTrapecioRectangulo()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrapecioRectangulo(4 , 5 , 9),
                new Cuadrado(2),
                new TrapecioRectangulo(5, 5, 8),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m),
                new TrianguloEquilatero(9)
            };
            var formaGeometricaPrincipal = new FormaGeometricaMain(formas);

            var resumen = formaGeometricaPrincipal.Imprimir(Languages.Castellano);

            Assert.That(resumen, Is.EqualTo(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>2 Trapecios/Rectángulos | Area 80,5 | Perimetro 53,03 <br/>2 Triángulos | Area 42,71 | Perimetro 39,6 <br/>TOTAL:<br/>8 formas Perimetro 138,69 Area 165,22"));
        }

        [TestCase]
        public void TestResumenListaConMasCuadradosItaliano()
        {
            var cuadrados = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3),
                new Cuadrado(10),
                new Cuadrado(66)
            };
            var formaGeometricaPrincipal = new FormaGeometricaMain(cuadrados);

            var resumen = formaGeometricaPrincipal.Imprimir(Languages.Italiano);

            Assert.That(resumen, Is.EqualTo("<h1>Rapporto di Forme</h1>5 Quadrati | Area 4491 | Perimetro 340 <br/>TOTALE:<br/>5 forme Perimetro 340 Area 4491"));
        }
    }
}
