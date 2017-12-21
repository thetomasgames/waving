using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {
    public Renderer renderer;
    Vector3 startPos;

    // Use this for initialization
    void Start () {
        startPos = transform.position;
    }

    public void Ripple (float secondsWaited,float variation) {
        //StopAllCoroutines();
        StartCoroutine (startRipple (secondsWaited,variation));
    }

    private IEnumerator startRipple (float secondsWaited,float variation) {
        yield return new WaitForSeconds (secondsWaited);
        transform.position = startPos;
        float curVariation = variation;
        for (float i = 0; i < 360 * 3; i += 15) {
            if (i % 360 == 0) {
                curVariation *= 0.5f;
            }
            float y = transform.position.y + curVariation * Mathf.Cos (Mathf.Deg2Rad * i);
            transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x,
                y, transform.position.z), Time.deltaTime);
            changeColor (transform.position.y);
            yield return new WaitForSeconds (0.01f);
        }
        //transform.position = startPos;
        changeColor (transform.position.y);
        yield return null;
    }

    private void changeColor (float y) {
        //renderer.material.color = Color.HSVToRGB (((1 + y) / 2), 1, 1);
    }

    void OnMouseDown () {
        GameManager.instance.Ripple (transform.position);
    }
}