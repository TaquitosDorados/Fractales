using System;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    [SerializeField] private bool isDraggable = true;
    public bool IsDraggable => isDraggable;

    [SerializeField] private String id;
    public String pId => id;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnStartDrag()
    {

    }

    public void OnStopDrag()
    {

    }


}
