using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mechanics
{
    public class Field : MonoBehaviour
    {
        public Transform canvas;

        public Text numberShovelsText, numberAwardsText, rightAmountAwardsText;

        public GameObject restartPanelPrefab;

        public GameObject cellPrefab;

        static private int depthField;
        static public int getDepthField
        {
            get { return depthField; }
        }
        

        private const float distanceBetweenCellsX = 0.2f,
                            distanceBetweenCellsY = 0.2f;

        private const float cellWidth = 1f,
                            cellHeight = 1f;

        public void Create(int inputFieldSize, int inputNumberShovels, int inputDepthField, int inputNumberAwards)
        {
            GameState gameState = new GameState(inputNumberAwards, inputNumberShovels, restartPanelPrefab, canvas, numberShovelsText, numberAwardsText, rightAmountAwardsText);

            //Присваиваеваем значение глубины поля
            depthField = inputDepthField;

            int halfSizeField = inputFieldSize / 2;
            //Все построение отталкивается от точки (0; 0)
            Vector2 centralPoint = Vector2.zero;
            Vector2 leftPoint = new Vector2(-halfSizeField * cellWidth, 0);
            Vector2 upperPoint = new Vector2(0, +halfSizeField * cellHeight);
            Vector2 upperLeftPoint = centralPoint + leftPoint + upperPoint;

            Vector2 cellPosition = upperLeftPoint;

            int numberCellsX = inputFieldSize,
                numberCellsY = inputFieldSize;
            int cell_z = 0;
            for (int cell_x = 0; cell_x < numberCellsX; cell_x++)
            {
                for (int cell_y = 0; cell_y < numberCellsY; cell_y++)
                {
                    //Создаем кл в Field в позиции cellPosition
                    GameObject newCell = Instantiate<GameObject>(cellPrefab, cellPosition, new Quaternion(), this.transform);

                    //Инициализируем координаты кл
                    newCell.GetComponent<Cell>().Initialize(new Coordinates(cell_x, cell_y, cell_z), gameState);

                    //Сдвигаем позицию кл вправо на (ширина кл + растояние между кл по оси X)
                    cellPosition.x += cellWidth + distanceBetweenCellsX;
                }

                cellPosition.x = leftPoint.x;
                //Сдвигаем позицию кл вниз на (высоту кл + растояние между кл по оси Y)
                cellPosition.y -= cellHeight + distanceBetweenCellsY;
            }

            //Distribute Awards
            DistributeAwards(inputFieldSize, inputNumberShovels, inputDepthField, inputNumberAwards);
        }

        public void Clear()
        {
            List<Transform> children = new List<Transform>();
            foreach (Transform child in transform)
            {
                children.Add(child);
            }
            for (int idxChild = 0; idxChild < children.Count; idxChild++)
            {
                Destroy(children[idxChild].gameObject);
            }
        }


        static private HashSet<Coordinates> coordinatesOfAwards;
        static public HashSet<Coordinates>  getCoordinatesOfAwards
        {
            get { return coordinatesOfAwards; }
        }
        //Fills coordinatesOfAwards with the coordinates of the awards. Каким-то образом
        private void DistributeAwards(int inputFieldSize, int inputNumberShovels, int inputDepthField, int inputNumberAwards)
        {
            coordinatesOfAwards = new HashSet<Coordinates>();

            System.Random random = new System.Random();

            //Коэффициент количества наград для увеличения количества наград
            float coefficientNumberAwards = 15f;
            int numberAwards = (int)(inputNumberAwards * coefficientNumberAwards);
            while (coordinatesOfAwards.Count != numberAwards)
            {
                Coordinates coordinatesOfNewReward = new Coordinates(random.Next(inputFieldSize), random.Next(inputFieldSize), random.Next(1, inputDepthField + 1));
                {
                    //int max
                    //int probabilityOfLevel = random.Next(0, 100);
                    ////0.1 0.3 0.6
                    //if (probabilityOfLevel < 10)
                    //{

                    //}
                    //else if(probabilityOfLevel < 60)
                    //{

                    //}
                    //else if(val < 100)
                    //{

                    //}
                }

                if (coordinatesOfAwards.Contains(coordinatesOfNewReward) == false)
                {
                    coordinatesOfAwards.Add(coordinatesOfNewReward);
                }
            }
        }
    }
}