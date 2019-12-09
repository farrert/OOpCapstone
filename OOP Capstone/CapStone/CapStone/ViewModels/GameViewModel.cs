﻿using System;
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

        public ICommand BoxChangeCommand { get; set; }

        #endregion

        #region Enums

        #endregion

        #region  Fields

        ObservableCollection<Box> _boxes;
        private List<Box> _boardState;
        private Box _currentBox;
        private bool MyTurn = true;
        public int _pos;
        private int _XWins;
        private int _OWins;
        Random rnd = new Random();
        private int move;
        #region ugly textbox fields
        private string _m0;
        private string _m1;
        private string _m2;
        private string _m3;
        private string _m4;
        private string _m5;
        private string _m6;
        private string _m7;
        private string _m8;
        private string _m9;
        private string _m10;
        private string _m11;
        private string _m12;
        private string _m13;
        private string _m14;
        private string _m15;
        #endregion
        #endregion

        #region Properties
        #region ugly textbox properties
        public string M0
        {
            get { return _m0; }
            set
            {
                _m0 = value;
                OnPropertyChanged("M0");
            }
        }
        public string M1
        {
            get { return _m1; }
            set
            {
                _m1 = value;
                OnPropertyChanged("M1");
            }
        }
        public string M2
        {
            get { return _m2; }
            set
            {
                _m2 = value;
                OnPropertyChanged("M2");
            }
        }
        public string M3
        {
            get { return _m3; }
            set
            {
                _m3 = value;
                OnPropertyChanged("M3");
            }
        }
        public string M4
        {
            get { return _m4; }
            set
            {
                _m4 = value;
                OnPropertyChanged("M4");
            }
        }
        public string M5
        {
            get { return _m5; }
            set
            {
                _m5 = value;
                OnPropertyChanged("M5");
            }
        }
        public string M6
        {
            get { return _m6; }
            set
            {
                _m6 = value;
                OnPropertyChanged("M6");
            }
        }
        public string M7
        {
            get { return _m7; }
            set
            {
                _m7 = value;
                OnPropertyChanged("M7");
            }
        }
        public string M8
        {
            get { return _m8; }
            set
            {
                _m8 = value;
                OnPropertyChanged("M8");
            }
        }
        public string M9
        {
            get { return _m9; }
            set
            {
                _m9 = value;
                OnPropertyChanged("M9");
            }
        }
        public string M10
        {
            get { return _m10; }
            set
            {
                _m10 = value;
                OnPropertyChanged("M10");
            }
        }
        public string M11
        {
            get { return _m11; }
            set
            {
                _m11 = value;
                OnPropertyChanged("M11");
            }
        }
        public string M12
        {
            get { return _m12; }
            set
            {
                _m12 = value;
                OnPropertyChanged("M12");
            }
        }
        public string M13
        {
            get { return _m13; }
            set
            {
                _m13 = value;
                OnPropertyChanged("M13");
            }
        }
        public string M14
        {
            get { return _m14; }
            set
            {
                _m14 = value;
                OnPropertyChanged("M14");
            }
        }
        public string M15
        {
            get { return _m15; }
            set
            {
                _m15 = value;
                OnPropertyChanged("M15");
            }
        }
        #endregion
        public int XWins
        {
            get { return _XWins; }
            set
            {
                _XWins = value;
                OnPropertyChanged(nameof(XWins));
            }
        }
        public int OWins
        {
            get { return _OWins; }
            set
            {
                _OWins = value;
                OnPropertyChanged(nameof(OWins));
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
        public int Pos
        {
            get { return _pos; }
            set
            {
                _pos = value;
                OnPropertyChanged("Pos");
            }
        }
        public List<Box> BoardState
        {
            get { return _boardState; }
            set
            {
                _boardState = value;
                OnPropertyChanged("BoardState");
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
        /// <summary>
        /// Makes a new board
        /// </summary>
        private void MakeBoard()
        {
            BoardState = new List<Box>(16);

            for (var i = 0; i < 17; i++)
            {
                _currentBox = new Box();
                _currentBox.Pos = i;
                _currentBox.State = Box.BoxState.Empty;
                _boardState.Add(_currentBox);
            }
        }
        /// <summary>
        /// Turns unused selected box into one with X in it and displays
        /// </summary>
        /// <param name="obj"></param>
        private void UpdateBox(object obj)
        {
            if (MyTurn)
            {
                if (int.TryParse(obj.ToString(), out _pos))
                {
                    foreach (Box _currentBox in BoardState)
                    {
                        if (_currentBox.Pos == _pos)
                        {
                            _currentBox.State = Box.BoxState.X;
                            switch (_currentBox.Pos)
                            {
                                case 0:
                                    if (M0 == null)
                                    {
                                        M0 = _currentBox.State.ToString();
                                        MyTurn = false;
                                    }
                                    break;
                                case 1:
                                    if (M1 == null)
                                    {
                                        M1 = _currentBox.State.ToString();
                                        MyTurn = false;
                                    }
                                    break;
                                case 2:
                                    if (M2 == null)
                                    {
                                        M2 = _currentBox.State.ToString();
                                        MyTurn = false;
                                    }
                                    break;
                                case 3:
                                    if (M3 == null)
                                    {
                                        M3 = _currentBox.State.ToString();
                                        MyTurn = false;
                                    }
                                    break;
                                case 4:
                                    if (M4 == null)
                                    {
                                        M4 = _currentBox.State.ToString();
                                        MyTurn = false;
                                    }
                                    break;
                                case 5:
                                    if (M5 == null)
                                    {
                                        M5 = _currentBox.State.ToString();
                                        MyTurn = false;
                                    }
                                    break;
                                case 6:
                                    if (M6 == null)
                                    {
                                        M6 = _currentBox.State.ToString();
                                        MyTurn = false;
                                    }
                                    break;
                                case 7:
                                    if (M7 == null)
                                    {
                                        M7 = _currentBox.State.ToString();
                                        MyTurn = false;
                                    }
                                    break;
                                case 8:
                                    if (M8 == null)
                                    {
                                        M8 = _currentBox.State.ToString();
                                        MyTurn = false;
                                    }
                                    break;
                                case 9:
                                    if (M9 == null)
                                    {
                                        M9 = _currentBox.State.ToString();
                                        MyTurn = false;
                                    }
                                    break;
                                case 10:
                                    if (M10 == null)
                                    {
                                        M10 = _currentBox.State.ToString();
                                        MyTurn = false;
                                    }
                                    break;
                                case 11:
                                    if (M11 == null)
                                    {
                                        M11 = _currentBox.State.ToString();
                                        MyTurn = false;
                                    }
                                    break;
                                case 12:
                                    if (M12 == null)
                                    {
                                        M12 = _currentBox.State.ToString();
                                        MyTurn = false;
                                    }
                                    break;
                                case 13:
                                    if (M13 == null)
                                    {
                                        M13 = _currentBox.State.ToString();
                                        MyTurn = false;
                                    }
                                    break;
                                case 14:
                                    if (M14 == null)
                                    {
                                        M14 = _currentBox.State.ToString();
                                        MyTurn = false;
                                    }
                                    break;
                                case 15:
                                    if (M15 == null)
                                    {
                                        M15 = _currentBox.State.ToString();
                                        MyTurn = false;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    };
                }
            };
            if (!MyTurn)
            {
                CheckConditions();
                OpponentTurn();
                CheckConditions();
            }
        }
        public Action<object> GetUpdateBox()
        {
            return UpdateBox;
        }
        /// <summary>
        /// Changes an unmarked box into an O and displays
        /// </summary>
        private void OpponentTurn()
        {
            while (!MyTurn)
            {
                move = rnd.Next(0, 16);
                _currentBox.Pos = move;
                foreach (Box _currentBox in BoardState)
                {
                    if (_currentBox.Pos == move)
                    {
                        _currentBox.State = Box.BoxState.O;
                        switch (_currentBox.Pos)
                        {
                            case 0:
                                if (M0 == null)
                                {
                                    M0 = _currentBox.State.ToString();
                                    MyTurn = true;
                                }
                                break;
                            case 1:
                                if (M1 == null)
                                {
                                    M1 = _currentBox.State.ToString();
                                    MyTurn = true;
                                }
                                break;
                            case 2:
                                if (M2 == null)
                                {
                                    M2 = _currentBox.State.ToString();
                                    MyTurn = true;
                                }
                                break;
                            case 3:
                                if (M3 == null)
                                {
                                    M3 = _currentBox.State.ToString();
                                    MyTurn = true;
                                }
                                break;
                            case 4:
                                if (M4 == null)
                                {
                                    M4 = _currentBox.State.ToString();
                                    MyTurn = true;
                                }
                                break;
                            case 5:
                                if (M5 == null)
                                {
                                    M5 = _currentBox.State.ToString();
                                    MyTurn = true;
                                }
                                break;
                            case 6:
                                if (M6 == null)
                                {
                                    M6 = _currentBox.State.ToString();
                                    MyTurn = true;
                                }
                                break;
                            case 7:
                                if (M7 == null)
                                {
                                    M7 = _currentBox.State.ToString();
                                    MyTurn = true;
                                }
                                break;
                            case 8:
                                if (M8 == null)
                                {
                                    M8 = _currentBox.State.ToString();
                                    MyTurn = true;
                                }
                                break;
                            case 9:
                                if (M9 == null)
                                {
                                    M9 = _currentBox.State.ToString();
                                    MyTurn = true;
                                }
                                break;
                            case 10:
                                if (M10 == null)
                                {
                                    M10 = _currentBox.State.ToString();
                                    MyTurn = true;
                                }
                                break;
                            case 11:
                                if (M11 == null)
                                {
                                    M11 = _currentBox.State.ToString();
                                    MyTurn = true;
                                }
                                break;
                            case 12:
                                if (M12 == null)
                                {
                                    M12 = _currentBox.State.ToString();
                                    MyTurn = true;
                                }
                                break;
                            case 13:
                                if (M13 == null)
                                {
                                    M13 = _currentBox.State.ToString();
                                    MyTurn = true;
                                }
                                break;
                            case 14:
                                if (M14 == null)
                                {
                                    M14 = _currentBox.State.ToString();
                                    MyTurn = true;
                                }
                                break;
                            case 15:
                                if (M15 == null)
                                {
                                    M15 = _currentBox.State.ToString();
                                    MyTurn = true;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// checks for a win on either side in any way
        /// </summary>
        private void CheckConditions()
        {
            if (M0 == Box.BoxState.X.ToString() && M1 == Box.BoxState.X.ToString() && M2 == Box.BoxState.X.ToString() && M3 == Box.BoxState.X.ToString())
            {
                XWins++;
                ClearBoard();
                MakeBoard();
            }
            if (M4 == Box.BoxState.X.ToString() && M5 == Box.BoxState.X.ToString() && M6 == Box.BoxState.X.ToString() && M7 == Box.BoxState.X.ToString())
            {
                XWins++;
                ClearBoard();
                MakeBoard();
            }
            if (M8 == Box.BoxState.X.ToString() && M9 == Box.BoxState.X.ToString() && M10 == Box.BoxState.X.ToString() && M11 == Box.BoxState.X.ToString())
            {
                XWins++;
                ClearBoard();
                MakeBoard();
            }
            if (M12 == Box.BoxState.X.ToString() && M13 == Box.BoxState.X.ToString() && M14 == Box.BoxState.X.ToString() && M15 == Box.BoxState.X.ToString())
            {
                XWins++;
                ClearBoard();
                MakeBoard();
            }
            if (M0 == Box.BoxState.X.ToString() && M4 == Box.BoxState.X.ToString() && M8 == Box.BoxState.X.ToString() && M12 == Box.BoxState.X.ToString())
            {
                XWins++;
                ClearBoard();
                MakeBoard();
            }
            if (M1 == Box.BoxState.X.ToString() && M5 == Box.BoxState.X.ToString() && M9 == Box.BoxState.X.ToString() && M13 == Box.BoxState.X.ToString())
            {
                XWins++;
                ClearBoard();
                MakeBoard();
            }
            if (M2 == Box.BoxState.X.ToString() && M6 == Box.BoxState.X.ToString() && M10 == Box.BoxState.X.ToString() && M14 == Box.BoxState.X.ToString())
            {
                XWins++;
                ClearBoard();
                MakeBoard();
            }
            if (M3 == Box.BoxState.X.ToString() && M7 == Box.BoxState.X.ToString() && M11 == Box.BoxState.X.ToString() && M15 == Box.BoxState.X.ToString())
            {
                XWins++;
                ClearBoard();
                MakeBoard();
            }
            if (M0 == Box.BoxState.X.ToString() && M5 == Box.BoxState.X.ToString() && M10 == Box.BoxState.X.ToString() && M15 == Box.BoxState.X.ToString())
            {
                XWins++;
                ClearBoard();
                MakeBoard();
            }
            if (M3 == Box.BoxState.X.ToString() && M6 == Box.BoxState.X.ToString() && M9 == Box.BoxState.X.ToString() && M12 == Box.BoxState.X.ToString())
            {
                XWins++;
                ClearBoard();
                MakeBoard();
            }
            if (M0 == Box.BoxState.O.ToString() && M1 == Box.BoxState.O.ToString() && M2 == Box.BoxState.O.ToString() && M3 == Box.BoxState.O.ToString())
            {                      
                OWins++;           
                ClearBoard();      
                MakeBoard();       
            }                      
            if (M4 == Box.BoxState.O.ToString() && M5 == Box.BoxState.O.ToString() && M6 == Box.BoxState.O.ToString() && M7 == Box.BoxState.O.ToString())
            {
                OWins++;
                ClearBoard();
                MakeBoard();
            }
            if (M8 == Box.BoxState.O.ToString() && M9 == Box.BoxState.O.ToString() && M10 == Box.BoxState.O.ToString() && M11 == Box.BoxState.O.ToString())
            {
                OWins++;
                ClearBoard();
                MakeBoard();
            }
            if (M12 == Box.BoxState.O.ToString() && M13 == Box.BoxState.O.ToString() && M14 == Box.BoxState.O.ToString() && M15 == Box.BoxState.O.ToString())
            {
                OWins++;
                ClearBoard();
                MakeBoard();
            }
            if (M0 == Box.BoxState.O.ToString() && M4 == Box.BoxState.O.ToString() && M8 == Box.BoxState.O.ToString() && M12 == Box.BoxState.O.ToString())
            {
                OWins++;
                ClearBoard();
                MakeBoard();
            }
            if (M1 == Box.BoxState.O.ToString() && M5 == Box.BoxState.O.ToString() && M9 == Box.BoxState.O.ToString() && M13 == Box.BoxState.O.ToString())
            {
                OWins++;
                ClearBoard();
                MakeBoard();
            }
            if (M2 == Box.BoxState.O.ToString() && M6 == Box.BoxState.O.ToString() && M10 == Box.BoxState.O.ToString() && M14 == Box.BoxState.O.ToString())
            {
                OWins++;
                ClearBoard();
                MakeBoard();
            }
            if (M3 == Box.BoxState.O.ToString() && M7 == Box.BoxState.O.ToString() && M11 == Box.BoxState.O.ToString() && M15 == Box.BoxState.O.ToString())
            {
                OWins++;
                ClearBoard();
                MakeBoard();
            }
            if (M0 == Box.BoxState.O.ToString() && M5 == Box.BoxState.O.ToString() && M10 == Box.BoxState.O.ToString() && M15 == Box.BoxState.O.ToString())
            {
                OWins++;
                ClearBoard();
                MakeBoard();
            }
            if (M3 == Box.BoxState.O.ToString() && M6 == Box.BoxState.O.ToString() && M9 == Box.BoxState.O.ToString() && M12 == Box.BoxState.O.ToString())
            {
                OWins++;
                ClearBoard();
                MakeBoard();
            }
            if (M0 != null && M1 != null && M2 != null && M3 != null && M4 != null && M5 != null && M6 != null && M7 != null && M8 != null && M9 != null && M10 != null && M11 != null && M12 != null && M13 != null && M14 != null && M15 != null)
            {
                ClearBoard();
                MakeBoard();
            }
        }
        private void ClearBoard()
        {
            BoardState.Clear();
            M0 = null;
            M1 = null;
            M2 = null;
            M3 = null;
            M4 = null;
            M5 = null;
            M6 = null;
            M7 = null;
            M8 = null;
            M9 = null;
            M10 = null;
            M11 = null;
            M12 = null;
            M13 = null;
            M14 = null;
            M15 = null;
        }
        #endregion
    }
}
