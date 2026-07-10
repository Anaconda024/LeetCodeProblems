using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace LeetCodePropblems.EasyProblems {
    public class TwoSum {
        public void Excecute() {
            while (true) {
                List<int> numbers = new List<int>();

                Console.WriteLine("Enter numbers one at a time. Enter any non-number to finish.");
                while (true) {
                    Console.Write("Number: ");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out int value)) {
                        break;
                    }
                    numbers.Add(value);
                }

                int target;
                Console.Write("Enter the target value: ");
                while (!int.TryParse(Console.ReadLine(), out target)) {
                    Console.Write("That's not a number. Enter the target value: ");
                }

                int[] nums = numbers.ToArray();
                Console.WriteLine($"Array: [{string.Join(", ", nums)}]");

                try {
                    int[] answer = FindTwoSum(nums, target);
                    Console.WriteLine($"Indices: [{answer[0]}, {answer[1]}]");
                    Console.WriteLine($"Values: {nums[answer[0]]} + {nums[answer[1]]} = {target}");
                }
                catch (Exception ex) {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.Write("Type 'stop' to exit, or anything else to try again: ");
                string command = Console.ReadLine();
                if (command != null && command.Trim().Equals("stop", StringComparison.OrdinalIgnoreCase)) {
                    break;
                }
            }
        }

        public int[] FindTwoSum(int[] nums, int target) {
            if (nums == null || nums.Length < 2) {
                throw new ArgumentException("Input must contain at least two numbers.", nameof(nums));
            }

            // Start j at i + 1 so a number is never paired with itself and no pair is checked twice
            for (int i = 0; i < nums.Length; i++) {
                for (int j = i + 1; j < nums.Length; j++) {
                    if (nums[i] + nums[j] == target) {
                        return [i, j];
                    }
                }
            }

            throw new InvalidOperationException($"No two numbers add up to {target}.");
        }
    }
}
