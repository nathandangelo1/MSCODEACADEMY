

using System;

namespace NewRomanNum_CSHARP {//begin namespace
    internal class Program {//begin class
        static void Main(string[] args) {//begin main

            //Console.WriteLine(36 / 10);
            Console.WriteLine($"ToRoman(): {convertToRoman(6449)}");
            Console.WriteLine($"From Roman(): {convertFromRoman("LXXXIII")}"); 

        }


        static int convertFromRoman(string romanNum) {
            int[] values =      { 1000  , 500   , 100   , 50    ,  10  ,   5   ,  1    };
            char[] letters =  { 'M'   , 'D'   , 'C'   , 'L'   , 'X'  ,  'V'  , 'I'   };
            int letterIndex;
            int value;
            int digits = 0;

            //confirm values are uppercase
            romanNum = romanNum.ToUpper();

            //get index of last char in romanNum
            int letterIndex1 = Array.IndexOf(letters, romanNum[romanNum.Length - 1]);
            //get value of the char by matching with its parallel index
            int firstValue = values[letterIndex1];
            //add to tally
            digits += firstValue;

            //if there is more than one char in roman numeral
            if (romanNum.Length > 1) {
                
                //for each remaining index from the end
                for (int i = romanNum.Length - 2; i >= 0; i--) {

                    //get the index of the char[i], followed by its value
                    letterIndex = Array.IndexOf(letters, romanNum[i]);
                    value = values[letterIndex];

                    //if its index is less than or equal to the previous(from the end) index
                    if (letterIndex <= Array.IndexOf(letters, romanNum[i + 1])) {
                        //add it to tally
                        digits += value;
                    } else {
                        //else, subtract it from tally
                        digits -= value;
                    }

                }
            }
            return (digits);
        }


        static string convertToRoman(int num) {
            int[] values =        {   1000 , 900  ,  500  ,  400  ,  100  ,  90  ,  50  ,  40    ,  10   ,    9   ,   5   ,   4   ,   1    };
            string[] letters =    {   "M"  , "CM" ,  "D"  ,  "CD" ,   "C" , "XC" ,  "L" ,  "XL"  ,  "X"  ,  "IX"  ,  "V"  , "IV"  ,  "I"   };
            string roman = "";
            int temp = 0;
            
            //for each index in values[]
            for(int i = 0; i < values.Length; i++) {
                
                //if quotient of num/value is greater than or equal to 1 
                if ((num / values[i]) >= 1){
                    
                    //integer division giving the number of times num can be divided by value
                    temp = num / values[i];

                    //reduce num by (value*temp) (example: 1199 ->199
                    num %= values[i];
                }
                //for temp times
                for(int j = 0; j < temp; j++) {
                    //add letter value to roman
                    roman += letters[i];
                }
                //reset temp
                temp = 0;
            }
            Console.WriteLine("");
            return roman;

        }//end main

    }//end class
}//end namespace

//function convertToRoman(num) {
//    //I = 1;
//    //V = 5;
//    //X = 10;
//    //L = 50;
//    //C = 100;
//    //D = 500;
//    //M = 1000;

//    var values = new Array(1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1);
//    var letters = new Array("M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I");
//    var roman = "";
//    var temp = 0;

//    //for each index in values[]
//    for (var i = 0; i < values.Length; i++) {

//        //if quotient of num/value is greater than or equal to 1 
//        if ((num / values[i]) >= 1) {

//            //integer division giving the number of times num can be divided by value
//            temp = num / values[i];
//            //reduce num by (value*temp) (example: 1199 ->199
//            num %= values[i];
//        }
//        //for temp times
//        for (var j = 0; j < temp; j++) {
//            //add letter value to roman
//            roman += letters[i];
//        }
//        //reset temp
//        temp = 0;
//    }
//    return roman;

//}//end function


//convertToRoman(2);