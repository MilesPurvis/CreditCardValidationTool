/*
 * Program -  Application 2 credit card validation
 * 
 * Purpose - validate if credit card numbers are numeric and if card is valid.
 * 
 * Revision History: 
 * Created by Miles Purvis and Gabriel Siewart
 * November - 15 2022
 * 
 */
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inClass5MPGSA2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declare cardNumber string and bool validateCard
            string cardNumber;
            bool validateCard = true;

            //Take users input for cardNumber
            Console.WriteLine("[Enter your credit card number]");
            cardNumber = Console.ReadLine();

            //Takes returned value for validate card
            validateCard = CreditCard(cardNumber, validateCard);

            //if validateCard is a valid numeric value is true go to the second method.
            // print "all entries are numeric".
            if (validateCard == true)
            {
                Console.WriteLine("\nAll Entries are Numeric");

                CreditCard(cardNumber);

                //if cardNumber is a valid credit card number print coresponding message.
                if (CreditCard(cardNumber) == true)
                {
                    Console.WriteLine("\nThis is a valid card number");
                }
                else
                {
                    Console.WriteLine("\nThis is an Invalid card number");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid Card - Not all Entries are Numeric");
            }

            Console.ReadLine();
    
        }

        //check to ensure all entries for the card are numeric and return true/false
        private static bool CreditCard(string cardNumber, bool validateCard)
        {

            for (int i = 0; i < cardNumber.Length; i++)
            {
                if (!char.IsDigit(cardNumber[i]))
                {
                    validateCard = false;
                    break;
                }
                else
                {
                    validateCard = true;
                }
            }

            return validateCard;
        }

        //Check if the user enterd a vaild card number,  using the modulus 10 algo, and return true / false
        private static bool CreditCard(string cardNumber)
        {
            //Declare Integer Array for cardNumber, total sum and cardValue
            int[] cardNumberArray = new int[cardNumber.Length];
            int total = 0;
            int cardValue = 0;

           //convert cardNumber to an int Array.
            for (int i = 0; i < cardNumber.Length; i++)
            {
                cardNumberArray[i] = (int)cardNumber[i] - '0';
            }

            //Starting from the right of the array, double everyother digit.
            for (int i = cardNumberArray.Length - 2; i >= 0; i = i - 2)
            {
              
                    //store value from array
                    cardValue = cardNumberArray[i];
                    //double it
                    cardValue = cardValue * 2;

                    //If the product is greater than 9, % 10 and add 1.
                    if (cardValue > 9)
                    {
                        cardValue = cardValue % 10 + 1;
                    }

                    //set digit to card value
                    cardNumberArray[i] = cardValue;
              

            }

            //Add each element for the array.
            for (int i = 0; i < cardNumberArray.Length; i++)
            {
                total += cardNumberArray[i];
            }

            //If number is mod 10 has no remainder, it is valid (true)/ else false
            if(total % 10 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
