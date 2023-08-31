using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour
{
    public float scrollSpeed;
    //public Material mat;
    public float forceAdded;

    void Update () {
        float offset = (Time.time * scrollSpeed) % 1.0f;
        //mat.SetTextureOffset ("_MainTex", new Vector2 (0, -offset));
        //mat.SetTextureOffset ("_BumpMap", new Vector2 (0, -offset));
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Block") {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * forceAdded, ForceMode.Impulse);
        }

    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Block") {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * forceAdded, ForceMode.Impulse);
        }
    }
}
