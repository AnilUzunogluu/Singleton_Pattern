using UnityEngine;

public class DropGarbage : MonoBehaviour {

    [SerializeField] private GameObject garbage;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update () {
        if(Input.GetMouseButtonDown(0)) {
            RaycastHit hitInfo;
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                GameObject obj = Instantiate(garbage,hitInfo.point,Quaternion.identity);
                GameEnvironment.Instance.AddObstacle(obj);
            }
        }
    }
}
