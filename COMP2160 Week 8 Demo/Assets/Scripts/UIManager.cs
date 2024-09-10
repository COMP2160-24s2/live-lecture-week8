/**
 * Handle the scoring UI
 *
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 2022.3
 */

using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

#region Parameters
    [SerializeField] private string scoreFormat = "The possessions of the workers: {0}?";
#endregion 

#region Connect Objects
    [SerializeField] private TextMeshProUGUI scoreText;
#endregion 

#region State
#endregion

#region Init & Destroy
    void OnEnable()
    {
        Debug.Log("UIManager.OnEnable");
        // run at OnEnable to ensure the instance is already set
        ScoreManager.Instance.UpdateScoreEvent += UpdateScore;
    }

    void OnDisable()
    {
        ScoreManager.Instance.UpdateScoreEvent -= UpdateScore;
    }
#endregion Init

#region Event handlers
    void UpdateScore(int oldScore, int newScore)
    {
        scoreText.text = string.Format(scoreFormat, newScore);
    }
#endregion Update
}
