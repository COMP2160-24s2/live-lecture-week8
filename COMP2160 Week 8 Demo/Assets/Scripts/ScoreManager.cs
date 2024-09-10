/**
 * Score manager singleton
 *
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 2022.3
 */

using UnityEngine;

public class ScoreManager : MonoBehaviour
{

#region Singleton
    static private ScoreManager instance;

    static public ScoreManager Instance {
        get { 
            if (instance == null)
            {
                Debug.Log("There is no ScoreManager in the scene.");
            }
            return instance; 
        }
    }
#endregion

#region State
    private int score = 0;
#endregion

#region Events
    public delegate void UpdateScoreEventHandler(int oldScore, int newScore);
    public event UpdateScoreEventHandler UpdateScoreEvent;
#endregion

#region Init & Destroy
    void Awake()
    {
        Debug.Log("ScoreManager.Awake");
        if (instance != null) 
        {
            Debug.LogError("There are multiple instances of the ScoreManger in the scene");
        }

        instance = this;
    }

    void Start()
    {
        UpdateScoreEvent?.Invoke(score, score);
    }
#endregion Init

#region Public Interface
    public void AddPoints(int points) 
    {
        int oldScore = score;
        score += points;

        UpdateScoreEvent?.Invoke(oldScore, score);
    }
#endregion 

}
