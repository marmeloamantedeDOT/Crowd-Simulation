using UnityEngine;
using UnityEngine.InputSystem;
public class DropCylinder : MonoBehaviour
{
    public GameObject obstacle;
    GameObject[] agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GameObject.FindGameObjectsWithTag("agent");
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current == null)
            return;

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                RaycastHit hitInfo;
                Vector2 mousePos = Mouse.current.position.ReadValue();
                Ray ray = Camera.main.ScreenPointToRay(mousePos);

                if(Physics.Raycast(ray, out hitInfo))
                {
                    Instantiate(obstacle, hitInfo.point, obstacle.transform.rotation);

                foreach (GameObject a in agent)
                {
                    a.GetComponent<AIControl>().DetectNewObstacle(hitInfo.point);
                }
                }
            }
        }
    }