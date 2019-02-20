using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


//This script was sourced courtesy of Paul Alexandrow at https://www.alexandrow.org/blog/autoscroll-dropdowns-in-unity/

[RequireComponent(typeof(ScrollRect))]
public class Dropdown_Scroller : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform scrollRectTransform;
    public RectTransform contentPanel;
    public RectTransform selectedRectTransform;
    GameObject lastSelected;

    Vector2 targetPos;

    void Start()
    {
        scrollRectTransform = GetComponent<RectTransform>();

        if (contentPanel == null)
            contentPanel = GetComponent<ScrollRect>().content;

        targetPos = contentPanel.anchoredPosition;
    }

    void Update()
    {
        if (!_mouseHover)
            Autoscroll();
    }


    public void Autoscroll()
    {
        if (contentPanel == null)
            contentPanel = GetComponent<ScrollRect>().content;

        GameObject selected = EventSystem.current.currentSelectedGameObject;

        if (selected == null)
        {
            return;
        }
        if (selected.transform.parent != contentPanel.transform)
        {
            return;
        }
        if (selected == lastSelected)
        {
            return;
        }

        selectedRectTransform = (RectTransform)selected.transform;
        targetPos.x = contentPanel.anchoredPosition.x;
        targetPos.y = -(selectedRectTransform.localPosition.y) - (selectedRectTransform.rect.height / 2);
        targetPos.y = Mathf.Clamp(targetPos.y, 0, contentPanel.sizeDelta.y - scrollRectTransform.sizeDelta.y);

        contentPanel.anchoredPosition = targetPos;
        lastSelected = selected;
    }

    bool _mouseHover;
    public void OnPointerEnter(PointerEventData eventData)
    {
        _mouseHover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _mouseHover = false;
    }
}
