using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public enum SummaryType { HP, Bux, Mood}
public class SummaryTooltip : MonoBehaviour
{
    private static SummaryTooltip SummaryTooltipInstance;

    [SerializeField] TMP_Text TitleText, gainTotalText, lossTotalText, passiveTotalText;
    [SerializeField] Transform statusRows;
    [SerializeField] GameObject statusRowPrefab;

    [SerializeField] private Player player;

    private bool refreshing;

    void Awake()
    {
        if (SummaryTooltip.SummaryTooltipInstance == null)
        {
            SummaryTooltip.SummaryTooltipInstance = this;
            SummaryTooltip.SummaryTooltipInstance.gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
        player = FindObjectOfType<Player>();
        //ShowTooltip(SummaryType.HP);
    }

    private void Start()
    {
        SetTooltipValues(SummaryType.HP);
    }

    private void FixedUpdate()
    {
        if (gameObject.activeInHierarchy)
        {
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        transform.position = Mouse.current.position.ReadValue();
    }

    public static void ShowTooltip_Static(SummaryType type)
    {
        if (!SummaryTooltipInstance.isActiveAndEnabled)
        {
            SummaryTooltipInstance.ShowTooltip(type);
        }
    }

    public static void HideTooltip_Static()
    {
        if (SummaryTooltipInstance.isActiveAndEnabled)
        {
            SummaryTooltipInstance.HideTooltip();
        }
    }

    public void ShowTooltip(SummaryType type)
    {
        //StartCoroutine(RefreshLayout());
        if (player.status.currentstatus != null)
        {
            if(player.status.currentstatus.Count == 0){return;}
            UpdatePosition();
            gameObject.SetActive(true);
            SetTooltipValues(type);
        }
    }

    public void HideTooltip()
    {
        if(refreshing){return;}
        gameObject.SetActive(false);
    }

    public void SetTooltipValues(SummaryType type)
    {
        TitleText.text = $"{type} - Status Effects";

        int GainTotal = 0;
        int LossTotal = 0;
        int PassiveTotal = 0;

        foreach(Transform transform in statusRows)
        {
            Destroy(transform.gameObject);
        }

        foreach(StatusEnum status in player.status.currentstatus)
        {
            StatusEffect statusEffect = FindObjectOfType<StatusEffectManager>().GetStatusEffect(status);

            switch (type)
            {
                case SummaryType.HP:
                    if(statusEffect.HealthPos !=0 || statusEffect.HealthNeg != 0 || statusEffect.HealthPassive != 0)
                    {
                        StatusSummaryRow row = Instantiate(statusRowPrefab,statusRows).GetComponent<StatusSummaryRow>();
                        row.SetStatusEffect(statusEffect,type);
                        GainTotal += statusEffect.HealthPos;
                        LossTotal += statusEffect.HealthNeg;
                        PassiveTotal += (int)statusEffect.HealthPassive;
                    }
                    break;
                case SummaryType.Bux:
                    if(statusEffect.BuxPos !=0 || statusEffect.BuxNeg != 0 || statusEffect.BuxPassive != 0)
                    {
                        StatusSummaryRow row = Instantiate(statusRowPrefab,statusRows).GetComponent<StatusSummaryRow>();
                        row.SetStatusEffect(statusEffect,type);
                        GainTotal += statusEffect.BuxPos;
                        LossTotal += statusEffect.BuxNeg;
                        PassiveTotal += (int)statusEffect.BuxPassive;
                    }
                    break;
                case SummaryType.Mood:
                    if(statusEffect.MoodPos !=0 || statusEffect.MoodNeg != 0 || statusEffect.MoodPassive != 0)
                    {
                        StatusSummaryRow row = Instantiate(statusRowPrefab,statusRows).GetComponent<StatusSummaryRow>();
                        row.SetStatusEffect(statusEffect,type);
                        GainTotal += statusEffect.MoodPos;
                        LossTotal += statusEffect.MoodNeg;
                        PassiveTotal += (int)statusEffect.MoodPassive;
                    }
                    break;
                        
            }
            
            SetTotals(GainTotal,LossTotal,PassiveTotal);
        }

        StartCoroutine(RefreshLayout());
    }

    private void SetTotals(int gainTotal, int lossTotal, int passiveTotal)
    {
        gainTotalText.text = GetPercentageString(gainTotal);
        SetStatColour(gainTotalText,gainTotal,true);
        lossTotalText.text = GetPercentageString(lossTotal);
        SetStatColour(lossTotalText,lossTotal,false);
        passiveTotalText.text = GetPercentageString(passiveTotal);
        SetStatColour(passiveTotalText,passiveTotal,true);
    }

    public IEnumerator RefreshLayout()
    {
        refreshing = true;
        GetComponent<VerticalLayoutGroup>().enabled = false;
        GetComponent<ContentSizeFitter>().enabled = false;

        yield return new WaitForSeconds(0.01F);
            
        GetComponent<ContentSizeFitter>().enabled = true;
        GetComponent<VerticalLayoutGroup>().enabled = true;
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);
        refreshing = false;
    }

    [ContextMenu("Test set statuses")]
    public void TestSetStatuses()
    {
        SetTooltipValues(SummaryType.HP);
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
