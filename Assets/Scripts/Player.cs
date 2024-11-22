using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player
{
    private string name;
    private string country;
    private int age;
    private float height;
    private string primaryPosition;
    private float agility;
    private float conditioning;
    private float receptionSkill;
    private float defenseSkill;
    private float setterSkill;
    private float blockHeight;
    private float blockSkill;
    private float spikeHeight;

    public string Name => name;
    public string Country => country;
    public int Age => age;
    public float Height => height;
    public string PrimaryPosition => primaryPosition;
    public float Agility => agility;
    public float Conditioning => conditioning;
    public float ReceptionSkill => receptionSkill;
    public float DefenseSkill => defenseSkill;
    public float SetterSkill => setterSkill;
    public float BlockHeight => blockHeight;
    public float BlockSkill => blockSkill;
    public float SpikeHeight => spikeHeight;

    public const float max_agility = 75;
    public const float max_conditioning = 70;
    public const float max_receptionSkill = 60;
    public const float max_defenseSkill = 80;
    public const float max_setterSkill = 90;
    public const float max_blockHeight = 315;
    public const float max_blockSKill = 80;
    public const float max_spikeHeight = 325;

    public Player(string name, string country, int age, float height, string primaryPosition, float agility, float conditioning, float receptionSkill, float defenseSkill, float setterSkill, float blockHeight, float blockSKill, float spikeHeight)
    {
        this.name = name;
        this.country = country;
        this.age = age;
        this.height = height;
        this.primaryPosition = primaryPosition;
        this.agility = agility;
        this.conditioning = conditioning;
        this.receptionSkill = receptionSkill;
        this.defenseSkill = defenseSkill;
        this.setterSkill = setterSkill;
        this.blockHeight = blockHeight;
        this.blockSkill = blockSKill;
        this.spikeHeight = spikeHeight;
    }
}
