using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Wall : MonoBehaviour
{   // Update is called once per frame
    public float spd;
    public int wallType;
    public int direction;
    new Rigidbody rigidbody;

    bool trigger = true;

    enum MoveType
    {
        _NORMAL = 0,
        _SWIPE
    }

    private void Awake()
    {
        wallType = UnityEngine.Random.Range(0,2);
        Debug.Log(wallType);

        try
        {
            this.rigidbody = GetComponent<Rigidbody>();
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }

        this.transform.position = new Vector3(
            this.transform.position.x,
            UnityEngine.Random.Range(-1f,2.5f),
            this.transform.position.z); ;
    }
    private void Start()
    {
        MoveWall();
    }
    void Update()
    {
        if (this.transform.position.x < -15)
        {
            Destroy(this.gameObject);
        }
        else if (this.transform.position.x < -5 && trigger)
        {
            trigger = false;
            GameManager.score += 1;
        }
    }

    private async void MoveWall()
    {
        while (true)
        {
            if (rigidbody == null) return;
            switch(wallType)
            {
                case (int)MoveType._NORMAL:
                    rigidbody.velocity = Vector3.left * spd * Time.deltaTime;
                    break;
                case (int)MoveType._SWIPE:
                    rigidbody.velocity = (Vector3.left + Vector3.up * direction) * spd * Time.deltaTime ;
                    break;
            }
            direction *= -1;
            await Task.Delay(1000);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PLAYER"))
            GameManager.resetGame();

    }
}
