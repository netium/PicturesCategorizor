/**********************************
 * Copyright 2017 Netium
 * 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace PicturesCategorizor
{
    class ByCaptureDateMethod : AbstractCategorizationMethod
    {
        public ByCaptureDateMethod(string parameter) : base(parameter)
        {
        }

        public override string GetTargetFolder(string mediaFile)
        {
            using (var stream = new FileStream(mediaFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                var exifInfo = ExifLib.ExifReader.ReadJpeg(stream);
                DateTime date;

                // The date time string in EXIF is in the format of yyyy:MM:dd HH:mm:ss
                if (exifInfo == null || !DateTime.TryParseExact(exifInfo.DateTimeOriginal, "yyyy:MM:dd HH:mm:ss", null, DateTimeStyles.AssumeLocal, out date))
                {
                    date = File.GetLastWriteTime(mediaFile);
                }
                return date.Year + "年" + date.Month + "月" + date.Day + "日";
            }
        }
    }
}
