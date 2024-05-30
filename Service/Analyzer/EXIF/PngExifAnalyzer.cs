using System;
using System.Collections.Generic;
using System.IO;
using MetadataExtractor;
using MetadataExtractor.Formats.Xmp;

namespace PhotoshopChecker.Service.Analyzer.EXIF
{
    public class PngExifAnalyzer : IImageAnalyzer
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

