using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using System;

public class ThirdPersonShooterController : MonoBehaviour

{


[SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
[SerializeField] private float normalSensitivity;
[SerializeField] private float aimSensitivity;
[SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
[SerializeField] private GameObject bullet;

[SerializeField] private Transform bulletSpawn;

[SerializeField] private Transform debugTransform;
private StarterAssetsInputs starterAssetsInputs;
private ThirdPersonController thirdPersonController;

[SerializeField] private ParticleSystem particle;

private Animator AnimatorController;

public static Action triggerObstacle;





private void Awake() {
    starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    thirdPersonController  =GetComponent<ThirdPersonController>();
    AnimatorController = GetComponent<Animator>(); 
    
}
void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 ScreenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenterPoint);
        Transform MousePoint = null;
        if(Physics.Raycast(ray,out RaycastHit raycastHit,999f, aimColliderLayerMask)) {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            MousePoint = raycastHit.transform;
        }
        if(starterAssetsInputs.aim){
            AnimatorController.SetLayerWeight(1,Mathf.Lerp(AnimatorController.GetLayerWeight(1),1f,Time.deltaTime * 10f));
            thirdPersonController.SetRotateOnMove(false);
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y ;
            Vector3 aimDirection =  (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward,aimDirection,Time.deltaTime * 20f);
            if (starterAssetsInputs.shoot){
                if(MousePoint != null){
                        if(MousePoint.GetComponent<TargetObstacle>()){
                        triggerObstacle?.Invoke();
                        Debug.Log("target çarptı");
                        Instantiate(particle,MousePoint.position,Quaternion.identity);
                        
                        }
                        else
                        {
                       
                       
                        

        }
                }

                //Vector3 aimDir = (mouseWorldPosition - bulletSpawn.position).normalized;
                //Instantiate(bullet,bulletSpawn.position,Quaternion.LookRotation(aimDir,Vector3.up));
                starterAssetsInputs.shoot = false;

            }
        }
        else {
            AnimatorController.SetLayerWeight(1,Mathf.Lerp(AnimatorController.GetLayerWeight(1),0f,Time.deltaTime * 10f));
            thirdPersonController.SetRotateOnMove(true);
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
        }

        
    }
}
