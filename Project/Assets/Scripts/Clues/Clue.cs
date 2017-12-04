using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;

/* Clues need to:
 * Always face the camera
 * Be clickable to inspect
 * Each have their own text when inspected
 */
public class Clue : MonoBehaviour {

    [XmlAttribute("ClueName")]
    public string clueName;

    public bool isFound;
    public string clueText;

    //possibly move these to a new script? UI manager?
    public Text targetText;
    public Transform target;
    public Canvas canvas;
    public ClueManager clueManager;

	void Update () {
        //Make sure clue is always facing camera (target)
        transform.LookAt(target);
    }

    void OnMouseDown() {
        canvas.gameObject.SetActive(true);
        gameObject.SetActive(false);
        targetText.text = clueText;
        //clueManager.FoundClue(this);
    }
}
