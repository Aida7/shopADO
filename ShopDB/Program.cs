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
    class Program
    {
        static void Main(string[] args)
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["Automate"];

            //DbProviderFactory factory = DbProviderFactories.GetFactory(connectionString.ProviderName);
            //DbConnection connection = factory.CreateConnection();
            //connection.ConnectionString = connectionString.ConnectionString;

            //DataSet marketDataSet = new DataSet("ShopDB");

            //DbDataAdapter adapter = factory.CreateDataAdapter();
            //DbCommand selectComand = connection.CreateCommand();
            //selectComand.CommandText =
            //  "select *from Creators; select*from Products";
            //adapter.SelectCommand = selectComand;

            //(adapter as SqlDataAdapter).SelectCommand =
            //    new SqlCommand("select *from Creators; select*from Products", connection as SqlConnection);


            //DataTable table = new DataTable("Orders");
            //DataColumn idColumn = new DataColumn();
            //idColumn.ColumnName = "id";
            //idColumn.DataType = typeof(int);
            //idColumn.AllowDBNull = false;
            //idColumn.AutoIncrement = true;
            //idColumn.Unique = true;

            //DataTable table = new DataTable("Customers");
            //DataColumn idColumn = new DataColumn();
            //idColumn.ColumnName = "id";
            //idColumn.DataType = typeof(int);
            //idColumn.AllowDBNull = false;
            //idColumn.AutoIncrement = true;
            //idColumn.Unique = true;

            //DataColumn nameColumn = new DataColumn("name", typeof(string));
            //table.Columns.AddRange(new DataColumn[] { idColumn, nameColumn });

            //DataRow row = table.NewRow();
            //row["id"] = 1;
            //row["name"] = "fic";
            //table.Rows.Add(row);
            //marketDataSet.Tables.Add(table);
            //marketDataSet.AcceptChanges();

            //row.BeginEdit();//изменить строку
            //row["name"] = "petya";
            //row.EndEdit();

            //row["name"] = "petya";
            //marketDataSet.AcceptChanges(); //по шагам 

            DataSet shopDb = new DataSet();

            DataTable products = new DataTable("Products");
            {
                DataColumn idColumn = new DataColumn("Id", typeof(int));
                DataColumn name = new DataColumn("Name", typeof(string));
                DataColumn price = new DataColumn("Price", typeof(float));
                products.Columns.AddRange(new DataColumn[] { idColumn, name, price });

                products.PrimaryKey = new DataColumn[] { idColumn };

                DataRow newRow = products.NewRow();
                newRow[idColumn] = 1;
                newRow[name] = "Laptop";
                newRow[price] = 989.99;

                products.Rows.Add(newRow);
            }



            shopDb.Tables.Add(products);

            DataTable customers = new DataTable("Customers");
            {
                DataColumn idColumn = new DataColumn("Id", typeof(int));
                DataColumn name = new DataColumn("Name", typeof(string));
                DataColumn surname = new DataColumn("Surname", typeof(string));
                customers.Columns.AddRange(new DataColumn[] { idColumn, name, surname });

                customers.PrimaryKey = new DataColumn[] { idColumn };

                DataRow newRow = customers.NewRow();
                newRow[idColumn] = 1;
                newRow[name] = "John";
                newRow[surname] = "Smith";

                customers.Rows.Add(newRow);
            }

            shopDb.Tables.Add(customers);

            DataTable employees = new DataTable("Employees");
            {
                DataColumn idColumn = new DataColumn("Id", typeof(int));
            DataColumn name = new DataColumn("Name", typeof(string));
            DataColumn surname = new DataColumn("Surname", typeof(string));
            employees.Columns.AddRange(new DataColumn[] { idColumn, name, surname });

            employees.PrimaryKey = new DataColumn[] { idColumn };

            DataRow newRow = employees.NewRow();
            newRow[idColumn] = 1;
            newRow[name] = "Adam";
            newRow[surname] = "Aaron";

            employees.Rows.Add(newRow);
        }

            shopDb.Tables.Add(employees);

            DataTable orders = new DataTable("Orders");
            {
                DataColumn idColumn = new DataColumn("Id", typeof(int));
                DataColumn customerId = new DataColumn("CustomerId", typeof(int));
                DataColumn employeeId = new DataColumn("EmployeeId", typeof(int));
                DataColumn saleDate = new DataColumn("SaleDate", typeof(DateTime));
                DataColumn totalSum = new DataColumn("TotalSum", typeof(float));
                orders.Columns.AddRange(new DataColumn[] { idColumn, customerId, employeeId, saleDate, totalSum });

                orders.PrimaryKey = new DataColumn[] { idColumn };


                DataRow newRow = orders.NewRow();
                newRow[idColumn] = 1;
                newRow[customerId] = 1;
                newRow[employeeId] = 1;
                newRow[saleDate] = DateTime.Today;
                newRow[totalSum] = 2325235;

                orders.Rows.Add(newRow);

            }

            shopDb.Tables.Add(orders);
            ForeignKeyConstraint fkCustomer = new ForeignKeyConstraint(shopDb.Tables["Customers"].Columns["Id"], shopDb.Tables["Orders"].Columns["CustomerId"]);
            ForeignKeyConstraint fkEmployee = new ForeignKeyConstraint(shopDb.Tables["Employees"].Columns["Id"], shopDb.Tables["Orders"].Columns["EmployeeId"]);
            shopDb.Tables["Orders"].Constraints.AddRange(new Constraint[] { fkCustomer, fkEmployee });



            DataTable orderDetails = new DataTable("OrderDetails");
            {
                DataColumn orderId = new DataColumn("OrderId", typeof(int));
                DataColumn productId = new DataColumn("ProductId", typeof(int));
                orderDetails.Columns.AddRange(new DataColumn[] { orderId, productId, });

                DataRow newRow = orderDetails.NewRow();
                newRow[orderId] = 1;
                newRow[productId] = 1;

                orderDetails.Rows.Add(newRow);
            }

            shopDb.Tables.Add(orderDetails);

            ForeignKeyConstraint fkOrder = new ForeignKeyConstraint(shopDb.Tables["Orders"].Columns["Id"], shopDb.Tables["OrderDetails"].Columns["OrderId"]);
            ForeignKeyConstraint fkProduct = new ForeignKeyConstraint(shopDb.Tables["Products"].Columns["Id"], shopDb.Tables["OrderDetails"].Columns["ProductId"]);
            shopDb.Tables["OrderDetails"].Constraints.AddRange(new Constraint[] { fkOrder, fkProduct });

        }
    }


}
    }
}
