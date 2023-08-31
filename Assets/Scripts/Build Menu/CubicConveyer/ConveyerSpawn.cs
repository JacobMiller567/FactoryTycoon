using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private Transform startPos;
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
            //Instantiate(cube, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Instantiate(cube, new Vector3(startPos.position.x, startPos.position.y, startPos.position.z), Quaternion.identity);
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
