using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHoverAndPressed : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        UIAudioManager.Instance.PlayMousePressedAudio();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UIAudioManager.Instance.PlayMouseHoverAudio();
    }
}
