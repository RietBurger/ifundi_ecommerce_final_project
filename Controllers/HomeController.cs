using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc_ecommerce_tutorial.Models;
using System.Data;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Web;

namespace mvc_ecommerce_tutorial.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // private string constr = "server=localhost;port=3306;uid=root;pwd=;database=;charset=utf8;sslmode=none;AllowPublicKeyRetrieval=True"; 
        private string constr = "server=localhost;port=3306;uid=online;pwd=online21#!;database=ecommerce;charset=utf8;sslmode=none;AllowPublicKeyRetrieval=True";
        // if (GlobalModel.firstName != null)   
        //         ViewBag.FirstName = GlobalModel.firstName;


        public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger;
        }
/*
        public IActionResult Index()
        {
            if (GlobalModel.firstName != null)
                ViewBag.FirstName = GlobalModel.firstName;
            if (GlobalModel.idxImg != null)
                ViewBag.imgSrc = GlobalModel.idxImg;
            else
                @ViewBag.imgSrc = "img1.jpg";                
            return View();
        }
        */

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult about()
        {
            return View();
        }

        public IActionResult contact()
        {
            return View();
        }

        public IActionResult faq()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

[HttpPost] 
        public ActionResult Register(UserModel obj)
        {
            // ViewBag.FirstName = obj.FirstName;
            // ViewBag.LastName = obj.LastName;
            // ViewBag.Email = obj.Email;
            // ViewBag.Password = obj.Password;

            // Console.WriteLine("This is mail set first: " + obj.Email);
            // Console.WriteLine(obj.Email);
            
            string enPassword = obj.EncodePasswordToBase64(obj.Password);

            // ViewBag.enPassword = enPassword;
            // ViewBag.dePassword = dePassword;
            MySqlConnection conn = new MySqlConnection(constr);

            using (conn)
            {
                try
                {
                    List<UserModel> user = new List<UserModel>();
                    conn.Open();
                    MySqlCommand command =  conn.CreateCommand();
                    command.CommandType=System.Data.CommandType.Text;

                    string fname = obj.FirstName; 
                    string lname = obj.LastName; 
                    string email = obj.Email;
                    string password = enPassword;
                    
                    GlobalModel.globalMail = email;
                    Console.WriteLine("This is global mail");
                    Console.WriteLine(email);


                   // reader.Close();
                   Console.WriteLine("fname: " + fname);
                    command.CommandText=$"Insert into customer(FirstName, LastName, email, password) values('{fname}','{lname}','{email}','{password}');";
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();

                    conn.Close();
                    System.Console.WriteLine("Connection is : " + conn.State.ToString() + Environment.NewLine);
                    // return StatusCode(200);
                }catch(MySql.Data.MySqlClient.MySqlException ex){
                    string errorMessage = ex.Message.ToString();
                    if (errorMessage.IndexOf("Duplicate entry") != -1)
                    {
                        ViewBag.err = "Email already exists";
                    }
                    else 
                        System.Console.WriteLine("Error: " + errorMessage);
                    conn.Close();
                    System.Console.WriteLine("Connection is : " + conn.State.ToString() + Environment.NewLine);
                    // return StatusCode(500);
                }finally {
                    //System.Console.WriteLine("Press any key to Exit...");
                    //
                    //Console.ReadKey();
                }

            // return View(obj);
            return View(nameof(Login));
            // return View();
            }
        }
        

public IActionResult Login()
        {
            if (GlobalModel.globUserID == null)
                ViewBag.notLoggedIn = "Please login to add items to cart";
            return View();
        }
