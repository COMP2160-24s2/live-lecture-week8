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
    [SerializeField] private int scoreStep = 5;
    [SerializeField] private float scoreStepTime = 0.1f;    // seconds
#endregion 

#region State
    private int displayScore = 0;
    private int targetScore = 0;
    private float timer = 0;
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

    void Start()
    {
        scoreText.text = string.Format(scoreFormat, displayScore);
    }
#endregion Init

#region Update
    void Update()
    {
        // make the time roll up to the target
        if (targetScore > displayScore)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                displayScore += scoreStep;
                if (displayScore > targetScore)
                {
                    displayScore = targetScore;
                }
                scoreText.text = string.Format(scoreFormat, displayScore);
                timer += scoreStepTime;
            }
        }
    }

#endregion

#region Event handlers
    void UpdateScore(int oldScore, int newScore)
    {
        targetScore = newScore;
        timer = 0;
    }
#endregion Update
}
