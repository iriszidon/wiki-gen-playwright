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
        /// Returns the name of the Nth (indirect) parent directory of the current working directory.
        /// For example, level=1 returns the immediate parent name; level=2 returns the grandparent name.
        /// Returns an empty string if the Nth parent does not exist (e.g., reached the root).
        /// </summary>
        /// <param name="level">The number of levels to go up from the current directory (must be >= 1).</param>
        /// <returns>The name of the Nth parent directory, or an empty string if it doesn't exist.</returns>
        public static string GetNthParentDirectory(int level)
        {
            if (level < 1)
                throw new ArgumentOutOfRangeException(nameof(level), "Level must be greater than or equal to 1.");

            var current = new DirectoryInfo(Directory.GetCurrentDirectory());

            for (int i = 0; i < level; i++)
            {
                if (current?.Parent == null)
                    return string.Empty;

                current = current.Parent;
            }

            return current.FullName ?? string.Empty;
        }
    }
}