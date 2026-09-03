using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonClick : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public BallPrefab ballprefab;
    public GameHandler gameHandler;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Touchscreen.current.press.wasPressedThisFrame)
        {
            gameHandler.ButtonPressed();

            //BallPrefab ball = Instantiate<BallPrefab>(ballprefab);
            //ball.transform.localPosition = transform.localPosition;
            //ball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * UnityEngine.Random.Range(500, 750)); 
        }
    }
}
