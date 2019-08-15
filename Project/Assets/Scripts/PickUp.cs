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
                    targetObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
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

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            targetObj = other.gameObject;
            GameObject middleDot = GameObject.Find("MiddleDot");
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            targetObj = null;
            GameObject middleDot = GameObject.Find("MiddleDot");
            middleDot.GetComponent<RectTransform>().sizeDelta = new Vector2(normalWidth, normalHeight);
        }
    }
}
