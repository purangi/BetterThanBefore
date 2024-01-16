using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talent : MonoBehaviour
{
    private string name;
    public bool haveWeakness { get; set; }
    public bool isEmployed { get; set; }
    public bool isVisited { get; set; }
    public bool isAlive { get; set; }

    public Talent(string _name)
    {
        name = _name;
        haveWeakness = false;
        isEmployed = false;
        isVisited = false;
        isAlive = true;
    }
}
