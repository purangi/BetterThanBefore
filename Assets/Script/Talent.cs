using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talent : MonoBehaviour
{
    private bool haveWeakness;
    private bool isEmployed;
    private bool isVisited;

    public Talent(bool haveWeakness, bool isEmployed, bool isVisited)
    {
        this.haveWeakness = haveWeakness;
        this.isEmployed = isEmployed;
        this.isVisited = isVisited;
    }

    public bool HaveWeakness
    {
        get { return haveWeakness; }
        set { haveWeakness = value; }
    }

    public bool IsEmployed
    {
        get { return isEmployed; }
        set { isEmployed = value; }
    }

    public bool IsVisited
    {
        get { return isVisited; }
        set { isVisited = value; }
    }
}
