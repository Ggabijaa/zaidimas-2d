using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counting : MonoBehaviour
{
   // Start is called before the first frame update
    public static int scores;
    //public Text countText;
    void Start()
    {
       // countText.text = " ";
        scores = 0;
    }

    // Update is called once per frame
    void Update()
    {
       // countText.text = scores;
    }
}
