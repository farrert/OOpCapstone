using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapStone.ViewModels.GameViewModel;

namespace CapStone.Models
{
    public class Box : ObservableObject
    {
        #region Enum

            public enum BoxState { Empty, X, O }
            private Dictionary<string, BoxState> CurrentBox = new Dictionary<string, BoxState>()
        {
            { "", BoxState.Empty },
            { "X", BoxState.X },
            { "O", BoxState.O }
        };
            #endregion
            #region Fields

            private bool _checked;
            private int _id;
            private BoxState _state;

        #endregion
        #region PROPERTIES

        public bool Checked
        {
            get { return _checked; }
            set { _checked = value; }
        }

        public int Id
            {
                get { return _id; }
                set
                {
                    _id = value;
                }
            }
            public BoxState State
            {
                get { return _state; }
                set
                {
                    _state = value;
                    OnPropertyChanged(nameof(BoxState));
                }
            }
        #endregion
        #region Constructors
        public Box()
        {

        }
        #endregion
    }
}