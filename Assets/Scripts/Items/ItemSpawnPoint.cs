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
        item.transform.position = transform.position;
    }

    public void Empty()
    {
        IsEmpty = true;
    }
}