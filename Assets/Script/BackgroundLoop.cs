using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject Background;
    private Camera camera;
    private Tilemap tilemap;
    private BoundsInt current_bounds;

    // Start is called before the first frame update
    void Start()
    {
        this.camera = this.gameObject.GetComponent<Camera>();
        this.tilemap = this.Background.GetComponent<Tilemap>();
        this.current_bounds = tilemap.cellBounds;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
