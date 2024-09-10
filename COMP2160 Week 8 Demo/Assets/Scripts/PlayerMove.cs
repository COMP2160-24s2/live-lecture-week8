/**
 *
 *
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 2022.3
 */

using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMove : MonoBehaviour
{

#region Parameters
    [SerializeField] private float speed = 5;
    [SerializeField] private int coinValue = 10;
    [SerializeField] private string scoreFormat = "Money: {0}?";
#endregion 

#region Connect Objects
    [SerializeField] private TextMeshProUGUI scoreText;
#endregion 

#region Tags
    private const string COIN_TAG = "Coin";
#endregion

#region Components
#endregion

#region State
    private int score = 0;
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

#region FixedUpdate
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag(COIN_TAG))
        {
            score += coinValue;
            scoreText.text = string.Format(scoreFormat, score);
            Destroy(collider.gameObject);
        }
    }
#endregion FixedUpdate

}
