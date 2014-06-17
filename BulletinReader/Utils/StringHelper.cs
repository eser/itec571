namespace BulletinReader.Utils
{
    using System;
    using System.Text;

    public class StringHelper
    {
        public static string Replace(string original, string pattern, Func<string, string> replacement, StringComparison comparisonType, int stringBuilderInitialSize = -1)
        {
            if (original == null || String.IsNullOrEmpty(pattern))
            {
                return original;
            }

            int posCurrent = 0;
            int lenPattern = pattern.Length;
            int idxNext = original.IndexOf(pattern, comparisonType);
            StringBuilder result = new StringBuilder(stringBuilderInitialSize < 0 ? Math.Min(4096, original.Length) : stringBuilderInitialSize);

            while (idxNext >= 0)
            {
                result.Append(original, posCurrent, idxNext - posCurrent);
                result.Append(replacement(original.Substring(idxNext, lenPattern)));

                posCurrent = idxNext + lenPattern;

                idxNext = original.IndexOf(pattern, posCurrent, comparisonType);
            }

            result.Append(original, posCurrent, original.Length - posCurrent);

            return result.ToString();
        }
    }
}