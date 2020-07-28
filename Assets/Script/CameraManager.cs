using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class CameraManager : MonoBehaviour
{
    public float CameraOffsetY = 2.0f;
    public GameObject Background;

    private Camera main_camera;
    private PlayerController player;
    private Vector3 camerapos;
    private float x_min, x_max, y_min, y_max;

    // Start is called before the first frame update
    void Start()
    {
        this.main_camera = this.gameObject.GetComponent<Camera>();
        this.player = GameObject.Find("Player").GetComponent<PlayerController>();
        this.camerapos = new Vector3 { z = -10 };
        this.SetupBounds();
        this.FollowCameraToPlayer(this.CameraOffsetY);
    }

    void SetupBounds()
    {
        var local_bounds = this.Background.GetComponent<Tilemap>().localBounds;
        float screen_ratio = (float)Screen.width / (float)Screen.height;
        this.x_min = local_bounds.center.x - local_bounds.extents.x + this.main_camera.orthographicSize * screen_ratio;
        this.x_max = local_bounds.center.x + local_bounds.extents.x - this.main_camera.orthographicSize * screen_ratio;
        this.y_min = local_bounds.center.y - local_bounds.extents.y + this.main_camera.orthographicSize;
        this.y_max = local_bounds.center.y + local_bounds.extents.y - this.main_camera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        this.FollowCameraToPlayer(this.CameraOffsetY);
    }

    void FollowCameraToPlayer(float offset_y = 0)
    {
        this.SetNextCameraPos(this.player.transform.position.x, this.player.transform.position.y + offset_y);
        this.main_camera.transform.position = this.camerapos;
    }
    
    void SetNextCameraPos(float nextx, float nexty)
    {
        if (nextx < this.x_min)
        {
            this.camerapos.x = this.x_min;
        } else if (nextx > this.x_max)
        {
            this.camerapos.x = this.x_max;
		} else {
            this.camerapos.x = nextx;
		}
        if (nexty < this.y_min)
        {
            this.camerapos.y = this.y_min;
        }
        else if (nexty > this.y_max)
        {
            this.camerapos.y = this.y_max;
        }
        else
        {
            this.camerapos.y = nexty;
		}
    }

}
