using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator Anim;
    
    protected virtual void Start()
    {
        Anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
   
    
}
