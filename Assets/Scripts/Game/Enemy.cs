using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public const string FreezeTag = "Player";

    [field: SerializeField]
    public Transform FleeFrom { get; set; }

    [SerializeField]
    private float speed;

    [SerializeField]
    private Rigidbody2D rigid;

    private void FixedUpdate()
    {
        if (rigid.bodyType != RigidbodyType2D.Static)
        {
            var dir = transform.position - FleeFrom.position;

            rigid.velocity = dir.normalized * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rigid.bodyType = RigidbodyType2D.Static;
        }
    }
}
