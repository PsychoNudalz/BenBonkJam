using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffectIcon : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] [Range(1f,20f)] private float moveSpeed;

    private Vector3 endPosition;
    private bool isMoving;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, Time.deltaTime * moveSpeed * 50f);
            if (Vector3.Distance(transform.position, endPosition) < 250f)
            {
                animator.SetTrigger("Disappear");
            }
        }
    }

    public void SetIcon(Sprite iconSprite)
    {
        icon.sprite = iconSprite;
        endPosition = GetComponentInParent<StatusEffectIconSpawner>().EndPosition;
        StartMoving();
    }

    public void StartMoving()
    {
        isMoving = true;
    }

    public void AtEndLocation()
    {
        FindObjectOfType<UIHandler>().UpdateStatusDisplay(FindObjectOfType<Player>());
        Destroy(gameObject);
    }
}
