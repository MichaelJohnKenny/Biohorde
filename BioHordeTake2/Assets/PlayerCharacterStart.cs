using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacterStart : MonoBehaviour
{
    public GameObject uiIndicator;
    public GameObject uiControlIndicator;
    public GameObject uiTimeIndicator;
    public GameObject uiStartTime;
    public GameObject ZombiePreFab;
    private GameObject playerCamera;
    private bool isZombie = false;
    public AudioSource Alarm1;
    public AudioSource Alarm2;
    public AudioSource Screams;
    public AudioClip Exploison;
    public Text currentTimeText;
    private float currentTime = 30f;

    private void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        GameObject[] allHumans = GameObject.FindGameObjectsWithTag("Human");
        foreach (GameObject currentHuman in allHumans)
        {
            currentHuman.GetComponent<HumanAI>().enabled = false;
        }
    }

    void startScarySounds()
    {
        Alarm1.PlayDelayed(0.8f);
        Alarm2.PlayDelayed(1.5f);
        Screams.PlayDelayed(.2f);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        currentTimeText.text = currentTime.ToString("n2");

        if (Input.GetKeyDown("e") && !isZombie||currentTime<=0f)
        {
            uiIndicator.SetActive(false);
            uiTimeIndicator.SetActive(false);
            uiControlIndicator.SetActive(false);
            uiStartTime.SetActive(false);

            AudioSource.PlayClipAtPoint(Exploison, playerCamera.transform.position, 1.4f);

            Destroy(this.gameObject);
            Instantiate(ZombiePreFab, this.transform.position, this.transform.rotation);
            GameObject[] allHumans = GameObject.FindGameObjectsWithTag("Human");
            foreach (GameObject currentHuman in allHumans)
            {
                currentHuman.GetComponent<HumanAI>().enabled = true;
            }
            isZombie = true;
            startScarySounds();
        }
    }
}