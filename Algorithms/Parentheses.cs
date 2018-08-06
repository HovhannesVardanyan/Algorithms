using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Algo
{
    /// <summary>
    /// This class is designed to provide solution to the following problem.
    /// 
    /// Given a string, determine whether it violates the policy of opening and closing parantheses
    /// 
    /// a(bc)k(de) - correct
    /// a(k))de( - incorrect
    /// </summary>
    static class Parentheses
    {
        private static char[] opening = new char[] { '(','[','{'};
        private static char[] closing = new char[] { ')', ']', '}' };
        static public bool AreParanthesesCorrect(string text)
        {
            DataStructures.Stack<char> stack = new DataStructures.Stack<char>();
            foreach (char character in text)
            {
                if (!IsParantheses(character))
                    continue;

                if (IsOpening(character))
                    stack.Push(character);

                else
                {
                    if (stack.IsEmpty)
                        return false;
                    char c = stack.Pop();

                    if (!ArePair(c, character))
                        return false;

                }

            }


            return stack.IsEmpty;
        }

        static public bool ArePair(char opening, char closing)
            => Array.IndexOf(Parentheses.opening, opening) == Array.IndexOf(Parentheses.closing, closing);
        static public bool IsParantheses(char c)
            => opening.Contains(c) || closing.Contains(c);
        static public bool IsOpening(char c)
            => opening.Contains(c);
        static public bool IsClosing(char c)
            => closing.Contains(c);
    }
}
