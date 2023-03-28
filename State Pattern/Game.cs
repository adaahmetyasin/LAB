public class Game
{
    private Console1 console;

    public Game()
    {
        Console.WriteLine("Oyun başladı");
        console = new Attack();
    }

    public void square()
    {
        console.squareTouch();
    }

    public void triangle()
    {
        console.triangleTouch();
    }

    public void circle()
    {
        console.circleTouch();
    }

    public void cross()
    {
        console.crossTouch();
    }

    public void takeBall(){
        Console.WriteLine("Top alındı. Hücuma çıkılıyor");
        console = new Attack();
    }

    public void loseBall(){
        Console.WriteLine("Top kaybedildi. Savunmaya geçiliyor. Allah'ını seven defansa gelsin.");
        console = new Defense();
    }
}