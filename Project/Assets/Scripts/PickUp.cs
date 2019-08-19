using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PickUp : MonoBehaviour
{
    [SerializeField] private Transform pickUpDest;

    [SerializeField] private KeyCode pickUpKey;

    [SerializeField] private float canPickUpHeight;
    [SerializeField] private float canPickUpWidth;
    [SerializeField] private float normalHeight;
    [SerializeField] private float normalWidth;

    [SerializeField] private float minHandDistance = 1.3f;
    private bool handBusy;

    private GameObject pickedUpObj;

    private GameObject targetObj;
    private void Start()
    {
        handBusy = false;
        GameObject middleDot = GameObject.Find("MiddleDot");
        middleDot.GetComponent<RectTransform>().sizeDelta = new Vector2(normalWidth, normalHeight);
    }
    private void Update()
    {
        if (GameObject.Find("PlayerBody").GetComponent<PlayerStates>().isDead)
        {
            return;
        }
        RaycastHit hit;
        GameObject middleDot = GameObject.Find("MiddleDot");

        targetObj = null;
        middleDot.GetComponent<RectTransform>().sizeDelta = new Vector2(normalWidth, normalHeight);
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Collider other = hit.collider;

            // Debug.Log("Distance: " + Vector3.Distance(pickUpDest.position, other.transform.position));
            if (other && Vector3.Distance(pickUpDest.position, other.transform.position) <= minHandDistance)
            {
                if (other.gameObject.CompareTag("Collectable"))
                {
                    targetObj = other.gameObject;
                    if (!handBusy)
                    {
                        middleDot.GetComponent<RectTransform>().sizeDelta = new Vector2(canPickUpWidth, canPickUpHeight);
                    }
                    else
                    {
                        middleDot.GetComponent<RectTransform>().sizeDelta = new Vector2(normalWidth, normalHeight);
                    }

                }
            }
        }
        if (Input.GetKeyDown(pickUpKey))
        {
            if (!handBusy)
            {
                // Picking up logic
                if (targetObj != null)
                {
                    targetObj.GetComponent<Rigidbody>().useGravity = false;
                    // targetObj.GetComponent<Rigidbody>().freezeRotation = true;
                    // targetObj.GetComponent<Rigidbody>().freezePosition = true;
                    targetObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll
                            | RigidbodyConstraints.FreezePositionY;
                    targetObj.transform.position = pickUpDest.transform.position;
                    targetObj.transform.parent = pickUpDest.transform;
                    SwitcherObj switcherObjScript = targetObj.GetComponent<SwitcherObj>();
                    if (switcherObjScript != null)
                    {
                        switcherObjScript.isOn = true;
                    }
                    pickedUpObj = targetObj;
                    // Debug.Log("pickedUp && !handBusy: " + pickedUpObj.GetInstanceID());
                    handBusy = true;
                }
            }
            else
            {
                // Dropping down logic
                if (pickedUpObj != null)
                {
                    // Debug.Log("pickedUp && handBusy: " + pickedUpObj.GetInstanceID());
                    pickedUpObj.GetComponent<Rigidbody>().useGravity = true;
                    // pickedUpObj.GetComponent<Rigidbody>().freezeRotation = false;
                    // pickedUpObj.GetComponent<Rigidbody>().freezePosition = false;
                    pickedUpObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    SwitcherObj switcherObjScript = pickedUpObj.GetComponent<SwitcherObj>();
                    if (switcherObjScript != null)
                    {
                        switcherObjScript.isOn = false;
                    }
                    pickedUpObj.transform.parent = null;
                    handBusy = false;
                    pickedUpObj = null;
                }
            }
        }
        if (handBusy && pickedUpObj != null)
        {
            // Vector3 distance = pickUpDest.transform.position - pickedUpObj.transform.position;
            // Transform parent = pickUpDest.transform.parent;
            // Debug.Log("Distance: " + Vector3.Distance(distance, Vector3.zero));
            // pickedUpObj.transform.position = Vector3.Lerp(
            //     pickedUpObj.transform.position,
            //     pickUpDest.transform.position,
            //     Time.deltaTime * smooth);
        }
    }
}
