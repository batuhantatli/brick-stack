using UnityEngine;

public class Brick : MonoBehaviour
{
    private void Start()
    {
        BuildManager.Instance.Add(this);
    }

    public void Build()
    {
        BuildManager.Instance.Build(this);
    }
}
