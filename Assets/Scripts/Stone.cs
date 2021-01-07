using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public float moveSpeed;

    Rigidbody2D m_rb;

    bool m_isGround;

    public bool IsGround { get => m_isGround; }

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (m_rb)
        {
            m_rb.velocity = Vector3.down * moveSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            m_isGround = true;

            Destroy(gameObject, 1f);

            GameManager.Ins.Score++;

            GameGUIManager.Ins.UpdateScoreCounting(GameManager.Ins.Score);
        }
    }


}
