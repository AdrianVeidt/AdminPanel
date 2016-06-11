using System;

namespace AdminPanel.Domain
{
    [Serializable]
    public class InformationOrders
    {
        public int Id { get; set; }
		public string Client_name
		{
			get;
			set;
		}
		public string Phone
		{
			get;
			set;
		}
		public string Menu
		{
			get;
			set;
		}
		public string Price
		{
			get;
			set;
		}
		public string Client_table
		{
			get;
			set;
		}
		public int Places
		{
			get;
			set;
		}
		public string Date
		{
			get;
			set;
		}
		public string Time
		{
			get;
			set;
		}
		public InformationOrders(int id, string client_name, string phone, string menu, string price, string client_table, int places, DateTime date, DateTime time)
        {
            Id = id;
			Client_name = client_name;
			Phone = phone;
			Menu = menu;
			Price = price;
            Client_table = client_table;
			Places = places;
			Date = date.ToShortDateString();
			Time = time.ToShortTimeString(); 
        }
    }
}