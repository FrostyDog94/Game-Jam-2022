using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private ThirdPersonMovement playerMovement;


    private void Awake()
    {
        playerMovement = GetComponent<ThirdPersonMovement>();
    }

    public void OnMove(CallbackContext context)
    {
        if (playerMovement != null)
            playerMovement.SetMoveVector(context.ReadValue<Vector2>());
    }

}
