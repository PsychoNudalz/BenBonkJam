using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public static class CreateNewCards
{
    public static GameObject[] CreateNewCard(CardHandler cardHandler, GameObject baseCard,CardSave cs, string cardName = null)
    {
        GameObject instanceRoot = (GameObject)PrefabUtility.InstantiatePrefab(baseCard);
        Card newCard = instanceRoot.GetComponent<Card>();
        newCard.UpdateCard(cs, cardHandler.GetCardsFromIDs(cs.headsOption.sequenceCardsAdd), cardHandler.GetCardsFromIDs(cs.headsOption.sequenceCardsRemove), cardHandler.GetCardsFromIDs(cs.tailsOption.sequenceCardsAdd), cardHandler.GetCardsFromIDs(cs.tailsOption.sequenceCardsRemove));
        newCard.CardID = CardManager.GetIDValue(newCard);
        if (cardName == null)
        {
            if (newCard.CardDetails != "")
            {
                instanceRoot.name = "Card_" + newCard.CardDetails;
            }
            else
            {
                instanceRoot.name = "Card_" + newCard.CardDescriptionText;
            }
        }
        else
        {
            instanceRoot.name = "Card_" + cardName;
        }
        GameObject pVariant = PrefabUtility.SaveAsPrefabAsset(instanceRoot, "Assets/Cards_New/" + CardManager.GetAgeFolderString((int)cs.ageNeeded[0]) + "/" + instanceRoot.name + ".prefab");
       // DestroyImmediate(instanceRoot);
        return new GameObject[] {instanceRoot,pVariant};
    }
}
