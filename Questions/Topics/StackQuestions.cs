using System;

namespace Questions
{
    public static class StackQuestions
    {
        /// <summary>
        /// Question: Stack operations
        /// </summary>
        public static void StackOperations()
        {
            var arr = Helper.ReadElementsInOneLine();
            var stack = ConvertToStack(arr);
            Print(stack);
            while (!stack.IsEmpty())
            {
                Helper.WriteLine(stack.Top());
                Helper.WriteLine("Popping");
                stack.Pop();
                Console.Write("Stack: "); Print(stack);
            }
            Helper.WriteLine(stack.IsEmpty());
        }
        // ------------------------------------

        /// ------------------------------------
        /// <summary>
        /// Question: Reverse a string using Stack
        /// </summary>
        public static void ReverseString()
        {
            var str = Helper.ReadString();
            str = ReverseString(str);
            Helper.WriteLine(str);
        }

        private static string ReverseString(string s)
        {
            var stack = new Stack<string>();
            var sentenceArray = s.Split(' ');

            for (int i = 0; i < sentenceArray.Length; i++)
            {
                stack.Push(sentenceArray[i]);
            }

            string reversed = string.Empty;
            for (int i = 0; i < sentenceArray.Length; i++)
            {
                reversed += $"{stack.Top()} ";
                stack.Pop();
            }

            return reversed;
        }
        // ------------------------------------

        // Postfix, prefix and Infix notations

        /*
         *
         * Humans use Infix notation, infix notation requires usage of operator precedence
         * To make it easier for computers, we can use either postfix or prefix( aka polish notation)
         * here we don't need to know precedence for evaluation as it is handled automatically 
         * while converting from infix to either postfix or prefix
         * 
         * Example: 
         * Infix:   a+b*c
         * Postfix: abc*+
         * Prefix:  +a*bc
         *
         * One easy way to convert from infix to others is to imagine brackets around
         * expressions that have higher precedence like so
         *  Step1: Add brackets
         *         (a + (b*c))
         *  Step2: Solve inner most brackets first and then outer
         *         -> (a + *(bc))
         *         -> +(a*(bc))
         *         -> +a*bc
         *  Similar steps for postfix
         *  
         *  ------------------------------------------
         *  Approach for evaluation of prefix notation
         *  
         *  expression: +a*bc
         *  
         *  1. Traverse from right to left one by one
         *  2. Push operands into stack
         *  3. When operator is encountered, pop out top two operands from stack
         *  4. first popped item becomes operand1, second operand2 ***
         *  5. evaluate with operator found in step 2, operand1 operator operand2
         *  6. push result into stack
         *  7. When end of string is reached, only 1 number should be in stack, it would be the result
         *  
         *  ------------------------------------------
         *  
         *  ------------------------------------------
         *  Approach for evaluation of postfix notation
         *  
         *  expression: abc*+
         *  
         *  1. Traverse from left to right one by one
         *  2. Push operands into stack
         *  3. When operator is encountered, pop out top two operands from stack
         *  4. first popped item becomes operand2, second operand1 ***
         *  5. evaluate with operator found in step 2, operand1 operator operand2
         *  6. push result into stack
         *  7. When end of string is reached, only 1 number should be in stack, it would be the result
         *  
         *  ------------------------------------------
         *  
         */

        /// <summary>
        /// Prefix evaluation
        /// </summary>
        public static void PrefixEvaluation()
        {
            var s = Helper.ReadString();
            var ans = PrefixEvaluation(s);
            Helper.WriteLine(ans);
        }

        private static int PrefixEvaluation(string s)
        {
            var stack = new Stack<int>();
            string[] arr = s.Trim().Split(' ');

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (int.TryParse(arr[i], out int val))
                {
                    stack.Push(val);
                }
                else
                {
                    int operand1 = stack.Top();
                    stack.Pop();
                    int operand2 = stack.Top();
                    stack.Pop();

                    switch (arr[i])
                    {
                        case "+":
                            stack.Push(operand1 + operand2);
                            break;
                        case "-":
                            stack.Push(operand1 - operand2);
                            break;
                        case "*":
                            stack.Push(operand1 * operand2);
                            break;
                        case "/":
                            stack.Push(operand1 / operand2);
                            break;
                        case "^":
                            stack.Push((int)Math.Pow(operand1, operand2));
                            break;
                    }
                }

            }

