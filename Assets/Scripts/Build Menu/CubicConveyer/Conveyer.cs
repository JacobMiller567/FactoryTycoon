using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyer : MonoBehaviour
{
    //public Transform[] target;
    public GameObject endPoint; 
    //public Transform target; 
    [SerializeField] public float speed;  
    private int current;
    private bool endReached = false;  
    // Use this for initialization    
    void Start() 
    {
       // gameObject.loc
       endPoint = GameObject.FindWithTag("Target");
       //gameObject.transform.localScale = new Vector3(.2f, .2f, .2f);

    }  
    // Update is called once per frame    
    void Update() 
    {  
        /*
        if (transform.position != target[current].position) {  
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);  
            GetComponent < Rigidbody > ().MovePosition(pos);  
        } else current = (current + 1) % target.Length;
        */
        if (transform.position != endPoint.transform.position && endReached == false)
        {
            Vector3 pos = Vector3.MoveTowards(gameObject.transform.position, endPoint.transform.position, speed * Time.deltaTime);
            gameObject.GetComponent<Rigidbody>().MovePosition(pos); 
           // transform.position = pos;
        }
        else
        {
            endReached = true;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }


    }  
}
