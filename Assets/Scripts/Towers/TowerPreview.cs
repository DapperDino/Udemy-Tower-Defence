using System;
using UnityEngine;

namespace DapperDino.TD.Towers
{
    public class TowerPreview : MonoBehaviour
    {
        [SerializeField] private GameObject visuals = null;

        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;

            MoveToCursor();

            visuals.SetActive(true);
        }

        private void Update() => MoveToCursor();

        private void MoveToCursor()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            if (!plane.Raycast(ray, out float distance)) { return; }

            transform.position = ray.GetPoint(distance);
        }
    }
}
