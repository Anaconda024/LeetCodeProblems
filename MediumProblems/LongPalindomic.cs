using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace LeetCodePropblems.MediumProblems {
    public class LongPalindomic {
        public void Execute() {
            Console.WriteLine("Enter a string, Enter 'Stop' finish.");
            while (true) {
                Console.Write("String: ");
                string input = Console.ReadLine();

                if (input != null && input.Trim().Equals("stop", StringComparison.OrdinalIgnoreCase)) {
                    break;
                }

                try {
                    PalindromeModel answer = LongestPalindrome(input);
                    Console.WriteLine($"Palindrome: [{answer.P_word}, {answer.P_count}]");
                }
                catch (Exception ex) {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }



        public PalindromeModel LongestPalindrome(string s) {
            string tempPalindrome = string.Empty;
            int tempPalidndromeCount = 0;

            PalindromeModel model = new PalindromeModel();

            char[] charArray = s.ToCharArray();

            for (int i = 0; i < charArray.Length; i++) {
                //first assign first letter repeat as palindromeKD
                int x = 1;
                bool isPalindrome = true;
                while ( i - x > 0 && isPalindrome && i <= charArray.Length-2) {
                    var aa = charArray[i - x + 1];
                    var bb = charArray[i + x];
                    var cc = charArray[i - x];
                    var dd = charArray[i + x];

                    if (charArray[i - x + 1] == charArray[i + x] && i != 0) {
                        int startIndex = i - x + 1;
                        int length = 2 * x;
                        model.P_word = new string(charArray, startIndex, length);

                        if (model.P_word.Length > tempPalidndromeCount) {
                        model.P_count = model.P_word.Length;
                        tempPalidndromeCount = model.P_word.Length;
                        }
                        x++;
                        isPalindrome = true;
                    }
                    else if (charArray[i - x] == charArray[i + x] && i != 0) {
                        model.P_word = string.Concat(charArray[i - x], charArray[i + x]);

                        int startIndex = i - x;
                        int length = 2 * x +1 ;
                        model.P_word = new string(charArray, startIndex, length);

                        if (model.P_word.Length > tempPalidndromeCount) {
                            model.P_count = model.P_word.Length;
                            tempPalidndromeCount = model.P_word.Length;
                        }
                        x++;
                        isPalindrome = true;

                    }
                    else {
                        isPalindrome = false;
                    }
                }
            }
            return model;
        }

        public class PalindromeModel {
            public int P_count { get; set; }
            public string P_word { get; set; }
        }



    }
}

