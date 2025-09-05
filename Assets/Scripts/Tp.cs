using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tp : MonoBehaviour
{
    public string stage = "";
    public Player lvl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter(Collision collision){
        Debug.Log("kms");
        if(collision.gameObject.CompareTag("Player"))
        {

        if(lvl.lvlCount>1)
        {
            Debug.Log("kys");
            SceneManager.LoadScene(stage);
        }
        }
    }
}