// https://www.aspsnippets.com/Articles/Using-MySql-Database-with-MySql-Connector-in-ASPNet-MVC-Razor-Tutorial-with-example.aspx
// GET: Home
[HttpPost]
public ActionResult Login(UserModel user)
    {
        
        MySqlConnection conn = new MySqlConnection(constr);

        string mail = user.Email;
        string enPassword = user.EncodePasswordToBase64(user.Password);
        ViewBag.MailIn = user.Email;

        GlobalModel.resetUserInfo();
        
        using (conn)
        {
            string query = $"SELECT a.FirstName, a.email, a.password, a.userID, b.profileID FROM customer a left outer join profile b on a.userID = b.userID where a.email = '{mail}' and a.password = '{enPassword}';";
            // string query = "SELECT FirstName, LastName, email, password FROM customer";
            Console.WriteLine("Printing query: ");
            Console.WriteLine(query);
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                cmd.Connection = conn;
                conn.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read())
                    {
                            GlobalModel.firstName = string.Format("{0:S}", sdr["FirstName"]); //.toString(),
                            GlobalModel.globalMail = string.Format("{0:S}", sdr["email"]); //.ToString(),
                            GlobalModel.globUserID = string.Format("{0:D}", sdr["userID"]); //.ToString(),
                            GlobalModel.globProfileID = string.Format("{0:D}", sdr["profileID"]);
                            GlobalModel.idxImg = "img2.jpg";
                    }
                    if (GlobalModel.globUserID == null)
                    {
                        ViewBag.Err = "Incorrect Email or Password";
                        return View(user);
                    }
                }
            }
            conn.Close();

            ViewBag.FirstName = GlobalModel.firstName;
            ViewBag.Mail = GlobalModel.globalMail;
            ViewBag.UserID = GlobalModel.globUserID;
        }
        
        // return View(user); // send to different page?
        // return View(nameof(Index));
        return RedirectToAction("Index");
        // return View("")
    }
        
        public IActionResult AddProd()
        {
            return View();
        }

        // public IActionResult prev_prod()
        // {
        //     return View();
        // }

        // public IActionResult cart()
        // {
        //     return View();
        // }

[HttpPost]
        public ActionResult AddProd(ProductModel prodAdd)
        {
            if (ModelState.IsValid)    
            { 
                Console.WriteLine("ProdAdd.Name: ");
                Console.WriteLine(prodAdd.Name);
                Console.WriteLine("ProdAdd.Desc: ");
                Console.WriteLine(prodAdd.Desc);
                Console.WriteLine("ProdAdd.Qty: ");
                Console.WriteLine(prodAdd.Qty);
                Console.WriteLine("ProdAdd.Price: ");
                Console.WriteLine(prodAdd.Price);
                Console.WriteLine("ProdAdd.ImgSource: ");
                Console.WriteLine(prodAdd.ImgSource);
                Console.WriteLine("ProdAdd.CategoryID: ");
                Console.WriteLine(prodAdd.CatID);

                MySqlConnection conn = new MySqlConnection(constr);
  
                using (conn)
                {
                    try
                    {
                        List<ProductModel> user = new List<ProductModel>();
                        conn.Open();
                        MySqlCommand command =  conn.CreateCommand();
                        command.CommandType=System.Data.CommandType.Text;

                        string name = prodAdd.Name; 
                        string desc = prodAdd.Desc; 
                        string qty = prodAdd.Qty;
                        string price = prodAdd.Price;
                        string imgSource = prodAdd.ImgSource;
                        string catID = prodAdd.CatID;


                        command.CommandText=$"Insert into products(catID, name, description, price, qty, imgSrc) values('{catID}','{name}','{desc}','{price}','{qty}','{imgSource}');";
                        MySqlDataReader reader = command.ExecuteReader();
                        reader.Close();

                        conn.Close();
                        System.Console.WriteLine("Connection is : " + conn.State.ToString() + Environment.NewLine);
                        // return StatusCode(200);
                    }
                    catch(MySql.Data.MySqlClient.MySqlException ex)
                    {
                        string errorMessage = ex.Message.ToString();
                        if (errorMessage.IndexOf("Duplicate entry") != -1)
                        {
                            ViewBag.err = "Email already exists";
                        }
                        else 
                            System.Console.WriteLine("Error: " + errorMessage);
                        conn.Close();
                        System.Console.WriteLine("Connection is : " + conn.State.ToString() + Environment.NewLine);
                    // return StatusCode(500);
                    }
                    finally 
                    {
                        //System.Console.WriteLine("Press any key to Exit...");
                        //
                        //Console.ReadKey();
                    }
                }
            }
            return View(prodAdd);
        }


