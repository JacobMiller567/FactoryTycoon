using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    //[SerializeField] private GameObject[] balls;
    [SerializeField] private GameObject ball;
    public bool canSpawn;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            SpawnBalls();
        }
        
    }

    public void SpawnBalls()
    {
        if (canSpawn)
        {
            Instantiate(ball, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            StartCoroutine(CoolDown());
        }
    }

    IEnumerator CoolDown()
    {
        canSpawn = false;
        yield return new WaitForSeconds(speed);
        canSpawn = true;
    }
}
