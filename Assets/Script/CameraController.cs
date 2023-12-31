using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curPos = transform.position;

        float clampX = Mathf.Clamp(curPos.x, minX, maxY);
        float clampY = Mathf.Clamp(curPos.y, minY, maxY);

        transform.position = new Vector3(clampX, clampY, curPos.z);
    }
}