// use this concept to load products
// rename Products() to Index()
    public IActionResult Index()
    {
         if (GlobalModel.firstName != null)
                ViewBag.FirstName = GlobalModel.firstName;
            if (GlobalModel.idxImg != null)
                ViewBag.imgSrc = GlobalModel.idxImg;
            else
                @ViewBag.imgSrc = "img1.jpg"; 

        List<ProductModel> prod = new List<ProductModel>();

        MySqlConnection conn = new MySqlConnection(constr);

        using (conn)
        {
            string query = $"SELECT name, description, price, qty, imgSrc, prodID, categoryName FROM products a left outer join categories b on a.catID = b.catID where deleteInd = 0 and qty > 0;";
            Console.WriteLine("Printing query: ");
            Console.WriteLine(query);
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                cmd.Connection = conn;
               conn.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        prod.Add(new ProductModel
                        {
                            Name = string.Format("{0:S}", sdr["name"]), //.toString(),
                            Desc = string.Format("{0:S}", sdr["description"]), //.ToString(),
                            Price = string.Format("{0:S}", sdr["price"]), //.ToString(),
                            Qty = string.Format("{0:S}", sdr["qty"]), //.ToString(),
                            ImgSource = string.Format("{0:S}", sdr["imgSrc"]), //.ToString(),
                            ProdID = string.Format("{0:D}", sdr["prodID"]), //.ToString(),
                            CategoryName = string.Format("{0:S}", sdr["categoryName"]), //.ToString(),
                            QtySelected = 1,
                        });
                    }
                }
                conn.Close();
            }

        }
        
        return View(prod); // send to different page?
    }

    public IActionResult ProductsDetail(int id)
        {
            List<ProductModel> prod = new List<ProductModel>();

        MySqlConnection conn = new MySqlConnection(constr);

        using (conn)
        {
            string query = $"SELECT name, description, price, qty, imgSrc, prodID, categoryName FROM products a left outer join categories b on a.catID = b.catID where deleteInd = 0 and qty > 0 and prodID = '{id}';";
            Console.WriteLine("Printing query: ");
            Console.WriteLine(query);
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                cmd.Connection = conn;
               conn.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        prod.Add(new ProductModel
                        {
                            Name = string.Format("{0:S}", sdr["name"]), //.toString(),
                            Desc = string.Format("{0:S}", sdr["description"]), //.ToString(),
                            Price = string.Format("{0:S}", sdr["price"]), //.ToString(),
                            Qty = string.Format("{0:S}", sdr["qty"]), //.ToString(),
                            ImgSource = string.Format("{0:S}", sdr["imgSrc"]), //.ToString(),
                            ProdID = string.Format("{0:D}", sdr["prodID"]), //.ToString(),
                            CategoryName = string.Format("{0:S}", sdr["categoryName"]), //.ToString(),
                            QtySelected = 1,
                        });
                    }
                }
                conn.Close();
            }

        }
        
        return View(prod); // send to different page?
        }

        // [Route({level}/{type}/{id})]
        public IActionResult Cart(int id)
        {
            Console.WriteLine("Entering Cart");
            int userID = Convert.ToInt32( GlobalModel.globUserID);
            int subTotal = 0;
            int delivery = 100;
            int GrandTotal = 0;

            ViewBag.UserID = userID;

            List<CartModel> cart = new List<CartModel>();
           

        MySqlConnection conn = new MySqlConnection(constr);

        using (conn)
        {
            string query = $"select coalesce(a.cartID, 0) as cartID, coalesce(a.orderID, '0') as orderID, coalesce(a.userID, 0) as userID, coalesce(a.prodID, 0) as prodID, coalesce(a.qtySelected, 1) as qtySelected, coalesce(b.name, '0') as name, coalesce(b.description, '0') as description, coalesce(b.price, '0') as price, coalesce(b.imgSrc, 'placeholder.png') as imgSrc, coalesce(c.categoryName, '0') as categoryName from cart a inner join products b on a.prodID = b.prodID left outer join categories c on b.catID = c.catID where a.deleteInd = 0 and userID = '{userID}'";
                        Console.WriteLine("Printing query: ");
            Console.WriteLine(query);

            


            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                cmd.Connection = conn;
               conn.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        cart.Add(new CartModel
                        {
                            cartID = string.Format("{0:D}", sdr["cartID"]), //.toString(),
                            orderID = string.Format("{0:S}", sdr["orderID"]), //.ToString(),
                            userID = string.Format("{0:D}", sdr["userID"]), //.ToString(),
                            prodID = string.Format("{0:D}", sdr["prodID"]), //.ToString(),
                            qtySelected = string.Format("{0:D}", sdr["qtySelected"]), //.ToString(),
                            name = string.Format("{0:S}", sdr["name"]), //.ToString(),
                            description = string.Format("{0:S}", sdr["description"]), //.ToString(),
                            price = string.Format("{0:S}", sdr["price"]), //.ToString(),
                            imgSrc = string.Format("{0:S}", sdr["imgSrc"]), //.ToString(),
                            categoryName = string.Format("{0:S}", sdr["categoryName"]), //.ToString(),
                            // Total = string.Format("{0:D}", sdr["total"]), //.ToString(),
                             Total = 0,
                        });
                        
                    }
                }
                conn.Close();
            }
            if (ModelState.IsValid)  
            {
                foreach(CartModel item in cart) {
                    item.Total = Convert.ToInt32(item.price) * Convert.ToInt32(item.qtySelected);
                    Console.WriteLine("Total: ");
                    Console.WriteLine(item.Total);
                    subTotal = subTotal + Convert.ToInt32(item.Total);
                    Console.WriteLine("GrandTotal: ");
                    Console.WriteLine(subTotal);
                }

            }
        }
        ViewBag.subTotal = subTotal;
        // free delivery for orders over R99
        if(subTotal > 99)
            delivery = 0;
        ViewBag.delivery = delivery;
        GrandTotal = subTotal + delivery;
        ViewBag.grandTotal = GrandTotal;
        return View(cart); // send to different page?      
            // return View();
        }

            public IActionResult Checkout()
        {
            return View();
        }

