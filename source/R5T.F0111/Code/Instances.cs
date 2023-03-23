using System;


namespace R5T.F0111
{
    public static class Instances
    {
        public static F0000.IFileOperator FileOperator => F0000.FileOperator.Instance;
        public static F0082.IFileSystemOperator FileSystemOperator => F0082.FileSystemOperator.Instance;
        public static Z0022.IRepositoriesDirectoryPaths RepositoriesDirectoryPaths => Z0022.RepositoriesDirectoryPaths.Instance;
    }
}