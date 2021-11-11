using UnityEngine;
using UnityEngine.EventSystems;

public class TouchHandler : MonoBehaviour, IPointerClickHandler
{
    private Mechanics.Cell cell;
    void Start()
    {
        cell = GetComponent<Mechanics.Cell>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        cell.DigUpOrPick();
    }
}
