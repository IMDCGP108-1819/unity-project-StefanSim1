using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float health = 500;
    public float maxThrust;
    public float maxTorque;
    public Rigidbody2D rb;
    [SerializeField] GameObject VFX;
    [SerializeField] float explosionDuration;
    [SerializeField] AudioClip SFX;
    [SerializeField] [Range(0,1)] float VFXVolume = 0.5f;
    void Start()
    {
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        rb.AddForce(thrust);
        rb.AddTorque(torque);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        HitProcess(damageDealer);
    }

    private void HitProcess(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(VFX, transform.position, transform.rotation);
        Destroy(explosion, explosionDuration);
        AudioSource.PlayClipAtPoint(SFX, Camera.main.transform.position, VFXVolume);
    }
}
    
