using System;
using UnityEngine;

public class Bomb : Trap
{
    [Range(10f, 20f)] public float force = 10f;
    [Range(3f, 5f)] public float radius = 3f;

    private static readonly int Use = Animator.StringToHash("Use");
    private readonly Collider2D[] _targets = new Collider2D[10];

    protected override void Activate(Collider2D other)
    {
        if (IsTriggered) return;

        Audio.PlayOneShot(Resources.Load<AudioClip>("Audio/explosion"));
        Anim.SetBool(Use, true);

        int n = Physics2D.OverlapCircleNonAlloc(transform.position, radius, _targets, TomatoLayer);

        for (var i = 0; i < n; i++)
        {
            Rigidbody2D target = _targets[i].GetComponent<Rigidbody2D>();
            target.velocity = Vector2.zero;

            Vector2 pos = target.transform.position - transform.position;
            target.AddForce(pos.normalized * force, ForceMode2D.Impulse);
        }

        base.Activate(other);
    }

    public void Disable()
    {
        Anim.SetBool(Use, false);
        gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}