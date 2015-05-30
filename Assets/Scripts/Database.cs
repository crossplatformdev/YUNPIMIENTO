using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Database : MonoBehaviour{
	
	
	public List<CardLogic> events = new List<CardLogic>();
	public List<CardLogic> locations = new List<CardLogic>();
	public List<CardLogic> consecuences = new List<CardLogic>();
	
	public List<CardLogic> locsycons = new List<CardLogic>();

	
	void Awake(){
	
		events.Add(new CardLogic("eve", 1, "infarto"));
		events.Add(new CardLogic("eve", 2, "palmada"));
		events.Add(new CardLogic("eve", 3, "zombies"));
		events.Add(new CardLogic("eve", 4, "jesucristo"));
		events.Add(new CardLogic("eve", 5, "atraco"));
		events.Add(new CardLogic("eve", 6, "perros"));
		events.Add(new CardLogic("eve", 7, "policia"));	
		
		locations.Add(new CardLogic("loc", 1, "barAmigos"));
		locations.Add(new CardLogic("loc", 2, "barOsos"));
		locations.Add(new CardLogic("loc", 3, "cementerio"));
		locations.Add(new CardLogic("loc", 4, "iglesia"));
		locations.Add(new CardLogic("loc", 5, "calle"));
		locations.Add(new CardLogic("loc", 6, "hospital"));
		locations.Add(new CardLogic("loc", 7, "multitud"));
		
		consecuences.Add(new CardLogic("con", 1, "ambulancia"));
		consecuences.Add(new CardLogic("con", 2, "huyendo"));
		consecuences.Add(new CardLogic("con", 3, "motosierra"));
		consecuences.Add(new CardLogic("con", 4, "confesarse"));
		consecuences.Add(new CardLogic("con", 5, "superman"));
		consecuences.Add(new CardLogic("con", 6, "arbol"));
		consecuences.Add(new CardLogic("con", 7, "carcel"));


		for (int i = 0; i < locations.Count; i++){
			locsycons.Add(locations[i]);
		}
		for (int i = 0; i < consecuences.Count; i++){
			locsycons.Add(consecuences[i]);
		}

		
		
		StartParsing();
	
	}
	
	public TextAsset csvFile;
	
	
	public void StartParsing()
	{
		string[,] grid = SplitCsvGrid(csvFile.text);
		Debug.Log("size = " + (1+ grid.GetUpperBound(0)) + "," + (1 + grid.GetUpperBound(1))); 
		
		DebugOutputGrid(grid); 
		//data = grid;
		MakeCards(grid);
		//DebugDatabase();
	}
	
	// outputs the content of a 2D array, useful for checking the importer
	static public void DebugOutputGrid(string[,] grid)
	{
		string textOutput = ""; 
		for (int y = 0; y < grid.GetUpperBound(1); y++) {	
			for (int x = 0; x < grid.GetUpperBound(0); x++) {
				
				textOutput += grid[x,y]; 
				textOutput += "|"; 
			}
			textOutput += "\n"; 
		}
		Debug.Log(textOutput);
		//Debug.Log(" a ");
	}
	
	// splits a CSV file into a 2D string array
	static public string[,] SplitCsvGrid(string csvText)
	{
		string[] lines = csvText.Split("\n"[0]); 
		
		// finds the max width of row
		int width = 0; 
		for (int i = 0; i < lines.Length; i++)
		{
			string[] row = SplitCsvLine( lines[i] ); 
			width = Mathf.Max(width, row.Length); 
		}
		
		// creates new 2D string grid to output to
		string[,] outputGrid = new string[width + 1, lines.Length + 1]; 
		for (int y = 0; y < lines.Length; y++)
		{
			string[] row = SplitCsvLine( lines[y] ); 
			for (int x = 0; x < row.Length; x++) 
			{
				outputGrid[x,y] = row[x]; 
				
				// This line was to replace "" with " in my output. 
				// Include or edit it as you wish.
				outputGrid[x,y] = outputGrid[x,y].Replace("\"\"", "\"");
			}
		}
		
		return outputGrid; 
	}
	
	// splits a CSV row 
	static public string[] SplitCsvLine(string line){
		/*return (from System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(line,
		                                                                                                    @"(((?<x>(?=[,\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^,\r\n]+)),?)", 
		                                                                                                    System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
		        select m.Groups[1].Value).ToArray();*/
		string[] temp = line.Split(","[0]); 
		
		
		
		
		return temp;
	}
	
	
	public void MakeCards(string[,] data){
		int yPrevias = 0;
		int yPosteriores = 0;
				
		for (int y = 0; y < data.GetUpperBound(1); y++) {	
			for (int x = 0; x < data.GetUpperBound(0); x++) {
				if (data[x,y] == "PREVIAS"){
					yPrevias = y;	
					//Debug.Log (y);
				}
				if (data[x,y] == "POSTERIORES"){
					yPosteriores = y;	
					//Debug.Log (y);
				}			
			}
		}
		/*string[,] subArray = new string[data.GetUpperBound (0),yPosteriores - yPrevias];	
		int i = 0;
		int j = 0;	
		for (int y = yPrevias; y < yPosteriores; y++) {	
			j++;
			for (int x = 0; x < data.GetUpperBound(0); x++) {
				i++;
				subArray[i,j] = data[x,y];
			}			
		}
		
		*/
		
		for (int j = 0; j<7; j++){
			for (int i = 0; i < data.GetUpperBound(0)-3; i++){
				Debug.Log(data[i+2,yPrevias+1+j]);
				events[j].SetPuntPrevia(i,int.Parse(data[i+2,yPrevias+1+j]));
			}
		}
		
		
		for (int j = 0; j<7; j++){
			for (int i = 0; i < data.GetUpperBound(0)-3; i++){
				Debug.Log(data[i+2,yPosteriores+1+j]);
				events[j].SetPuntPosterior(i,int.Parse(data[i+2,yPosteriores+1+j]));
			}
		}
		//Debug.Log(events[0].puntPrevias[0]);

		/*
		subArray = new string[data.GetUpperBound (0),yEvents];		
		for (int y = yPlays; y < yEvents; y++) {	
			for (int x = 0; x < data.GetUpperBound(0); x++) {
				subArray[x,y] = data[x,y];
			}			
		}

		
		subArray = new string[data.GetUpperBound (0),yTrainers];		
		for (int y = yEvents; y < yTrainers; y++) {	
			for (int x = 0; x < data.GetUpperBound(0); x++) {
				subArray[x,y] = data[x,y];
			}			
		}
	
		
		subArray = new string[data.GetUpperBound (0),data.GetUpperBound (1)];		
		for (int y = yTrainers; y < data.GetUpperBound(1); y++) {	
			for (int x = 0; x < data.GetUpperBound(0); x++) {
				subArray[x,y] = data[x,y];
			}			
		}
		*/
		
		
	}

	/*
	public void MakeCharacters(string[,] data){
		//Debug.Log(data[0,21]);
		for (int y = 0; y<data.GetUpperBound(1); y++){
			//Card aux;
			//for (int x = 0; x<data.GetUpperBound(0); x++){
			if (data[0,y]!=null && data[0,y] !="CHARACTERS" && data[0,y].Length >0) {
				//Debug.Log(data[0,y]+data[1,y]+data[2,y]+data[3,y]);
				Card aux = new Card(data[0,y],data[1,y],data[2,y],data[3,y],data[4,y],data[5,y],data[6,y],data[7,y],data[8,y],data[9,y],data[10,y]);
				database.Add (aux);
				characters.Add (aux);	
			}					
		}
		
	}
	
	public void MakePlays(string[,] data){
		//Debug.Log(data[0,21]);
		for (int y = 0; y<data.GetUpperBound(1); y++){
			//Card aux;
			//for (int x = 0; x<data.GetUpperBound(0); x++){
			if (data[0,y]!=null && data[0,y] !="PLAYS" && data[0,y].Length >0) {
				//Debug.Log(data[0,y]+data[1,y]+data[2,y]+data[3,y]);
				Card aux = new Card(data[0,y],data[1,y],data[2,y],data[3,y],data[4,y],data[5,y],"0",data[7,y],data[8,y],data[9,y],data[10,y]);
				database.Add (aux);
				plays.Add (aux);	
			}					
		}
		
	}
	
	
	public void MakeEvents(string[,] data){
		//Debug.Log(data[0,21]);
		for (int y = 0; y<data.GetUpperBound(1); y++){
			//Card aux;
			//for (int x = 0; x<data.GetUpperBound(0); x++){
			if (data[0,y]!=null && data[0,y] !="EVENTS" && data[0,y].Length >0) {
				//Debug.Log(data[0,y]+data[1,y]+data[2,y]+data[3,y]);
				Card aux = new Card(data[0,y],data[1,y],data[2,y],data[3,y],data[4,y],data[5,y],"0",data[7,y],data[8,y],data[9,y],data[10,y]);
				database.Add (aux);
				events.Add (aux);	
			}					
		}
		
	}
	
	public void MakeTrainers(string[,] data){
		//Debug.Log(data[0,21]);
		for (int y = 0; y<data.GetUpperBound(1); y++){
			//Card aux;
			//for (int x = 0; x<data.GetUpperBound(0); x++){
			if (data[0,y]!=null && data[0,y] !="TRAINER" && data[0,y].Length >0) {
				//Debug.Log(data[0,y]+data[1,y]+data[2,y]+data[3,y]);
				Debug.Log(data[0,y]);
				Card aux = new Card(data[0,y],data[1,y],data[2,y],data[3,y],data[4,y],data[5,y],"0",data[7,y],data[8,y],data[9,y],data[10,y]);
				database.Add (aux);
				trainer.Add (aux);	
			}					
		}
		
	}
	
	
	*/
	/*
	public void DebugDatabase(){
		for (int i = 0; i<database.Count; i++){
			Debug.Log (database[i].name + database[i].stars);
		}
	}
	*/
}
