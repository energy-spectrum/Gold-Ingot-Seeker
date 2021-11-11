using UnityEngine;

namespace Mechanics {
    public class Cell : MonoBehaviour
    {
        public GameObject goldIngotPrefab;

        [SerializeField]
        private Coordinates coordinates;
        private GameState gameState;

        private bool areInitialized = false;
        public void Initialize(Coordinates inputCoordinates, GameState inputGameState)
        {
            if (!areInitialized)
            {
                this.coordinates = inputCoordinates;
                areInitialized = true;

                this.gameState = inputGameState;

                gameIsOver = false;
            }
            else
            {
                print("Ban!!! The cell has already been initialized");
            }
        }


        static private bool gameIsOver = false;
        ////����������, ���� ������ �� ������ ���
        //private void OnMouseDown()
        //{
        //    if (!gameIsOver)
        //    {
        //        DigUpOrPick();
        //    }
        //}

        //A function that determines what to do: dig or collect a reward
        public void DigUpOrPick()
        {
            if (Field.getCoordinatesOfAwards.Contains(coordinates))
            {
                Pick();
                return;
            }
            else if(coordinates.z != Field.getDepthField)
            {
                Dig();
            }
        }

        private GameObject newGoldIngot;
        private void Dig()
        {
            IncreaseDepth();

            //���� �� ���� ������ � ���� �� ���� �������, �� 
            if (Field.getCoordinatesOfAwards.Contains(coordinates))
            {   //������� ������� ������(�������) � ������� �� � ������� ���� ������� ������ �������� �������� ���� 
                newGoldIngot = Instantiate(goldIngotPrefab, transform.localPosition, new Quaternion(), transform.parent);
            }

            //��������� ���������� �����
            gameState.ReduceNumberShovels();

            gameIsOver = gameState.GameIsOver();
        }
        private void Pick()
        {
            Destroy(newGoldIngot);

            //����������� ���������� ������
            gameState.IncreaseNumberCollectedAwards();

            gameIsOver = gameState.GameIsOver();
        }

        
        private SpriteRenderer spriteRenderer;
        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        private Color[] cellDepthColors = { new Color(90f / 256, 255f / 256, 1f),       new Color(69f / 256, 140f / 256, 61f / 256),
                                            new Color(52f / 256, 87f / 256, 33f / 256), new Color(80F / 256, 69f / 256, 33f / 256),
                              /*���� ���*/  new Color(58f / 256, 58f / 256, 58f / 256)};
        //����������� �������
        private void IncreaseDepth()
        {
            coordinates += Coordinates.up;
            spriteRenderer.color = cellDepthColors[coordinates.z];
        }
    }
}