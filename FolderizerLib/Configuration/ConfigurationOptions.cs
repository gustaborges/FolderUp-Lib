using System;
using System.IO;

namespace FolderizerLib.Configuration
{
    public class ConfigurationOptions
    {
        public static readonly int SearchDepthLimit = 5;
        private string _mountingPath;
        private string _basePath;
        private uint _maxSearchDepth = 0;

        public ConfigurationOptions()
        {

        }

        /// <summary>
        /// When this constructor is used, the mounting path is set to be the same as base path.
        /// </summary>
        /// <param name="basePath"></param>
        public ConfigurationOptions(string basePath)
        {
            BasePath = basePath;
            MountingPath = BasePath;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="basePath"></param>
        /// <param name="mountingPath"></param>
        public ConfigurationOptions(string basePath, string mountingPath)
        {
            BasePath = basePath;
            MountingPath = mountingPath;
        }

        public ConfigurationOptions(string basePath, string mountingPath, uint searchDepth)
        {
            BasePath = basePath;
            MountingPath = mountingPath;
            MaxSearchDepth = searchDepth;
        }
        public ConfigurationOptions(string basePath, string mountingPath, OperationMethod operationMethod)
        {
            BasePath = basePath;
            MountingPath = mountingPath;
            OperationMethod = operationMethod;
        }

        public ConfigurationOptions(string basePath, string mountingPath, uint searchDepth, OperationMethod operationMethod)
        {
            BasePath = basePath;
            MountingPath = mountingPath;
            MaxSearchDepth = searchDepth;
            OperationMethod = operationMethod;
        }

        public string BasePath
        {
            get => _basePath ?? throw new BasePathNotDefinedException("The BasePath property has not been set.");
            set => _basePath = Directory.Exists(value) ? value : throw new DirectoryNotFoundException("The given path leads to an inexistent directory.");
        }
        public string MountingPath
        {
            get => _mountingPath is null ? BasePath : _mountingPath;
            set => _mountingPath = value;
        }
        public OperationMethod OperationMethod { get; set; } = OperationMethod.CopyFiles;

        public uint MaxSearchDepth { 
            get => _maxSearchDepth; 
            set
            {
                if (value > SearchDepthLimit)
                {
                    throw new SearchDepthExceedsAcceptableLimitException($"The search depth exceeds the acceptable threshold of {SearchDepthLimit} subdirectories.");
                }
                _maxSearchDepth = value;
            } 
        }


    }
}