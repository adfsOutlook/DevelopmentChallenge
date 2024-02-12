using DevelopmentChallenge.Data.Utils;
using DevelopmentChallenge.Data.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Utils
{
    public class CultureResources:ICultureResources { 

        private readonly ResourceManager _resourceManager;

        public CultureResources(string language) 
        {
            _resourceManager = new ResourceManager(@"DevelopmentChallenge.Data.Resources.Res", Assembly.GetExecutingAssembly());

            SetCulture.InitializeCulture(language);   
            


           // Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(idioma);
        }

        public string GetValue(string text, int quantity = 1 )
        {
            if(quantity > 1)
            {
                text = text + "N";
            }
            
            var description = _resourceManager.GetString(text);
            return description;
        }
        
    }
}
