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
                    PalindromeModel answer = LongestPalindrome2(input);
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
                while (i - x > 0 && isPalindrome && i <= charArray.Length - 2) {
                    if (charArray[i - x + 1] == charArray[i + x] && i != 0) {
                        int startIndex = i - x + 1;
                        int length = 2 * x;
                        tempPalindrome = new string(charArray, startIndex, length);
                        tempPalidndromeCount = tempPalindrome.Length;

                        if (tempPalidndromeCount > model.P_word.Length) {
                            model.P_word = tempPalindrome;
                            model.P_count = model.P_word.Length;
                        }
                        x++;
                        isPalindrome = true;
                    }
                    else if (charArray[i - x] == charArray[i + x] && i != 0) {
                        int startIndex = i - x;
                        int length = 2 * x + 1;
                        tempPalindrome = new string(charArray, startIndex, length);
                        tempPalidndromeCount = tempPalindrome.Length;

                        if (tempPalidndromeCount > model.P_word.Length) {
                            model.P_word = tempPalindrome;
                            model.P_count = model.P_word.Length;
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

        public PalindromeModel LongestPalindrome2(string s) {
            PalindromeModel model = new PalindromeModel();
            char[] charArray = s.ToCharArray();

            for (int i = 0; i < charArray.Length; i++) {
                // odd-length palindromes, centered on i
                CheckLongestPalindrome(charArray, i, i, model);
                // odd-length palindromes, centered on i
                CheckLongestPalindrome(charArray, i, i + 1, model);
            }

            return model;
        }

        private void CheckLongestPalindrome(char[] charArray, int left, int right, PalindromeModel model) {
            // expand outward while both sides match and stay in bounds
            while (left >= 0 && right < charArray.Length && charArray[left] == charArray[right]) {
                left--;
                right++;
            }

            // left/right overshot by one on each side when the loop exits, so the real palindrome is between them
            int length = right - left - 1;
            
            if (length > model.P_count) {
                model.P_word = new string(charArray, left + 1, length);
                model.P_count = length;
            }
        }

        public class PalindromeModel {
            public int P_count { get; set; } = 0;
            public string P_word { get; set; } = "";
        }



    }
}

