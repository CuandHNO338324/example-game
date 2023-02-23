using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Image fadeImage;

    private Blade blade;
    private Spawner spawner;

    private int score ;

    private void Awake()
    {
        blade = FindObjectOfType<Blade>();
        spawner = FindObjectOfType<Spawner>();
    }
    private void NewGame()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
    public void IncreaseScore(int amount)
    {
        score+=amount;
        scoreText.text = score.ToString();
    }


    public void Explode()
    {
        blade.enabled = false;
        spawner.enabled = false;
    }

    private IEnumerator ExplodeSequence()
    {
        float elapsed = 0f;
        float duration = 0.5f;

        while (elapsed<duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.white,t);

            Time.timeScale = 1-t;
            elapsed += Time.deltaTime;

            yield return null;
        }
    }
}
