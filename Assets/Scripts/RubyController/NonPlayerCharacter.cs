using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    float timerDisplay;

    public GameObject ruby;
    void Start()
    {
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
    }

    void Update()
    {
        if (ruby.GetComponent<RubyController>().frogbool) {
            transform.position = new Vector3(ruby.transform.position.x + 3, ruby.transform.position.y, ruby.transform.position.z);
        }
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }

    public void DisplayDialog()
    {
        transform.GetComponent<AudioSource>().Play();
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
        Invoke("Launcher",2);
    }

    public void Launcher() {
        SceneManager.LoadScene("SampleScene 2");
    }
}