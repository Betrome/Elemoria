using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;//Be Sure To Include This
 
public class TargetController : MonoBehaviour {
 
    public Camera cam; //Main Camera
    public GameObject target; //Current Focused Enemy In List
    public GameObject player;
    public Image activeTarget;//active Target image Of Crosshair
    int lockedEnemy = 0;

    public GameObject freeCam;
    public GameObject lockCam;

    private PlayerControls controls;
    public EnemyFinder e;
 
    public bool lockedOn;//Keeps Track Of Lock On Status 
    public bool passiveLock;   

    public Vector3 dir;
    public float distance;
  
    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Target.performed += ctx => Target();
        controls.Gameplay.NextTarget.performed += ctx => NextTarget();
        controls.Gameplay.PreviousTarget.performed += ctx => PreviousTarget();
    }

    void Start ()
    {
 
        lockedOn = false;
    }  
    
    void Update()
    {
        if(lockedEnemy < 0 || lockedEnemy > e.EnemyList.Count - 1)
        {
            lockedEnemy = 0;
        }
        if (!e.EnemyList.Any() || target == null)
        {
            lockedOn = false;
            freeCam.SetActive(true);
            freeCam.transform.position = cam.transform.position;
            freeCam.transform.rotation = cam.transform.rotation;
            lockCam.SetActive(false);
            activeTarget.enabled = false;
        }
        if (lockedOn && target != null)
        {
            distance = Vector3.Distance(player.transform.position, target.transform.position);
            dir = target.transform.position - player.transform.position;
            activeTarget.transform.position = cam.WorldToScreenPoint(target.transform.position);
            activeTarget.transform.Rotate(new Vector3(0, 0, -1));
        }
        else
        {
            freeCam.SetActive(true);
            freeCam.transform.position = cam.transform.position;
            freeCam.transform.rotation = cam.transform.rotation;
            lockCam.SetActive(false);
            activeTarget.enabled = false;  
        }
    }

    void Target()
    {       
        if (!lockedOn && e.EnemyList.Any() && e.closestEnemy != null)
        {
                float y = 12.0f;
                lockCam.SetActive(true);
                lockCam.transform.position = new Vector3 (cam.transform.position.x, y, cam.transform.position.z);
                lockCam.transform.rotation = cam.transform.rotation;
                freeCam.SetActive(false);
                lockedOn = true;
                activeTarget.enabled = true;
                target.transform.SetParent(e.closestEnemy.transform, false);   
                target.transform.position = e.closestEnemy.bounds.center;             
        }
        else if (lockedOn || !e.EnemyList.Any() || e.closestEnemy == null)
        {
            LockOff();
        }
    }

    void NextTarget()
    {
        if (lockedEnemy == e.EnemyList.Count - 1)
        {
            //If End Of List Has Been Reached, Start Over
            lockedEnemy = 0;
            target.transform.SetParent(e.EnemyList[lockedEnemy].transform, false);   
            target.transform.position = e.EnemyList[lockedEnemy].bounds.center;
            Debug.Log("Next Target");
        }
        else
        {
            //Move To Next Enemy In List
            lockedEnemy++;
            target.transform.SetParent(e.EnemyList[lockedEnemy].transform, false);   
            target.transform.position = e.EnemyList[lockedEnemy].bounds.center;
        }             
    }

    void PreviousTarget()
    {
        if (lockedEnemy == 0)
        {
            //If End Of List Has Been Reached, Start Over
            lockedEnemy = e.EnemyList.Count -1;
            target.transform.SetParent(e.EnemyList[lockedEnemy].transform, false);   
            target.transform.position = e.EnemyList[lockedEnemy].bounds.center;
            Debug.Log("Previous Target");
        }
        else
        {
            //Move To Next Enemy In List
            lockedEnemy--;
            target.transform.SetParent(e.EnemyList[lockedEnemy].transform, false);   
            target.transform.position = e.EnemyList[lockedEnemy].bounds.center;
        }  
    }

    public void LockOff()
    {
        freeCam.SetActive(true);
        freeCam.transform.position = cam.transform.position;
        freeCam.transform.rotation = cam.transform.rotation;
        lockCam.SetActive(false);
        lockedOn = false;
        activeTarget.enabled = false;
        target.transform.SetParent(null, true);
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Jump.Disable();
        controls.Gameplay.Action.Disable();
    }
}
