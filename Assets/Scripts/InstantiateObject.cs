using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    private GameObject _target;
    [SerializeField]
    private float targetsSpeed = 2f;
    [SerializeField]
    private List<GameObject> prefList;

    int targetCount = 3;

    private void Start()
    {
        if (prefList.Count == 0)
            Debug.LogWarning("No Target Prefab to Instantiate");
        else
            StartCoroutine(InstObj());
    }


    IEnumerator InstObj() 
    {
        while (transform.childCount < targetCount)
        {
            _target = prefList[Random.Range(0, prefList.Count - 1)];
            GameObject go = Instantiate(_target, transform);
            go.name = $"Target {transform.childCount}";
            go.GetComponent<CircleMovement>().angularSpeed = targetsSpeed;
            yield return new WaitForSeconds(2);
        }
    }
}
