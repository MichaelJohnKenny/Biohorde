using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp = 10;
    public AudioClip humanScream;
    public AudioClip zombieDeathSound;
    public GameObject HumanZombiePreFab;
    private GameObject ZombieMovementTarget;
    private GameObject playerController;
    private GameObject playerCamera;
    private ScreenShake cameraShake;
    private AudioSource hitSound;

    private void Awake()
    {
        cameraShake = GameObject.FindObjectOfType<ScreenShake>() as ScreenShake;
        hitSound = GameObject.FindGameObjectWithTag("hitSound").GetComponent<AudioSource>();
    }

    void Start()
    {
        ZombieMovementTarget = GameObject.FindGameObjectWithTag("ZombieMovementTarget");
        playerController = GameObject.FindGameObjectWithTag("PlayerController");
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    

    public float Get()
    {
        return this.hp;
    }

    public void Heal(int amount)
    {
        Debug.Log(this.tag + " healed for " + amount);
        this.hp += amount;
    }

    public void Damage(int amount)
    {
        Debug.Log(this.tag + " hurt for " + amount);
        this.hp -= amount;
        cameraShake.Shake(.13f, 1f, true);
        hitSound.Play();


        if (this.hp <= 0f)
        {
            Debug.Log(this.name + " died");
            switch(this.tag)
            {
                case "Human":
                    Destroy(this.gameObject);
                    AudioSource.PlayClipAtPoint(humanScream, playerCamera.transform.position);
                    Instantiate(HumanZombiePreFab, this.transform.position, this.transform.rotation);
                    ZombieMovementTarget.GetComponent<ZombieMovementTargetMove>().UnlockTarget();
                    playerController.GetComponent<PlayerAbilities>().updatePlayerScore(150);
                    break;
                case "Zombie":
                    AudioSource.PlayClipAtPoint(zombieDeathSound, playerCamera.transform.position);
                    this.GetComponent<Zombie>().enabled = false;
                    this.GetComponent<ZombieAiMovement>().enabled = false;
                    this.GetComponent<CharacterAnim>().enabled = false;
                    playerController.GetComponent<PlayerAbilities>().updatePlayerScore(-10);
                    Destroy(this.gameObject);
                    break;
            }
        }
    }
}
