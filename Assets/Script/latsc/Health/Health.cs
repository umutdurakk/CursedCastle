using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOffFlashes;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage,0,startingHealth) ;
        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
                anim.SetBool("grounded", true);
                anim.SetTrigger("die");


                //Oyuncu
                if (GetComponent<PlayerMovement>() != null)
                GetComponent<PlayerMovement>().enabled = false;

                //Düþman
                if (GetComponentInParent<EnemyPatrol>() !=null)
                    GetComponentInParent<EnemyPatrol>().enabled = false;


                if (GetComponentInParent<meleeEnemy>() != null)
                {
                    GetComponentInParent<meleeEnemy>().enabled = false;
                }

                dead = true;
            }
           
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
        
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOffFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration/(numberOffFlashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOffFlashes * 2));
        }

        Physics2D.IgnoreLayerCollision(10, 11, false);

    }

}
