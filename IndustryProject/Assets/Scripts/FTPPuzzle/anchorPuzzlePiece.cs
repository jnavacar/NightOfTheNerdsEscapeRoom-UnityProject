﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anchorPuzzlePiece : MonoBehaviour
{
    private movePuzzlePiece key;
    public movePuzzlePiece occupyingPiece;
    [SerializeField] RectTransform thisAnchor;

    private void Start()
    {
        key = FindObjectOfType<movePuzzlePiece>();
        thisAnchor = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Vector2 mousePos = thisAnchor.InverseTransformPoint(Input.mousePosition);
        if (thisAnchor.rect.Contains(mousePos) && key.isBeingHeld)
        {
            key.AnchorPiece(thisAnchor);
            //Debug.Log("works");
        }
        if (key.anchor == thisAnchor)
        {
            occupyingPiece = key;
        }
        else
        {
            occupyingPiece = null;
        }
    }

    #region old code
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (occupyingPiece==null)
        //{
        //    Debug.Log("trigger enter" + this.GetInstanceID());
        //    if (collision.TryGetComponent(out movePuzzlePiece piece))
        //    {
        //        piece.AnchorPiece(new Vector3(transform.position.x, transform.position.y, 0));
        //        occupyingPiece = piece.GetComponent<movePuzzlePiece>();
        //    }
        //}
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        //if (collision.TryGetComponent(out movePuzzlePiece piece))
        //{
        //    piece.unAnchor();
        //}
        //if (collision.GetComponent<movePuzzlePiece>() == occupyingPiece)
        //{
        //    occupyingPiece = null;
        //    Debug.Log("trigger exit " + this.GetInstanceID());
        //}
        
    }
    #endregion
}
