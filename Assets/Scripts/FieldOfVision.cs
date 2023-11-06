using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class FieldOfVision : MonoBehaviour
{
    private float maxDistance = 50f;
    private Vector3 direction = Vector3.forward;
    [SerializeField] private Vector3 offset;
    [SerializeField] private int _raysCount;
    [SerializeField] private float _angle;
    private bool playerInTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RayToScan();
    }

    private bool RaycastField(Vector3 globalDirection)
    {
        playerInTarget = false;
        //Vector3 globalDirection = transform.TransformDirection(direction);
        Vector3 position = transform.position + offset;
        RaycastHit hit = new RaycastHit();
        if(Physics.Raycast(position, globalDirection, out hit, maxDistance))
        {
            if(hit.collider.CompareTag("Player"))
            {
                Debug.DrawLine(position, hit.point, Color.green);
                playerInTarget = true;
                Debug.Log("PlayerInTarget");
                Debug.Log(playerInTarget);
            }
            else
            {
                Debug.DrawLine(position, hit.point, Color.blue);
            }
        }
        else
        {
            Debug.DrawRay(position, globalDirection * maxDistance, Color.red);
        }
        return playerInTarget;
    }

    bool RayToScan()
    {
        bool result = false;
        bool a = false;
        bool b = false;
        float j = 0;

        for (int i = 0; i < _raysCount; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);

            j += +_angle * Mathf.Deg2Rad / _raysCount;

            Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));
            if (RaycastField(dir)) a = true;

            if (x != 0)
            {
                dir = transform.TransformDirection(new Vector3(-x, 0, y));
                if (RaycastField(dir)) b = true;
            }
        }

        if (a || b) result = true;
        return result;
    }

    public bool TakeTheTarget()
    {
        return playerInTarget;
    }
}
