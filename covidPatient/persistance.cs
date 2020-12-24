﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace covidPatient
{
    class persistance
    {
        static string chaine = @"Data Source = localhost; Initial Catalog = Covid19; Integrated Security = True";
        static SqlConnection cnx = new SqlConnection(chaine);
        static SqlCommand cmd = new SqlCommand();
        static SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        
        public void insertCitoyen(citoyen ct)
        {
            cnx.Open();
            cmd.Connection = cnx;

            cmd.CommandText = "INSERT INTO citoyen VALUES('" + ct.cin + "','" + ct.name + "','" + ct.age + "','" + ct.tel + "','" + ct.address + "')";
            int i = cmd.ExecuteNonQuery();

            Console.WriteLine("citoyen added ");
            cnx.Close();

        }
        public void insertDeath(citoyen ct,string dtime, string lieu, string raison) 
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "INSERT INTO death VALUES('" + ct.cin + "','" + ct.name + "','" + dtime+ "','" + lieu + "','" + raison + "')";
            int i = cmd.ExecuteNonQuery();
            Console.WriteLine("cas deces added");
            cnx.Close();
        }
        public void insertPatient(citoyen ct, string datePatient)
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "INSERT INTO patient VALUES('" + ct.cin + "','" + ct.name + "','" + datePatient + "')";
            int i = cmd.ExecuteNonQuery();
            cnx.Close();
        }

        public void get_possible_cases(string c)
        {
            cnx.Open();
            cmd.CommandText = "SELECT * FROM citoyen WHERE citoyen_tel="+ c +"";
            cmd.Connection = cnx;
            cmd.ExecuteNonQuery();
            
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            int i = 0;
            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine("\n");
                Console.WriteLine("suspect case numero : " + ++i);

                foreach (var item in dataRow.ItemArray)
                {

                    Console.WriteLine(item);
                    
                }
                Console.WriteLine("\n");

            }
            cnx.Close();
        }
    }
}
