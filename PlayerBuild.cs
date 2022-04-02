using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuild : MonoBehaviour
{
    public List<GameObject> _obstacleList = new List<GameObject>();

    public Animator _animator;

    [SerializeField] Transform _brickTransform;

    private void Start()
    {
        _animator = GetComponent<Animator>();        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("brickTag"))
        {
            other.gameObject.transform.parent = _brickTransform;

            BuildManager.Instance.Add(other.GetComponent<Brick>());
            _obstacleList.Add(other.gameObject);

            other.gameObject.transform.rotation = gameObject.transform.rotation;

            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;

            Destroy(other.gameObject.GetComponent<Rigidbody>());

            other.transform.localPosition = new Vector3(.25f, .25f - (_obstacleList.Count * .25f), 0);
        }

        if (other.gameObject.CompareTag("inFloorBrickTag"))
        {
            if(_obstacleList.Count != 0)
            {
                _animator.SetTrigger("Building");
                GameObject temp = _obstacleList[_obstacleList.Count - 1].gameObject;
                _obstacleList.RemoveAt(_obstacleList.Count - 1);
                temp.gameObject.transform.parent = null;
                temp.transform.rotation = other.transform.rotation;
                temp.transform.position = other.transform.position;
                temp.GetComponent<Brick>().Build();
                Destroy(other.gameObject);
                
            }

        }
        
    }
}
