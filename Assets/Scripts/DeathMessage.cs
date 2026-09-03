using TMPro;
using UnityEngine;

public class DeathMessage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TextMeshPro myTextObject;
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void revealMessage(string text)
    {
        this.gameObject.SetActive(true);
        myTextObject.text = text;
    }
}
