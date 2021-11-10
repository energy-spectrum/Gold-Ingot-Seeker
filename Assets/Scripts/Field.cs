using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics
{
    public class Field : MonoBehaviour
    {
        public GameObject cellPrefab;

        public void Create(int inputN, int inputM, int inputH, int inputK)
        {

        }

        public void Clear()
        {
            Transform[] children = transform.GetComponentsInChildren<Transform>();
            for (int idxChild = 0; idxChild < children.Length; idxChild++)
            {
                Destroy(children[idxChild].gameObject);
            }
        }

        private void DistributeAwards()
        {

        }
    }
}