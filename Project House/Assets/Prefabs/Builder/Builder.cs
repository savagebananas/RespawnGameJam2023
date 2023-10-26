using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    private GameState gameState;
    [SerializeField] Rigidbody2D rb;
    [SerializeField]Animator anim;
    private SpriteRenderer sprite;
    public float freezeTime = 3f;

    Vector3 lastPos;
    private float angle;
    private float timer = 0.5f;

    public GameObject bloodParticles;
    public GameObject bloodCloud;

    public bool isFixing = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = transform.GetChild(0).GetComponent<Animator> ();
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        
        anim.SetBool("up", false);
        anim.SetBool("down", false);
        anim.SetBool("side", false);
        anim.SetBool("idle", false);
        anim.SetBool("fix", false);

        gameState = GameObject.Find("General").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFixing)
        {
            var x = transform.position.x - lastPos.x;
            var y = transform.position.y - lastPos.y;
            angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

            //Up
            if (angle >= 45 && angle <= 135)
            {
                anim.SetBool("up", true);
                anim.SetBool("down", false);
                anim.SetBool("side", false);
                anim.SetBool("idle", false);
            }
            //Down
            if (angle >= -135 && angle <= -45)
            {
                anim.SetBool("up", false);
                anim.SetBool("down", true);
                anim.SetBool("side", true);
                anim.SetBool("idle", false);
            }

            //Left
            if (angle >= 135 && angle <= 180 || angle > -180 && angle <= -135)
            {
                anim.SetBool("up", false);
                anim.SetBool("down", false);
                anim.SetBool("side", true);
                anim.SetBool("idle", false);
                sprite.flipX = true;
            }
            //Right
            if (angle <= 45 && angle >= 0 || angle <= 0 && angle >= -45)
            {
                anim.SetBool("up", false);
                anim.SetBool("down", false);
                anim.SetBool("side", true);
                anim.SetBool("idle", false);
                sprite.flipX = false;
            }

            //StartCoroutine(setlastPos());
            if (timer <= 0)
            {
                lastPos = transform.position;
                timer = 0.5f;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        else if (isFixing)
        {
            anim.SetBool("fix", true);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            anim.SetBool("side", false);
            anim.SetBool("idle", false);
        }

    }

    private void resetAnimatorBools()
    {
        anim.SetBool("side", false);
        anim.SetBool("up", false);
        anim.SetBool("down", false);
        anim.SetBool("idle", false);
    }

    public void Stun()
    {
        this.FreezePosition();
    }

    IEnumerator FreezePosition()
    {
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(freezeTime);
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }

    public void Die()
    {
        //Show death animation
        GameObject p = Instantiate(bloodParticles);
        p.transform.position = this.transform.position;
        GameObject c = Instantiate(bloodCloud);
        c.transform.position = this.transform.position;
        //play some sound
        //change scene to death screen
        gameState.LoseGame();

        FindObjectOfType<AudioManager>().Play("PlayerDeath");

        Destroy(this.gameObject);
    }

}
