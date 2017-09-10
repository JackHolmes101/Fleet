using Assets.Code.Common.WorldObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEvent
{

}

public class SelectionEvent : GameEvent
{

    public List<Entity> selection { get; private set; }

    public SelectionEvent(List<Entity> selection)
    {
        this.selection = selection;
    }
}

public class StartSelectBoxEvent : GameEvent
{

    public Vector3 anchor { get; private set; }

    public StartSelectBoxEvent(Vector3 anchor)
    {
        this.anchor = anchor;
    }
}

public class DragSelectBoxEvent : GameEvent
{

    public Vector3 outer { get; private set; }

    public DragSelectBoxEvent(Vector3 outer)
    {
        this.outer = outer;
    }
}
