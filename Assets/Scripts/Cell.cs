using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private GameObject _wallLeft;
    [SerializeField] private GameObject _wallBottom;
    [SerializeField] private GameObject _floor;
    [SerializeField] private GameObject _zone;
    [SerializeField] private Material _materialZone;

    public GameObject WallLeft { get { return _wallLeft; } }
    public GameObject WallBottom { get { return _wallBottom; } }
    public GameObject Floor { get { return _floor; } }
    public GameObject Zone { get { return _zone; } }
    public Material MaterialZone { get { return _materialZone; } }

    
}
