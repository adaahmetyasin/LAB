public abstract class Observable
{
    private List<Observer> observers = new List<Observer>();

    public Observable()
    {
        observers = new List<Observer>();
    }

    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(Observer observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (Observer observer in observers)
        {
            observer.Update(this);
        }
    }
}