using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpPower = 5;
    public float acceleration = 5;
    public float _xLimit = 5;
    public GameManager gm;

    Rigidbody _rigid;

    // Start is called before the first frame update

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

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
            _rigid.velocity = new Vector3(0, jumpPower, 0);
        }

        if (this.transform.position.y < -7)
            GameManager.resetGame();

        _rigid.velocity += this.transform.position.x > _xLimit ?  Vector3.zero : Vector3.right * Time.deltaTime * acceleration;
    }
}
