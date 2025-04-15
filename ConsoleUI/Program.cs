using Business.Concrete;
using Business.Constants;
using DataAccess.Conrete.EntityFramework;


namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            //CategoryTest();
            //ProductDetails();
            //ProductManager productManager = new(new EfProductDal());
            //var result = productManager.GetProductDetails();
            //if (result.IsSuccess)
            //{
            //    foreach (var item in result.Data)
            //    {
            //        Console.WriteLine($"Prod_ID:{item.ProductId}||Prod_Name:{item.ProductName}||");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}
        }

        //private static void ProductDetails()
        //{
        //    ProductManager product = new(new EfProductDal());
        //    foreach (var item in product.GetProductDetails().Data)
        //    {
        //        Console.WriteLine($"Prod_ID:{item.ProductId}||Prod_Name:{item.ProductName}||CategoryName:{item.CategoryName}||UnitsinStock:{item.UnitsinStock}");
        //    }
        //}

        //private static void CategoryTest()
        //{
        //    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        //    foreach (var item in categoryManager.GetAll().Data)
        //    {
        //        Console.WriteLine($"Kateqoriya adi {item.CategoryName}");
        //    }
        //}

        //private static void ProductTest()
        //{
        //    ProductManager product = new(new EfProductDal());
        //    foreach (var item in product.GetByUnitPrice(40, 100).Data)
        //    {
        //        Console.WriteLine(item.ProductName);
        //    }
        //}
    }
}
