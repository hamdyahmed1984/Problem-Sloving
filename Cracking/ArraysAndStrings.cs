using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking
{
    /// <summary>
    /// Some notes about strings
    /// ASCII codes table is of length 128 starting from index 0 to index 127 ===> 0-9 --> 48-57, A-Z --> 65-90, a-z --> 97-122
    /// EXTENDED ASCII codes starts from index 128 to index 255 and contains other special characters.
    /// </summary>
    public class ArraysAndStrings
    {
        public static bool DoesStringContainsAnother(string large, string small)
        {
            int smallLength = small.Length;
            int largeLength = large.Length;
            for (int i = 0; i <= largeLength - smallLength; i++)
            {
                if (large.Substring(i, smallLength) == small)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Time: O(n^2), Space: O(1)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool isUniqueChars(string str)
        {
            for (int i = 0; i < str.Length; i++)
                for (int j = i + 1; j < str.Length; j++)
                    if (str[i] == str[j])
                        return false;
            return true;
        }

        /// <summary>
        /// Time: O(n), Space: O(n)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool isUniqueChars2(string str)
        {
            HashSet<char> set = new HashSet<char>();
            for (int i = 0; i < str.Length; i++)
                if (set.Contains(str[i]))
                    return false;
                else
                    set.Add(str[i]);
            return true;
        }

        /// <summary>
        /// Assuming the str in ASCII only, we can use Extended ASCII and hence the array size will be 256.
        /// If it is Unicode we need to increase the size
        /// Time: O(min(n,m)), Space: O(m) ==> n is the length of the string and m is the length of assumed character set
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool isUniqueChars3(string str)
        {
            bool[] charSet = new bool[128];
            for (int i = 0; i < str.Length; i++)
            {
                int val = str[i];
                if (charSet[val])
                    return false;
                else
                    charSet[val] = true;
            }
            return true;
        }

        public static void Permutations(string str)
        {
            Permutations(str, 0, str.Length - 1);
        }
        /// <summary>
        /// O(N*N!) ==> O(N!) for calculating permutations and O(N) for printing to console.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public static void Permutations(string str, int start, int end)
        {
            if (start == end)
                Console.WriteLine(str);
            else
            {
                for (int i = start; i <= end; i++)
                {
                    str = swap(str, i, start);
                    Permutations(str, start + 1, end);
                    str = swap(str, i, start);
                }
            }
        }
        public static string swap(string str, int i, int j)
        {
            char[] chars = str.ToCharArray();
            char tmp = chars[i];
            chars[i] = chars[j];
            chars[j] = tmp;
            return new string(chars);

            //StringBuilder sb = new StringBuilder(str);
            //char tmp = sb[i];
            //sb[j] = sb[j];
            //sb[j] = tmp;
            //return sb.ToString();
        }

        public static List<List<int>> Permutations(List<int> lst)
        {
            List<List<int>> lstPerms = new List<List<int>>();
            Permutations(lst, 0, lstPerms);
            return lstPerms;
        }

        public static void Permutations(List<int> lst, int start, List<List<int>> lstPerms)
        {
            if (start >= lst.Count)
            {
                Console.WriteLine(string.Join(",", lst));
                lstPerms.Add(lst.ToList());//.ToList() creates a new list, otherwise every addition to the list will overwrite the previous entries
            }
            else
            {
                for (int i = start; i < lst.Count; i++)
                {
                    Swap(ref lst, start, i);
                    Permutations(lst, start + 1, lstPerms);
                    Swap(ref lst, start, i);
                }
            }
        }

        public static void Swap(ref List<int> lst, int i, int j)
        {
            int tmp = lst[i];
            lst[i] = lst[j];
            lst[j] = tmp;
        }
        public static void Permutations2(string suffix, string prefix)
        {
            if (suffix.Length == 0)
                Console.WriteLine(prefix);
            else
            {
                for (int i = 0; i < suffix.Length; i++)
                {
                    Permutations2(suffix.Substring(0, i) + suffix.Substring(i + 1), prefix + suffix[i]);
                }
            }
        }

        public static void isStringPermutaionOfAnother4(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                Console.WriteLine(str1 + " is not a permutation of " + str2);
                return;
            }
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in str1)
            {
                if (dict.ContainsKey(c))
                    dict[c]++;
                else
                    dict.Add(c, 1);
            }
            for (int i = 0; i < str2.Length; i++)
            {
                char c = str2[i];
                if (dict.ContainsKey(c))
                {
                    dict[c]--;
                    if (dict[c] < 0)
                    {
                        Console.WriteLine(str1 + " is NOT a permutation of " + str2);
                        return;
                    }
                }
                else
                {
                    Console.WriteLine(str1 + " is NOT a permutation of " + str2);
                    return;
                }
            }
            Console.WriteLine(str1 + " is a permutation of " + str2);
        }
        public static void isStringPermutaionOfAnother3(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                Console.WriteLine(str1 + " is NOT a permutation of " + str2);
                return;
            }
            int[] arrChars = new int[128];//Count of ascii codes
            foreach (char c in str1)
                arrChars[c]++;
            for (int i = 0; i < str2.Length; i++)
            {
                int c = str2[i];
                arrChars[c]--;
                if (arrChars[c] < 0)
                {
                    Console.WriteLine(str1 + " is NOT a permutation of " + str2);
                    return;
                }
            }
            Console.WriteLine(str1 + " is a permutation of " + str2);
        }
        public static void isStringPermutaionOfAnother2(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                Console.WriteLine(str1 + " is NOT a permutation of " + str2);
                return;
            }
            if (SortString(str1) == SortString(str2))
                Console.WriteLine(str1 + " is a permutation of " + str2);
            else
                Console.WriteLine(str1 + " is NOT a permutation of " + str2);
        }
        public static string SortString(string str)
        {
            char[] chars = str.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
        public static void isStringPermutaionOfAnother(string strToTest, string strToTestAgainst)
        {
            Permutations2Check(strToTestAgainst, "", strToTest);
        }
        public static void Permutations2Check(string suffix, string prefix, string strToTest)
        {
            if (suffix.Length == 0 && prefix == strToTest)
            {
                Console.WriteLine("True");
                return;
            }
            else
            {
                for (int i = 0; i < suffix.Length; i++)
                {
                    Permutations2Check(suffix.Substring(0, i) + suffix.Substring(i + 1), prefix + suffix[i], strToTest);
                }
            }
        }

        public static int CountValidPathsWithMemorization(int[,] grid, int row, int col, int[,] savedPaths)
        {
            if (!IsValidSquare(grid, row, col))
                return 0;
            if (IsAtEnd(grid, row, col))
                return 1;
            if (savedPaths[row, col] == 0)
                savedPaths[row, col] = CountValidPathsWithMemorization(grid, row + 1, col, savedPaths) +
                    CountValidPathsWithMemorization(grid, row, col + 1, savedPaths);
            return savedPaths[row, col];
        }
        public static int CountValidPaths(int[,] grid, int row, int col)
        {
            if (!IsValidSquare(grid, row, col))
                return 0;
            if (IsAtEnd(grid, row, col))
                return 1;
            return CountValidPaths(grid, row + 1, col) + CountValidPaths(grid, row, col + 1);
        }

        private static bool IsAtEnd(int[,] grid, int row, int col)
        {
            int matrixRowLength = grid.GetLength(0);
            if (row == matrixRowLength - 1 || col == matrixRowLength - 1)
                return true;
            return false;
        }

        private static bool IsValidSquare(int[,] grid, int row, int col)
        {
            if (grid[row, col] == 0)
                return false;
            return true;
        }

        public static void ReplaceSpaceWithHTMLUnicode(char[] str, int actualLength)
        {
            int spacesCount = 0;
            for (int i = 0; i < actualLength; i++)
            {
                if (str[i] == ' ')
                    spacesCount++;
            }
            int stringEndIndex = actualLength + spacesCount * 2;
            for (int i = actualLength - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    str[stringEndIndex - 1] = '0';
                    str[stringEndIndex - 2] = '2';
                    str[stringEndIndex - 3] = '%';

                    stringEndIndex = stringEndIndex - 3;
                }
                else
                {
                    str[stringEndIndex - 1] = str[i];
                    stringEndIndex--;
                }
            }
            Console.WriteLine(new string(str));
        }
        public static void ReplaceSpaceWithHTMLUnicode2(char[] str, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (str[i] == ' ')
                {
                    ShiftArrayItems(str, length, i, 2);
                    str[i] = '%';
                    str[++i] = '2';
                    str[++i] = '0';
                    length += 2;

                }
            }
            Console.WriteLine(new string(str));
        }
        public static char[] ShiftArrayItems(char[] str, int length, int start, int shift)
        {
            for (int i = length - 1 + 2; i >= start; i--)
                str[i] = str[i - shift];
            return str;
        }

        public static bool IsPalendromePermutation(string str)
        {
            Dictionary<char, int> dictCounts = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (c == ' ')//ignore spaces
                    continue;
                if (dictCounts.ContainsKey(c))
                    dictCounts[c]++;
                else
                    dictCounts.Add(c, 1);
            }
            int oddCounts = 0;
            foreach (KeyValuePair<char, int> kvp in dictCounts)
            {
                if (kvp.Value % 2 != 0)
                    oddCounts++;
            }
            if (oddCounts > 1)//It should be 0 for even count of chars and 1 for odd count of chars
            {
                Console.WriteLine("String \"" + str + "\" is NOT a permutation for a palendrome.");
                return false;
            }
            Console.WriteLine("String \"" + str + "\" is a permutation for a palendrome.");
            return true;
        }

        public static bool IsOneEditAway(string s1, string s2)
        {
            if (s1.Length == s2.Length)
                return IsOneEditReplace(s1, s2);
            else if (s1.Length + 1 == s2.Length)
                return IsOneEditInsert(s1, s2);
            else if (s1.Length == s2.Length + 1)
                return IsOneEditInsert(s2, s1);
            return false;
        }

        private static bool IsOneEditReplace(string s1, string s2)
        {
            bool diffFound = false;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    if (diffFound)
                        return false;
                    diffFound = true;
                }
            }
            return true;
        }

        private static bool IsOneEditInsert(string s1, string s2)
        {
            int index1 = 0;
            int index2 = 0;
            while (index1 < s1.Length && index2 < s2.Length)
            {
                if (s1[index1] != s2[index2])
                {
                    if (index1 != index2)
                        return false;
                    index2++;
                }
                else
                {
                    index1++;
                    index2++;
                }
            }
            return true;
        }


        public static void FirstDegreePolynomial(int a, int b)
        {
            double x = -b / a;
            Console.WriteLine("X= {0}", x);
        }
        public static void QuadraticEquationRoots(int a, int b, int c)
        {
            double x1, x2;
            double sqrtPart = b * b - 4 * a * c;
            if (sqrtPart == 0)//Both roots are equal
            {
                x1 = x2 = (-b /*+ Math.Sqrt(sqrtPart)*/) / (2 * a);// Math.Sqrt(sqrtPart) is commented as it its value is 0
                Console.WriteLine("Both roots are equal: {0}", x1);
            }
            else if (sqrtPart > 0)//Both roots are real and diff-2
            {
                x1 = (-b + Math.Sqrt(sqrtPart)) / (2 * a);
                x2 = (-b - Math.Sqrt(sqrtPart)) / (2 * a);
                Console.Write("First  Root Root1= {0}\n", x1);
                Console.Write("Second Root root2= {0}\n", x2);
            }
            else
                Console.Write("Root are imaginary;\nNo Solution. \n\n");
        }


        public static string StringCompression(string str)
        {
            StringBuilder sbCompressed = new StringBuilder();
            int countConsecutive = 0;
            for (int i = 0; i < str.Length; i++)
            {
                countConsecutive++;
                if (i == str.Length - 1 || str[i] != str[i + 1])
                {
                    sbCompressed.Append(str[i]);
                    sbCompressed.Append(countConsecutive);
                    countConsecutive = 0;
                }
            }
            return sbCompressed.Length < str.Length ? sbCompressed.ToString() : str;
        }
        public static string StringCompression2(string str)
        {
            if (str == null || str.Length == 0)
                return "";
            StringBuilder sbCompressed = new StringBuilder();
            int charsCount = 0;
            char lastChar = str[0];
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == lastChar)
                    charsCount++;
                else
                {
                    sbCompressed.Append(lastChar);
                    sbCompressed.Append(charsCount);
                    charsCount = 1;
                    lastChar = str[i];
                }
                if (i == str.Length - 1)
                {
                    sbCompressed.Append(lastChar);
                    sbCompressed.Append(charsCount);
                }
            }
            return sbCompressed.Length < str.Length ? sbCompressed.ToString() : str;
        }



        public static void SetMatrixToZeros(int[][] matrix)
        {
            DisplayMatrix(matrix);
            bool[] rowsWithZero = new bool[matrix.Length];
            bool[] colsWithZero = new bool[matrix[0].Length];

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == 0)
                    {
                        rowsWithZero[row] = true;
                        colsWithZero[col] = true;
                    }
                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                if (rowsWithZero[row])
                    NullifyRow(matrix, row);
            }
            for (int col = 0; col < matrix[0].Length; col++)
            {
                if (colsWithZero[col])
                    NullifyColumn(matrix, col);
            }
            Console.WriteLine("\r\n");
            DisplayMatrix(matrix);
        }

        public static void DisplayMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + "\t");
                }
                Console.WriteLine(Environment.NewLine);
            }
        }

        private static void NullifyColumn(int[][] matrix, int col)
        {
            for (int row = 0; row < matrix.Length; row++)
                matrix[row][col] = 0;
        }

        private static void NullifyRow(int[][] matrix, int row)
        {
            for (int col = 0; col < matrix[0].Length; col++)
                matrix[row][col] = 0;
        }

        public static bool IsStringRotation(string s1, string s2)
        {
            if (!string.IsNullOrEmpty(s1) && !string.IsNullOrEmpty(s2) && s1.Length == s2.Length)
            {
                string s1s1 = s1 + s1;
                if (s1s1.Contains(s2))
                {
                    Console.WriteLine("String: {0} is a rotation for string: {1}.", s2, s1);
                    return true;
                }
                else
                {
                    Console.WriteLine("String: {0} is NOT a rotation for string: {1}.", s2, s1);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("String: {0} is NOT a rotation for string: {1}.", s2, s1);
                return false;
            }
        }
        public static bool IsStringRotation2(string s1, string s2)
        {
            if (!string.IsNullOrEmpty(s1) && !string.IsNullOrEmpty(s2) && s1.Length == s2.Length)
            {
                int index = s2.IndexOf(s1[0]);
                if(index != -1)
                {
                    int finalPos = s2.Length - index;
                    if(s2[0] == s1[finalPos] &&
                            s1.Substring(finalPos) == s2.Substring(0, index))
                    {
                        Console.WriteLine("String: {0} is a rotation for string: {1}.", s2, s1);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("String: {0} is NOT a rotation for string: {1}.", s2, s1);
                        return false;
                    }

                }
                else
                {
                    Console.WriteLine("String: {0} is NOT a rotation for string: {1}.", s2, s1);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("String: {0} is NOT a rotation for string: {1}.", s2, s1);
                return false;
            }
        }
    }
}
