using System;
using System.Collections;

// Bir koleksiyonu temsil eden arayüz
public interface IAggregate
{
    Iterator CreateIterator();
}

// Koleksiyon öğelerini gezinmek için arayüz
public interface Iterator
{
    object Current { get; }
    bool MoveNext();
}

// Koleksiyon sınıfı, IAggregate arayüzünü uygular
public class ConcreteAggregate : IAggregate
{
    private ArrayList _items = new ArrayList();

    public Iterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }

    public int Count
    {
        get { return _items.Count; }
    }

    public object this[int index]
    {
        get { return _items[index]; }
        set { _items.Insert(index, value); }
    }
}

// Iterator arayüzünü uygulayan sınıf
public class ConcreteIterator : Iterator
{
    private ConcreteAggregate _aggregate;
    private int _current = 0;

    public ConcreteIterator(ConcreteAggregate aggregate)
    {
        _aggregate = aggregate;
    }

    public object Current
    {
        get { return _aggregate[_current]; }
    }

    public bool MoveNext()
    {
        if (_current < _aggregate.Count)
        {
            _current++;
            return true;
        }
        else
        {
            return false;
        }
    }
}

// Kullanımı
class Program
{
    static void Main(string[] args)
    {
        ConcreteAggregate aggregate = new ConcreteAggregate();
        aggregate[0] = "Öğe 1";
        aggregate[1] = "Öğe 2";
        aggregate[2] = "Öğe 3";

        Iterator iterator = aggregate.CreateIterator();
        while (iterator.MoveNext())
        {
            string item = (string)iterator.Current;
            Console.WriteLine(item);
        }
    }
}