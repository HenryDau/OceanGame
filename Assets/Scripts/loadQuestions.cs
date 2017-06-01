using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class loadQuestions : MonoBehaviour {
	
	public TextAsset textFile;
	public string[] textLines;


	// Use this for initialization
	void Start () {
		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));
	}

	
}
}
