using Assets.Code.Common.Architecture;
using Assets.Code.Common.WorldObjects;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController:Controller
{

    private Level level;
    //private Team playerTeam;

    public List<Entity> selection { get; private set; }

    public SelectionController(Level level)
    {
        //this.level = level;
        //selection = new List<Entity>();
        //this.playerTeam = level.playerTeam;
    }

    public void ClearSelection()
    {
        //RemoveAllSelections();

        //EventManager.Instance.TriggerEvent(new SelectionEvent(selection));
    }

    private void AddToSelection(Entity entity)
    {
        //DebugUtil.Assert(entity != null, "Selected object with no entity");

        //selection.Add(entity);

        //entity.transform.Find("Halo").gameObject.SetActive(true);
    }

    private void AddAllWithinBounds()
    {
        //Bounds bounds = SelectUtils.GetViewportBounds(Camera.main, anchor, outer);

        //this.level.playerTeam.ForEach((Entity entity) => {
        //    if (SelectUtils.IsWithinBounds(Camera.main, bounds, entity.transform.position))
        //    {
        //        AddToSelection(entity);
        //    }
        //});
    }

    private void AddSingleEntity()
    {
        //Entity entity = SelectUtils.FindEntityAt(Camera.main, anchor);

        //if (entity != null)
        //{
        //    if (entity.team == level.playerTeam)
        //    {
        //        AddToSelection(entity);
        //    }
        //}
    }

    private void RemoveAllSelections()
    {
        //foreach (Entity entity in selection)
        //{
        //    entity.transform.Find("Halo").gameObject.SetActive(false);
        //}

        //selection.Clear();
    }

    public void SelectEntities()
    {
        //RemoveAllSelections();

        //if (outer == anchor)
        //{
        //    AddSingleEntity();
        //}
        //else
        //{
        //    AddAllWithinBounds();
        //}

        //hasActiveBox = false;

        //EventManager.Instance.TriggerEvent(new SelectionEvent(selection));
    }

    public void CreateBoxSelection()
    {
        
        //hasActiveBox = true;

        //anchor = Input.mousePosition;
        //outer = Input.mousePosition;

        //EventManager.Instance.TriggerEvent(new StartSelectBoxEvent(anchor));
    }

    public void DragBoxSelection()
    {
        //if (hasActiveBox)
        //{
        //    outer = Input.mousePosition;

        //    EventManager.Instance.TriggerEvent(new DragSelectBoxEvent(outer));
        //}
    }
}
