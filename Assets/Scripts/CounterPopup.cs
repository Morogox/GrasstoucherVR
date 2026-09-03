using UnityEngine;
using TMPro;

public class CounterPopup : MonoBehaviour
{
    public TextMeshPro text;

    public float floatSpeed = 1f;
    public float lifetime = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;

        Color color = text.color;
        color.a -= Time.deltaTime / lifetime;
        text.color = color;

        if (color.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
