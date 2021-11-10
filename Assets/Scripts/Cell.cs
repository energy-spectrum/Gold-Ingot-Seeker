using UnityEngine;

namespace Mechanics {
    public class Cell : MonoBehaviour
    {
        [SerializeField]
        private Coordinates coordinates;

        private bool areCoordinatesInitialized = false;
        public void InitializeCoordinates(Coordinates inputCoordinates)
        {
            if (!areCoordinatesInitialized)
            {
                this.coordinates = inputCoordinates;
                areCoordinatesInitialized = true;
            }
            else
            {
                print("Ban!!! The coordinates have already been initialized");
            }
        }

        private void OnMouseDown()
        {
            print("LBM");
            DigUpOrPick();
        }

        private void DigUpOrPick()
        {
            //HERE !!!!!!!!!
        }

        private Coordinates GetCoordinates()
        {
            return coordinates;
        }

        private void DownPosion()
        {
            coordinates += Coordinates.down;
        }
    }
}