using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthManager : MonoBehaviour
{
    [SerializeField]
    private List<RawImage> _imagesList;
    public void UpdateHealthUI(int healthAmount)
    {
        for (int i = _imagesList.Count; i >0; i--)
        {
            if (i < healthAmount)
            {
                _imagesList[i].enabled = true;
            }
            else
            {
                _imagesList[i].enabled = false;
            }
        }
    }
}
