using System;
using System.IO;

namespace GenWikiTests.Helpers
{
    public static class DirectoryUtils
    {
        /// <summary>
        /// Returns the current working directory of the application.
        /// </summary>
        public static string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// Returns the parent directory of the supplied path.
        /// If the path is null, empty, or at the root, an empty string is returned.
        /// </summary>
        public static string GetParentDirectory(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
                throw new ArgumentException("Directory path cannot be null or empty.", nameof(directoryPath));

            var parent = Directory.GetParent(directoryPath);
            return parent?.FullName ?? string.Empty;
        }
    }
}