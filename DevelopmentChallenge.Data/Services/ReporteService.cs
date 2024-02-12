using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Resources;
using DevelopmentChallenge.Data.Utils;
using DevelopmentChallenge.Data.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Services
{
    public class ReporteService : IReporteServices
    {
        ICultureResources _culture;
        StringBuilder _sb;

        public ReporteService() {

           // SetCulture.InitializeCulture(); 
        }

        public string Imprimir(List<FormasGeometricas> formas, string language)
        {
            _sb = new StringBuilder();
            _culture = new CultureResources(language);

            if (formas.Count() < 1)
            {
                _sb.Append($"<h1>{_culture.GetValue("ListaVaciaDeFormas")}!</h1>");
                return _sb.ToString();
            }

            var datosFormasGeometricas = GetTotalsFromShapes(formas);

            AddHeader();
            AddBody(datosFormasGeometricas);
            AddFooter(datosFormasGeometricas);

            return _sb.ToString();
        }

        private void AddHeader()
        {
            _sb.Append($"<h1>{_culture.GetValue("ReporteDeFormas")}</h1>");
        }

        private void AddBody(List<TotalResults> totalResults)
        {

         
            foreach (var totals in totalResults)
            {
                AddLine(totals.Total,
                    _culture.GetValue(totals.Description, totals.Total),
                    totals.TotalArea,
                    totals.TotalPerimeter);
            }
        }

        private void AddLine(int cantidad, string descripcion, decimal area, decimal perimetro)
        {
            if (cantidad == 0)
            {
                return;
            }

            _sb.Append($"{cantidad} {descripcion} | {_culture.GetValue("Area")} {area:#.##} | {_culture.GetValue("Perimetro")} {perimetro:#.##} <br/>");
        }

        private void AddFooter(List<TotalResults> totalResults)
        {
            _sb.Append(_culture.GetValue("Total").ToUpper() + ":<br/>");

            _sb.Append(
                (totalResults.Sum(x => x.Total))
                + $" {_culture.GetValue("Formas").ToLower()} ");

            _sb.Append($"{_culture.GetValue("Perimetro")} " + 
                (totalResults.Sum(s => s.TotalPerimeter)
                ).ToString("#.##") + " ");

            _sb.Append($"{_culture.GetValue("Area")} " + 
                (totalResults.Sum(s => s.TotalArea)
                ).ToString("#.##"));
        }

        private List<TotalResults> GetTotalsFromShapes(List<FormasGeometricas> formasGeometricasList)
        {


            var result = new List<TotalResults>();

            foreach (ShapeType shapeType in Enum.GetValues(typeof(ShapeType)))
            {
                var ShapeByTypeList = formasGeometricasList.Where(x => x._Type == shapeType);

                if (!ShapeByTypeList.Any())
                {
                    continue;
                }

                var totalResults = new TotalResults
                {
                    Total = ShapeByTypeList.Count(),
                    TotalArea = ShapeByTypeList.Sum(x => x.Area()),
                    TotalPerimeter = ShapeByTypeList.Sum(x => x.Perimeter()),
                    Description = ShapeByTypeList.First().Description()
                };
                result.Add(totalResults);
            }

            return result;
        }

    }
}
