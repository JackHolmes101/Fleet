using RTS;
using UnityEngine;

public class PlacementGrid : MonoBehaviour
{
    //testing, TODO switch back to private
    public int currentFloor = 0;
    public int xSize;
    public int ySize;
    public int zSize;
    private Placement[,,] placements; // Array of Placements that represent the entire Ship.
    private int currentFloorNumber = 0;

    public int XSize
    {
        get { return xSize; }
    }

    public int YSize
    {
        get { return ySize; }
    }

    public int ZSize
    {
        get { return zSize; }
    }

    public int CurrentFloorNumber
    {
        get { return currentFloorNumber; }
        set { currentFloorNumber = value; }
    }

    //testing, TODO put constructors back in.
    private void Start()
    {
        ResourceManager.loadAssets();
        setupPlacementGrid(0, 0, 0);
    }

    //public ConstructionGrid()
    //{
    //    setupPlacementGrid(0,0,0);
    //}

    //public ConstructionGrid(int width, int height, int length)
    //{
    //    setupPlacementGrid(width, height, length);
    //}

    private void setupPlacementGrid(int width, int height, int length)
    {
        int minWidth = 6;
        int minHeight = 4;
        int minLength = 10;

        if (width < minWidth)
            xSize = minWidth;
        else
            xSize = width;

        if (height < minHeight)
            ySize = minHeight;
        else
            ySize = height;

        if (length < minLength)
            zSize = minLength;
        else
            zSize = length;

        initiatePlacementGrid();
    }

    private void initiatePlacementGrid()
    {
        // Fill with placements.
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                for (int z = 0; z < zSize; z++)
                {
                    Vector3 pos = new Vector3(x, y, z);
                    var prefab = ResourceManager.LoadedAssetBundle.LoadAsset("Placement");
                    GameObject newPlacement = Instantiate(prefab, transform) as GameObject;
                    newPlacement.transform.localPosition += pos;  
                }
            }
        }
    }
}
