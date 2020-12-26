using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundLoop : MonoBehaviour
{
    public List<GameObject> Backgrounds;
    public List<GameObject> GroundGrids;
    Vector2[] bg_orig_poses;
    Vector2[] ground_orig_poses;
    int current_move_grid_idx = 0;
    int current_target_grid_idx = 1;
    float x_offset = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.x_offset = this.Backgrounds[0].GetComponent<Tilemap>().localBounds.center.x;
        this.bg_orig_poses = new Vector2[this.Backgrounds.Count];
        this.ground_orig_poses = new Vector2[this.GroundGrids.Count];
        for(var i = 0; i<this.Backgrounds.Count; ++i) {
            this.bg_orig_poses[i] = new Vector2(this.Backgrounds[i].transform.position.x, this.Backgrounds[i].transform.position.y);
            this.ground_orig_poses[i] = new Vector2(this.GroundGrids[i].transform.position.x, this.GroundGrids[i].transform.position.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Tilemap CurrentBackground { 
        get { return this.Backgrounds[this.current_move_grid_idx].GetComponent<Tilemap>(); }
    }

    public void MoveBackground() {
        var mov_grid = this.Backgrounds[this.current_move_grid_idx];
        var mov_ground = this.GroundGrids[this.current_move_grid_idx];
        mov_grid.transform.position = new Vector3(mov_grid.transform.position.x + 120, mov_grid.transform.position.y, mov_grid.transform.position.z);
        mov_ground.transform.position = new Vector3(mov_ground.transform.position.x + 120, mov_ground.transform.position.y, mov_ground.transform.position.z);
        this.current_move_grid_idx = this.current_move_grid_idx == 0 ? 1 : 0;
        this.current_target_grid_idx = this.current_target_grid_idx == 0 ? 1 : 0;
    }

    public bool IsMoveTriggered(Vector3 player_pos)
    {
        var grid = this.Backgrounds[this.current_target_grid_idx];
        return player_pos.x > grid.transform.position.x + this.x_offset;
	}

    public void ResetBackgrounds()
    {
        for(var i = 0; i<this.Backgrounds.Count; ++i)
        {
            this.Backgrounds[i].transform.position = new Vector2(this.bg_orig_poses[i].x, this.bg_orig_poses[i].y);
            this.GroundGrids[i].transform.position = new Vector2(this.ground_orig_poses[i].x, this.ground_orig_poses[i].y);
        }
        current_move_grid_idx = 0;
        current_target_grid_idx = 1;
    }
}
