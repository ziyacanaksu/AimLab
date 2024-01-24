using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public int Id;

    public TargetObstacle obstacleToEnable;
    void Awake(){
        ThirdPersonShooterController.triggerObstacle += EnableObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void EnableObject(){
        Debug.Log("çalıştı");
        
    
        obstacleToEnable.gameObject.transform.parent.gameObject.SetActive(true);
        gameObject.SetActive(false);
            
        
            
    }
}
