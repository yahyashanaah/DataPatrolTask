public class Listener
{
    public string Name { get; }
    public int TargetNumber { get; }
    public int Counter { get; private set; }

    public Listener(string name, int targetNumber)
    {
        Name = name;
        TargetNumber = targetNumber;
        Counter = 0;
    }

    public void Process(int number)
    {
        if (number == TargetNumber)
        {
            Counter++;
        }
    }
}
