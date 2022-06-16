using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;
public class MazeSpawner : MonoBehaviour
{
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private Vector3 _cellSize = new Vector3(1, 1, 0);
    [SerializeField] private Material _materialDeathZone;
    [SerializeField] private Material _materialFinishZone;
    //public HintRenderer HintRenderer;

    private Maze _maze;

    private void Start()
    {
        MazeGenerator generator = new MazeGenerator();
        _maze = generator.GenerateMaze();

        for (int x = 0; x < _maze.Cells.GetLength(0); x++)
        {
            for (int y = 0; y < _maze.Cells.GetLength(1); y++)
            {
                Cell c = Instantiate(_cellPrefab, new Vector3(x * _cellSize.x, y * _cellSize.y, y * _cellSize.z), Quaternion.identity);
                c.name = $"{x}, {y}";
                c.WallLeft.SetActive(_maze.Cells[x, y].WallLeft);
                c.WallBottom.SetActive(_maze.Cells[x, y].WallBottom);
                c.Floor.SetActive(_maze.Cells[x, y].Floor);

                if(_maze.Cells[x, y].DeathZone)
                {
                    c.Zone.GetComponent<MeshRenderer>().material = _materialDeathZone;
                    c.Zone.AddComponent<DeathZone>();
                }
                if (_maze.Cells[x, y].Finish)
                {
                    c.Zone.GetComponent<MeshRenderer>().material = _materialFinishZone;
                    c.Zone.AddComponent<FinishZone>();
                }
                
            }
        }
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}
