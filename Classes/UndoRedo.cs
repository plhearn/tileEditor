using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using XNA_Map_Editor.Helpers;

namespace XNA_Map_Editor.Classes
{
    class UndoRedo
    {
        #region Class Fields        

        Deque undo_deque;
        Deque redo_deque;

        public UndoRedo()
        {
            Clear();
        }

        #endregion

        #region Public Methods

        public void Clear()
        {
            undo_deque = new Deque();
            redo_deque = new Deque();
        }

        public bool CanUndo()
        {
            if (undo_deque.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }        
        }

        public bool CanRedo()
        {
            if (redo_deque.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddRedoHistory(Tile[,,] MapState)
        {
            redo_deque.PushFront(MapState.Clone());
        }

        public void AddUndoHistory()
        {
            // Check undo limit first
            if (undo_deque.Count > Constants.UNDO_LIMIT)
            {
                undo_deque.PopBack();
                undo_deque.PushFront(GLB_Data.TileMap.Clone());
            }
            else
            {
                undo_deque.PushFront(GLB_Data.TileMap.Clone());
            }
        }

        public void Undo()
        {
            AddRedoHistory(GLB_Data.TileMap);

            GLB_Data.TileMap = (Tile[,,]) undo_deque.PopFront();            
        }

        public void Redo()
        {
            AddUndoHistory();

            GLB_Data.TileMap = (Tile[,,])redo_deque.PopFront();
        }

        #endregion

        #region Private Methods


        #endregion
    }
}
