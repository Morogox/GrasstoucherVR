using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class DeathEffect : MonoBehaviour
{
    public Image redScreen;

    public DeathMessage message;

    public GameHandler handler;
    
    private void Start()
    {
 
    }
    public void StartDeath()
    {
        StartCoroutine(DeathSequence());
    }

    IEnumerator DeathSequence()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return StartCoroutine(FadeTo(0.4f, 0.05f));
            yield return StartCoroutine(FadeTo(0.1f, 0.05f));
        }
        yield return StartCoroutine(FadeTo(1f, 1f));

        yield return new WaitForSeconds(2f);
        message.revealMessage("You died! \n\n Grass touched: " + handler.pressCount);
    }

    IEnumerator FadeTo(float targetAlpha, float duration)
    {
        float startAlpha = redScreen.color.a;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            float alpha = Mathf.Lerp(
                startAlpha,
                targetAlpha,
                timer / duration
            );

            Color color = redScreen.color;
            color.a = alpha;
            redScreen.color = color;

            yield return null;
        }
    }
}
