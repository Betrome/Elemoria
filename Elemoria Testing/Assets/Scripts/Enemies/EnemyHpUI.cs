using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpUI : MonoBehaviour
{
    [SerializeField] private GameObject enemyHp;
    [SerializeField] private Canvas canvas;
    public GameObject hpUI;
    private Camera cam;

    void Awake()
    {
        hpUI = Instantiate(enemyHp, new Vector3(transform.position.x,transform.position.y, transform.position.z), Quaternion.identity, canvas.transform);
    }

    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        Vector3 pos = cam.WorldToScreenPoint(this.transform.position);
        if(pos.z > 0.0f)
        {
            hpUI.SetActive(true);
            hpUI.transform.position = pos;
        }
        else
        {
            hpUI.SetActive(false);
        }
    }

}
