using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameOver : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] Movement movement;
    Collectible collectible;
    private float totalTime;
    // Start is called before the first frame update
    void Start()
    {
        collectible = FindObjectOfType<Collectible>();
        GameEvents.PlayerDied.AddListener(PlayerJustDied);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerJustDied()
    {
        totalTime = Time.time;
        gameOverText.text = $"You survived {(totalTime >= 1 && totalTime < 2 ? Mathf.Floor(totalTime) + " second" : Mathf.Floor(totalTime) + " seconds")} and achieved {collectible.score} {(collectible.score == 1 ? "point." : "points.")}";
        gameOverUI.SetActive(true);
        movement.GameIsOver();
    }
}
