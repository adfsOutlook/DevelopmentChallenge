using DevelopmentChallenge.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Rectangulo : FormasGeometricas
    {
        private readonly decimal _ladoMenor;
        private readonly decimal _ladoMayor;

        public override ShapeType _Type => ShapeType.Rectangulo;

        public Rectangulo(decimal ladoMenor, decimal ladoMayor)
        {
            _ladoMenor = ladoMenor;
            _ladoMayor = ladoMayor;
        }

        public override decimal Area()
        {
            return _ladoMenor * _ladoMayor;
        }

        public override string Description()
        {
            return "Rectangulo";
        }

        public override decimal Perimeter()
        {
            return (_ladoMenor * 2 + _ladoMayor * 2);
        } 
    }
}
