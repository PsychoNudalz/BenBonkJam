using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Tooltip : MonoBehaviour
{
    private static Tooltip instance;

    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text hpGainText;
    [SerializeField] private TMP_Text hpLossText;
    [SerializeField] private TMP_Text hpPassiveText;
    [SerializeField] private TMP_Text buxGainText;
    [SerializeField] private TMP_Text buxLossText;
    [SerializeField] private TMP_Text buxPassiveText;
    [SerializeField] private TMP_Text moodGainText;
    [SerializeField] private TMP_Text moodLossText;
    [SerializeField] private TMP_Text moodPassiveText;
    

    void Awake()
    {
        if (Tooltip.instance == null)
        {
            Tooltip.instance = this;
            Tooltip.instance.gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
        if (gameObject.activeInHierarchy)
        {
            transform.position = Mouse.current.position.ReadValue();
        }
    }

    public static void ShowTooltip_Static(StatusEffect status)
    {
        if (!instance.isActiveAndEnabled)
        {
            instance.ShowTooltip(status);
        }
    }

    public static void HideTooltip_Static()
    {
        if (instance.isActiveAndEnabled)
        {
            instance.HideTooltip();
        }
    }

    public void ShowTooltip(StatusEffect status)
    {
        gameObject.SetActive(true);
        SetTooltipValues(status);
        
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    private void SetTooltipValues(StatusEffect statusEffect)
    {
         icon.sprite = statusEffect.icon;
         titleText.text = StatusEnumName.GetStatusNameString(statusEffect.status);
         descriptionText.text = statusEffect.description;
         
         hpGainText.text = GetPercentageString(statusEffect.HealthPos);
         SetStatColour(hpGainText, statusEffect.HealthPos, true);
         hpLossText.text = GetPercentageString(statusEffect.HealthNeg);
         SetStatColour(hpLossText, statusEffect.HealthNeg, false);
         hpPassiveText.text = GetPercentageString(statusEffect.HealthPassive);
         SetStatColour(hpPassiveText, (int)statusEffect.HealthPassive, true);
         
         buxGainText.text = GetPercentageString(statusEffect.BuxPos);
         SetStatColour(buxGainText, statusEffect.BuxPos, true);
         buxLossText.text = GetPercentageString(statusEffect.BuxNeg);
         SetStatColour(buxLossText, statusEffect.BuxNeg, false);
         buxPassiveText.text = GetPercentageString(statusEffect.BuxPassive);
         SetStatColour(buxPassiveText, (int)statusEffect.BuxPassive, true);

         moodGainText.text = GetPercentageString(statusEffect.MoodPos);
         SetStatColour(moodGainText, statusEffect.MoodPos, true);
         moodLossText.text = GetPercentageString(statusEffect.MoodNeg);
         SetStatColour(moodLossText, statusEffect.MoodNeg, false);
         moodPassiveText.text = GetPercentageString(statusEffect.MoodPassive);
         SetStatColour(moodPassiveText, (int)statusEffect.MoodPassive, true);

    }

    private void SetStatColour(TMP_Text text, int value, bool isPositive)
    {
        if (value != 0)
        {
            if (isPositive)
            {
                text.color = Color.green;
            }
            else
            {
                text.color = Color.red;
            }
        }
        else
        {
            text.color = Color.white;
        }
    }

    private string GetPercentageString(int value)
    {
        if (value == 0)
        {
            return "-";
        }

        return $"{value}%";
    }

    private string GetPercentageString(float value)
    {
        if (value == 0)
        {
            return "-";
        }

        return $"{value}%";
    }
}
