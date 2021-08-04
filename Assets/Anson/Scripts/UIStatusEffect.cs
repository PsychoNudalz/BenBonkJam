using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIStatusEffect : MonoBehaviour
{
    public StatusEffect status;
    [SerializeField] Image spriteRenderer;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
        textMeshProUGUI.text = s.status.ToString();

    }
}
