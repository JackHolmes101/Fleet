using Assets.Code.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Common.Architecture
{
    public class Engine : MonoBehaviour
    {
        public Level level { get; private set; }

        private SelectionController _selectionController;
        //private CommandController _commandController;
        //private UiController _uiController;
        //private GameOverController _gameOverController;

        // Use this for initialization
        void Start()
        {

        }

        public void Update()
        {
            if (level.IsGameOver())
            {
                //_gameOverController.EndGame();
                return;
            }

            if (Input.GetButtonDown("Fire1"))
            {
                // TODO: do a check to see if its on gui or worldspace?
                //_selectionController.CreateBoxSelection();
            }

            if (Input.GetButtonUp("Fire1"))
            {
                //_selectionController.SelectEntities();
            }

            _selectionController.DragBoxSelection();

            if (Input.GetButtonDown("Fire2"))
            {
                //_commandController.ActionAtPoint(Input.mousePosition);
            }

        }

        public void LoadLevel()//LevelData levelData)
        {
            level.LoadData();//levelData, Teams.One, Teams.Two);

            //_selectionController = new SelectionController(this.level);
            //_commandController = new CommandController(this.level);
            //_uiController = new UiController();
            //_gameOverController = new GameOverController(level);

            //SpawnUtils.SpawnAll(level.teamList);

            //EventManager.Instance.AddListener<SelectionEvent>(OnSelection);
            //EventManager.Instance.AddListener<StartSelectBoxEvent>(OnStartSelectBox);
            //EventManager.Instance.AddListener<DragSelectBoxEvent>(OnDragSelectBox);
        }

        private void OnSelection()//SelectionEvent e)
        {
            //_commandController.selection = e.selection;

            //_uiController.ClearBox();
        }

        private void OnStartSelectBox()//StartSelectBoxEvent e)
        {
            //_uiController.StartSelectBox(e.anchor);
        }

        private void OnDragSelectBox()//DragSelectBoxEvent e)
        {
            //_uiController.DragSelectBox(e.outer);
        }

        private void OnGameOver()//GameOverEvent e)
        {
            //_uiController.ClearAll();
        }
    }
}
