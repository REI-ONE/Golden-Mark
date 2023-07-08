using System.Collections;
using UnityEngine;

public class ThrowableWeapon : MonoBehaviour
{
    public Vector2 direction;
    public bool hasHit = false;
    public float speed = 10f;
    public float _timeLife = 2f;

    private Rigidbody2D _rigidbody2D;

    public void Fire()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(Timer());
    }

    void FixedUpdate()
    {
        if (!hasHit)
            if (_rigidbody2D != null)
                _rigidbody2D.velocity = direction * speed;
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(_timeLife);
        if (gameObject != null)
            Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("ApplyDamage", Mathf.Sign(direction.x) * 2f);
            Destroy(gameObject);
        }

    }
}
