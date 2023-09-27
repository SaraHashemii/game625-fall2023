using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver 
{
    void OnCollectibleUpdated(object obj, ItemType type);
}
