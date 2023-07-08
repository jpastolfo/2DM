using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private int maxCards = 1;
    public int currentCards = 0;
    private GameObject currentRoomPrefab;
    [SerializeField] Transform roomWorldPositon;
    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        Draggable cardScript = eventData.pointerDrag.GetComponent<Draggable>();
        if(cardScript != null && currentCards < maxCards && cardScript.parentToReturnTo != this.transform)
        {
            currentCards++;
            cardScript.parentToReturnTo = this.transform;
            cardScript.changedByDropZone = true;
            if (this.tag != "Hand")
            {
                cardScript.HideImage();
                Camera cam = Camera.main;
                currentRoomPrefab = Instantiate(cardScript.GetPrefab(), roomWorldPositon.position, this.transform.rotation);
            }
        }
    }

    public GameObject GetRoomPrefab()
    {
        return this.currentRoomPrefab;
    }
}
