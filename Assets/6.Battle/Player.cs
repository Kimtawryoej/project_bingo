using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public static Player Instance;
    override protected void Awake()
    {

        Instance = this;
        animator = GetComponent<Animator>();
    }
    override protected void Start()
    {


    }

 

}
