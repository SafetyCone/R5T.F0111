using System;
using System.Linq;

using R5T.T0132;
using R5T.T0159;
using R5T.T0159.Extensions;


namespace R5T.F0111
{
    [FunctionalityMarker]
    public partial interface IOperations : IFunctionalityMarker
    {
        /// <summary>
        /// <inheritdoc cref="Documentation.Find_AllProjectFilePaths" path="/summary"/>
        /// </summary>
        public string[] Find_AllProjectFilePaths(
            ITextOutput textOutput)
        {
            // Output project paths to current run date's directory.
            var repositoriesDirectoryPaths = Instances.RepositoriesDirectoryPaths.AllOfMine;

            // Write out the repositories directories to the human output.
            textOutput.HumanOutput.WriteLine("Projects will be found in directories:");
            foreach (var repositoriesDirectoryPath in repositoriesDirectoryPaths)
            {
                textOutput.HumanOutput.WriteLine($"\t{repositoriesDirectoryPath}");
            }

            var projectFilePaths = Instances.FileSystemOperator.GetAllProjectFilePaths_FromRepositoriesDirectoryPaths(
                repositoriesDirectoryPaths,
                textOutput)
                .OrderAlphabetically()
                .Now();

            return projectFilePaths;
        }

        /// <summary>
        /// <inheritdoc cref="Documentation.Find_AllProjectFilePaths" path="/summary"/>
        /// Also removes all projects that should not be built.
        /// Outputs the projects to a text file.
        /// </summary>
        /// <returns>
        /// The filtered list of projects.
        /// </returns>
        public string[] Find_AllProjectFilePaths(
            string allProjectsListTextFilePath,
            string projectsOfInterestTextFilePath,
            string doNotBuildProjectsListTextFilePath,
            ITextOutput textOutput)
        {
            textOutput.WriteInformation("Searching for all project files...");

            var allProjectFilePaths = this.Find_AllProjectFilePaths(
                textOutput);

            textOutput.WriteInformation("Found {ProjectFileCount} project files.", allProjectFilePaths.Length);

            textOutput.WriteSectionSeparator();

            // Write out all projects.
            Instances.FileOperator.Write_Lines_Synchronous(
                allProjectsListTextFilePath,
                allProjectFilePaths);

            textOutput.WriteInformation("Wrote all project files to:\n\t{0}.", allProjectsListTextFilePath);

            // Now filter out projects we don't want to built.
            textOutput.WriteInformation("Filtering out project files that should not be built...");

            textOutput.WriteInformation("Using do-not-build project files list from:\n\t{0}.", doNotBuildProjectsListTextFilePath);

            var projectFilePathsToSkip = Instances.FileOperator.ReadAllLines_Synchronous(
               doNotBuildProjectsListTextFilePath);

            var projectFilePaths = allProjectFilePaths
                .Except(projectFilePathsToSkip)
                .Now();

            textOutput.WriteInformation("After filtering {0} project files remain.", projectFilePaths.Length);

            // Write out projects list we actually want to build.
            Instances.FileOperator.Write_Lines_Synchronous(
                projectsOfInterestTextFilePath,
                projectFilePaths);

            textOutput.WriteInformation("Wrote project files to:\n\t{0}.", projectsOfInterestTextFilePath);

            return projectFilePaths;
        }
    }
}
