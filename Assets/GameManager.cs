using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public GameObject prefab;
    public int numberOfObjects = 16;

    private List<Shake> objects;

    public float variation = 15f;

    void Start () {
        GameManager.instance = this;
        objects = new List<Shake> ();
        for (var i = 0; i < numberOfObjects; i++) {
            GameObject go = GameObject.Instantiate (prefab, getPos (i), Quaternion.identity);
            objects.Add (go.GetComponent<Shake> ());
        }
    }

    private Vector3 getPos (int index) {
        int size = (int) Mathf.Sqrt ((float) numberOfObjects);
        return new Vector3 (index / size, 0, index % size);
    }

    public void Ripple (Vector3 start) {
        objects.ForEach (o => {
            float distance = (start - o.transform.position).magnitude;
            o.Ripple (distance / 15, variation);
        });
    }
}