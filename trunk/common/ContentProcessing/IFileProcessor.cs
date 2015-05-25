using System;
using System.IO;

namespace Common.ContentProcessing
{
    public interface IFileProcessor
    {
        void ProcessTo(Stream _fileStream, Guid _guid, string[] _targetDirectories, string _userPath, out long _fileSize);
        string GetFileFormat();
    }
}