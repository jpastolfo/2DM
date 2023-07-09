using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Transform parentToReturnTo = null;
    private Transform lastRoom = null;
    public bool changedByDropZone;
    private Image image;
    [SerializeField] private GameObject roomPrefab;
    public LayoutElement layoutElement;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    // Pointer enter/exit lidar com visuais das salas?
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Entrou");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Saiu");
    }

    public void OnBeginDrag(PointerEventData eventdata)
    {
        Debug.Log("OnBeginDrag");
        layoutElement.preferredWidth = 100;
        if (image.color.a == 0f)
            ShowImage();
        parentToReturnTo = this.transform.parent;
        lastRoom = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventdata)
    {
        // Maybe add offset later
        this.transform.position = eventdata.position;
        Debug.Log("OnDrag");
    }

    public void OnEndDrag(PointerEventData eventdata)
    {
        Debug.Log("OnEndDrag");
        if(lastRoom != null)
            Debug.Log(parentToReturnTo.name);
        
        if(changedByDropZone)
        {
            Debug.Log("-1");
            DropZone roomScript = lastRoom.GetComponent<DropZone>();
            roomScript.currentCards -= 1;
            Destroy(roomScript.GetRoomPrefab());
        }

        if (lastRoom == parentToReturnTo && parentToReturnTo.tag == "Room")
        {
            HideImage();
            layoutElement.preferredWidth = 250;
        }

        this.transform.SetParent(parentToReturnTo);
        changedByDropZone = false;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void HideImage()
    {
        Color tempCor = image.color;
        tempCor.a = 0f;
        image.color = tempCor;
    }

    public void ShowImage()
    {
        Color tempCor = image.color;
        tempCor.a = 1f;
        image.color = tempCor;
    }

    public GameObject GetPrefab()
    {
        return this.roomPrefab;
    }
}
