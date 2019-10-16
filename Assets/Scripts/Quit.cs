using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class Quit : MonoBehaviour {
    void Start(){
        GetComponent<Button>().onClick.AddListener(()=>Application.Quit());
    }
}
