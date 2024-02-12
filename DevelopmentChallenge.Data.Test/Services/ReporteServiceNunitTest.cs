using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Services;
using DevelopmentChallenge.Data.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Test.Services
{
    [TestFixture]
    public class ReporteServiceNunitTest
    {
        private IReporteServices _reporte;

        [SetUp]
        public void SetUp()
        {
            _reporte = new ReporteService();
        }

        [TestCase]
        public void TestResumenListaVacia()
        {
            var listaVacia = new List<FormasGeometricas>();

            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
               _reporte.Imprimir(listaVacia, LanguageType.Castellano));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                _reporte.Imprimir(new List<FormasGeometricas>(), LanguageType.Ingles));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            Assert.AreEqual("<h1>IT Lista vacía de formas!</h1>",
                _reporte.Imprimir(new List<FormasGeometricas>(), LanguageType.Italiano));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormasGeometricas> { new Cuadrado(5) };
            var resumen = _reporte.Imprimir(cuadrados, LanguageType.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecioRectangulo()
        {
            var trapeciosRectangulos = new List<FormasGeometricas> { new TrapecioRectangulo(5, 3, 4) };
            var resumen = _reporte.Imprimir(trapeciosRectangulos, LanguageType.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio rectangulo | Area 16 | Perimetro 16,47 <br/>TOTAL:<br/>1 formas Perimetro 16,47 Area 16", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTrapeciosRectangulos()
        {
            var trapeciosRectangulos = new List<FormasGeometricas> { new TrapecioRectangulo(5, 3, 4), new TrapecioRectangulo(10, 5, 5) };
            var resumen = _reporte.Imprimir(trapeciosRectangulos, LanguageType.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>2 Trapecios rectangulos | Area 53,5 | Perimetro 43,54 <br/>TOTAL:<br/>2 formas Perimetro 43,54 Area 53,5", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormasGeometricas> {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3),
            };

            var resumen = _reporte.Imprimir(cuadrados, LanguageType.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnIngles()
        {
            var formas = new List<FormasGeometricas> {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m),
            };

            var resumen = _reporte.Imprimir(formas, LanguageType.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormasGeometricas> {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m),
            };

            var resumen = _reporte.Imprimir(formas, LanguageType.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Circulos | Area 13,01 | Perimetro 18,06 <br/>3 Triangulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }
        [TestCase]

        public void TestResumenListaConMasTiposEnItaliano()
        {
            var formas = new List<FormasGeometricas> {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m),
            };

            var resumen = _reporte.Imprimir(formas, LanguageType.Italiano);

            Assert.AreEqual(
                "<h1>IT Reporte de Formas</h1>2 IT Cuadrados | IT Area 29 | IT Perimetro 28 <br/>2 IT Circulos | IT Area 13,01 | IT Perimetro 18,06 <br/>3 IT Triangulos | IT Area 49,64 | IT Perimetro 51,6 <br/>IT TOTAL:<br/>7 it formas IT Perimetro 97,66 IT Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnRectangulo()
        {
            var cuadrados = new List<FormasGeometricas> { new Rectangulo(4,5) };
            var resumen = _reporte.Imprimir(cuadrados, LanguageType.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Rectangulo | Area 20 | Perimetro 18 <br/>TOTAL:<br/>1 formas Perimetro 18 Area 20", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasRectangulos()
        {
            var cuadrados = new List<FormasGeometricas> { new Rectangulo(4, 5), new Rectangulo(4, 5) };
            var resumen = _reporte.Imprimir(cuadrados, LanguageType.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>2 Rectangulos | Area 40 | Perimetro 36 <br/>TOTAL:<br/>2 formas Perimetro 36 Area 40", resumen);
        }
    }
}
