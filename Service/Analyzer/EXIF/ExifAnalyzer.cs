using MetadataExtractor.Formats.Xmp;
using MetadataExtractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace PhotoshopChecker.Service.Analyzer.EXIF
{
    public class ExifAnalyzer : IImageAnalyzer
    {
        private readonly IImageReader _metadataReader;

        public ExifAnalyzer(IImageReader metadataReader)
        {
            _metadataReader = metadataReader;
        }

        public PhotoshopStatus AnalyzeImage(string pathToImage)
        {
            IEnumerable<MetadataExtractor.Directory> directories = _metadataReader.ReadMetadata(pathToImage);
            IEnumerable<XmpDirectory> xmpDirectories = directories.OfType<XmpDirectory>();

            PhotoshopStatus result = PhotoshopStatus.Unknown;

            // Проходим по всем свойствам метаданных, и проверяем содержится ли Adobe
            foreach (XmpDirectory directory in xmpDirectories)
            {
                foreach (var properties in directory.GetXmpProperties())
                {
                    if (properties.Value.Contains("Adobe"))
                    {
                        result = PhotoshopStatus.Photoshopped;
                    }
                }
            }

            // Если после проверки метаданных мы не смогли найти следы фотошопа, считаем, что картинка оригинальная
            if (result != PhotoshopStatus.Photoshopped)
            {
                result = PhotoshopStatus.Original;
            }

            return result;
        }
    }
}
