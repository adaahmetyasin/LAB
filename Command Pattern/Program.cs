class Program
{
    static void Main(string[] args)
    {
        int  sum = Calculator.calculate(10, 5, new Add());
        int  sub = Calculator.calculate(10, 5, new Subtract());
        int  mul = Calculator.calculate(10, 5, new Multiply());
        int  div = Calculator.calculate(10, 5, new Divide());
        int  pow = Calculator.calculate(10, 5, new Power());
        int  mod = Calculator.calculate(10, 5, new Modulus());
        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Sub: " + sub);
        Console.WriteLine("Mul: " + mul);
        Console.WriteLine("Div: " + div);
        Console.WriteLine("Pow: " + pow);
        Console.WriteLine("Mod: " + mod);
    }

    public interface Process
    {
        int process(int num1, int num2);
    }

    public class Add : Process
    {
        public int process(int num1, int num2)
        {
            return num1 + num2;
        }
    }
    public class Subtract : Process
    {
        public int process(int num1, int num2)
        {
            return num1 - num2;
        }
    }
    public class Multiply : Process
    {
        public int process(int num1, int num2)
        {
            return num1 * num2;
        }
    }
    public class Divide : Process
    {
        public int process(int num1, int num2)
        {
            return num1 / num2;
        }
    }
    public class Power : Process
    {
        public int process(int num1, int num2)
        {
            return (int)Math.Pow(num1, num2);
        }
    }

    public class Modulus : Process
    {
        public int process(int num1, int num2)
        {
            return num1 % num2;
        }
    }

    public class Calculator
    {
        public static int calculate(int num1, int num2, Process process)
        {
            return process.process(num1, num2);
        }
    }





}