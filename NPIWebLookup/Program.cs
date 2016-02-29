using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPIWebLookup {
    class Program {

        public class RootObject {
            public int result_count { get; set; }
            public Result[] results { get; set; }
        }

        public class Result {
            public Taxonomy[] taxonomies { get; set; }
            public Address[] addresses { get; set; }
            public int created_epoch { get; set; }
            public Identifier[] identifiers { get; set; }
            public Other_Names[] other_names { get; set; }
            public int number { get; set; }
            public int last_updated_epoch { get; set; }
            public Basic basic { get; set; }
            public string enumeration_type { get; set; }
        }

        public class Basic {
            public string status { get; set; }
            public string credential { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string middle_name { get; set; }
            public string name { get; set; }
            public string gender { get; set; }
            public string sole_proprietor { get; set; }
            public string last_updated { get; set; }
            public string enumeration_date { get; set; }
        }

        public class Taxonomy {
            public string state { get; set; }
            public string code { get; set; }
            public bool primary { get; set; }
            public string license { get; set; }
            public string desc { get; set; }
        }

        public class Address {
            public string city { get; set; }
            public string address_2 { get; set; }
            public string telephone_number { get; set; }
            public string fax_number { get; set; }
            public string state { get; set; }
            public string postal_code { get; set; }
            public string address_1 { get; set; }
            public string country_code { get; set; }
            public string country_name { get; set; }
            public string address_type { get; set; }
            public string address_purpose { get; set; }
        }

        public class Identifier {
            public string code { get; set; }
            public string issuer { get; set; }
            public string state { get; set; }
            public string identifier { get; set; }
            public string desc { get; set; }
        }

        public class Other_Names {
            public string credential { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string middle_name { get; set; }
            public string code { get; set; }
            public string type { get; set; }
        }

        [STAThread]
        static void Main(string[] args) {
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Title = "Please select Excel file containing NPI data";
            //ofd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

            //if (ofd.ShowDialog() != DialogResult.OK) {
            //    return;
            //}

            //Console.WriteLine(ofd.FileName);
            //Console.ReadKey();

            // Input NPI data
            RunAsync().Wait();
            Console.ReadKey();
        }

        static async Task RunAsync() {
            using (var client = new HttpClient()) {
                // Establish connection
                client.BaseAddress = new Uri("https://npiregistry.cms.hhs.gov/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("api?last_name=sonido");
                if (response.IsSuccessStatusCode) {
                    RootObject resultSet = await response.Content.ReadAsAsync<RootObject>();

                    foreach (Result provider in resultSet.results) {
                        Console.WriteLine(provider.number);
                        Console.WriteLine("\t" + provider.basic.name);
                    }

                }
            }
        }
    }
}
