/**
 * Handles Coin Collection & scoring
 *
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 2022.3
 */

using UnityEngine;

public class Coin : MonoBehaviour
{

#region Parameters
    [SerializeField] private int coinValue = 10;
#endregion 

#region FixedUpdate

    void OnTriggerEnter2D(Collider2D collider)
    {
        ScoreManager.Instance?.AddPoints(coinValue);
        Destroy(gameObject);
    }

#endregion
}
