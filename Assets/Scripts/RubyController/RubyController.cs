using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RubyController : MonoBehaviour
{
    public float speed = 3.0f;

    public float maxHealth = 5;
    public float timeInvincible = 2.0f;
    public GameObject projectilePrefab, frog;
    public Image imagen, healtImagen;

    public AudioClip throwSound;
    public AudioClip hitSound;
    AudioSource audioSource;

    public bool second;
    public float health { get { return currentHealth; } }
    float currentHealth;

    public ParticleSystem healt, damage;

    Rigidbody2D rigidbody2d;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    private int robotCount;
    public TMP_Text robots, loser, win, projectile;

    private int Projectilenum =4;
    private bool startGame = true;
    public bool frogbool = true;

    public AudioControllerManager audioController;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        projectile.text = Projectilenum.ToString();
        if (startGame)
        {
            imagen.fillAmount = currentHealth / 10;
            healtImagen.fillAmount = currentHealth / 10;

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 move = new Vector2(horizontal, vertical);

            if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();
            }

            animator.SetFloat("Look X", lookDirection.x);
            animator.SetFloat("Look Y", lookDirection.y);
            animator.SetFloat("Speed", move.magnitude);

            Vector2 position = rigidbody2d.position;

            position = position + move * speed * Time.deltaTime;

            rigidbody2d.MovePosition(position);


            if (Input.GetKeyDown(KeyCode.C))
            {
                if (Projectilenum > 0)
                {
                    Launch();
                    Projectilenum--;
                }
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
                if (hit.collider != null)
                {
                    NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                    if (character != null)
                    {
                        character.DisplayDialog();
                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    public void PorjectileSave()
    {
        Projectilenum = Projectilenum + 4;
    }

    public void ChangeHealth(int amount)
    {
        float temp = currentHealth;
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        if (temp > currentHealth)
        {
            damage.gameObject.SetActive(true);
            PlaySound(hitSound);
        }
        else
        {
            healt.gameObject.SetActive(true);
        }
        if (currentHealth == 0)
        {
            startGame = false;
            loser.gameObject.SetActive(true);
            audioController.Loser();
        }
        Invoke("SpritesSize", 1);
    }

    private void SpritesSize()
    {
        healt.gameObject.SetActive(false);
        damage.gameObject.SetActive(false);
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);
        animator.SetTrigger("Launch");
        PlaySound(throwSound);

    }

    public void EnemysCount()
    {
        robotCount++;
        robots.text = $"Robots Fixed: {robotCount}/4";
        if (robotCount == 4)
        {
            if (second)
            {
                startGame = false;
                win.gameObject.SetActive(true);
            }
            else
            {
                frogbool = false;
                frog.GetComponent<SpriteRenderer>().enabled = true;
            }

        }
    }
}