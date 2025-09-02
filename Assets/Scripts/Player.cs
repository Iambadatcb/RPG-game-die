using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI lvl;
    private int xp = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xp++;
        if (xp == 100)
        {
            xp -=100;
        }
        lvl.text = xp.ToString();
    }
}
