using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusSummaryRow : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TMP_Text statusNameText;
    [SerializeField] TMP_Text gainText;
    [SerializeField] TMP_Text lossText;
    [SerializeField] TMP_Text passiveText;

    [SerializeField] StatusEffect status;
    
    public void SetStatusEffect(StatusEffect status, SummaryType type)
    {
        this.status = status;
        icon.sprite = status.icon;
        statusNameText.text = StatusEnumName.GetStatusNameString(status.status);



        switch (type)
        {
            case SummaryType.HP:
                gainText.text = GetPercentageString(status.HealthPos);
                SetStatColour(gainText,status.HealthPos,true);
                lossText.text = GetPercentageString(status.HealthNeg);
                SetStatColour(lossText,status.HealthNeg,false);
                passiveText.text = GetPercentageString((int)status.HealthPassive);
                SetStatColour(passiveText,(int)status.HealthPassive,true);
                break;
            case SummaryType.Bux:
                gainText.text = GetPercentageString(status.BuxPos);
                SetStatColour(gainText,status.BuxPos,true);
                lossText.text = GetPercentageString(status.BuxNeg);
                SetStatColour(lossText,status.BuxNeg,false);
                passiveText.text = GetPercentageString((int)status.BuxPassive);
                SetStatColour(passiveText,(int)status.BuxPassive,true);
                break;
            case SummaryType.Mood:
                gainText.text = GetPercentageString(status.MoodPos);
                SetStatColour(gainText,status.MoodPos,true);
                lossText.text = GetPercentageString(status.MoodNeg);
                SetStatColour(lossText,status.MoodNeg,false);
                passiveText.text = GetPercentageString((int)status.MoodPassive);
                SetStatColour(passiveText,(int)status.MoodPassive,true);
                break;
        }
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


}
