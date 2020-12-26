using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public int X_OFFSET = 123;
    public List<GameObject> SkyGrids;
    public List<GameObject> GroundGrids;
    int current_move_ground_idx = 0;

    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsMoveTriggered(Vector3 pos)
    {
        var target_ground_idx = this.current_move_ground_idx == 0 ? 1 : 0;
        return pos.x > this.SkyGrids[target_ground_idx].transform.position.x + X_OFFSET / 2;
    }

    public void MoveGrids()
    {
        this.SkyGrids[this.current_move_ground_idx].transform.position += new Vector3(X_OFFSET, 0);
        this.GroundGrids[this.current_move_ground_idx].transform.position += new Vector3(X_OFFSET, 0);
        this.current_move_ground_idx = this.current_move_ground_idx == 0 ? 1 : 0;
    }
}
