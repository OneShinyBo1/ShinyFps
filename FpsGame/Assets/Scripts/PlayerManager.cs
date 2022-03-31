using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;
    public float health;
    public float maxHealth;
    public MeshRenderer model;
    public MeshRenderer gunModel;
    public MeshRenderer vizorModel;

    // Interpolation
    [SerializeField] private Transform startTransform;
    [SerializeField] private Transform endTransform;
    [SerializeField]

    private Vector3 fromPos = Vector3.zero;
    private Vector3 toPos = Vector3.zero;
    private float lastTime;

    public float Smoothing = 33.3f;
    

    public void Initialize(int _id, string _username)
    {
        id = _id;
        username = _username;
        health = maxHealth;
    }

   public void SetPosition(Vector3 position)
   {
        fromPos = toPos;
        toPos = position;
        lastTime = Time.time;
   }

    private void Update()
    {
        this.transform.position = Vector3.Lerp(fromPos, toPos, (Time.time - lastTime) / (1.0f / Smoothing));
    }

    public void SetHealth(float _health)
    {
        health = _health;

        if (health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        vizorModel.enabled = false;
        gunModel.enabled = false;
        model.enabled = false;
    }

    public void Respawn()
    {
        vizorModel.enabled = true;
        gunModel.enabled = true;
        model.enabled = true;
        SetHealth(maxHealth);
    }
}
 