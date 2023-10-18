using System;

using R5T.T0132;
using R5T.T0159;


namespace R5T.F0111
{
    [FunctionalityMarker]
    public partial interface IFileSystemOperator : IFunctionalityMarker,
        F0082.IFileSystemOperator
    {
        /// <inheritdoc cref="IFileSystemOperator.Find_AllProjectFilePaths(ITextOutput)"/>
        public string[] Find_AllProjectFilePaths(
            ITextOutput textOutput)
        {
            var output = Instances.Operations.Find_AllProjectFilePaths(textOutput);
            return output;
        }
    }
}
