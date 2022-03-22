using NLog;
using System.Diagnostics;
using TaidanaKage.Kek.Common;

namespace TaidanaKage.Kek.Meta
{
    internal class MyClient : IClient
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        private readonly string _folder;
        private readonly string _exeFile;

        internal MyClient(string folder)
        {
            _folder = folder;

            if (!Directory.Exists(_folder))
            {
                Exception ex = new DirectoryNotFoundException("Client folder doesn't exist: " + _folder);
                logger.Error(ex);
                throw ex;
            }

            string exeFile32 = Path.Combine(_folder, Constants.WoWClient32ExeFileName);
            string exeFile64 = Path.Combine(_folder, Constants.WoWClient64ExeFileName);

            // TODO this should be configurable
            // 64-bit version is preferred
            if (File.Exists(exeFile64))
            {
                _exeFile = exeFile64;
            }
            else if (File.Exists(exeFile32))
            {
                _exeFile = exeFile32;
            }
            else
            {
                Exception ex = new FileNotFoundException("Client executable not found: " + exeFile32 + " or " + exeFile64);
                logger.Error(ex);
                throw ex;
            }
        }

        public string Folder => _folder;

        public string ExeFile => _exeFile;

        public FileVersionInfo ClientVersion => throw new NotImplementedException();

        public WorldVersion WorldVersion => throw new NotImplementedException();

        public void Configure()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}