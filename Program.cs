public class Program
{
    static void Main(string[] args)
    {
        //Local variables use their type and not "var"
        //Makes it easier for others that aren't familiar with the code to understand whats happening.
        Player player = new Player("Simon", 100);
        player.Attack(5);
        
        Skill skill = new Skill("Mining", 5);
        player.LearnSkill(skill);
        player.LearnSkill(skill);

    }
}

