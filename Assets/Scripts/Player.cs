using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI lvl;
    public TextMeshProUGUI xpForLvl;
    public Transform player;
    public float speed = 1.5f;
    private float normalSpeed;
    private float xp = 0;
    private float forLvl = 100;
    public int lvlCount = 1;
    
    public float speedMulti = 4f;
    // Start is called before the first frame update
    void Start()
    {
        xpForLvl.text = forLvl.ToString();   
        normalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var z = Input.GetAxisRaw("Vertical");
        //xp++;
        if (xp >=   forLvl)
        {
            xp -=forLvl;
            forLvl = forLvl*1.25f;
            ++lvlCount;

        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            
            speed = speedMulti;
        }
        else
        {
            speed = normalSpeed;
        }
        lvl.text = xp.ToString("F2");
        xpForLvl.text = forLvl.ToString("F2");
        player.position += new Vector3(x,0,z).normalized * speed * Time.deltaTime;
    }
    void OnCollisionEnter(Collision collider)
    {
        Debug.Log("touch you");
        if(collider.gameObject.CompareTag("Mob"))
        {
            xp = xp+100;
            Destroy(collider.gameObject);   
        }
    }
}