using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Assignment_1;

class Program
{
    static double totalCost = 0;
    static string? itemChosen = ""; //Null saftey to remove warnings
    static int itemQuantity = 0;
    static bool hasLoyaltycard = false;
    static string? loyaltyCardinput = ""; //Null saftey to remove warnings
    static double loyaltyDiscount = 0;
    static double itemCost = 0;
    static double subTotalCost = 0;
    static double itemDiscount = 0;
    static double taxAmount = 0;

    static string? quantityEntered = ""; //Null saftey to remove warnings
    static void Main(string[] args)
    {
       
        try
        {
            //Choose Product
            Console.WriteLine("Welcome! Please pick an item to buy: \n 1. Fish \n 2. Cat Food \n 3. Dog Food. \n 4. Bird Food");
            itemChosen = Console.ReadLine();

            //Store price if item chosen within menu
            if(itemChosen == "1" || itemChosen.Contains("Fish") || itemChosen.Contains("fish")){
                itemCost = 5.0;           
            }
            else if(itemChosen == "2" || itemChosen.Contains("Cat Food") || itemChosen.Contains("cat food")){
                itemCost = 10.0;            
            }
           else if(itemChosen == "3" || itemChosen.Contains("Dog Food") || itemChosen.Contains("dog food")){
                itemCost = 15.0;            
            }
            else if(itemChosen == "4" || itemChosen.Contains("Bird Food") || itemChosen.Contains("bird food")){
                itemCost = 18.0;
            }
            //error
            else {
                Console.WriteLine("Invalid Item Name or Number. Please Restart the Application and try again.");
                System.Environment.Exit(1);
               
            }

            Console.WriteLine("Enter the quantity you want to purchase!");
            
            //In order to check if user enetered, added a string variable to readline and then assigned it to int variable itemQuantity
            quantityEntered = Console.ReadLine();
            if(quantityEntered == "" || int.Parse(quantityEntered!) <=0){
                Console.WriteLine("Invalid Quantity. Please Restart the Application");
                System.Environment.Exit(1);
            }
            else {
                 itemQuantity = int.Parse(quantityEntered!);
                
            }

            //Check if user has loyalty membership
            Console.WriteLine("Do you have a loyalty card? \n 1. Yes \n 2. No");
            loyaltyCardinput = Console.ReadLine();
            if(loyaltyCardinput == "1" || loyaltyCardinput!.Contains("Yes") || loyaltyCardinput.Contains("yes")){
                hasLoyaltycard = true;          
            }
            
            //total Cost Before discounts
            subTotalCost = itemQuantity * itemCost;

            //Calculate Discounts
            //Quantity > or = 3 for fish, apply 10% discount
            if((itemChosen == "1" || itemChosen == "Fish" || itemChosen == "fish") && itemQuantity >= 3){
                itemDiscount = subTotalCost * 0.10;
                calculateTotalPrice(subTotalCost, itemDiscount, hasLoyaltycard); 
            }
            //1 bag free for 5 bags of cat food
            else if ((itemChosen == "2" || itemChosen == "Cat Food" || itemChosen.Contains("cat food")) && itemQuantity >= 5){
                itemQuantity++;
                itemDiscount = 10; //Price for 1 cat food bag
                calculateTotalPrice(subTotalCost, itemDiscount, hasLoyaltycard);
            }

            else if ((itemChosen == "3" || itemChosen == "Dog Food" || itemChosen.Contains("dog food")) && itemQuantity >= 3){
                itemDiscount = 15/2;
                calculateTotalPrice(subTotalCost, itemDiscount, hasLoyaltycard);
            }
            else if (itemQuantity >=2) {
                itemDiscount = subTotalCost * 0.05;
                calculateTotalPrice(subTotalCost, itemDiscount, hasLoyaltycard);
            }
            else {
                Console.WriteLine("Invalid Item Name or Number. Please Restart the Application and try again.");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        //Calculate total price by minusing discounts and added tax
        static void calculateTotalPrice (double subTotalCost, double itemDiscount, bool loyalty){
            string discountGiven = "";
            taxAmount = subTotalCost * 0.13;
            taxAmount = Math.Round(taxAmount,2);
            
            try {
                //check for loyalty card
                if(loyalty){
                    loyaltyDiscount = subTotalCost * 0.05;
                    totalCost = subTotalCost - itemDiscount;
                    totalCost -= loyaltyDiscount;
                    totalCost = Math.Round(totalCost,2);
                }
                else
                {
                    totalCost = subTotalCost - itemDiscount;
                    totalCost -= loyaltyDiscount;
                    totalCost = Math.Round(totalCost,2);
                }
            
                //check item chosen to show what discount applied
                if(itemChosen == "1" || itemChosen == "Fish" || itemChosen == "fish")
                {
                    itemChosen = "Fish";
                    discountGiven = "YOU GET 10% OFF!";
                }
                else if (itemChosen == "2")
                {
                    itemChosen = "Cat Food";
                    discountGiven = "YOU GET 1 BAG FREE!";
                }
                else if (itemChosen == "3")
                {
                    itemChosen = "Dog Food";
                    discountGiven = "YOU GET HALF OFF ON ONE BAG!";
                }
                else if (itemChosen == "4")
                {
                    itemChosen = "Bird Food";
                    discountGiven = "YOU GET 5% OFF!";
                }

                //Print Reciept
                Console.WriteLine("");
                Console.WriteLine("============== RECIEPT ==================");
                Console.WriteLine("Steve Soares || 8917866 || ssoares7866@conestogac.on.ca (Dubai Guy)");
                Console.WriteLine("======================================");
                Console.WriteLine("");
                Console.WriteLine("---- " + discountGiven + " ----"); 
                Console.WriteLine("");
                Console.WriteLine("Item: " + itemChosen); //Chosen Item
                Console.WriteLine("Item Cost: $" + itemCost); //Item Price
                Console.WriteLine("Quantity: " + itemQuantity); //Quantity
                Console.WriteLine("Loyalty Card: " + loyalty); //Loyalty member
                Console.WriteLine("");
                Console.WriteLine("--------------------");
                Console.WriteLine("Sub Total: $" + subTotalCost); //Subtotal w/0 discounts
                Console.WriteLine("--");
                Console.WriteLine("Discounts");
                Console.WriteLine("Item Discount: $" + itemDiscount); //Item Discount
                Console.WriteLine("Loyalty Discount: $" + loyaltyDiscount); //Loyalty Discount
                Console.WriteLine("--");
                Console.WriteLine("Total W/O Tax: $" + totalCost); //Total w/0 tax
                Console.WriteLine("Tax: $" + taxAmount); //Tax amount
                Console.WriteLine("");
                totalCost += taxAmount;
                Console.WriteLine("TOTAL: $" + totalCost); //Total with Tax
                Console.WriteLine("");
            }
            catch (Exception e) {
                Console.WriteLine(e);
            } 
        }
    }
}
