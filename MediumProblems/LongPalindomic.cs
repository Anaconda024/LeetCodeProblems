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
            string palindrome = string.Empty;
            int palidndromeCount = 0;

            PalindromeModel model = new PalindromeModel();

            char[] charArray = s.ToCharArray();

            for (int i = 0; i < charArray.Length; i++) {
                //first assign first letter repeat as palindromeKD
                int x = 1;
                bool isPalindrome = true;
                if( i - x > 0) {
                    var aa = charArray[i - x + 1];
                    var bb = charArray[i + x];
                    var cc = charArray[i - x];
                    var dd = charArray[i + x];

                    if (charArray[i - x + 1] == charArray[i + x] && i != 0) {
                        model.P_word = string.Concat(charArray[i - x + 1], charArray[i + x]);

                        model.P_count = model.P_word.Length;
                        x++;

                    }
                    else if (charArray[i - x] == charArray[i + x] && i != 0) {
                        model.P_word = string.Concat(charArray[i - x], charArray[i + x]);

                        model.P_count = model.P_word.Length;
                        x++;
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

