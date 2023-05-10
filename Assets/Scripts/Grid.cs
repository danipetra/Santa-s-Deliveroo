using UnityEngine;

public class Grid : MonoBehaviour
{
    private int _width, _height;
    private float _cellSize;
    private int [,] _gridArray;

    public Grid(int width, int height, float cellSize)
    {
        this._width = width;
        this._height = height;
        this._cellSize = cellSize;

        _gridArray = new int [width, height];   
    }

    private void Awake() 
    {
        for(int x = 0; x <_gridArray.GetLength(0); x++){
            for(int y = 0; y <_gridArray.GetLength(0); y++){
                Utils.CreateWorldText(_gridArray[x, y].ToString(), null, GetWorldPosition(x, y), 20, Color.white, TextAnchor.MiddleCenter);
            }
        }
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * _cellSize;
    }

    
}
