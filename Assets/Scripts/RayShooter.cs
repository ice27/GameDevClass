//Lisa Ice
//lice@cnm.edu
//Game Development, CIS 2250
//UIA Chapter 3 Assignment
//Created 2/6/21

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{

    private Camera _camera;
    public int sizeOfCursor = 12;
    public float sizeOfSphereIndicator = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();

        // Cursor.lockState = CursorLockMode.Locked;
        //  Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.scaledPixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if(target != null)
                {
                    target.ReactToHit();
                } else {
                StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        Vector3 scale = new Vector3(sizeOfSphereIndicator / 10.0f, sizeOfSphereIndicator / 10.0f, sizeOfSphereIndicator / 10.0f);
        sphere.transform.localScale = scale;
        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }

    private void OnGUI()
    {
        int size = sizeOfCursor;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), $"<size={size}>*</size>");
    }
}
