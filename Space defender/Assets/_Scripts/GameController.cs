using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    private GameObject thePlayer;
    public Vector3 playerPositionValues;
    public Vector3 positionValues;
    public int enemyCount;
    public float startWait;
    public float shipDeploymentWait;
    public float attackWaveWait;
    //public int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        createThePlayer();
        StartCoroutine(createEnemy());
    }
    void Update()
    {
        //&& lives != 0
        if (thePlayer == null )
        {
          //  lives -= 1;
            createThePlayer();
            SumScore.SaveHighScore();
        }
        /*
        else
        {
            SumScore.SaveHighScore();
            Application.Quit();
        }
        */
    }

    IEnumerator createEnemy()
    {
        // the initial waiting  before relasing the enemy ships 
        // to give the player time to start and focus 
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 position = new Vector3(Random.Range(-positionValues.x, positionValues.x), positionValues.y, positionValues.z);
                Quaternion rotation = Quaternion.identity;
                Instantiate(enemy, position, rotation);
                // to wait after releasing each ship 
                //so that they do not collide with each other on the release
                yield return new WaitForSeconds(shipDeploymentWait);
            }

            // the amount of time wa wait between the attack waves 
            yield return new WaitForSeconds(attackWaveWait);
        }
    }

    void createThePlayer()
    {
        Vector3 playerPosition = new Vector3(Random.Range(-positionValues.x, positionValues.x), positionValues.y, 5);
        Quaternion rotation = Quaternion.identity;
        thePlayer = Instantiate(player, playerPosition, rotation) as GameObject;
    }
}

