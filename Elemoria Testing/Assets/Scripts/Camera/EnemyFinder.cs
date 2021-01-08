using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyFinder : MonoBehaviour
{

    //The list of colliders currently inside the trigger
    public List<Collider> EnemyList = new List<Collider>();
    //public List<Transform> enemyTransforms = new List<Transform>();
    public List<Collider> OrderedList = new List<Collider>();

    public Collider closestEnemy;
    
    //called when something enters the trigger
    void OnTriggerEnter(Collider other)
    {
        //if the object is not already in the list
        if(!EnemyList.Contains(other) && other.gameObject.tag == "Enemy")
        {
            //add the object to the list
            EnemyList.Add(other);
            //enemyTransforms.Add(other.gameObject.transform);
        }
    }
    
    //called when something exits the trigger
    void OnTriggerExit(Collider other)
    {
        //if the object is in the list
        if(EnemyList.Contains(other))
        {
            //remove it from the list
            EnemyList.Remove(other);
            //enemyTransforms.Remove(other.gameObject.transform);
        }
    }

    Collider GetClosestEnemy (List<Collider> Enemy, Transform fromThis)
         {
             Collider bestTarget = new Collider();
             float closestDistanceSqr = Mathf.Infinity;
             Vector3 currentPosition = fromThis.position;
             foreach(Collider potentialTarget in EnemyList)
             {  
                 if(potentialTarget == null)
                 {
                     EnemyList.Remove(potentialTarget);
                     Debug.Log("Removed");
                 }
                 else
                 {
                    Vector3 directionToTarget = potentialTarget.bounds.center - currentPosition;
                    float dSqrToTarget = directionToTarget.sqrMagnitude;
                    if(dSqrToTarget < closestDistanceSqr)
                    {
                        closestDistanceSqr = dSqrToTarget;
                        bestTarget = potentialTarget;
                    }
                 }

             }             
             return bestTarget;
         }
    void Update()
    {
        closestEnemy = GetClosestEnemy(EnemyList, this.transform);
        OrderedList = EnemyList.OrderBy(x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();
    }
}