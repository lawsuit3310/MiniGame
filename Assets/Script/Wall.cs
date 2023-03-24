using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Wall : MonoBehaviour
{   // Update is called once per frame
    public float spd;
    new Rigidbody rigidbody;

    private void Awake()
    {
        try
        {
            this.rigidbody = GetComponent<Rigidbody>();
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
    private void Start()
    {
        MoveWall();
    }
    void Update()
    {
        if (this.transform.position.x < -15)
        {
            this.transform.position = new Vector3(5, 1, -10);
        }
    }

    private async void MoveWall()
    {
        while (true)
        {
            rigidbody.velocity = Vector3.left * spd;
            await Task.Delay(1000);
        }
    }
}
