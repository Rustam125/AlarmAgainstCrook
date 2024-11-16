using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool IsOpened { get; private set; }
    
    public event Action Opened;
    
    public void Open()
    {
        IsOpened = true;
        Opened?.Invoke();
    }
    
    public void Close()
    {
        IsOpened = false;
    }
}
