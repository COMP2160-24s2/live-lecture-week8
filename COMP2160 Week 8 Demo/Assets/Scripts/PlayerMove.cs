/**
 * Handles player movement
 *
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 2022.3
 */

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

#region Parameters
    [SerializeField] private float speed = 5;
#endregion 

#region Actions
    private Actions actions;
    private InputAction moveAction;
#endregion

#region Init & Destroy
    void Awake()
    {
        actions = new Actions();
        moveAction = actions.movement.move;
    }

    void OnEnable() 
    {
        actions.movement.Enable();
    }

    void OnDisable() 
    {
        actions.movement.Disable();        
    }
#endregion Init

#region Update
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();

        transform.Translate(move * speed * Time.deltaTime);
    }
#endregion Update

}
