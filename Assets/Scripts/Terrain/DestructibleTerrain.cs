using System.Collections.Generic;
using UnityEngine;
using Vector2f = UnityEngine.Vector2;
using Vector2i = ClipperLib.IntPoint;
using int64 = System.Int64;

public class DestructibleTerrain : MonoBehaviour
{
    public Material material;

    [Range(0.1f, 3.0f)]
    public float blockSize = 0.5f;

    private int64 blockSizeScaled;

    [Range(0.0f, 5.0f)]
    public float simplifyEpsilonPercent=1.0f;

    [Range(1, 100)]
    public int resolutionX = 10;

    [Range(1, 100)]
    public int resolutionY = 10;

    private float depth = 0.0f;

    private float width;
    private float height;
    private DestructibleBlock[] blocks;

    private void Awake()
    {
        // Calculate and set the epsilon for block simplification
        BlockSimplification.epsilon = (int64)(simplifyEpsilonPercent / 100f * blockSize * VectorEx.float2int64);

        // Calculate the width and height of the terrain
        width = blockSize * resolutionX;
        height = blockSize * resolutionY;

        // Scale the block size
        blockSizeScaled = (int64)(blockSize * VectorEx.float2int64);

        // Initialize the destructible blocks
        Initialize();
    }

    private void Initialize()
    {
        blocks = new DestructibleBlock[resolutionX * resolutionY];

        for (int x = 0; x < resolutionX; x++)
        {
            for (int y = 0; y < resolutionY; y++)
            {
                // Create the vertices of the block
                List<Vector2i> vertices = new List<Vector2i>
                {
                    new Vector2i(x * blockSizeScaled, (y + 1) * blockSizeScaled),
                    new Vector2i(x * blockSizeScaled, y * blockSizeScaled),
                    new Vector2i((x + 1) * blockSizeScaled, y * blockSizeScaled),
                    new Vector2i((x + 1) * blockSizeScaled, (y + 1) * blockSizeScaled)
                };

                List<List<Vector2i>> polygons = new List<List<Vector2i>> { vertices };
                int idx = x + resolutionX * y;

                // Create and initialize the block
                DestructibleBlock block = CreateBlock();
                blocks[idx] = block;
                UpdateBlockBounds(x, y);
                block.UpdateGeometryWithMoreVertices(polygons, width, height, depth);
            }
        }
    }

    public Vector2 GetPositionOffset()
    {
        return transform.position;
    }

    private DestructibleBlock CreateBlock()
    {
        GameObject childObject = new GameObject("DestructableBlock");
        childObject.transform.SetParent(transform);
        childObject.transform.localPosition = Vector3.zero;

        DestructibleBlock blockComp = childObject.AddComponent<DestructibleBlock>();
        blockComp.SetMaterial(material);

        return blockComp;
    }

    private void UpdateBlockBounds(int x, int y)
    {
        int lx = x == 0 ? -1 : x;
        int ly = y == 0 ? -1 : y;
        int ux = x == resolutionX - 1 ? resolutionX + 1 : x + 1;
        int uy = y == resolutionY - 1 ? resolutionY + 1 : y + 1;

        BlockSimplification.currentLowerPoint = new Vector2i(lx * blockSizeScaled, ly * blockSizeScaled);
        BlockSimplification.currentUpperPoint = new Vector2i(ux * blockSizeScaled, uy * blockSizeScaled);
    }

    public void ExecuteClip(IClip clip)
    {
        // Calculate and set the epsilon for block simplification
        BlockSimplification.epsilon = (int64)(simplifyEpsilonPercent / 100f * blockSize * VectorEx.float2int64);

        // Get the vertices and bounds of the clip
        List<Vector2i> clipVertices = clip.GetVertices();
        ClipBounds bounds = clip.GetBounds();

        int x1 = Mathf.Clamp((int)(bounds.lowerPoint.x / blockSize), 0, resolutionX - 1);
        int y1 = Mathf.Clamp((int)(bounds.lowerPoint.y / blockSize), 0, resolutionY - 1);
        int x2 = Mathf.Clamp((int)(bounds.upperPoint.x / blockSize), 0, resolutionX - 1);
        int y2 = Mathf.Clamp((int)(bounds.upperPoint.y / blockSize), 0, resolutionY - 1);

        for (int x = x1; x <= x2; x++)
        {
            for (int y = y1; y <= y2; y++)
            {
                if (clip.CheckBlockOverlapping(new Vector2f((x + 0.5f) * blockSize, (y + 0.5f) * blockSize), blockSize))
                {
                    DestructibleBlock block = blocks[x + resolutionX * y];

                    List<List<Vector2i>> solutions = new List<List<Vector2i>>();
                    ClipperLib.Clipper clipper = new ClipperLib.Clipper();
                    clipper.AddPolygons(block.Polygons, ClipperLib.PolyType.ptSubject);
                    clipper.AddPolygon(clipVertices, ClipperLib.PolyType.ptClip);
                    clipper.Execute(ClipperLib.ClipType.ctDifference, solutions, ClipperLib.PolyFillType.pftNonZero, ClipperLib.PolyFillType.pftNonZero);

                    UpdateBlockBounds(x, y);
                    block.UpdateGeometryWithMoreVertices(solutions, width, height, depth);
                }
            }
        }
    }
}
