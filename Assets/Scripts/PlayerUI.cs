using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public RectTransform basicContent;
    public RectTransform statsContent;
    public InfoBlock basicInfoTemplate;
    public InfoBlock statsInfoTemplate;

    private Dictionary<string, InfoBlock> basicInfos;
    private Dictionary<string, InfoBlock> statsInfos;

    public void SetPlayer(Player player)
    {
        if (basicInfos == null)
        {
            basicInfos = new Dictionary<string, InfoBlock>();
            CreateBasicInfoBlock("Name", player.Name);
            CreateBasicInfoBlock("Country", player.Country);
            CreateBasicInfoBlock("Age", player.Age + "");
            CreateBasicInfoBlock("Height", player.Height + "");
            CreateBasicInfoBlock("Primary Pos", player.PrimaryPosition);
        }
        else
        {
            SetInfoBlock("Name", player.Name);
            SetInfoBlock("Country", player.Country);
            SetInfoBlock("Age", player.Age + "");
            SetInfoBlock("Height", player.Height + "");
            SetInfoBlock("Primary Pos", player.PrimaryPosition);
        }

        if (statsInfos == null)
        {
            statsInfos = new Dictionary<string, InfoBlock>();
            CreateStatsInfoBlock("Agility", player.Agility, Player.max_agility);
            CreateStatsInfoBlock("Conditioning", player.Conditioning, Player.max_conditioning);
            CreateStatsInfoBlock("Reception Skill", player.ReceptionSkill, Player.max_receptionSkill);
            CreateStatsInfoBlock("Defense Skill", player.DefenseSkill, Player.max_defenseSkill);
            CreateStatsInfoBlock("Setter Skill", player.SetterSkill, Player.max_setterSkill);
            CreateStatsInfoBlock("Block Height", player.BlockHeight, Player.max_blockHeight);
            CreateStatsInfoBlock("Block Skill", player.BlockSkill, Player.max_blockSKill);
            CreateStatsInfoBlock("Spike Height", player.SpikeHeight, Player.max_setterSkill);
        }
        else
        {
            SetStatsBlock("Agility", player.Agility, Player.max_agility);
            SetStatsBlock("Conditioning", player.Conditioning, Player.max_conditioning);
            SetStatsBlock("Reception Skill", player.ReceptionSkill, Player.max_receptionSkill);
            SetStatsBlock("Defense Skill", player.DefenseSkill, Player.max_defenseSkill);
            SetStatsBlock("Setter Skill", player.SetterSkill, Player.max_setterSkill);
            SetStatsBlock("Block Height", player.BlockHeight, Player.max_blockHeight);
            SetStatsBlock("Block Skill", player.BlockSkill, Player.max_blockSKill);
            SetStatsBlock("Spike Height", player.SpikeHeight, Player.max_setterSkill);
        }
    }

    private void SetInfoBlock(string title, string value)
    {
        if (basicInfos[title] != null)
            basicInfos[title].SetInfo(title, value);
        else
            CreateBasicInfoBlock(title, value);
    }

    private void CreateBasicInfoBlock(string title, string value)
    {
        InfoBlock block = Instantiate(basicInfoTemplate, basicContent);
        block.SetInfo(title, value);
        basicInfos.Add(title, block);
        block.gameObject.SetActive(true);
    }

    private void SetStatsBlock(string title, int value, int maxValue)
    {
        if (statsInfos[title] != null)
            statsInfos[title].SetInfo(title, value, maxValue);
        else
            CreateStatsInfoBlock(title, value, maxValue);
    }

    private void SetStatsBlock(string title, float value, float maxValue)
    {
        if (statsInfos[title] != null)
            statsInfos[title].SetInfo(title, value, maxValue);
        else
            CreateStatsInfoBlock(title, value, maxValue);
    }

    private void CreateStatsInfoBlock(string title, int value, int maxValue)
    {
        InfoBlock block = Instantiate(statsInfoTemplate, statsContent);
        block.SetInfo(title, value, maxValue);
        statsInfos.Add(title, block);
        block.gameObject.SetActive(true);
    }

    private void CreateStatsInfoBlock(string title, float value, float maxValue)
    {
        InfoBlock block = Instantiate(statsInfoTemplate, statsContent);
        block.SetInfo(title, value, maxValue);
        statsInfos.Add(title, block);
        block.gameObject.SetActive(true);
    }
}
