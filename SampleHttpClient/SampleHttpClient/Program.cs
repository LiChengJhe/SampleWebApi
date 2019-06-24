using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SampleHttpClient
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            string url = "https://localhost:44359/customer";
            string targetId = "A54A";
            List<Customer> getCustomers = await HttpHelper.GetConnection(url).GetAsync<List<Customer>>();
            Console.WriteLine(JsonConvert.SerializeObject(getCustomers));

            Customer getCustomer = await HttpHelper.GetConnection($"{url}/{targetId}").GetAsync<Customer>();
            Console.WriteLine(JsonConvert.SerializeObject(getCustomer));

            dynamic postCustomer = await HttpHelper.GetConnection($"{url}").PostAsync<dynamic>(new Customer { Id = "test-1", Name = "test-1", Location = "tw" });
            Console.WriteLine(JsonConvert.SerializeObject(postCustomer));

            dynamic putCustomer = await HttpHelper.GetConnection($"{url}/{targetId}").PutAsync<dynamic>(new Customer { Id = targetId, Name = "changed", Location = "changed" });
            Console.WriteLine(JsonConvert.SerializeObject(putCustomer));

            dynamic patchCustomer = await HttpHelper.GetConnection($"{url}/{targetId}").PatchAsync<dynamic>(new Customer { Location = "changed" });
            Console.WriteLine(JsonConvert.SerializeObject(patchCustomer));

            dynamic delCustomer = await HttpHelper.GetConnection($"{url}/{targetId}").DeleteAsync<dynamic>();
            Console.WriteLine(JsonConvert.SerializeObject(delCustomer));

            Console.ReadKey();
        }
    }
}
