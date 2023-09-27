using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observable : MonoBehaviour
{
    private List<IObserver> observers = new List<IObserver>();
    private List<Collectibles> resources = new List<Collectibles>();

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void AddResource(Collectibles collectible)
    {
        resources.Add(collectible);
        NotifyObservers(collectible);
    }

    protected void NotifyObservers(Collectibles collectible)
    {
        ItemType type = collectible.type;

        foreach (var observer in observers)
        {
            observer.OnCollectibleUpdated(collectible, type);
        }
    }
}
