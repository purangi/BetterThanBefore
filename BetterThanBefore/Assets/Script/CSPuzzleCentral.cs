using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSPuzzleCentral : MonoBehaviour
{
    public Transform AHPuzzleInvisible;
    List<CSPuzzleArranger> arrangers;

    void Start()
    {
        arrangers = new List<CSPuzzleArranger>();

        var arrs = transform.GetComponentsInChildren<CSPuzzleArranger>();

        for (int i = 0; i < arrs.Length; i++)
        {
            arrangers.Add(arrs[i]);
        }
    }

    public static void SwapCards(Transform sour, Transform dest)
    {
        Transform sourParent = sour.parent;
        Transform destParent = dest.parent;

        int sourindex = sour.GetSiblingIndex();
        int destindex = dest.GetSiblingIndex();

        sour.SetParent(destParent);
        sour.SetSiblingIndex(destindex);

        dest.SetParent(sourParent);
        dest.SetSiblingIndex(sourindex);
    }

    void SwapPuzzle(Transform sour, Transform dest)
    {
        SwapCards(sour, dest);
        arrangers.ForEach(t => t.UpdateChildren());
    }

    bool ContainPos(RectTransform rt, Vector2 pos)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rt, pos);
    }

    void BeginDrag(Transform card)
    {
        SwapPuzzle(AHPuzzleInvisible, card);
    }

    void Drag(Transform card)
    {

        var whichArrangerCard = arrangers.Find(t => ContainPos(t.transform as RectTransform, card.position));

        if (whichArrangerCard == null)
        {

        }
        else
        {
            int invisiblePuzzleindex = AHPuzzleInvisible.GetSiblingIndex();
            int targetindex = whichArrangerCard.GetIndexByPosition(card, invisiblePuzzleindex);

            if (invisiblePuzzleindex != targetindex)
            {
                whichArrangerCard.SwapCard(invisiblePuzzleindex, targetindex);
            }
        }
    }

    void EndDrag(Transform card)
    {
        SwapPuzzle(AHPuzzleInvisible, card);
    }

}