using System;

namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var formatter = new PrintingHouse();
            var book = new Book(formatter)
            {
                Title = "Design Patterns",
                Author = "Gang of Four",
                Text = "Some text"
            };
            book.Print();

            var document = new Document(formatter);
            document.Print();
        }
    }

    public interface IFormatter
    {
        string Format();
    }

    public class PrintingHouse : IFormatter
    {
        public string Format()
        {
            return "Ada BasimEvi";
        }
    }
    public abstract class Manuscript
    {
        protected IFormatter _formatter;

        public Manuscript(IFormatter formatter)
        {
            _formatter = formatter;
        }

        public abstract void Print();
    }
    public class Book : Manuscript
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }

        public Book(IFormatter formatter): base(formatter)
        {
        }

        public override void Print()
        {
            Console.WriteLine("Book: {0} by {1}", Title, Author);
            Console.WriteLine("Text: {0}", Text);
        }
    }
    public class Document : Manuscript
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }

        public Document(IFormatter formatter): base(formatter)
        {
        }

        public override void Print()
        {
            Console.WriteLine("Document: {0} by {1}", Title, Author);
            Console.WriteLine("Text: {0}", Text);
        }
    }

    public class Column : Manuscript
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }

        public Column(IFormatter formatter): base(formatter)
        {
        }

        public override void Print()
        {   
            Console.WriteLine("Column: {0} by {1}", Title, Author);
            Console.WriteLine("Text: {0}", Text);
        }

    }
}

    
