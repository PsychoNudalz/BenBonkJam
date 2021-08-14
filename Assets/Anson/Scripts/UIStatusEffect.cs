using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class UIStatusEffect : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    public StatusEffect status;
    [SerializeField] Image spriteRenderer;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    
    private void OnEnable()
    {
        if (status!=null)
        {
            SetNewStatus(status);
        }
    }

    public void SetNewStatus(StatusEffect s)
    {
        status = s;
        spriteRenderer.sprite = s.icon;
    }

    /*
    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.ShowTooltip_Static(status);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideTooltip_Static();
    }*/
}
