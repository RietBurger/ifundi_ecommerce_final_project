using System;
using System.IO;
using System.Linq;

namespace mvc_ecommerce_tutorial.Models
{
    class GlobalModel
    {
        public static string globalMail;
        public static string firstName;
        public static string globUserID;
        public static string globProfileID; // set this value as well when customer logs in, then update will be run in profile, not insert.
        public static string currOrderID;
        public static string currProductID;
        public static string currProductName;
        public static int currProductQty;
        public static string idxImg;

        public static void generateOrderID(string userID)
        {
            Random ran = new Random();
             
                        String b = "abcdefghijklmnopqrstuvwxyz";
            
                        int length = 6;
             
                       String random = "";
             
                     for(int i =0; i<length; i++)
                     {
                             int a = ran.Next(26);
                             random = random + b.ElementAt(a);
                     }
             
                Console.WriteLine("The random alphabet generated is: {0}", random);
                DateTime myDate = DateTime.Now;
                currOrderID = "OA" + userID + myDate + random;
        }

        public static void resetUserInfo()
        {
            globalMail = null;
            firstName = null;
            globUserID = null;
            idxImg = null;
        }

        public static void resetOrderInfo()
        {
            currOrderID = null;
        }

        public static void resetProductInfo()
        {
            currProductID = null;
            currProductName = null;
            currProductQty = 0;
        }

    }
}