public IActionResult addToCart(int id)
        {
            ViewBag.id = id;

            // add this if you don't want visitors to add to cart
            // if (GlobalModel.globUserID == null)
            //     return RedirectToAction("Index");

            ViewBag.UserID = GlobalModel.globUserID;
            if (GlobalModel.currOrderID == null)
                GlobalModel.generateOrderID(GlobalModel.globUserID);

            // ViewBag.orderID = GlobalModel.currOrderID;   

                MySqlConnection conn = new MySqlConnection(constr);
  
                using (conn)
                {
                    try
                    {
                        List<ProductModel> user = new List<ProductModel>();
                        conn.Open();
                        MySqlCommand command =  conn.CreateCommand();
                        command.CommandType=System.Data.CommandType.Text;

                        int prodID = id;
                        int userID = Convert.ToInt32(GlobalModel.globUserID);
                        string orderID = GlobalModel.currOrderID;
                        int QtyS = 1;

                        command.CommandText=$"insert into cart(orderID, userID, prodID, qtySelected) values('{orderID}','{userID}','{prodID}','{QtyS}');";
                        MySqlDataReader reader = command.ExecuteReader();
                        Console.WriteLine("Insert stmt: ");
                        Console.WriteLine(command.CommandText);

                        reader.Close();

                        conn.Close();
                        System.Console.WriteLine("Connection is : " + conn.State.ToString() + Environment.NewLine);
                        // return StatusCode(200);
                    }
                    catch(MySql.Data.MySqlClient.MySqlException ex)
                    {
                        string errorMessage = ex.Message.ToString();
                        if (errorMessage.IndexOf("Duplicate entry") != -1)
                        {
                            // ViewBag.err = "Email already exists";
                        }
                        else 
                            System.Console.WriteLine("Error: " + errorMessage);
                        conn.Close();
                        System.Console.WriteLine("Connection is : " + conn.State.ToString() + Environment.NewLine);
                    // return StatusCode(500);
                    }
                    finally 
                    {
                        //System.Console.WriteLine("Press any key to Exit...");
                        //
                        //Console.ReadKey();
                    }
            // return View(prodAdd);
            }
            Console.WriteLine("Exiting add to cart");
            return RedirectToAction("Index");
            // return View(nameof(Cart));
            // return View(nameof(Index));
            // return View();
        }

