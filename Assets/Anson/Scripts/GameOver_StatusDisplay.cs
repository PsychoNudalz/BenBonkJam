using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver_StatusDisplay : MonoBehaviour
{
    [SerializeField] GameOver_StatusStatus baseGO;
    [SerializeField] Transform scrollViewContent;
    [SerializeField] List<StatusEffect> savedStatuses;
    [SerializeField] float timeBetweenStatuses = 0.5f;
    [SerializeField] Scrollbar verticalBar;

    public void Initialise(StatusEffect[] statusEffects)
    {
        savedStatuses.AddRange(statusEffects);
        StartCoroutine(DisplayStatus());
    }




    private GameOver_StatusStatus InitialiseStatusEffect(StatusEffect se)
    {
        GameOver_StatusStatus newSS = Instantiate(baseGO.gameObject, scrollViewContent).GetComponent<GameOver_StatusStatus>();
        newSS.Initialise(se);
        RectTransform rt = scrollViewContent.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, baseGO.GetComponent<RectTransform>().rect.height * scrollViewContent.childCount);
        verticalBar.value = 1f;
        return newSS;
    }


    IEnumerator DisplayStatus()
    {
        InitialiseStatusEffect(savedStatuses[0]).StartAnimation();
        savedStatuses.RemoveAt(0);
        yield return new WaitForSeconds(timeBetweenStatuses);
        if (savedStatuses.Count > 0)
        {
            StartCoroutine(DisplayStatus());
        }
    }

}
