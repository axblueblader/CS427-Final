using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;

    private float moveSpeed;
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float vertInput = Input.GetAxis(verticalInputName) * moveSpeed;
        float horizInput = Input.GetAxis(horizontalInputName) * moveSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        characterController.simpleMove(forwardMovement + rightMovement);
    }
}
