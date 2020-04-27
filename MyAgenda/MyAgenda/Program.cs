using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace MyAgenda
{
    class Program
    {
        static List<Activity> activities;
        static void Main(string[] args)
        {
            activitiesDataLoad(@"..\..\activities.csv");
            Console.WriteLine();
            personDataLoad(@"..\..\personData.csv");

            Console.ReadKey();
        }
        static void activitiesDataLoad(string filepath)
        {
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(new FileStream(filepath, FileMode.Open, FileAccess.Read));
                string line = string.Empty;
                string[] headers = sr.ReadLine().Split(',');
                //for (int i = 0; i < headers.Length; i++)
                //{
                //    Console.Write(headers[i] + " ");
                //}
                Console.WriteLine();
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");

                line = sr.ReadLine();
                string[] activity = line.Split(',');
                Activity activity1 = new Activity(activity);
                activities.Add(activity1);
                
                while (line != null)
                {
                    //Console.WriteLine(line);

                    activity = line.Split(',');
                    Activity currentActivity = new Activity(activity);
                    activities.Add(currentActivity);
                    Console.WriteLine(currentActivity);
                    line = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sr.Dispose();
                sr.Close();
            }
        }
    
        
        static void personDataLoad(string filepath)
        {
     
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(new FileStream(filepath, FileMode.Open, FileAccess.Read));
                string line = string.Empty;
                string[] headers = sr.ReadLine().Split(',');
                //for (int i = 0; i < headers.Length; i++)
                //{
                //    Console.Write(headers[i] + " ");
                //}
                Console.WriteLine();
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                line = sr.ReadLine();
                while (line != null)
                {
                    //Console.WriteLine(line);
                  
                    line = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sr.Dispose();
                sr.Close();
            }
        }
    }
}
            
                
