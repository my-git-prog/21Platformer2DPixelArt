using UnityEngine;

public class ItemSpawnPoint : MonoBehaviour
{
    public bool IsEmpty { get; private set;}

    private void Awake()
    {
        IsEmpty = true;
    }

    public void AddItem(Item item)
    {
        IsEmpty = false;
        item.Taken += Empty;
        item.transform.position = transform.position;
    }

    private void Empty(Item item)
    {
        IsEmpty = true;
        item.Taken -= Empty;
    }
}