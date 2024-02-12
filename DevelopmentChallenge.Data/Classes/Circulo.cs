using DevelopmentChallenge.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : FormasGeometricas
    {
        private readonly decimal _lado;

        public override ShapeType _Type => ShapeType.Circulo;

        public Circulo(decimal diametro)
        {
            _lado = diametro;
        }

        public override decimal Area()
        {
            return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
        }

        public override decimal Perimeter()
        {
            return (decimal)Math.PI * _lado;
        }

        public override string Description()
        {
            return "Circulo";
        }
    }
}