public ActionResult Delete(int id)
        {

            MySqlConnection conn = new MySqlConnection(constr);

            using (conn)
            {
                try
                {
                    List<UserModel> user = new List<UserModel>();
                    conn.Open();
                    MySqlCommand command =  conn.CreateCommand();
                    command.CommandType=System.Data.CommandType.Text;

                    int cartID = id; 
                    int userID = Convert.ToInt32( GlobalModel.globUserID);

                   // reader.Close();
                //    Console.WriteLine("fname: " + fname);
                    command.CommandText=$"update cart set deleteInd = 1 where cartID = '{cartID}' and userID = '{userID}';";
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();

                    conn.Close();
                    System.Console.WriteLine("Connection is : " + conn.State.ToString() + Environment.NewLine);
                    // return StatusCode(200);
                }catch(MySql.Data.MySqlClient.MySqlException ex){
                    string errorMessage = ex.Message.ToString();
                    if (errorMessage.IndexOf("Duplicate entry") != -1)
                    {
                        // ViewBag.err = "Email already exists";
                    }
                    else 
                        System.Console.WriteLine("Error: " + errorMessage);
                    conn.Close();
                    System.Console.WriteLine("Connection is : " + conn.State.ToString() + Environment.NewLine);
                    // return StatusCode(500);
                }finally {
                    //System.Console.WriteLine("Press any key to Exit...");
                    //
                    //Console.ReadKey();
                }

            // return View(obj);
            return RedirectToAction("Cart");
            // return View();
            }
        }

        public ActionResult Plus(int level, int id)
        {

            // qtyAvailable = select qty available from db...
            // if(level >= qtyAvailable)
            //     {return}

            MySqlConnection conn = new MySqlConnection(constr);

            using (conn)
            {
                try
                {
                    List<UserModel> user = new List<UserModel>();
                    conn.Open();
                    MySqlCommand command =  conn.CreateCommand();
                    command.CommandType=System.Data.CommandType.Text;

                    int cartID = id; 
                    int userID = Convert.ToInt32( GlobalModel.globUserID);

                   // reader.Close();
                //    Console.WriteLine("fname: " + fname);
                    command.CommandText=$"update cart set qtySelected = qtySelected + 1 where cartID = '{cartID}' and userID = '{userID}';";
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();

                    conn.Close();
                    System.Console.WriteLine("Connection is : " + conn.State.ToString() + Environment.NewLine);
                    // return StatusCode(200);
                }catch(MySql.Data.MySqlClient.MySqlException ex){
                    string errorMessage = ex.Message.ToString();
                    if (errorMessage.IndexOf("Duplicate entry") != -1)
                    {
                        // ViewBag.err = "Email already exists";
                    }
                    else 
                        System.Console.WriteLine("Error: " + errorMessage);
                    conn.Close();
                    System.Console.WriteLine("Connection is : " + conn.State.ToString() + Environment.NewLine);
                    // return StatusCode(500);
                }finally {
                    //System.Console.WriteLine("Press any key to Exit...");
                    //
                    //Console.ReadKey();
                }

            // return View(obj);
            return RedirectToAction("Cart");
            // return View();
            }
        }
        
