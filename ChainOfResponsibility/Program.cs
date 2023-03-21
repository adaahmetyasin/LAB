class Program
{
    static void Main(string[] args)
    {
        Person person = new Person() { Name = "John", Age = 70, Income = 14100 };
        Request request = new Request() { Data = person };
        MaxAgeHandler maxAgeHandler = new MaxAgeHandler();
        MaxNameLengthHandler maxNameLengthHandler = new MaxNameLengthHandler();
        MaxIncomeHandler maxIncomeHandler = new MaxIncomeHandler();

        maxAgeHandler.SetNextHandler(maxNameLengthHandler);
        maxNameLengthHandler.SetNextHandler(maxIncomeHandler);
        maxAgeHandler.Process(request);

        foreach (var item in request.ValdiationMessages)
        {
            Console.WriteLine(item);
        }

        PaymentMethod paymentMethod = new PaymentMethod() { PaymentType = PaymentType.CreditCard };
        CreditCardHandler creditCardHandler = new CreditCardHandler();
        DebitCardHandler debitCardHandler = new DebitCardHandler();
        PaymentWalletHandler paymentWalletHandler = new PaymentWalletHandler();
        NetBankingHandler netBankingHandler = new NetBankingHandler();
        creditCardHandler.SetNextHandler(debitCardHandler);
        debitCardHandler.SetNextHandler(paymentWalletHandler);
        paymentWalletHandler.SetNextHandler(netBankingHandler);

        creditCardHandler.Process(new Request() { Data = paymentMethod });
    }
interface IHandler
    {
    void SetNextHandler(IHandler handler);
    void Process(Request request);
    }

    class Person
    {
    public string Name { get; set; }
    public int Age { get; set; }
    public float Income { get; set; }

    }
    class BaseHandler : IHandler
    {
    protected IHandler _nextHandler;
    public BaseHandler()
    {
        _nextHandler = null;
    }
    public void SetNextHandler(IHandler handler)
    {
        _nextHandler = handler;
    }

    public virtual void Process(Request request)
    {
        throw new NotImplementedException();
    }
    }

    class Request
    {
    public object Data { get; set; }
    public List<string> ValdiationMessages;
    public Request()
    {
        ValdiationMessages = new List<string>();
    }
    }

    class MaxAgeHandler : BaseHandler
    {
    public override void Process(Request request)
    {
        if(request.Data is Person person)
        {
            if(person.Age > 55) request.ValdiationMessages.Add("Invalid age");
            if(_nextHandler != null) _nextHandler.Process(request);
        }
        else
        {
            throw new Exception("Invalid data type");
        }
    }
    }
    class MaxNameLengthHandler : BaseHandler
    {
    public override void Process(Request request)
    {
        if (request.Data is Person person)
        {
            if (person.Name.Length > 10) request.ValdiationMessages.Add("Invalid name length");
            if (_nextHandler != null) _nextHandler.Process(request);
        }
        else
        {
            throw new Exception("Invalid data type");
        }
    }
    }

    class MaxIncomeHandler : BaseHandler
    {
        public override void Process(Request request)
        {
            if (request.Data is Person person)
            {
                if (person.Income > 10000) request.ValdiationMessages.Add("Invalid income");
                if (_nextHandler != null) _nextHandler.Process(request);
            }
            else
            {
                throw new Exception("Invalid data type");
            }
        }
    }

    enum PaymentType
    {
        CreditCard = 1,
        DebitCard = 2,
        PaymentWallet = 3,
        NetBanking = 4
    }

    class PaymentMethod
    {
        public PaymentType PaymentType;
    }

    class CreditCardHandler : BaseHandler
    {
        public override void Process(Request request)
        {
            if (request.Data is PaymentMethod paymentMethod)
            {
                if (paymentMethod.PaymentType == PaymentType.CreditCard)
                {
                    Console.WriteLine("Processing payment using credit card");
                }
                else
                {
                    if (_nextHandler != null) _nextHandler.Process(request);
                }
            }
            else
            {
                throw new Exception("Invalid data type");
            }
        }
    }

    class DebitCardHandler : BaseHandler
    {
        public override void Process(Request request)
        {
            if (request.Data is PaymentMethod paymentMethod)
            {
                if (paymentMethod.PaymentType == PaymentType.DebitCard)
                {
                    Console.WriteLine("Processing payment using debit card");
                }
                else
                {
                    if (_nextHandler != null) _nextHandler.Process(request);
                }
            }
            else
            {
                throw new Exception("Invalid data type");
            }
        }
    }

    class PaymentWalletHandler : BaseHandler
    {
        public override void Process(Request request)
        {
            if (request.Data is PaymentMethod paymentMethod)
            {
                if (paymentMethod.PaymentType == PaymentType.PaymentWallet)
                {
                    Console.WriteLine("Processing payment using payment wallet");
                }
                else
                {
                    if (_nextHandler != null) _nextHandler.Process(request);
                }
            }
            else
            {
                throw new Exception("Invalid data type");
            }
        }
    }

    class NetBankingHandler : BaseHandler
    {
        public override void Process(Request request)
        {
            if (request.Data is PaymentMethod paymentMethod)
            {
                if (paymentMethod.PaymentType == PaymentType.NetBanking)
                {
                    Console.WriteLine("Processing payment using net banking");
                }
                else
                {
                    if (_nextHandler != null) _nextHandler.Process(request);
                }
            }
            else
            {
                throw new Exception("Invalid data type");
            }
        }
    }

}
