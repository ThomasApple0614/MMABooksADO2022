using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;
using System.Data;
using MMABooksBusinessClasses;
using MMABooksDBClasses;
public static class ProductDB
{

    public static Product GetProduct(string ProductCode) 
    { 
        MySqlConnection connection = MMABooksDB.GetConnection();
        string selectStatement
            = "SELECT ProductCode, Description, UnitPrice, OnHandQuantity "
            + "FROM Products "
            + "WHERE ProductCode = @ProductCode";
        MySqlCommand selectCommand =
            new MySqlCommand(selectStatement, connection);
        selectCommand.Parameters.AddWithValue("@ProductCode", ProductCode);
        try
        {
            connection.Open();
            MySqlDataReader productReader =
                selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (productReader.Read())
            {
                Product product = new Product();
                product.ProductCode = productReader["ProductCode"].ToString();
                product.Description = productReader["Description"].ToString();
                product.Price = (decimal)productReader["UnitPrice"];
                product.Quantity = (int)productReader["OnHandQuantity"];
                return product;
            }
            else
            {
                return null;
            }
        }
        catch (MySqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }
    public static int AddProduct(Product product)
    {
        MySqlConnection connection = MMABooksDB.GetConnection();
        string insertStatement =
            "INSERT Product " +
            "(Description, UnitPrice, OnHandQuantity) " +
            "VALUES (@Description, @UnitPrice, @OnHandQuantity)";
        MySqlCommand insertCommand =
            new MySqlCommand(insertStatement, connection);
        insertCommand.Parameters.AddWithValue(
            "@Description", product.Description);
        insertCommand.Parameters.AddWithValue(
            "@UnitPrice", product.Price);
        insertCommand.Parameters.AddWithValue(
            "@OnHandQuantity", product.Quantity);
        
        try
        {
            connection.Open();
            insertCommand.ExecuteNonQuery();
            string selectStatement =
                "SELECT LAST_INSERT_ID()";
            MySqlCommand selectCommand =
                new MySqlCommand(selectStatement, connection);
            int ProductCode = Convert.ToInt32(selectCommand.ExecuteScalar());
            return ProductCode;
        }
        catch (MySqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }

}