public ActionResult Minus(int level, int id)
        {

            // Can't have 0 or minus value as QTY
            if(level <= 1)
                 return RedirectToAction("Cart");

            MySqlConnection conn = new MySqlConnection(constr);

            using (conn)
            {
                try
                {
                    List<UserModel> user = new List<UserModel>();
                    conn.Open();
                    MySqlCommand command =  conn.CreateCommand();
                    command.CommandType=System.Data.CommandType.Text;

                    int cartID = id; 
                    int userID = Convert.ToInt32( GlobalModel.globUserID);

                   // reader.Close();
                //    Console.WriteLine("fname: " + fname);
                    command.CommandText=$"update cart set qtySelected = qtySelected - 1 where cartID = '{cartID}' and userID = '{userID}';";
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();

                    conn.Close();
                    System.Console.WriteLine("Connection is : " + conn.State.ToString() + Environment.NewLine);
                    // return StatusCode(200);
                }catch(MySql.Data.MySqlClient.MySqlException ex){
                    string errorMessage = ex.Message.ToString();
                    if (errorMessage.IndexOf("Duplicate entry") != -1)
                    {
                        // ViewBag.err = "Email already exists";
                    }
                    else 
                        System.Console.WriteLine("Error: " + errorMessage);
                    conn.Close();
                    System.Console.WriteLine("Connection is : " + conn.State.ToString() + Environment.NewLine);
                    // return StatusCode(500);
                }finally {
                    //System.Console.WriteLine("Press any key to Exit...");
                    //
                    //Console.ReadKey();
                }

            // return View(obj);
            return RedirectToAction("Cart");
            // return View();
            }
        }
        

public ActionResult ResetPWD()
        {
            return View();
        }

[HttpPost] 
        public ActionResult ResetPWD(UserModel obj)
        {
            // ViewBag.FirstName = obj.FirstName;
            // ViewBag.LastName = obj.LastName;
            // ViewBag.Email = obj.Email;
            // ViewBag.Password = obj.Password;
            // ViewBag.Password = obj.Password2;

            // Console.WriteLine("This is mail set first: " + obj.Email);
            // Console.WriteLine(obj.Email);
            
            string enPassword = obj.EncodePasswordToBase64(obj.Password);

            // ViewBag.enPassword = enPassword;
            // ViewBag.dePassword = dePassword;
            MySqlConnection conn = new MySqlConnection(constr);

            using (conn)
            {
                try
                {
                    List<UserModel> user = new List<UserModel>();
                    conn.Open();
                    MySqlCommand command =  conn.CreateCommand();
                    command.CommandType=System.Data.CommandType.Text;

                    string fname = obj.FirstName; 
                    string lname = obj.LastName; 
                    string email = obj.Email;
                    string password = enPassword;
                    
                    GlobalModel.globalMail = email;
                    Console.WriteLine("This is global mail");
                    Console.WriteLine(email);


                   // reader.Close();
                   Console.WriteLine("fname: " + fname);
                    command.CommandText=$"update customer set password = '{password}' where FirstName = '{fname}' 	and LastName = '{lname}' and email = '{email}';";
                    Console.WriteLine("Command: " + command.CommandText);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();

                    conn.Close();
                    System.Console.WriteLine("Connection is : " + conn.State.ToString() + Environment.NewLine);
                    // return StatusCode(200);
                }catch(MySql.Data.MySqlClient.MySqlException ex){
                    string errorMessage = ex.Message.ToString();
                    if (errorMessage.IndexOf("Duplicate entry") != -1)
                    {
                        // ViewBag.err = "Email already exists";
                    }
                    else 
                        System.Console.WriteLine("Error: " + errorMessage);
                    conn.Close();
                    System.Console.WriteLine("Connection is : " + conn.State.ToString() + Environment.NewLine);
                    // return StatusCode(500);
                }finally {
                    //System.Console.WriteLine("Press any key to Exit...");
                    //
                    //Console.ReadKey();
                }

            // return View(obj);
            return View(nameof(Login));
            // return View();
            }
        }

        // public IActionResult Profile()
        // {
        //     return View();
        // }
