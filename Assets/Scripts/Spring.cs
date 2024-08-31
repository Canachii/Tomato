using UnityEngine;

public class Spring : Trap
{
    [Range(10f, 20f)] public float force = 10f;
    
    protected override void Activate(Collider2D other)
    {
        Audio.PlayOneShot(Resources.Load<AudioClip>("Audio/jump"));
        
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * rb.velocity.x;
        rb.AddForce(transform.up * force, ForceMode2D.Impulse);

        base.Activate(other);
    }
}