using System.Collections;
using UnityEngine;

public class MoveByRigidbody : MonoBehaviour {

    public float speed;
    public Vector2 targetPosition;
    public float spawnWait;
    
    //anima stuff
    private Animator m_Anim;
    private Rigidbody2D m_Rigidbody2D;

    void Awake()
    {
        m_Anim = GetComponentInChildren<Animator>();
        m_Anim.SetFloat("speed", 0);
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        StartCoroutine("PlayAnim");
    }

    IEnumerator PlayAnim()
    {
        while (true)
        {
            //anima stuff
            m_Anim.SetFloat("speed", m_Rigidbody2D.velocity.magnitude * 500);
            print(m_Rigidbody2D.velocity.magnitude);
            yield return new WaitForSeconds(spawnWait);
            StartCoroutine("Move");
        }
    }

    IEnumerator Move()
    {
        while (true)
        {
            m_Rigidbody2D.AddRelativeForce(targetPosition * 5 * speed);
            m_Rigidbody2D.AddForce(targetPosition * 10 * speed);
            
            //anima stuff
            m_Anim.SetFloat("speed", m_Rigidbody2D.velocity.magnitude * 500);
            print(m_Rigidbody2D.velocity.magnitude);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}


