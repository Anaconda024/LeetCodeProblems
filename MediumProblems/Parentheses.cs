using LeetCodePropblems.EasyProblems;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;
using static LeetCodePropblems.MediumProblems.LongPalindomic;

namespace LeetCodePropblems.MediumProblems {
    public class Parentheses {
        public void Execute() {
            Console.WriteLine("Enter a number between 1 and 5, Enter 'Stop' finish.");
            while (true) {
                Console.Write("String: ");
                string input = Console.ReadLine();

                if (input != null && input.Trim().Equals("stop", StringComparison.OrdinalIgnoreCase)) {
                    break;
                }

                try {
                    int n = int.Parse(input);
                    IList<string> answer = GenerateParenthesis(n);
                    Console.WriteLine($"Palindrome: [{answer}]");
                }
                catch (Exception ex) {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public IList<string> GenerateParenthesis(int n) {
            string paranth = "()";
            int count = 0;
            List<string> answer = new List<string>();

            string firstParanth = string.Empty;
            while (count < n) {
                firstParanth += paranth;
                count++;
            }
            answer.Add(firstParanth);
            char[] charArray = firstParanth.ToCharArray();
            int[] intArray = ConvertArrayStringToInt(charArray);

            List<int[]> rows = GenerateRandoms(intArray);

            var array = GenerateNewCharArray(rows);

            answer = CharArraysToStrings(array);

            return answer;
        }

        private List<int[]> GenerateRandoms(int[] intArray) {
            int[] trimmed = intArray.Skip(1).SkipLast(1).ToArray();

            long targetCount = CountUniqueArrangements(trimmed);

            var uniqueArrangements = new List<int[]>();

            uniqueArrangements.Add(trimmed);
            int count = 1;
            if(targetCount == count) {
                while (count < targetCount) {
                    var shuffled = Shuffle(trimmed);
                    if (!uniqueArrangements.Any(arr => arr.SequenceEqual(shuffled))) {
                        uniqueArrangements.Add(shuffled);
                        count++;
                    }
                }
            };

            return uniqueArrangements;
        }

        private List<char[]> GenerateNewCharArray(List<int[]> intArray) {
            var newcharArray = new List<char[]>(); 
            var newIntArray = new List<int[]>(); 
            foreach (var array in intArray) {
                if (CheckIfLegit(array)) {
                    newIntArray.Add(array);
                }
            }
            foreach (var array in newIntArray) {
               var charArray = ConvertArrayIntToString(array);
                newcharArray.Add(charArray);
            }
            return newcharArray;
        }

        private int[] ConvertArrayStringToInt(char[] charArray) {
            int[] digits = new int[charArray.Length];

            for (int i = 0; i < charArray.Length; i++) {
                if (charArray[i] == '(') {
                    charArray[i] = '1';
                }
                if (charArray[i] == ')') {
                    charArray[i] = '0';
                }

                // '0' is 48 in Unicode, so subtracting it maps '0'-'9' onto 0-9
                digits[i] = charArray[i] - '0';

            }
            return digits;
        }

        private char[] ConvertArrayIntToString(int[] digits) {
            char[] charArray = new char[digits.Length];

            for (int i = 0; i < digits.Length; i++) {
                if (digits[i] == 1) {
                    charArray[i] = '(';
                }
                else if (digits[i] == 0) {
                    charArray[i] = ')';
                }
                else {
                    // Adding '0' (48) maps 0-9 back onto the characters '0'-'9'
                    charArray[i] = (char)(digits[i] + '0');
                }
            }
            return charArray;
        }

        public static long CountUniqueArrangements(int[] arr) {
            if (arr == null || arr.Length % 2 != 0) {
                throw new ArgumentException("Array must be non-null and have an even length.");
            }

            int n = arr.Length;
            int k = n / 2;

            long result = 1;

            // Multiplies and divides in tandem to prevent intermediate overflow
            for (int i = 1; i <= k; i++) {
                result = result * (n - k + i) / i;
            }

            return result;
        }

        public static int[] Shuffle(int[] array) {
            int[] result = new int[array.Length];
            Array.Copy(array, result, array.Length);

            Random random = new Random();
            for (int i = result.Length - 1; i > 0; i--) {
                int j = random.Next(i + 1);
                int temp = result[i];
                result[i] = result[j];
                result[j] = temp;
            }

            return result;
        }

        private bool CheckIfLegit(int[] intArray) {
            var length = intArray.Length;
            var midpoint = length / 2;
            var sum = 0;

            for(int i = 0;i < midpoint; i++) {
                sum += intArray[i];
            }

            if (sum < midpoint) {
                return true;
            }
            else return false;

        }

        public static List<string> CharArraysToStrings(List<char[]> charArrays) {
            return charArrays.Select(chars => new string(chars)).ToList();
        }
    }
}

