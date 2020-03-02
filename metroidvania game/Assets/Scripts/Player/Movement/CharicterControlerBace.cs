using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CharicterControlerBace : MonoBehaviour
{
    const float skinwidth = .015f;
    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;

    public LayerMask whatToCol;

    float horizontalRaySpacing;
    float verticalRaySpacing;

    BoxCollider2D col;
    RaycastOrigins raycastOrigins;
    public CollitionInfo colinfo;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        calculateRaySpacing();
    }
    public void Move(Vector3 velocity)
    {
        UpdateRaycastOrigens();
        colinfo.Reset();
        if (velocity.y != 0)
        {
            VerticalCollitions(ref velocity);
        }

        if (velocity.x != 0)
        {
            HorizontalCollitions(ref velocity);
        }
        transform.Translate(velocity);
    }
    void HorizontalCollitions(ref Vector3 velocity)
    {
        float directionX = Mathf.Sign(velocity.x);
        float rayLength = Mathf.Abs(velocity.x) + skinwidth;
        for (int i = 0; i < horizontalRayCount; i++)
        { 
            Vector2 rayOrigen = (directionX == -1) ? raycastOrigins.bottemLeft : raycastOrigins.bottomRight;
            rayOrigen += Vector2.up * (horizontalRaySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigen, Vector2.right * directionX, rayLength, whatToCol);

            Debug.DrawRay(rayOrigen, Vector2.right * directionX * rayLength, Color.red);

            if (hit)
            {
                velocity.x = (hit.distance - skinwidth) * directionX;
                rayLength = hit.distance;
                colinfo.left = directionX == -1;
                colinfo.right = directionX == 1;
            }
        }
    }
    void VerticalCollitions(ref Vector3 velocity)
    {
        float directionY = Mathf.Sign(velocity.y);
        float rayLength = Mathf.Abs(velocity.y) + skinwidth;
        for (int i = 0; i < verticalRayCount; i++)
        {

            Vector2 rayOrigen = (directionY == -1) ? raycastOrigins.bottemLeft : raycastOrigins.topLeft;
            rayOrigen += Vector2.right * (verticalRaySpacing * i + velocity.x);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigen, Vector2.up * directionY, rayLength, whatToCol);

            Debug.DrawRay(rayOrigen, Vector2.up * directionY * rayLength, Color.red);

            if (hit)
            {
                velocity.y = (hit.distance - skinwidth) * directionY;
                rayLength = hit.distance;

                colinfo.above = directionY == 1;
                colinfo.bellow = directionY == -1;
            }
        }
    }
    void UpdateRaycastOrigens()
    {
        Bounds bounds = col.bounds;
        bounds.Expand(skinwidth * -2);
        raycastOrigins.bottemLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }
    void calculateRaySpacing()
    {
        Bounds bounds = col.bounds;
        bounds.Expand(skinwidth * -2);
        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }
    struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottemLeft, bottomRight;
    }
    public struct CollitionInfo
    {
        public bool above, bellow;
        public bool right, left;
        public void Reset()
        {
            above = bellow = false;
            left = right = false;
        }
    }
}
