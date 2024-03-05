using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum JobType
{
    Knight,
    Mercenary,
    Alchem,
    Acrobat
}

public class Talent : MonoBehaviour
{
    private string name;

    public JobType jobType;
    public bool haveWeakness { get; set; }
    public bool isEmployed { get; set; }
    public bool isVisited { get; set; }
    public bool isAlive { get; set; }

    public Talent(string _name, JobType jobType)
    {
        name = _name;
        this.jobType = jobType;
        haveWeakness = false;
        isEmployed = false;
        isVisited = false;
        isAlive = true;
    }
}
