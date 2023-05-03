using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBlocks : MonoBehaviour
{
    public List<GameObject> blocks = new List<GameObject>();
    [SerializeField]GameObject[] red_block;
    [SerializeField]GameObject[] blue_block;
    [SerializeField]GameObject[] yellow_block;

    SceneAdministrator admin;
    public string name_scene;
    private void Awake()
    {
        red_block = GameObject.FindGameObjectsWithTag("Double");        
        blue_block = GameObject.FindGameObjectsWithTag("Normal");        
        yellow_block = GameObject.FindGameObjectsWithTag("OneSide");
        admin = GameObject.Find("Core").GetComponent<SceneAdministrator>();
    }
    void Start()
    {
        foreach (GameObject block in red_block)
        {
            blocks.Add(block);
        }
        foreach (GameObject block in blue_block)
        {
            blocks.Add(block);
        }
        foreach (GameObject block in yellow_block)
        {
            blocks.Add(block);
        }
    }
    void Update()
    {
        if(blocks.Count == 0)
        {
            StartCoroutine(Time());
        }
    }
    IEnumerator Time()
    {
        yield return new WaitForSeconds(1f);
        admin.changeScene(name_scene);
    }
}
