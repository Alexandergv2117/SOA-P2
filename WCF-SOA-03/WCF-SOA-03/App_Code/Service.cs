using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

    // Auth

    public string LogIn(string email, string password)
    {
        var newPerson = new LogIn
        {
            email = email,
            password = password,
        };
        string data = "";
        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            // Serializa el objeto newPerson a JSON
            var json = JsonConvert.SerializeObject(newPerson);

            // Crea el contenido de la solicitud POST con el JSON serializado
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Envía la solicitud POST a la URL deseada
            var response = client.PostAsync("http://localhost:8080/Auth", content).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<DataResponsePost>(result);

                data = JsonConvert.SerializeObject(res);
            }
        }
        catch (Exception ex)
        {
            data = "Error: " + ex.Message;
        }

        return data;
    }

    // Employees
    public string GetAllDataPerson()
    {
        string data = "";
        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetAsync("http://localhost:8080/Employees").Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                var res = JsonConvert.DeserializeObject<DataResponse<List<Person>>>(result);

                data = JsonConvert.SerializeObject(res.Data);
            }
        }
        catch (Exception ex)
        {
            data = "Error: " + ex.Message;
        }

        return data;
    }

    public string GetDataPersonById(int id)
    {
        string data = "";
        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetAsync("http://localhost:8080/Employees").Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                var res = JsonConvert.DeserializeObject<DataResponse<List<Person>>>(result);

                var person = res.Data.FirstOrDefault(x => x.num_employee == id);

                data = JsonConvert.SerializeObject(person);
            }
        }
        catch (Exception ex)
        {
            data = "Error: " + ex.Message;
        }

        return data;
    }

    public string CreatePersonAsync(string curp, string name, string last_name, string birth_date, string email, string password)
    {
        var newPerson = new CreatePerson
        {
            birth_date = birth_date,
            email = email,
            password = password,
            curp = curp,
            name = name,
            last_name = last_name,
        };
        string data = "";
        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            // Serializa el objeto newPerson a JSON
            var json = JsonConvert.SerializeObject(newPerson);

            // Crea el contenido de la solicitud POST con el JSON serializado
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Envía la solicitud POST a la URL deseada
            var response = client.PostAsync("http://localhost:8080/Employees", content).Result;

            if(response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<DataResponsePost>(result);

                data = JsonConvert.SerializeObject(res.Data);
            }
        }
        catch (Exception ex)
        {
            data = "Error: " + ex.Message;
        }

        return data;
    }
}
