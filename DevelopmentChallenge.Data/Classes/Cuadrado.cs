using DevelopmentChallenge.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : FormasGeometricas
    {
        private readonly decimal _lado;

        public override ShapeType _Type => ShapeType.Cuadrado;

        public Cuadrado(decimal lado)
        {
            _lado = lado;
        }

        public override decimal Area()
        {
            return _lado * _lado;
        }

        public override decimal Perimeter()
        {
            return _lado * 4;
        }

        public override string Description()
        {
            return "Cuadrado";
        }
    }
}
