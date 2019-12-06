using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CapStone.Models;
using Demo_NTier_XmlJsonData;
using static CapStone.Models.Box;

namespace CapStone.ViewModels
{
    public class GameViewModel : ObservableObject
    {
        #region Commands

        public ICommand ChangeBoxCommand
        {
            get { return new DelegateCommand(OnChangeBox); }
        }

        public ICommand BoxChangeCommand { get; set; }
        public ICommand GameLogicCommand { get; set; }

        #endregion

        #region Enums
        private enum BoxStatus
        {
            X, O, Empty
        }
        #endregion

        #region  Fields

        ObservableCollection<Box> _boxes;
        private List<Box> _boardState;
        private Box _currentBox;
        private BoxStatus BoxState;
        private bool MyTurn = true;
        public bool Checked = false;
        public int _pos;
        private Box _selectedBox;
        private string _displayContent = "";
        private Box _getState;
        private string _getMark;

        #endregion

        #region Properties

        public string GetMark
        {
            get { return _getMark; }
            set
            {
                _getMark = value;
                OnPropertyChanged("GetMark");
            }
        }
        public ObservableCollection<Box> Boxes
        {
            get { return _boxes; }
            set
            {
                _boxes = value;
                OnPropertyChanged(nameof(Boxes));
            }
        }
        public Box GetState
        {
            get { return _getState; }
            set
            {
                if (_getState == value)
                {
                    return;
                }
                _getState = value;
                OnPropertyChanged("GetState");
            }
        }

        public int Pos
        {
            get { return _pos; }
            set
            {
                _pos = value;
                OnPropertyChanged(nameof(Pos));
            }
        }
        public List<Box> BoardState
        {
            get { return _boardState; }
            set
            {
                _boardState = value;
                OnPropertyChanged(nameof(BoardState));
            }
        }
        public Box CurrentBox
        {
            get { return _currentBox; }
            set
            {
                _currentBox = value;
                OnPropertyChanged("CurrentBox");
            }
        }
        public string DisplayContent
        {
            get { return _displayContent; }
            set
            {
                _displayContent = value;
                OnPropertyChanged("DisplayContent");
            }
        }
        #endregion

        #region Methods
        public GameViewModel()
        {
            InitializeViewModel();
        }
        private void InitializeViewModel()
        {
            MakeBoard();
            BoxChangeCommand = new RelayCommand(new Action<object>(GetUpdateBox()));
        }
        private void MakeBoard()
        {
            BoardState = new List<Box>(16);

            for (var i = 0; i < BoardState.Capacity; i++)
            {
                _currentBox = new Box();
                _currentBox.Pos = i;
                BoardState.Add(_currentBox);

            }
        }
        private void SetBoard(object obj)
        {
            if (int.TryParse(obj.ToString(), out _pos)) ;



        }
        private void UpdateBox(object obj)
        {
            if (MyTurn == true)
            {
                if (int.TryParse(obj.ToString(), out _pos))
                {
                    foreach (Box _currentBox in BoardState)
                    {
                        if (_currentBox.Pos == _pos)
                        {
                            _currentBox.State = Box.BoxState.X;
                            GetMark = "X";
                        }
                    };
                }
            };
        }
        //private string GetMark()
        //{
        //    _currentBox.Mark = _currentBox.State.ToString();
        //    return _currentBox.Mark;
        //}
        private void OnChangeBox()
        {
            if (_currentBox.Mark.Length < 3)
            {
                UpdateSelectedBox();
            }
        }
        public Action<object> GetUpdateBox()
        {

            return UpdateBox;
        }

        private void OnBoxChange()
        {
            if (_currentBox.State.ToString() == "")
            {
                _currentBox.State = Box.BoxState.X;
                OnPropertyChanged("BoxState");
            }
        }
        private string UpdateSelectedBox()
        {

            _currentBox.State = Box.BoxState.X;
            return "X";
        }
        //private void Button_Click(object sender, RoutedEventArgs e) => UpdateBox(this);
        private void CheckConditions(object obj)
        {

        }
        #endregion
    }


}
