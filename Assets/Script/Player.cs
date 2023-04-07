using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpPower = 5;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            gm = GameObject.FindWithTag("GAMEMANAGER").GetComponent<GameManager>();
        }
        catch
        {
            Debug.LogError("Cannot Found GameManager Object");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
        }

        if (this.transform.position.y < -7)
            GameManager.resetGame();

        
    }
}