            return stack.Top();
        }
        // ------------------------------------

        /// <summary>
        /// Prefix evaluation
        /// </summary>
        public static void PostfixEvaluation()
        {
            var s = Helper.ReadString();
            var ans = PostfixEvaluation(s);
            Helper.WriteLine(ans);
        }

        private static int PostfixEvaluation(string s)
        {
            var stack = new Stack<int>();
            string[] arr = s.Trim().Split(' ');

            for (int i = 0; i < arr.Length; i++)
            {
                if (int.TryParse(arr[i], out int val))
                {
                    stack.Push(val);
                }
                else
                {
                    int operand2 = stack.Top();
                    stack.Pop();
                    int operand1 = stack.Top();
                    stack.Pop();

                    switch (arr[i])
                    {
                        case "+":
                            stack.Push(operand1 + operand2);
                            break;
                        case "-":
                            stack.Push(operand1 - operand2);
                            break;
                        case "*":
                            stack.Push(operand1 * operand2);
                            break;
                        case "/":
                            stack.Push(operand1 / operand2);
                            break;
                        case "^":
                            stack.Push((int)Math.Pow(operand1, operand2));
                            break;
                    }
                }

            }

            return stack.Top();
        }
        // ------------------------------------

        /// ------------------------------------
        /// <summary>
        /// Question: Check if parenthesis are balanced
        /// </summary>
        public static void AreParenthesisBalanced()
        {
            var s = Helper.ReadString();
            var ans = AreParenthesisBalanced(s);
            Helper.WriteLine(ans);
        }

