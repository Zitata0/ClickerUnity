using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventClick : MonoBehaviour
{
    [Header("TextBoxes")]
    public TextMeshProUGUI diamondText;
    public TextMeshProUGUI strangeText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI researchText;
    public TextMeshProUGUI strangeUpgradeText;
    public TextMeshProUGUI speedUpgradeText;
    [Header("Values")]
    private int diamond;
    private int strange;
    private int speed;
    private int research;
    private int strangeUpgradeCost;
    private int speedUpgradeCost;
    [Header("Other")]
    private DateTime timer;
    void Start()
    {
        diamond = PlayerPrefs.GetInt("diamond", 0);
        strange = PlayerPrefs.GetInt("strange", 1);
        speed = PlayerPrefs.GetInt("speed", 0);
        research = PlayerPrefs.GetInt("research", 0);
        UpdateStatsCost();
        timer = DateTime.Now;
    }
    void Update()
    {
        if (DateTime.Now.Subtract(timer).Seconds >= 1)
        {
            timer = DateTime.Now;
            diamond += speed;
        }
        diamondText.text = diamond.ToString();
        strangeText.text = strange.ToString();
        speedText.text = speed.ToString();
        researchText.text = research.ToString();
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("diamond", diamond);
        PlayerPrefs.SetInt("strange", strange);
        PlayerPrefs.SetInt("speed", speed);
        PlayerPrefs.SetInt("research", research);
    }
    public void Click()
    {
        diamond += strange;
    }
    public void UpgradeStrange()
    {
        if (diamond - strangeUpgradeCost > 0)
        {
            diamond -= strangeUpgradeCost;
            strange++;
            UpdateStatsCost();
        }
    }
    public void UpgradeSpeed()
    {
        if (diamond - speedUpgradeCost > 0)
        {
            diamond -= speedUpgradeCost;
            speed++;
            UpdateStatsCost();
        }
    }
    private void UpdateStatsCost()
    {
        strangeUpgradeCost = 100 * strange * (strange / 4 + 1);
        strangeUpgradeText.text = strangeUpgradeCost.ToString();
        speedUpgradeCost = 1000 * speed;
        speedUpgradeText.text = speedUpgradeCost.ToString();
    }
}
