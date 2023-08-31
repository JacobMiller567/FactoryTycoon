using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    [SerializeField] public GameObject[] prefabBuilds;
    private bool isDragging;
    private GameObject currentObject;
    private Vector3 offset;

    public bool tycoonPurchased;

  //  public float xRot;
  //  public float yRot;
  //  public float zRot;

    public LayerMask layerMask;
    public LayerMask wallLayer;

    void Update() 
    {
        if (isDragging) // ADD: Only can be placed on land!!
        {
            MoveBuilding();
        }
            
            
    }

    public void SpawnBuilding(int num, float xValue, float yValue, float zValue)
    {
        /*
        if (tycoonPurchased == true)
        {

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 7;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            RaycastHit hit;

            if (Physics.Raycast(worldPos, Vector3.up, out hit))//, layerMask))

            {
                //currentObject = Instantiate(prefabBuilds[num], hit.point , Quaternion.identity);//prefabBuilds[num].transform.rotation);//Quaternion.identity);
                currentObject = Instantiate(prefabBuilds[num], hit.point + new Vector3(0f, 0.2f, 0f), Quaternion.identity);

                offset = hit.point - currentObject.transform.position;
                //offset = hit.point - currentObject.transform.rotation;
                isDragging = true;
            }
        }
        */

    //// TESTING CODE HERE ////
        if (tycoonPurchased == true)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 7;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(worldPos, Vector3.up, out hit))
            {
                Vector3 finalPos = new Vector3(Mathf.Round(hit.point.x), Mathf.Round(hit.point.y), Mathf.Round(hit.point.z)); // IS THIS NEEDED?
                //currentObject = Instantiate(prefabBuilds[num], finalPos + new Vector3(0f, 0.2f, 0f), Quaternion.identity);
                currentObject = Instantiate(prefabBuilds[num], finalPos + new Vector3(0f, yValue, 0f), Quaternion.identity);
                offset = hit.point - currentObject.transform.position;
                isDragging = true;
            }
        }
    //// END OF TEST ////
    }


    public void MoveBuilding()
    {
        // ADD: prevent building from being lifted off the ground. Snap on plane.
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane; /// TEST
        mousePos.z = 7; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        RaycastHit hit;

        //if (Physics.Raycast(ray, out hit, 10f)) //, layerMask))
        if (Physics.Raycast(worldPos, Vector3.up, out hit, layerMask))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground") && hit.collider.gameObject.layer != LayerMask.NameToLayer("Wall")) // WORKS!!!!
            {

                // ADD: prevent building from being placed inside walls or other machines!
                Vector3 finalPos = new Vector3(Mathf.Round(hit.point.x), Mathf.Round(hit.point.y), Mathf.Round(hit.point.z)); /// TEST

                currentObject.transform.position = hit.point - offset;
               // currentObject.transform.position = hit.point + new Vector3(0f, 0.2f, 0f) - offset;
                

                // If click "r" allow rotating of buildings
                if (Input.GetKeyDown(KeyCode.R)) // Does not work for dropper
                {
                    currentObject.transform.Rotate(Vector3.up * 45);
                    // currentObject.transform.Rotate(xRot, yRot + 45f, zRot); // rotate y axis by 45 degrees each time your press r.
                }

                // ADD: Machine can not generate money till it is placed!
                // if (isDragging)
                    // Prevent spawning of money



                if (Input.GetMouseButtonDown(0))
                {
                    isDragging = false;
                    tycoonPurchased = false;

                }
        
            }
        }
        /*
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = false;
            tycoonPurchased = false;
        }
        */
    }




}
