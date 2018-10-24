using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject testObj;
    public float interval = 2f;

    List<GameObject> list = new List<GameObject>();

    void Start()
    {
        StartCoroutine(insta());
    }

    private IEnumerator insta()
    {
        while (true)
        {
            GameObject go = (GameObject)Instantiate(testObj, transform.position, transform.rotation);
            list.Add(go);

            if (list.Count > 3)
            {
                Destroy(list[0]);
                list.RemoveAt(0);
            }

            yield return new WaitForSeconds(interval);
        }
    }
}