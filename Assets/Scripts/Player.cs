using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI lvl;
    public TextMeshProUGUI xpForLvl;
    public Transform player;
    public float speed = 1.5f;
    private float normalSpeed;
    private float xp = 0;
    private float forLvl = 100;
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
        xp++;
        if (xp >=   forLvl)
        {
            xp -=forLvl;
            forLvl = forLvl*1.25f;

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
    void OnCollision3D(Collider collider)
    {
        if(collider.CompareTag("Mob"))
        {
            collider.gameObject.SetActive(false);   
        }
    }
}