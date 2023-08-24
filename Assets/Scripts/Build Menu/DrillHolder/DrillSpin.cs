using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillSpin : MonoBehaviour
{
    public int speed;
    public GameObject target;
    
    void Update()
    {
        //transform.Rotate(0f, 10f, 0f, Space.World); // Weirdly glitched. Should not move and just spin!!!
     //   transform.Rotate(Vector3.down * Time.deltaTime * speed);//, Space.Self);
        transform.RotateAround(target.transform.position, Vector3.down, speed * Time.deltaTime);
    }
}
