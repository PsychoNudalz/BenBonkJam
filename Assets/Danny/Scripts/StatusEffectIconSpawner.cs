using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectIconSpawner : MonoBehaviour
{
    [SerializeField] private GameObject EffectIconGO;
    [SerializeField] private Transform endLocationObject;

    private Vector3 endPosition;

    public Vector3 EndPosition => endPosition;

    void Start()
    {
        endPosition = endLocationObject.position;
        FindObjectOfType<UIHandler>().UpdateStatusDisplay(FindObjectOfType<Player>());
    }

    public void SpawnStatusEffectIcon(StatusEffect status)
    {
        GameObject icon = Instantiate(EffectIconGO, transform.position, Quaternion.identity, this.transform);
        icon.GetComponent<StatusEffectIcon>().SetIcon(status.icon);
    }
}
