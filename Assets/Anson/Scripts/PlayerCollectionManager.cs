using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerCollectionManager : MonoBehaviour
{
    [SerializeField] GameObject buttonScreen;
    [SerializeField] List<PlayerCollectionButton> buttons;
    [SerializeField] int pageNumber;
    int maxButtonsPerPage = 6;
    protected List<PlayerCollection> playerCollections = new List<PlayerCollection>();
    [Header("Details Screen")]
    [SerializeField] GameObject detailsScreen;
    [SerializeField] TextMeshProUGUI detailsTitle;
    [SerializeField] Image detailsImage;
    [SerializeField] TextMeshProUGUI detailsDetails;


    private void Awake()
    {
    }

    public void LoadButtons()
    {
        //for (int i = pageNumber*maxButtonsPerPage;i< pageNumber * (maxButtonsPerPage+1)
        int i = pageNumber * maxButtonsPerPage;
        foreach (PlayerCollectionButton b in buttons)
        {
            if (i < playerCollections.Count)
            {
                UpdateButton(b, playerCollections[i]);
                i++;
            }
            else
            {
                UpdateButton(b);
            }
        }
    }


    void UpdateButton(PlayerCollectionButton b, PlayerCollection pc)
    {
        b.gameObject.SetActive(true);

        b.SetButton(pc);
    }

    void UpdateButton(PlayerCollectionButton b)
    {
        b.gameObject.SetActive(false);

    }

    public void OpenDetails(int i)
    {
        buttonScreen.SetActive(false);
        detailsScreen.SetActive(true);
        PlayerCollection currectPC = playerCollections[i + pageNumber * maxButtonsPerPage];

        detailsTitle.text = currectPC.CollectionName;
        detailsImage.sprite = currectPC.Sprite;
        detailsDetails.text = currectPC.Details;
    }

    public void CloseDetails()
    {
        buttonScreen.SetActive(true);
        detailsScreen.SetActive(false);
    }

    public void NextPage()
    {
        pageNumber++;
        pageNumber = Mathf.Clamp(pageNumber, 0, playerCollections.Count / maxButtonsPerPage);
        LoadButtons();
    }
    public void PrevPage()
    {
        pageNumber--;
        pageNumber = Mathf.Clamp(pageNumber, 0, playerCollections.Count / maxButtonsPerPage);
        LoadButtons();
    }

    protected virtual void LoadIsUnlocked()
    {

    }
}