        private static bool AreParenthesisBalanced(string s)
        {
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '{':
                    case '(':
                    case '[':
                        stack.Push(s[i]);
                        break;
                    case ')':
                        if (stack.Top() == '(') stack.Pop();
                        else return false;
                        break;
                    case ']':
                        if (stack.Top() == '[') stack.Pop();
                        else return false;
                        break;
                    case '}':
                        if (stack.Top() == '{') stack.Pop();
                        else return false;
                        break;
                }
            }

            return stack.IsEmpty();
        }
        // ------------------------------------

        /// ------------------------------------
        /// <summary>
        /// Question: Convert from infix expression to postfix expression
        /// Solution:
        /// 
        /// I: (a-b/c)*(a/k-l)
        /// O: abc/-ak/l-*
        /// 
        /// Traverse from left to right
        /// create a function to return precedence as such
        /// ^ = 3
        /// *, / = 2
        /// -, = 1
        /// 
        /// if operand
        ///     print
        /// else if '('
        ///     push
        /// else if ')' 
        ///     pop from stack until opening bracket is found
        /// else if operator
        ///     Take stack top
        ///     if operator has greater precedence than stack top
        ///         push
        ///     else
        ///         pop until above condition becomes true, then push operator
        ///         
        ///     
        /// 
        /// </summary>
        public static void InfixToPostfix()
        {
            var s = Helper.ReadString();
            var ans = InfixToPostfix(s);
            Helper.WriteLine(ans);
        }

        private static string InfixToPostfix(string s)
        {
            var stack = new Stack<char>();
            string str = string.Empty;

            for (int i = 0; i < s.Length; i++)
            {
                if (
                    s[i] >= 'a' && s[i] <= 'z' ||
                    s[i] >= 'A' && s[i] <= 'Z'
                    )
                {
                    str += s[i];
                }
                else if (s[i] == '(')
                {
                    stack.Push(s[i]);
                }
                else if (s[i] == ')')
                {
                    while (
                        !stack.IsEmpty() && 
                        stack.Top() != '('
                        )
                    {
                        str += stack.Top();
                        stack.Pop();
                    }
                    stack.Pop();
                }
                else // handle operators
                {
                    var currPrecedence = GetPrecedence(s[i]);
                    if ( currPrecedence > GetPrecedence(stack.Top()))
                    {
                        stack.Push(s[i]);
                    }
                    else
                    {
                        while (!stack.IsEmpty() && currPrecedence < GetPrecedence(stack.Top()))
                        {
                            str += stack.Top();
                            stack.Pop();
                        }
                        stack.Push(s[i]);
                    }
                }
            }

            while(!stack.IsEmpty())
            {
                str += stack.Top();
                stack.Pop();
            }

            return str;
        }

        private static int GetPrecedence(char c)
        {
            switch (c)
            {
                case '^':
                    return 3;
                case '*':
                case '/':
                    return 2;
                case '+':
                case '-':
                    return 1;
                default:
                    return 0;
            }
        }
        // ------------------------------------

        /// ------------------------------------
        /// <summary>
        /// Question: Convert from infix expression to prefix expression
        /// </summary>
        /// /// <summary>
        /// 
        /// Solution:
        /// 
        /// I: (a-b/c)*(a/k-l)
        /// O: *-a/bc-/akl
        /// 
        /// Traverse from right to left
        /// create a function to return precedence as such
        /// ^ = 3
        /// *, / = 2
        /// -, = 1
        /// 
        /// if operand
        ///     print
        /// else if closing bracket ')'
        ///     push
        /// else if opening bracket '(' 
        ///     pop from stack until closing bracket is found
        /// else if operator
        ///     Take stack top
        ///     if operator is greater than stack top (precedence wise)
        ///         push
        ///     else
        ///         while operator is smaller than stack top
        ///             pop 
        ///         then push operator
        ///         
        ///     
        /// 
        /// </summary>
        public static void InfixToPrefix()
        {
            var s = Helper.ReadString();
            var ans = InfixToPrefix(s);
            Helper.WriteLine(ans);
        }

        private static string InfixToPrefix(string s)
        {
            var stack = new Stack<char>();
            var str = string.Empty;

            for (int i = s.Length-1; i >=0; i--)
            {
                if (
                    s[i] >= 'a' && s[i] <= 'z' ||
                    s[i] >= 'A' && s[i] <= 'Z'
                    )
                {
                    str = s[i] + str;
                }
                else if (s[i] == ')')
                {
                    stack.Push(s[i]);
                }
                else if (s[i] == '(')
                {
                    while (!stack.IsEmpty() && stack.Top() != ')')
                    {
                        str = stack.Top() + str;
                        stack.Pop();
                    }
                    stack.Pop();
                }
                else
                {
                    var operatorPrecedence = GetPrecedence(s[i]);
                    if (operatorPrecedence > GetPrecedence(stack.Top()))
                    {
                        stack.Push(s[i]);
                    }
                    else
                    {
                        while (!stack.IsEmpty() && GetPrecedence(stack.Top()) > operatorPrecedence)
                        {
                            str = stack.Top() + str;
                            stack.Pop();
                        }

                        stack.Push(s[i]);
                    }
                }
            }

            while (!stack.IsEmpty())
            {
                str = stack.Top() + str;
                stack.Pop();
            }


            return str;
        }
        // ------------------------------------

        #region helpers
        private static Stack<int> ConvertToStack(int[] arr)
        {
            var stack = new Stack<int>();

            foreach (int i in arr)
                stack.Push(i);

            return stack;
        }

        private static void Print(Stack<int> stack)
        {
            var len = stack.List.GetLength();
            var str = string.Empty;
            for (int i = 0; i < len; i++)
            {
                str += $"{stack.List.GetNthValue(i)} -> ";
            }

            Helper.WriteLine($"[{str}null ]");
        }
        #endregion
    }
}

/* 
/// ------------------------------------
/// <summary>
/// Question: Stack
/// </summary>
public static void Stack()
{
    var arr = Helper.ReadElementsInOneLine();
    var stack = ConvertToStack(arr);
    Print(stack);
    stack = Operation(stack);
    Print(stack);
}

private static Node Operation(Stack stack)
{

}
// ------------------------------------

*/