using UnityEngine;

public abstract class Poolable : MonoBehaviour
{
    [HideInInspector]
    public GameObjectPool pool;
}
