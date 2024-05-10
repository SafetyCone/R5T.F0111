using System;


namespace R5T.F0111
{
    public static class Instances
    {
        public static F0000.IFileOperator FileOperator => F0000.FileOperator.Instance;
        public static IFileSystemOperator FileSystemOperator => F0111.FileSystemOperator.Instance;
        public static IOperations Operations => F0111.Operations.Instance;
        public static Z0022.IRepositoriesDirectoryPathsSets RepositoriesDirectoryPathsSets => Z0022.RepositoriesDirectoryPathsSets.Instance;
    }
}