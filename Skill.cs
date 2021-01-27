/*
    Data objects with no methods doesn't require getters and setters.
*/

public struct Skill
{
    public string Name;
    public int Level;

    public Skill(string name, int level)
    {
        Name = name;
        Level = level;
    }
}