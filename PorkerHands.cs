// C# program to illustrate the
// Initialization of an object
using System;

// Class Declaration
namespace PlayCard{

		
	public class PorkerHands {

		// Instance Variables
		String[] Black;
		String[] White;
		
		Dictionary<String, int> jqka = new Dictionary<string, int>(){
			{"J", 11}, {"Q", 12}, {"K", 13}, {"A", 14}
		};
		Dictionary<int, String> num2jqka = new Dictionary<int, string>(){
			{11, "J"}, {12, "Q"}, {13, "K"}, {14, "A"}
		};
		// Constructor Declaration of Class
		public PorkerHands()
		{
		
		}

		private int GetInt(String card)
		{
			String num = card.Substring(0, 1).ToUpper();
			bool exist = this.jqka.ContainsKey(num);
			if(exist)
			{
				return this.jqka[num];
			}else{
				return Int32.Parse(num);
			}
		}

		private String GetString(int num)
		{
			bool exist = this.num2jqka.ContainsKey(num);
			if(exist)
			{
				return this.num2jqka[num];
			}else{
				return num.ToString();
			}
		}

		public static Boolean GetStraight(int[] sorted_nums){
			bool isStraight = true;
			for(int i=0; i < sorted_nums.Length-1; i ++){
				if(sorted_nums[i]+1 != sorted_nums[i+1]){
					isStraight = false;
				}
			}
			return isStraight;
		}

		// private String[] GetPairs(String[] sorted_nums){
		// 	String[] consecutive = new string[2]();
		// 	foreach(var i in hand_nums){

		// 	}
		// 	return consecutive;
		// }
		
		
		public String[] Compare(String[] black, String[] white)
		{
			this.Black = black;
			this.White = white;
			String[] winner={"Tie", ""};
			int[] black_num = new int[5];
			for(int i = 0; i< 5; i ++){
				black_num[i] = this.GetInt(this.Black[i]);
			}
			int[] white_num = new int[5];
			for(int i = 0; i< 5; i ++){
				white_num[i] = this.GetInt(this.White[i]);
			}
			Array.Sort(black_num);
			Array.Sort(white_num);

			// High Card
			for(int i = 4; -1 < i ; i--){
				if(black_num[i]>white_num[i]){
					winner[0] = "Black";
					winner[1] = "high card:" + this.GetString(black_num[i]);
					break;
				}else if(black_num[i]<white_num[i]){
					winner[0] = "White";
					winner[1] = "high card:" + this.GetString(white_num[i]);
					break;
				}else{
					continue;
				}
			}
			// Pair
			foreach(var i in black){

			}
			// Two Pairs

			// Three of a Kind, 33312

 			// Straight, A2345

			// Flush, AH2H4H6H8H

			// Full House, 33322

			// Four of a kind, 33332

			// Straight flush, AH2H3H4H5H

			// Console.WriteLine("[{0}]", string.Join(", ", black_num));
			// Console.WriteLine("[{0}]", string.Join(", ", white_num));
			// winner = "Black";
			return winner;
		}
		

		// Method 1
		public String ToString()
		{
			return ("Black is:" + string.Join(", ", this.Black) + "\nWhite is:" + string.Join(", ", this.White));
		}

	// Main Method
	public static void Main(String[] args)
		{
			
	// Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C AH

			// Creating object
			String[][] black = new String[][]{
				new String[]{"2H", "3D", "5S", "9C", "KD"},
				new String[]{"2H", "4S", "4C" ,"2D", "4H"},
				new String[]{"2H", "3D", "5S", "9C", "KD"}, 
				new String[]{"2H", "3D" ,"5S" ,"9C", "KD"}};
			String[][] white = new String[][]{
				new String[]{"2C", "3H", "8C", "AH", "4S"},
				new String[]{"2S", "8S", "AS", "QS", "3S"}, 
				new String[]{"2C", "3H", "4S", "8C", "KH"}, 
				new String[]{"2D", "3H", "5C", "9S", "KH"}};

			for(int i=0 ; i < black.Length; i++){
				PorkerHands pokerHands = new PorkerHands();
				String[] winner = pokerHands.Compare(black[i], white[i]);
				
				Console.WriteLine(pokerHands.ToString());
				if(winner[0] == "Tie"){
					Console.WriteLine($"{winner[0]}.\n");
				}else{
					Console.WriteLine($"{winner[0]} wins. - with {winner[1]}\n");
				}
			}
		}
	}
}