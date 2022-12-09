using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace GraphSystem.Utils
{
    public class Grid<TGrid>
    {
        private readonly Vector2 worldGridSize;
        private readonly Vector2Int gridSize;
        private readonly Vector2 cellSize;
        private readonly Vector2 cellOffsetSize;
        private readonly Vector2 pivot;
        private TGrid[,] gridMap;

        public int Height
        {
            get
            {
                return gridSize.y;
            }
        }

        public int Width
        {
            get
            {
                return gridSize.x;
            }
        }

        public Grid(Vector2Int gridSize, Vector2 cellSize, Vector2 pivot, System.Func<int, int, TGrid> initialize = null)
        {
            this.gridSize = gridSize;
            this.cellSize = cellSize;
            this.cellOffsetSize = cellSize / 2;
            this.pivot = new Vector2(gridSize.x / 2, gridSize.y / 2) + pivot;
            this.gridMap = new TGrid[gridSize.x, gridSize.y];

            for (int x = 0; x < gridMap.GetLength(0); x++)
            {
                for (int y = 0; y < gridMap.GetLength(1); y++)
                {
                    if (initialize != null)
                        gridMap[x, y] = initialize.Invoke(x, y);
                    // debugMap[x, y] = DebugUtilities.GridVisual(gridMap[x, y].ToString(), GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * 0.5f, Color.white, fontSize: 5);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 1f);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 1f);
                }
            }
            Debug.DrawLine(GetWorldPosition(0, Height), GetWorldPosition(Width, Height), Color.white, 1f);
            Debug.DrawLine(GetWorldPosition(Width, 0), GetWorldPosition(Width, Height), Color.white, 1f);
            Debug.Log("Creating Grid. Width: " + Width + " Height: " + Height);
        }

        public Vector3 GetWorldPosition(int x, int y)
        {
            return new Vector3(x - pivot.x + cellOffsetSize.x, y - pivot.y + cellOffsetSize.y, 0) * cellSize;
        }
        public void GetXY(Vector3 worldPosition, out int x, out int y)
        {
            x = Mathf.FloorToInt((worldPosition.x + pivot.x - cellOffsetSize.x) / cellSize.x);
            y = Mathf.FloorToInt((worldPosition.y + pivot.y - cellOffsetSize.y) / cellSize.y);
        }

        public void SetValue(int x, int y, TGrid value)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
            {
                gridMap[x, y] = value;
            }
        }

        public void SetValue(Vector3 worldPosition, TGrid value)
        {
            GetXY(worldPosition, out int x, out int y);
            SetValue(x, y, value);
        }

        public TGrid GetValue(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
                return gridMap[x, y];
            else
                return default(TGrid);
        }

        public TGrid GetValue(Vector3 worldPosition, TGrid value)
        {
            GetXY(worldPosition, out int x, out int y);
            return GetValue(x, y);
        }

        public Vector2 Clamp(Vector2 worldPos)
        {
            GetXY(worldPos, out int x, out int y);
            if (x < 0)
                x = 3;
            else if (x > Width)
                x = Width - 3;
            if (y < 0)
                y = 3;
            else if (y > Height)
                y = Height - 3;

            return GetWorldPosition(x, y);
        }
    }
}