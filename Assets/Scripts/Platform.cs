using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10f;
    public string soundName = "platform";
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            FindObjectOfType<AudioManager>().Play(soundName);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce);
        }
    }
}
