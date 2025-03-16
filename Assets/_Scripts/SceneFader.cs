using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage;           // Fullscreen UI Image (black or any color)
    public float fadeDuration = 1f;   // Duration of fade in seconds

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(int sceneName)
    {
        Time.timeScale = 1f;
        StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeIn()
    {
        float t = fadeDuration;
        Color color = fadeImage.color;
        color.a = 1f;
        fadeImage.color = color;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            color.a = Mathf.Clamp01(t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }
    }

    IEnumerator FadeOut(int sceneName)
    {
        float t = 0f;
        Color color = fadeImage.color;
        color.a = 0f;
        fadeImage.color = color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Clamp01(t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}
