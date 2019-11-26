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
using static CapStone.Models.Box;

namespace CapStone.ViewModels
{
    public class GameViewModel : ObservableObject
    {
        #region Commands

        public ICommand BoxChangeCommand { get; set; }
        public ICommand GameLogicCommand { get; set; }

        #endregion
        #region  Fields

        private ObservableCollection<Box> _board;
        private BoxState _getState;
        private Box _currentBox;
        public bool Checked = false;

        #endregion
        #region Properties

        public Box BoxChange
        {
             get; set; 
        }
        //public ObservableCollection<Box> Board
        //{
        //    get { return _board; }
        //    set { _board = value; }
        //}
        private Box CurrentBox { get; set; }
        public BoxState GetState
        {
            get { return _getState; }
            set
            {
                _getState = value;
                // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("X"));
            }
        }
        #endregion
        private string _displayContent = "";
        

        public string DisplayContent
        {
            get { return _displayContent; }
            set
            {
                _displayContent = value;
                OnPropertyChanged("DisplayContent");
            }
        }
        public GameViewModel()
        {
            InitializeViewModel();
        }
        private void InitializeViewModel() => BoxChangeCommand = new RelayCommand(new Action<object>(GetUpdateBox()));
        //GameLogicCommand = new RelayCommand(new Action(CheckConditions));

        //private void UpdateBox(object obj)
        //{
        //    if (obj.ToString() == "X")
        //    {
        //        DisplayContent = obj.ToString();
        //    }
        //    else DisplayContent = "X";
        //}
            public Action<object> GetUpdateBox()
        {
            return UpdateBox;
        }

        private void UpdateBox(Object obj)
        {
            _currentBox = new Box();
            _currentBox.State = BoxState.X;
            OnPropertyChanged("DisplayContent");
            _displayContent = "X";
            if (obj.ToString() != "X" || obj.ToString() != "O")
            {
                obj = "X";

            }
        }
        private void OnBoxChange()
        {
            if (_currentBox == null)
            {
                _currentBox = new Box();
                _currentBox.State = BoxState.X;
               // PropertyChanged("BoxChange");
            }
        }
        //private void Button_Click(object sender, RoutedEventArgs e) => UpdateBox(this);
        private void CheckConditions(object obj)
        {

        }
    }


}
