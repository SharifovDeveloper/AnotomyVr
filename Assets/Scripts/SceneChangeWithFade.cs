using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChangeWithFade : MonoBehaviour
{
    // Flag to track whether the code has already run
    private static bool hasRun = false;

    public string targetSceneName = "Scene2";
    public float delayBeforeSceneChange = 86.0f;
    public float fadeDuration = 1.0f;
    public AnimationCurve fadeCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

    private Image fadePanel;

    void Start()
    {
        // Check if the code has already run
        if (!hasRun)
        {
            // Create a UI panel for fading
            fadePanel = CreateFadePanel();

            // Start the coroutine to change scene with fade after a delay
            StartCoroutine(ChangeSceneWithFade());

            // Set the flag to true to indicate that the code has run
            hasRun = true;
        }
    }

    IEnumerator ChangeSceneWithFade()
    {
        // Wait for the specified delay before starting the fade
        yield return new WaitForSeconds(delayBeforeSceneChange);

        // Fade in
        yield return StartCoroutine(Fade(0f, 1f, fadeDuration));

        // Change scene
        SceneManager.LoadScene(targetSceneName);

        // Destroy the fade panel after a short delay
        yield return new WaitForSeconds(1.0f);
        Destroy(fadePanel.gameObject);
    }

    IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, fadeCurve.Evaluate(elapsedTime / duration));
            fadePanel.color = new Color(0, 0, 0, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadePanel.color = new Color(0, 0, 0, endAlpha);
    }

    Image CreateFadePanel()
    {
        // Create a UI canvas
        GameObject canvasGO = new GameObject("FadeCanvas");
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 999;

        // Create a UI panel
        GameObject panelGO = new GameObject("FadePanel");
        panelGO.transform.SetParent(canvasGO.transform, false);
        RectTransform rectTransform = panelGO.AddComponent<RectTransform>();
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.sizeDelta = Vector2.zero;

        // Add an Image component to the panel
        Image image = panelGO.AddComponent<Image>();
        image.color = new Color(0, 0, 0, 0); // Set initial alpha to 0

        return image;
    }
}
