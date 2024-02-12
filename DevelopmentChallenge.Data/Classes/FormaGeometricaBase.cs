using DevelopmentChallenge.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public abstract class FormasGeometricas
    {
        public virtual ShapeType _Type { get; }

        public abstract decimal Area();
        public abstract decimal Perimeter();
        public abstract string Description();
    }
}