/* // can complete profile when everything else is done
        public ActionResult Profile(UserModel prof)
        {

            if(GlobalModel.globUserID == null)
                ViewBag.Err = "Please log in before completing the profile";
                // return RedirectToAction("Index");

            if (ModelState.IsValid)    
            { 
            Console.WriteLine(prof.FirstName);
            Console.WriteLine(prof.LastName);
            Console.WriteLine(prof.Email);
            Console.WriteLine(prof.Street);
            Console.WriteLine(prof.Complex);
            Console.WriteLine(prof.PostalCode);
            Console.WriteLine(prof.Suburb);
            Console.WriteLine(prof.Province);
            Console.WriteLine(prof.Country);
            Console.WriteLine("UserID: ");
            Console.WriteLine(GlobalModel.globUserID);

MySqlConnection conn = new MySqlConnection(constr);

            using (conn)
            {
                try
                {
                    string fname = prof.FirstName; 
                    string lname = prof.LastName; 
                    string email = prof.Email;
                    string street = prof.Street;
                    string complex = prof.Complex;
                    string postalCode = prof.PostalCode;
                    string suburb = prof.Suburb;
                    string province = prof.Province;
                    string country = prof.Country;
                    int userID = Convert.ToInt32(GlobalModel.globUserID);
                    
                    // if (GlobalModel.globalMail != email)
                    // {
                    //     ViewBag.LoginErr = "Unable to update profile. Please ensure correct information supplied";
                    //     return View(nameof(Login));
                    // }

                    List<UserModel> user = new List<UserModel>();
                    conn.Open();
                    MySqlCommand command =  conn.CreateCommand();
                    command.CommandType=System.Data.CommandType.Text;
                    Console.WriteLine("This is global mail");
                    Console.WriteLine(GlobalModel.globalMail);

                    if(GlobalModel.globProfileID == "0")
                    {
                        // insert statment
                        command.CommandText=$"insert into profile (FirstName, LastName, email, Street, Complex, PostalCode, Suburb, Province, Country, userID) values('{fname}]', '{lname}', '{email}', '{street}', '{complex}', '{postalCode}', '{suburb}', '{province}', '{country}', {userID});";
                        Console.WriteLine("Command: " + command.CommandText);
                    }
                    else {
                        // Update statement
                        // Email to be updated separately, as this is used as primary identifier for customer, as good as username
                        command.CommandText=$"update profile set FirstName = '{fname}', LastName = '{lname}', Street = '{street}', Complex = '{complex}', PostalCode = '{postalCode}', Suburb = '{suburb}', Province = '{province}', Country = '{country}' where userID = '{userID}';";
                        Console.WriteLine("Command: " + command.CommandText);
                    }
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();

                    conn.Close();
                    System.Console.WriteLine("Connection is : " + conn.State.ToString() + Environment.NewLine);
                    // return StatusCode(200);
                }catch(MySql.Data.MySqlClient.MySqlException ex){
                    string errorMessage = ex.Message.ToString();
                    if (errorMessage.IndexOf("Duplicate entry") != -1)
                    {
                        ViewBag.err = "Email already exists";
                    }
                    else 
                        System.Console.WriteLine("Error: " + errorMessage);
                    conn.Close();
                    System.Console.WriteLine("Connection is : " + conn.State.ToString() + Environment.NewLine);
                    // return StatusCode(500);
                }finally {
                    //System.Console.WriteLine("Press any key to Exit...");
                    //
                    //Console.ReadKey();
                }
                
            }
            return View(nameof(Login));
            // return View(obj);
            }
        else 
            // return View();
            return View(prof);
        }
*/
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

