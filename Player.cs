using System.Collections.Generic;
using System;
/*
    Variables are sorted by accessability from most- to least accessible.

    Class structure is as follows:
    - Variables
    - Lambda Getters
    - Properties
    - Constructor(s)
    - Methods

    Unity Specifics:
    [SerializeField] attribute to make variables appear in inspector instead of using public variables.

    Should only use public variables for data objects.
    Very hard to break stuff when working in a team if everything is public as there is no error checking.
*/

public class Player : IAttackable
{
    //Static variables are written with snake case and capitalized.
    public static int PLAYER_MAX_LEVEL = 100;

    //Private and protected variables start with an underscore. Important to differenciate public and private variables.
    //Can also type "_" and use auto-complete to quickly browse through variables. Good for learning new codebases.
    private string _name;
    private List<Skill> _skills;
    private int _playerLevel;
    private int _health;
    private int _maxHealth;

    public string Name => _name;                    //Public getters are accessed with a lambda statement
    public bool IsDead => _health <= 0;             //Can also be used for simple logic statements

    //If setter is required, use a property
    public int PlayerLevel
    {
        get => _playerLevel;
        set
        {
            _playerLevel = (value > PLAYER_MAX_LEVEL) ? PLAYER_MAX_LEVEL : value;         //Ternary operators are cool but not required
        }
    }

    public int Health
    {
        get => _health;
        set
        {
            //One liner if statements doesn't require brackets
            if (value < 0)
                _health = 0;
            else
                _health = value;
        }
    }

    //Parameter arguments use camelCase
    //Removes the need for "this.name = name"
    public Player(string name, int maxHealth)
    {
        _name = name;
        _maxHealth = maxHealth;
        _health = maxHealth;
        _playerLevel = 1;

        _skills = new List<Skill>();
    }

    //All methods use PascalCase including Private ones
    public void Attack(int damage)
    {
        Health -= damage;

        Console.WriteLine($"{_name} took {damage} Damage!");
    }

    public void LearnSkill(Skill skill)
    {
        //Error checking should always be up top in methods.
        if (HasSkill(skill))
        {
            Console.WriteLine($"{_name} already knows the skill: {skill.Name}!");
            return;
        }


        _skills.Add(skill);

        Console.WriteLine($"{_name} learned the skill: {skill.Name}!");
    }

    //Preferrably only use one return statement. Easier to debug especially in longer methods.
    //I know this can be an easy LINQ oneliner but couldn't come up with a better example hehe
    private bool HasSkill(Skill skill)
    {
        bool hasSkill = false;
        foreach (Skill s in _skills)
        {
            if (s.Name == skill.Name)
            {
                hasSkill = true;
                break;
            }
        }

        return hasSkill;
    }
}