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


    private Vector3 fromPos = Vector3.zero;
    private Vector3 toPos = Vector3.zero;
    private float lastTime;

    public float Smoothing = 33.3f;
    

    // Player getting initialized
    public void Initialize(int _id, string _username)
    {
        id = _id;
        username = _username;
        health = maxHealth;
    }

    // Setting positions of what is going to be used for interpolation
   public void SetPosition(Vector3 position)
   {
        fromPos = toPos;
        toPos = position;
        lastTime = Time.time;
   }

    private void Update()
    {
        // Interpolation so that the player moves more smooth
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
 