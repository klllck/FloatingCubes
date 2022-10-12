using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour {
    private Vector2 worldBounds;
    private float cameraHeight;
    private float cameraWidth;

    private void Awake() 
    {
        worldBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        cameraHeight = Camera.main.orthographicSize * 2f;
        cameraWidth = cameraHeight * Camera.main.aspect;
    }

    private void LateUpdate() 
    {
        var cameraPos = transform.position;
        cameraPos.x = Mathf.Clamp(cameraPos.x, -worldBounds.x, worldBounds.x);
        cameraPos.y = Mathf.Clamp(cameraPos.y, -worldBounds.y, worldBounds.y);
        transform.position = cameraPos;
    }
}
