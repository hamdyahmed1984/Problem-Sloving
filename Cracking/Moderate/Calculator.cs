using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracking.Moderate
{
    /// <summary>
    /// 16.26 Calculator: Given an arithmetic equation consisting of positive integers,+,-,* and/ (no parentheses), compute t he result.
    /// EXAMPLE
    /// Input: 2*3+5/6*3+15
    /// Output: 23.5
    /// </summary>
    class Calculator
    {
        public void Test()
        {
            string sequence = "2*3+5/6*3+15";
            double output = Compute(sequence);
        }

        /* Compute the result of the arithmetic sequence. This
   works by reading left to right and applying each term to
   a result. When we see a multiplication or division, we 
   instead apply this sequence to a temporary variable. */
        public double Compute(String sequence)
        {
            List<Term> terms = Term.parseTermSequence(sequence);
            if (terms == null) return int.MinValue;

            double result = 0;
            Term processing = null;
            for (int i = 0; i < terms.Count; i++)
            {
                Term current = terms[i];
                Term next = i + 1 < terms.Count ? terms[i + 1] : null;

                /* Apply the current term to “processing”. */
                processing = collapseTerm(processing, current);

                /* If next term is + or -, then this cluster is done 
                 * and we should apply “processing” to “result”. */
                if (next == null || next.getOperator() == Operator.ADD || next.getOperator() == Operator.SUBTRACT)
                {
                    result = applyOp(result, processing.getOperator(), processing.getNumber());
                    processing = null;
                }
            }

            return result;
        }
        public Term collapseTerm(Term primary, Term secondary)
        {
            if (primary == null) return secondary;
            if (secondary == null) return primary;

            double value = applyOp(primary.getNumber(), secondary.getOperator(), secondary.getNumber());
            primary.setNumber(value);
            return primary;
        }

        public double applyOp(double left, Operator op, double right)
        {
            if (op == Operator.ADD)
            {
                return left + right;
            }
            else if (op == Operator.SUBTRACT)
            {
                return left - right;
            }
            else if (op == Operator.MULTIPLY)
            {
                return left * right;
            }
            else if (op == Operator.DIVIDE)
            {
                return left / right;
            }
            else
            {
                return right;
            }
        }
    }


    public enum Operator
    {
        ADD, SUBTRACT, MULTIPLY, DIVIDE, BLANK
    }
    public class Term
    {
        private double value;
        private Operator oper = Operator.BLANK;


    public Term(double v, Operator op)
        {
            value = v;
            oper = op;
        }

        public double getNumber()
        {
            return value;
        }

        public Operator getOperator()
        {
            return oper;
        }

        public void setNumber(double v)
        {
            value = v;
        }

        public static List<Term> parseTermSequence(String sequence)
        {
            List<Term> terms = new List<Term>();
            int offset = 0;
            while (offset < sequence.Length)
            {
                Operator op = Operator.BLANK;
                if (offset > 0)
                {
                    op = parseOperator(sequence[offset]);
                    if (op == Operator.BLANK)
                    {
                        return null;
                    }
                    offset++;
                }
                try
                {
                    int value = parseNextNumber(sequence, offset);
                    offset += value.ToString().Length;
                    Term term = new Term(value, op);
                    terms.Add(term);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return terms;
        }

        public static Operator parseOperator(char op)
        {
            switch (op)
            {
                case '+': return Operator.ADD;
                case '-': return Operator.SUBTRACT;
                case '*': return Operator.MULTIPLY;
                case '/': return Operator.DIVIDE;
            }
            return Operator.BLANK;
        }

        public static int parseNextNumber(String sequence, int offset)
        {
            StringBuilder sb = new StringBuilder();
            while (offset < sequence.Length && char.IsDigit(sequence[offset]))
            {
                sb.Append(sequence[offset]);
                offset++;
            }
            return int.Parse(sb.ToString());
        }
    }

}
