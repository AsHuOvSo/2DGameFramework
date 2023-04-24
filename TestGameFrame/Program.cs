using _2DGameFramework;

public class Program
{
    
    public static void Main(string[] args)
    {
        World myWorld = new World(200, 400);
        Position pos = new Position(5, 9);
        AttackItem sword = new AttackItem(true, true, "Sword", false, pos, 7, 2);
        pos = new Position(3, 1);
        Creature player = new Creature(false, false, "Player", false, pos, 100, 20, 5);
        sword.AddAttack(player);
        Console.WriteLine("player total attack after picking up sword: " + player.totalAttack.ToString());
        pos = new Position(4, 3);
        Creature wolf = new Creature(false, true, "Wolf", false, pos, 30, 10, 0);
        player.GetHit(wolf);
        Console.WriteLine("player hp after wolf attack is: " + player.HitPoints.ToString());
        wolf.GetHit(player);
    }

    

   

    
}