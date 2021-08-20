using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectIconSpawner : MonoBehaviour
{
    [SerializeField] private GameObject EffectIconGO;
    [SerializeField] private Transform endLocationObject;
    [SerializeField] private ParticleSystem statusEffectParticles;

    private Vector3 endPosition;

    public Vector3 EndPosition => endPosition;

    void Start()
    {
        endPosition = endLocationObject.position;
        FindObjectOfType<UIHandler>().UpdateStatusDisplay(FindObjectOfType<Player>());
        if(statusEffectParticles == null)
        {
            statusEffectParticles = GameObject.Find("StatusParticleSystem").GetComponent<ParticleSystem>();
        }
    }

    public void SpawnStatusEffectIcon(StatusEffect status)
    {
        GameObject icon = Instantiate(EffectIconGO, transform.position, Quaternion.identity, this.transform);
        icon.GetComponent<StatusEffectIcon>().SetIcon(status.icon);
        statusEffectParticles.Play();
    }

    [ContextMenu("Spawn test icon")]
    public void SpawnTestIcon()
    {
        StatusEffect testSE = FindObjectOfType<StatusEffectManager>().GetStatusEffect(StatusEnum.Addict);
        SpawnStatusEffectIcon(testSE);
    }
}
