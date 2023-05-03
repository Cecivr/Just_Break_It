using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerUps : MonoBehaviour
{
    public List<GameObject> AllBlocks = new List<GameObject>();
    public List<int> nums = new List<int>();
    GameObject[] red_block;
    GameObject[] blue_block;
    GameObject[] yellow_block;
    [HideInInspector]public int numRandom;
    public GameObject powerUp;
    [SerializeField] int HowManyPowerUps;
    Scene scene;
    private void Awake()
    {
        red_block = GameObject.FindGameObjectsWithTag("Double");
        blue_block = GameObject.FindGameObjectsWithTag("Normal");
        yellow_block = GameObject.FindGameObjectsWithTag("OneSide");
        scene = SceneManager.GetActiveScene();
    }
    void Start()
    {
        if(scene.name == "Level1")
        {
            foreach (GameObject block in red_block)
            {
                AllBlocks.Add(block);
            }
            for (int i = 0; i < HowManyPowerUps; i++)
            {
                numRandom = Random.Range(0, AllBlocks.Count);
                nums.Add(numRandom);
                //Debug.Log(AllBlocks[numRandom]);
                Debug.Log(AllBlocks[numRandom].GetComponent<Double>().isPoweredUp = true);         
            }
        }
        if(scene.name == "Level2")
        {
            foreach (GameObject block in blue_block)
            {
                AllBlocks.Add(block);
            }
            for (int i = 0; i < HowManyPowerUps; i++)
            {
                numRandom = Random.Range(0, AllBlocks.Count);
                nums.Add(numRandom);
                //Debug.Log(AllBlocks[numRandom]);
                Debug.Log(AllBlocks[numRandom].GetComponent<Destroy>().isPoweredUp = true);
            }
        }   
        if(scene.name == "Level3")
        {
            foreach (GameObject block in yellow_block)
            {
                AllBlocks.Add(block);
            }
            for (int i = 0; i < HowManyPowerUps; i++)
            {
                numRandom = Random.Range(0, AllBlocks.Count);
                nums.Add(numRandom);
                //Debug.Log(AllBlocks[numRandom]);
                Debug.Log(AllBlocks[numRandom].GetComponent<Destroy>().isPoweredUp = true);         
            }
        }   
    }
}
