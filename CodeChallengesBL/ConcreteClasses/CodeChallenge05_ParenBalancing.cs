﻿using CodeChallengesBL.Interfaces;
using System.Collections.Generic;
using System.Collections.Specialized;

/*
Code Challenge #5
For this week’s challenge, we’ll tackle trying to determine if a string containing parentheses is balanced or not.  You can think of this like a math equation or nested code blocks.  For example, if you had the following, your method or function would return “true” because there is a closing bracket for every opening bracket.
 
“((x+y (3x-2)) * (z^2 - 1) * (x + z))”
 
Extra credit if you can come up with a solution that solves the problem in a different way from your original solution (i.e. If your first solution used something like a stack data structure you should create an algorithm that solves this problem using another structure or solution).
 
Please send solutions and/or questions to dan.bunker@stgutah.com and brett.child@stgutah.com this week.  Thanks and happy coding!
 
Dan
 */

namespace CodeChallengesBL.ConcreteClasses
{
    public class CodeChallenge05_ParenBalancing : ICodeChallenge
    {
        public string OutputResult(OrderedDictionary inputValues)
        {
            string userInput = inputValues[0].ToString();
            return "Balanced (count implementation):" + HasBalancedParens1(userInput) +
                   "\nBalanced (stack implementation):" + HasBalancedParens2(userInput);
        }

        // count implementation
        public static bool HasBalancedParens1(string userInput)
        {
            int parenCount = 0;
            foreach (char c in userInput)
            {
                if (c == '(')
                {
                    parenCount++;
                }
                else if (c == ')')
                {
                    if (parenCount == 0)
                    {
                        return false;
                    }
                    parenCount--;
                }
            }
            return parenCount == 0;
        }

        // stack implementation
        public static bool HasBalancedParens2(string userInput)
        {
            var stackParens = new Stack<char>();
            foreach (char c in userInput)
            {
                if (c == '(')
                {
                    stackParens.Push(c);
                }
                else if (c == ')')
                {
                    if (stackParens.Count == 0)
                    {
                        return false;
                    }
                    stackParens.Pop();
                }
            }
            return stackParens.Count == 0;
        }
    }
}
