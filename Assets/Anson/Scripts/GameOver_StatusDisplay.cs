using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_StatusDisplay : MonoBehaviour
{
    [SerializeField] GameOver_StatusStatus baseGO;
    [SerializeField] Transform scrollViewContent;

    public void Initialise(StatusEffect[] statusEffects)
    {
        GameOver_StatusStatus newSS;
        foreach (StatusEffect se in statusEffects)
        {
            newSS = Instantiate(baseGO.gameObject, scrollViewContent).GetComponent<GameOver_StatusStatus>();
            newSS.Initialise(se);
        }


        RectTransform rt = scrollViewContent.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, baseGO.GetComponent<RectTransform>().rect.height * statusEffects.Length);
        

    }
}
