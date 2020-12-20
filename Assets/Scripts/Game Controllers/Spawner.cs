using System.Collections;
using UnityEngine;

[RequireComponent(typeof(GameObjectPool))]
public class Spawner : MonoBehaviour
{
    [SerializeField] float interval = 3f;
    [SerializeField] float minSpeed = 10f, maxSpeed = 20f;
    [SerializeField] float minHeight = -15f, maxHeight = 15f;

    GameObjectPool pool;
    Coroutine currentRoutine;

    private void Awake()
    {
        pool = GetComponent<GameObjectPool>();
    }

    private void OnEnable()
    {
        currentRoutine = StartCoroutine(SpawnObjectCoroutine());
    }

    private void OnDisable()
    {
        StopCoroutine(currentRoutine);
    }

    IEnumerator SpawnObjectCoroutine()
    {
        var obj = pool.GetObject();
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.left * Random.Range(minSpeed, maxSpeed);
            rb.AddTorque(new Vector3(Random.Range(minSpeed, maxSpeed), Random.Range(minSpeed, maxSpeed), Random.Range(minSpeed, maxSpeed)));
        }
        obj.transform.position = Vector3.up * Random.Range(minHeight, maxHeight) + transform.position;
        yield return new WaitForSeconds(interval);
        obj.gameObject.SetActive(true);
        StartCoroutine(SpawnObjectCoroutine());
    }
}
