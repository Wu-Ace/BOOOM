using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlackFade : MonoBehaviour
{
    public float fadeDuration = 2.0f; // 渐变持续时间（秒）
    private Image fadeImage;
    private Color initialColor;

    private void Start()
    {
        fadeImage = GetComponent<Image>();
        initialColor = fadeImage.color;

        // 开始渐变，从不透明到透明
        StartCoroutine(FadeToClear());
    }
    
    private IEnumerator FadeToClear()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;

            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            fadeImage.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);

            yield return null;
        }

        // 渐变结束后，禁用黑色覆盖层
        gameObject.SetActive(false);
    }
}