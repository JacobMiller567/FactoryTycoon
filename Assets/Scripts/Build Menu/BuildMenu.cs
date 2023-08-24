using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    //[SerializeField] public GameObject prefabBuild;
    [SerializeField] public GameObject[] prefabBuilds;
    private bool isDragging;
    private GameObject currentObject;
    private Vector3 offset;

    public bool tycoonPurchased;

    //public GameObject lasers;



    void Update() 
    {
        if (isDragging) // ADD: Only can be placed on land!!
        {
            // ADD: prevent building from being lifted off the ground. Snap on plane.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                currentObject.transform.position = hit.point - offset;


                // ADD: If click "r" allow rotating of buildings!

            /*
                // TEST:
                // Check if the building is above the ground
                float distanceToGround = Vector3.Distance(currentObject.transform.position, hit.point);
                if (distanceToGround > 0.1f)
                {
                    // Snap the building to the ground
                    currentObject.transform.position = new Vector3(currentObject.transform.position.x, hit.point.y + 0.1f, currentObject.transform.position.z);
                }
            // END of Test:
            */
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            isDragging = false;
            tycoonPurchased = false;
        }
    }

    public void SpawnBuilding(int num)
    {
  //      if (Input.GetMouseButtonDown(0)) // ADD: If tower is purchased
        if (tycoonPurchased == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                currentObject = Instantiate(prefabBuilds[num], hit.point, Quaternion.identity);
                offset = hit.point - currentObject.transform.position;
                isDragging = true;
            }
        }
    }

}
