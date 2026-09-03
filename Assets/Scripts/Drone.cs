using UnityEngine;
using System.Collections;
public class Drone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public GameHandler gameHandler;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip siren;
    public AudioClip crime;
    public AudioClip warnGrass;
    public AudioClip combat;
    public AudioClip execution;
    public AudioClip minigun;


    public Transform[] muzzles;
    public GameObject muzzleFlash;
    public void DroneIdle()
    {
        animator.Play("DroneHover");
        StartCoroutine(WarningOne());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator WarningOne()
    {
        audioSource.PlayOneShot(siren, 0.8f);
        yield return new WaitForSeconds(4f);
        audioSource.PlayOneShot(crime);
        yield return new WaitForSeconds(crime.length);
        audioSource.PlayOneShot(warnGrass);
        yield return new WaitForSeconds(warnGrass.length);
        gameHandler.droneActive = true;
    }


    public IEnumerator Execute()
    {
        audioSource.PlayOneShot(combat);
        yield return new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(execution);
        yield return new WaitForSeconds(1f);
        audioSource.PlayOneShot(minigun, 0.8f);
        yield return new WaitForSeconds(1.9f);
        gameHandler.PlayerDies();
        for (int i = 0; i < 30; i++)
        {
            FireGuns();
            yield return new WaitForSeconds(0.1f);
        }
    }


    public void ExecutionInProgress()
    {
        StartCoroutine(Execute());
    }

    void FireGuns()
    {
        Debug.Log("FIRING ONCE");
        foreach (Transform muzzle in muzzles)
        {
            GameObject flash = Instantiate(
                muzzleFlash,
                muzzle.position,
                muzzle.rotation * Quaternion.Euler(0, 180, 0)
            );

            Destroy(flash, 0.05f);
        }
    }
}
