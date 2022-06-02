using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
namespace CRUD_Inventory.Model
{
    internal static class Data
    {
        static public int StocksId { get; set; }
        static public int ProductId { get; set; }
        static public List<Stock> GetStocks(InventoryEntities db)
        {
            return db.Stocks.ToList();
        }
        static public void AddStocks(InventoryEntities db, Stock s)
        {
            db.Stocks.Add(s);
            db.SaveChanges();
        }
        static public void RemoveStock(InventoryEntities db, Stock s)
        {
            db.Stocks.Load();
            db.Stocks.Remove(s);
            db.SaveChanges();
        }
        static public void AddEmp(InventoryEntities db, Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();
        }
        static public string LogIn(InventoryEntities db, int id)
        {
            foreach (var entity in db.ChangeTracker.Entries())
            {
                entity.Reload();
            }
            SqlParameter Id = new SqlParameter("@id", id);
            SqlParameter stockid = new SqlParameter("@idd", StocksId);
            return db.Database.SqlQuery<string>("select password from employee where employeeid = @id and stockid = @idd", Id, stockid).Single();
        }
        static public Employee FindEmployee(InventoryEntities db, int id)
        {
            foreach (var entity in db.ChangeTracker.Entries())
            {
                entity.Reload();
            }
            return db.Employees.First(x => x.EmployeeId == id);
        }
        static public void AddProducer(InventoryEntities db, Producer p)
        {
            db.Producers.Add(p);
            db.SaveChanges();
        }
        static public List<Producer> GetProducers(InventoryEntities db)
        {
            SqlParameter id = new SqlParameter("@id", StocksId);
            return db.Producers.SqlQuery("select * from producer where stockid = @id", id).ToList();
        }
        static public List<Product> GetProducts(InventoryEntities db)
        {
            SqlParameter id = new SqlParameter("@id", StocksId);
            return db.Products.SqlQuery("select * from product where producerid in " +
                "(select producerid from producer where stockid = @id)", id).ToList();
        }
        static public List<Employee> GetEmployees(InventoryEntities db)
        {
            SqlParameter id = new SqlParameter("@id", StocksId);
            return db.Employees.SqlQuery("select * from employee where stockid = @id", id).ToList();
        }
        static public void AddProduct(InventoryEntities db, Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
        }
        static public void AddIn(InventoryEntities db, InProduct i)
        {
            db.InProducts.Add(i);
            db.SaveChanges();
        }
        static public void AddOut(InventoryEntities db, OutProduct o)
        {
            db.OutProducts.Add(o);
            db.SaveChanges();
        }
        static public List<InProduct> GetIn(InventoryEntities db, int ID)
        {
            SqlParameter id = new SqlParameter("@id", ID);
            return db.InProducts.SqlQuery("select * from inproduct where productid = @id", id).ToList();
        }
        static public List<OutProduct> GetOut(InventoryEntities db, int ID)
        {
            SqlParameter id = new SqlParameter("@id", ID);
            return db.OutProducts.SqlQuery("select * from outproduct where productid = @id", id).ToList();
        }
        static public int GetNost(InventoryEntities db, int id)
        {
            int a = 0;
            foreach (var i in GetIn(db, id))
                a += i.InCount;
            foreach (var i in GetOut(db, id))
                a -= i.OutCount;
            return a;
        }
        static public Product FingProduct(InventoryEntities db, int id)
        {
            foreach (var entity in db.ChangeTracker.Entries())
            {
                entity.Reload();
            }
            return db.Products.First(x => x.ProductId == id);
        }
        static public void RemoveProduct(InventoryEntities db, Product p)
        {
            db.Products.Remove(p);
            db.SaveChanges();
        }
        static public void RemoveEmployee(InventoryEntities db, Employee em)
        {
            db.Employees.Remove(em);
            db.SaveChanges();
        }
        static public void RemoveProducer(InventoryEntities db, Producer p)
        {
            db.Producers.Remove(p);
            db.SaveChanges();
        }
        static public Stock FingStock(InventoryEntities db, int id)
        {
            foreach (var entity in db.ChangeTracker.Entries())
            {
                entity.Reload();
            }
            return db.Stocks.First(x => x.StockId == id);
        }
    }
}
