using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ClickMonitor : MonoBehaviour, IPointerClickHandler
{
    public event Action<PointerEventData> OnClick;

    public static void AddEvent(Transform tra, Action<PointerEventData> act)
    {
        var monitor = tra.gameObject.GetComponent<ClickMonitor>();
        if (monitor == null)
            monitor = tra.gameObject.AddComponent<ClickMonitor>();
        monitor.OnClick += act;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnClick != null)
            OnClick.Invoke(eventData);
    }
}
