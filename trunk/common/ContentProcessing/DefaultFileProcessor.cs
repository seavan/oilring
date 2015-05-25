using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Common.ContentProcessing
{
    public class DefaultFileProcessor : IFileProcessor
    {
        public DefaultFileProcessor()
        {

        }


        public string TargetExtension = "dat";


        public void ProcessTo(Stream _fileStream, Guid _guid, string[] _targetDirectories, string _userPath, out long _fileSize)
        {
            var targetFName = String.Format("{0}.{1}", _guid, TargetExtension);

            _fileSize = _fileStream.Length;

            foreach (var dir in _targetDirectories)
            {
                var tgDirName = Path.Combine(dir, _userPath);
                if (!Directory.Exists(tgDirName))
                {
                    Directory.CreateDirectory(tgDirName);
                }

                var tempPath = System.IO.Path.GetTempPath();
                var tgFileName = Path.Combine(tgDirName, targetFName);
                var tempFileName = Path.Combine(tempPath, targetFName);
                FileStream stream = new FileStream(tempFileName, FileMode.Create);
                
                _fileStream.CopyTo(stream);

                _fileStream.Flush();
                _fileStream.Close();
                stream.Flush();
                stream.Close();

                File.Copy(tempFileName, tgFileName);
            }

        }


        public string GetFileFormat()
        {
            return TargetExtension;
        }
    }
}