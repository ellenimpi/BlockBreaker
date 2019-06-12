
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField] int currentScore = 0;
    [SerializeField] int pointsPerHit = 50;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlay = false;


    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerHit;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool isAutoPlayEnabled()
    {
        return isAutoPlay;
    }

   

}
