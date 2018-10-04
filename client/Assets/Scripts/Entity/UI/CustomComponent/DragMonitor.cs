using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

class DragMonitor : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public event Action<Vector2, float> OnDrag;

    public static void AddEvent(Transform tra, Action<Vector2, float> act)
    {
        var monitor = tra.gameObject.GetComponent<DragMonitor>();
        if (monitor == null)
            monitor = tra.gameObject.AddComponent<DragMonitor>();
        monitor.OnDrag += act;
    }
    
    Vector2 lastPos;
    float lastTime;

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        lastPos = eventData.position;
        lastTime = Time.time;

        //Debug.LogFormat("start drag {0}", eventData.position);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        var timeoffset = Time.time - lastTime;
        var offset = eventData.position - lastPos;
        lastPos = eventData.position;
        lastTime = Time.time;
        if (OnDrag != null)
            OnDrag.Invoke(offset, timeoffset);
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {

    }
}
