using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollectionButton : MonoBehaviour
{
    [SerializeField] PlayerCollection currentPC;
    [SerializeField] Color unlockedColour = new Vector4(1f,1f,1f,1f);
    [SerializeField] Color lockedColour = new Vector4(.5f, .5f, .5f, .5f);
    [SerializeField] GameObject lockSprite;
    [SerializeField] Button button;
    [SerializeField] Image buttonImage;
    [SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (!button)
        {
            button = GetComponent<Button>();
            
        }
        if (!buttonImage)
        {
            buttonImage = GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetButton(PlayerCollection pc)
    {
        currentPC = pc;
        buttonImage.sprite = pc.Sprite;
        text.text = pc.CollectionName;
        SetIsUnloack(pc.IsUnlocked);
    }

    public void SetIsUnloack(bool isUnloacked)
    {
        if (isUnloacked)
        {
            buttonImage.color = unlockedColour;
            lockSprite.SetActive(false);
            button.interactable = true;

        }
        else
        {
            buttonImage.color = lockedColour;
            lockSprite.SetActive(true);
            button.interactable = false;

        }
    }
}
