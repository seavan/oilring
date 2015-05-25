using System.IO;
using System;
using System.Drawing;

namespace Common.ContentProcessing
{
    public interface IImageProcessor
    {
        void ProcessTo(Stream _imageStream, Guid _guid, string[] _targetDirectories, string _userPath, 
                       out Size _originalSize, out Size _resultSize, out Size _thumbSize);

        string GetImageFormat();
    }
}