using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.GetComponent<Obstacle>() != null){
            Destroy(gameObject);
            return;
        }
        //check if object interacted with is player
        if(other.gameObject.name != "Player"){
            return;
        }

        //add to score/ destroy coin
        GameManager.inst.IncrementScore();
        Destroy(gameObject); 
    }

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0,0, turnSpeed * Time.deltaTime);
    }
}
