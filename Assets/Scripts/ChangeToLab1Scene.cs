﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class ChangeToLab1Scene : MonoBehaviour {
    
    void Start(){
        GetComponent<Button>().onClick.AddListener(()=>SceneManager.LoadScene(0));
    }
}
