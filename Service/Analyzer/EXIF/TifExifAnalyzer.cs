using MetadataExtractor.Formats.Xmp;
using MetadataExtractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoshopChecker.Service.Analyzer.EXIF
{
    public class TifExifAnalyzer : IImageAnalyzer
    {
        public PhotoshopStatus AnalyzeImage(string pathToImage)
        {
            IEnumerable<MetadataExtractor.Directory> directories = ImageMetadataReader.ReadMetadata(pathToImage);

            PhotoshopStatus result = PhotoshopStatus.Unknown;

            IEnumerable<XmpDirectory> xmpDirectories = directories.OfType<XmpDirectory>();


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
