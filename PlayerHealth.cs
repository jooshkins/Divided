using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public float health = 100f;					// The player's health.
	public float repeatDamagePeriod = 2f;		// How frequently the player can be damaged.
	public float damageAmount = 10f;			// The amount of damage to take when enemies touch the player
	private float lastHitTime;                  // The time at which the player was last hit.
    public AnimationClip animDie;
    private Animator m_Anim;

    	void Awake ()
    {
        m_Anim = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // If the colliding gameobject is an Enemy...
        if (other.gameObject.tag == "Enemy")
        {
            // ... and if the player still has health...
            if (health > 0f)
            {
            // ... take damage and reset the lastHitTime.
                TakeDamage(other.transform);
                lastHitTime = Time.time;
            }
            // If the player doesn't have health, destroy player 
            if (health <= 0f)
            {
                health = 0f;
                Dead();
            }
        }
    }

    void TakeDamage (Transform enemy)
	{
		health -= damageAmount;
	}

    void Dead()
    {
        m_Anim.SetBool("dead", true);
        Destroy(gameObject,1);
    }
}
