using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform camTransform;

    public float fireRate = 0.5f;

    public bool canFire = true;

    public ParticleSystem muzzleFlash;

    public AudioSource vineBoom;


    private void Start()
    {
        vineBoom = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&&canFire==true)
        { 
            muzzleFlash.Play();
            vineBoom.Play();
            canFire = false;
            ClientSend.PlayerShoot(camTransform.forward);
            StartCoroutine("Reset");
        }

    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

    private void FixedUpdate()
    {
        SendInputToServer();
    }

    // Sends player input to the server
    private void SendInputToServer()
    {
        bool[] _inputs = new bool[]
        {
            Input.GetKey(KeyCode.W),
            Input.GetKey(KeyCode.S),
            Input.GetKey(KeyCode.A),
            Input.GetKey(KeyCode.D),
            Input.GetKey(KeyCode.Space)
        };

        ClientSend.PlayerMovement(_inputs);
    }
}