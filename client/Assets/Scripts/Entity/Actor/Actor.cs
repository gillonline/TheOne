using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor
{
    public string name;
    public int hp;
    public int mp;
    public int attack;
    public AttackType attackType;
    public int defense;
    public DefenseType defenseType;

    public string resPath;
    public List<Skill> skillList;
}
