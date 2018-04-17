using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDB
{
    public class Class
    {
        DataSet ShopDb = new DataSet();
        //  Orders, Customers,
        //Employees, OrderDetails, Products

        DataTable orders = new DataTable("Orders");
        DataColumn idColumn = new DataColumn("Id", typeof(int),);
        DataColumn price = new DataColumn("Price", typeof(int));
        DataColumn name = new DataColumn("Name", typeof(string));
        

    }
        
    
}
