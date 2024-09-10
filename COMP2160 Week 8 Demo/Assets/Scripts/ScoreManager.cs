/**
 * Score manager singleton
 *
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 2022.3
 */

using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

#region Parameters
    [SerializeField] private string scoreFormat = "The possessions of the workers: {0}?";
#endregion 

#region Connect Objects
    [SerializeField] private TextMeshProUGUI scoreText;
#endregion 

#region Singleton
    static private ScoreManager instance;

    static public ScoreManager Instance {
        get { return instance; }
    }
#endregion

#region State
    private int score = 0;
#endregion

#region Events
#endregion

#region Init & Destroy
    void Awake()
    {
        if (instance != null) 
        {
            Debug.LogError("There are multiple instances of the ScoreManger in the scene");
        }

        instance = this;

        UpdateScoreText();
    }
#endregion Init

#region Public Interface
    public void AddPoints(int points) 
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = string.Format(scoreFormat, score);
    }

#endregion 

}
