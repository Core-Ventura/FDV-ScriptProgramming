using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    public float respawnDuration = 5f;
    public float spawnRadius = 30f;
    public float threshold = 0.75f;
    public float extraSpeed = 0f;
    public float extraJump = 0f;
    public Vector3 extraScale;
    private PlayerController player;
    private bool isSpawning = true;
    private bool isRespawning = false;
    private SpriteRenderer sprite;
    private Animator animator;
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        sprite = this.GetComponent<SpriteRenderer>();
        animator = this.GetComponent<Animator>();
        SetRandomPosition();
    }

    void Update()
    {   
        // Begin the respawn timer...
        if(!isRespawning){
            StartCoroutine(RespawnTimer());
        }

        // We check if the buff is spawning, or waiting for the player to get it.
        if(isSpawning)
        {
            StartCoroutine(Spawn());
        } else {

            if( player.transform.position.x <= transform.position.x + threshold &&
                player.transform.position.x > transform.position.x - threshold &&
                player.transform.position.z <= transform.position.z + threshold &&
                player.transform.position.z > transform.position.z - threshold &&
                animator.GetBool("isUsed") == false){
                Debug.Log("Buff Activated!");

                // Depending on the buff, the player will receive (if not maxed) one of the following benefits.
                if(player.speed < player.maxSpeed)
                {
                    player.speed += extraSpeed;
                }
                if(player.jumpForce < player.maxJumpForce)
                {
                    player.jumpForce += extraJump;
                }
                if(player.transform.localScale.x < player.maxScale)
                {
                    player.transform.localScale = player.transform.localScale + extraScale;
                }
                animator.SetBool("isUsed", true);
            }
        }

    }

    public IEnumerator Spawn()
    {
        animator.SetBool("isSpawning", true);
        // We wait for the animation to finish...
        yield return new WaitForSeconds(2f); 
        animator.SetBool("isSpawning", false);
        isSpawning = false;
    }

    public IEnumerator RespawnTimer()
    {
        isRespawning = true;
        // To spice things up we multiply the respawn duration for a random numnber
        yield return new WaitForSeconds(respawnDuration * Random.Range(0.8f, 1.25f));
        animator.SetBool("isDespawning", true);
        // We wait for the animation to finish...
        yield return new WaitForSeconds(2f);
        animator.SetBool("isDespawning", false);
        SetRandomPosition();
        isSpawning = true;
        animator.SetBool("isSpawning", true);
        animator.SetBool("isUsed", false);
        isRespawning = false;
    }

    public void SetRandomPosition()
    {
        Vector3 newPos = Random.insideUnitCircle * spawnRadius;
        // We set the Y coordinate a little highter than the ground level (2.50f)
        transform.localPosition = new Vector3(newPos.x, 2.51f, newPos.y);
    }
}
