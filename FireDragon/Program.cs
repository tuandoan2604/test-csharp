using System;

public interface IReptile
{
    ReptileEgg Lay();
}

public class FireDragon : IReptile
{
    public FireDragon()
    {
    }

    public ReptileEgg Lay()
    {
        return new ReptileEgg(() => new FireDragon());
    }
}

public class ReptileEgg
{
    public IReptile speciesNew;
    public int countHatch = 0;
    public ReptileEgg(Func<IReptile> createReptile)
    {
        this.speciesNew = createReptile();
    }

    public IReptile Hatch()
    {
        if(countHatch < 2)
        {
            countHatch++;
        }
        if(countHatch == 2)
        {
            throw new Exception("hatch more than once");
        }
        return speciesNew;

    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var fireDragon = new FireDragon();
        var egg = fireDragon.Lay();
        var childFireDragon = egg.Hatch();
        egg.Hatch();

    }
}
