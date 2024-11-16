using UnityEngine;

public class Door : MonoBehaviour
{
    public bool IsOpened { get; private set; }
    
    public void Open()
    {
        IsOpened = true;
    }
    
    public void Close()
    {
        IsOpened = false;
    }
}
