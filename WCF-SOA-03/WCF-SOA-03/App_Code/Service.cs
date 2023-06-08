using Newtonsoft.Json;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public string GetDataPersonById(int id)
	{
		string data = "";
		try 
		{
			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Clear();
			var response = client.GetAsync("http://api-soa.somee.com/api-soa/personas").Result;

			if (response.IsSuccessStatusCode)
			{
				var result = response.Content.ReadAsStringAsync().Result;

				List<Person> persons = JsonConvert.DeserializeObject<List<Person>>(result);

				var person = persons.FirstOrDefault(x => x.id == id);

				data = JsonConvert.SerializeObject(person);
			}
		} 
		catch (Exception ex)
		{
			data = ex.Message;
		}

		return data;
	}
}
