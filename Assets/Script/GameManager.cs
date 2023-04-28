using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Wall;
    public Transform trs;
    public static int score { get; set; } = 0;
    private void Awake()
    {
        StartCoroutine("CreateWall");
        trs = Wall.transform;
        score = 0;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"Score : {score}");
    }

    IEnumerator CreateWall()
    {
        while (true)
        {
            if (Wall == null)
            {
                Debug.LogError("Wall Object had not found");
                yield break;
            }
            Instantiate(Wall);
            yield return new WaitForSeconds(2.5f);
        }
    }

    public static void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
