using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using AdminPanel.Domain;
using AdminPanel.Models.Masters;

namespace AdminPanel.Mapper
{
    public class InformationOrdersMapper
    {
        private static JsonMaster jsonMaster = new JsonMaster();
		private static Dictionary<String, String> parameters = new Dictionary<String, String>();
        private static String urlGetInformations = "http://autoline.h1n.ru/get_test.php";
		private static String url_insert_information_order = "http://autoline.h1n.ru/insert_test.php";
  
        public static List<InformationOrders> GetInformations()
        {
            List<InformationOrders> informationOrders = new List<InformationOrders>();
            Dictionary<String, String> parameters = new Dictionary<String, String>();
            String response = jsonMaster.GetJSON(urlGetInformations, parameters);
            JObject jObject = JObject.Parse(response);
            JToken success = jObject["success"];
            if ((int)success == 1)
            {
				JToken jServices = jObject["infos"];
                var jArray = jServices.ToArray();
                informationOrders = jArray.Select(element => new InformationOrders((int)element["id"],
																	(string)element["client_name"],
																	(string)element["phone"],
																	(string)element["menu"],
																	(string)element["price"],
																	(string)element["client_table"],
																	(int)element["places"],
																	(DateTime)element["date"],
																	(DateTime)element["time"]

                                                                    )).ToList();
            }
            return informationOrders;
        }

		public int InsertInformationOrders(string table, string places, string name, string phone)
		{
			        
			parameters = new Dictionary<string, string>();
			parameters.Add("client_table", table);
			parameters.Add("places", places.ToString());
			parameters.Add("client_name", name);
			parameters.Add("phone", phone.ToString());
			String response = jsonMaster.GetJSON(url_insert_information_order, parameters);
			JObject jObject = JObject.Parse(response);
			JToken success = jObject["success"];
			/*
			if ((int)success == 1)
			{
				JToken jOrder = jObject["order"];
				var jArray = jOrder.ToArray();
				int id = jArray.Select(element => (int)element["id"]).ElementAt(0);
				return id;
			}*/
			return 0;
		}
    }
}