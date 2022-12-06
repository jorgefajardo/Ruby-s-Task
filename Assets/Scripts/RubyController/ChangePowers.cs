using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangePowers : MonoBehaviour
{
    [SerializeField]
    private Sprite fireball;

    [SerializeField]
    private List<Image> imagens;

    [SerializeField]
    private List<SpriteRenderer> sprites;
    public GameObject dialogBox;

    public Animator animator;

    public TMP_Text text;
    private bool first;

    public void RunVelocity()
    {
        if (first)
        {
            text.text = "Use space to run fast";
            first = false;
            transform.GetComponent<AudioSource>().Play();
            dialogBox.SetActive(true);
        }
    }
    public void ChangeFireball()
    {
        if (!first)
        {
            first = true;
            transform.GetComponent<AudioSource>().Play();
            dialogBox.SetActive(true);

            animator.SetBool("New Bool", true);
            foreach (Image s in imagens)
            {
                s.sprite = fireball;
            }
            foreach (SpriteRenderer s in sprites)
            {
                if (s != null)
                    s.sprite = fireball;
            }
        }
    }
}
