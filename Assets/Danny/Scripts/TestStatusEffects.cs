using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStatusEffects : MonoBehaviour
{
    [Header("For Testing")]
    [SerializeField] private List<StatusEnum> startEffects;

    void Start()
    {
        Player player = FindObjectOfType<Player>();
        StatusEffectManager effectManager = FindObjectOfType<StatusEffectManager>();
        foreach (var status in startEffects)
        {
            player.AddStatus(effectManager.GetStatusEffect(status));
        }
        FindObjectOfType<UIHandler>().UpdateStatusDisplay(player);
    }
}
