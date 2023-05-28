using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    public static RecoilSystem Instance { get; private set; } // Singleton instance

    public GameObject Gun; // Reference to the Gun game object
    private Gun gun; // Reference to the Gun script attached to the same game object
    private PlayerManager playerManager; // Reference to the PlayerManager script

    Animator animator; // Reference to the Animator component attached to the same game object

    // Start is called before the first frame update
    void Start()
    {
        Instance = this; // Set the singleton instance to this object
        animator = GetComponent<Animator>(); // Get the Animator component attached to the game object
        gun = Gun.GetComponent<Gun>(); // Get the Gun script attached to the Gun game object
        playerManager = GetComponent<PlayerManager>(); // Get the PlayerManager script attached to the game object

        playerManager.OnBulletCountChanged += UpdateAnimator; // Subscribe to bullet count change event
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && gun.isAuto && playerManager.bullet > 0)
        {
            animator.SetBool("AutoFire", true); // Set the "AutoFire" parameter of the Animator to true
        }

        if (playerManager.bullet <= 0)
        {
            animator.SetBool("AutoFire", false); // Set the "AutoFire" parameter of the Animator to false
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            animator.SetBool("AutoFire", false); // Set the "AutoFire" parameter of the Animator to false
        }

        if (Input.GetMouseButtonDown(0) && !gun.isAuto)
        {
            StartCoroutine(StartRecoil()); // Start the coroutine for recoil effect
        }
    }

    IEnumerator StartRecoil()
    {
        if (playerManager.bullet != 0)
        {
            Gun.GetComponent<Animator>().Play("RecoilAnimation"); // Play the "RecoilAnimation" state in the Animator
            yield return new WaitForSeconds(0.10f); // Wait for 0.10 seconds
            Gun.GetComponent<Animator>().Play("New State"); // Play the "New State" state in the Animator
        }
    }

    private void UpdateAnimator()
    {
        if (playerManager.bullet <= 0)
        {
            animator.SetBool("AutoFire", false); // Set the "AutoFire" parameter of the Animator to false
        }
    }
}
