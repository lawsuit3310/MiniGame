using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Wall;
    public Transform trs;
    private void Awake()
    {
        CreateWall();
        trs = Wall.transform;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Main");
    }

    async void CreateWall()
    {
        while (true)
        {
            if (Wall == null)
            {
                Debug.LogError("Wall Object had not found");
                return;
            }
            await Task.Delay(1000);
        }
    }
}
