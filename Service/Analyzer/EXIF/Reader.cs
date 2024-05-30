using MetadataExtractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoshopChecker.Service.Analyzer.EXIF
{
    public class XMPReader : IImageReader
    {
        public IEnumerable<MetadataExtractor.Directory> ReadMetadata(string pathToImage)
        {
            return ImageMetadataReader.ReadMetadata(pathToImage);
        }
    }
}
