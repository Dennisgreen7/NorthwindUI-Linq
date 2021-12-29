// See https://aka.ms/new-console-template for more information
using NorthwindUI.Models;

using (var db = new NorthwindContext())
{
    //1. 
    var query1 = db.Products.Select(p => new { p.ProductName, p.QuantityPerUnit }).ToList();
    //2.
    var query2 = db.Products.Where(p => !p.Discontinued).Select(p => new { p.ProductId, p.ProductName }).ToList();
    //3.
    var query3 = db.Products.Where(p => p.Discontinued).Select(p => new { p.ProductId, p.ProductName }).ToList();
    //4.
    var query4 = db.Products.Select(p => new { p.ProductName, p.UnitPrice }).OrderBy(p => p.UnitPrice).Reverse().ToList();
    //5.
    var query5 = db.Products.Where(p => p.UnitPrice < 20).Select(p => new { p.ProductId, p.ProductName, p.UnitPrice }).OrderBy(p => p.UnitPrice).Reverse().ToList();
    //6.
    var query6 = db.Products.Where(p => p.UnitPrice >= 15 && p.UnitPrice <= 25).Select(p => new { p.ProductName, p.UnitPrice }).OrderBy(p => p.UnitPrice).Reverse().ToList();
    //7.
    var avarageUnitpricre = db.Products.Average(p => p.UnitPrice);
    var query7 = db.Products.Where(p => p.UnitPrice > avarageUnitpricre).Select(p => new { p.ProductName, p.UnitPrice }).OrderBy(p => p.UnitPrice).ToList();
    //8.
    var query8 = db.Products.Select(p => new { p.ProductName, p.UnitPrice }).OrderBy(p => p.UnitPrice).Reverse().Take(10).ToList();
    //9.
    var countQuerryDiscontinued = db.Products.Count(p => p.Discontinued);
    var countQuerryCurrent = db.Products.Count(p => !p.Discontinued);
    //10.
    var query10 = db.Products.Where(p =>!p.Discontinued && p.UnitsInStock < p.UnitsOnOrder).Select(p => new { p.ProductName, p.UnitsOnOrder, p.UnitsInStock }).ToList();
}
Console.ReadLine();
