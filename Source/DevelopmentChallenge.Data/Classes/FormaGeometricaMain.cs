/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public class FormaGeometricaMain
    {
        private readonly List<IFormaGeometrica> formas;

        public FormaGeometricaMain(List<IFormaGeometrica> formas)
        {
            this.formas = formas;
        }

        public string Imprimir(int idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append(idioma == Languages.Castellano
                    ? "<h1>Lista vacía de formas!</h1>"
                    : (idioma == Languages.Italiano ? "<h1>Lista vuota di forme!</h1>" : "<h1>Empty list of shapes!</h1>"));
            }
            else
            {
                // HEADER
                sb.Append(idioma == Languages.Castellano
                    ? "<h1>Reporte de Formas</h1>"
                    : (idioma == Languages.Italiano ? "<h1>Rapporto di Forme</h1>" : "<h1>Shapes report</h1>"));

                //USO UN DICTIONARY PARA CONTAR LAS FORMAS, CAMBIO EL FOR QUE ESTABA ANTES.
                Dictionary<Type, int> formaCounts = new Dictionary<Type, int>();

                foreach (var forma in formas)
                {
                    Type formaType = forma.GetType();

                    if (typeof(IFormaGeometrica).IsAssignableFrom(formaType))
                    {
                        if (formaCounts.ContainsKey(formaType))
                        {
                            formaCounts[formaType]++;
                        }
                        else
                        {
                            formaCounts[formaType] = 1;
                        }
                    }
                }

                //ACA ITERO SOBRE EL MISMO
                foreach (var kvp in formaCounts)
                {
                    var formaType = kvp.Key;
                    var count = kvp.Value;
                    var key = formas.First(f => formaType.IsInstanceOfType(f)).ObtenerNombre(count, idioma);
                    var singularPlural = count == 1 ? "shape" : "shapes";

                    var area = formas.Where(f => formaType.IsInstanceOfType(f)).Sum(f => f.CalcularArea());
                    var perimeter = formas.Where(f => formaType.IsInstanceOfType(f)).Sum(f => f.CalcularPerimetro());
                    var perimeterText = idioma == Languages.Castellano ? "Perimetro" : (idioma == Languages.Italiano ? "Perimetro" : "Perimeter");

                    sb.Append($"{count} {key.Replace(count + " ", "")} | Area {area:#.##} | {perimeterText} {perimeter:#.##} <br/>");
                }

                // FOOTER
                sb.Append(idioma == Languages.Castellano ? "TOTAL:<br/>" : (idioma == Languages.Italiano ? "TOTALE:<br/>" : "TOTAL:<br/>"));
                var shapesText = idioma == Languages.Castellano ? "formas" : (idioma == Languages.Italiano ? "forme" : "shapes");
                var perimeterTextFooter = idioma == Languages.Castellano ? "Perimetro" : (idioma == Languages.Italiano ? "Perimetro" : "Perimeter");
                sb.Append($"{formas.Count} {shapesText} {perimeterTextFooter} {formas.Sum(f => f.CalcularPerimetro()):#.##} ");
                sb.Append($"Area {formas.Sum(f => f.CalcularArea()):#.##}");
            }

            return sb.ToString();
        }
    }
}