using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoshopChecker.Service.Analyzer
{
    public enum PhotoshopStatus
    {
        Photoshopped,
        Original,
        Unknown
    }

    public interface IImageAnalyzer
    {
        public PhotoshopStatus AnalyzeImage(string pathToImage);
    }
}
