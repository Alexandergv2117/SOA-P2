﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.IdentityModel.Protocols.WSTrust;
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
    private readonly string _URL_HOST = "http://localhost:8080/";
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

    // Activo
    public string GetAllDataActivo()
    {
        string data = "";
        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetAsync(_URL_HOST + "Activo").Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                var res = JsonConvert.DeserializeObject<DataResponse<List<Activo>>>(result);

                data = JsonConvert.SerializeObject(res.Data);
            }
        }
        catch (Exception ex)
        {
            data = "Error: " + ex.Message;
        }

        return data;
    }
    public string UpdateActivo(int id, bool status)
    {
        var newActivo = new UpdateActivo
        {
            id = id,
            status = status
        };

        string data = "";

        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            // Serializa el objeto newPerson a JSON
            var json = JsonConvert.SerializeObject(newActivo);

            // Crea el contenido de la solicitud POST con el JSON serializado
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Envía la solicitud POST a la URL deseada
            var response = client.PutAsync(_URL_HOST + "Activo", content).Result;

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
    public string DeleteActivo(int id)
    {
        string data = "";

        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            // Envía la solicitud DELETE a la URL deseada
            var response = client.DeleteAsync(_URL_HOST + "Activo?id=" + id).Result;

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


    public string CreateActivo(string name, string description)
    {
        var newActivo = new CreateActivo
        {
            description = description,
            name = name,
        };

        string data = "";

        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            // Serializa el objeto newPerson a JSON
            var json = JsonConvert.SerializeObject(newActivo);

            // Crea el contenido de la solicitud POST con el JSON serializado
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Envía la solicitud POST a la URL deseada
            var response = client.PostAsync(_URL_HOST + "Activo", content).Result;

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

    // Activo_Employee
    public string GetAllDataActivoEmpleadoUndelivery()
    {
        string data = "";
        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetAsync(_URL_HOST + "Activo_Employee/undelivery").Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                var res = JsonConvert.DeserializeObject<DataResponse<List<ActivoEmployeeUndelivey>>>(result);

                data = JsonConvert.SerializeObject(res.Data);
            }
        }
        catch (Exception ex)
        {
            data = "Error: " + ex.Message;
        }

        return data;
    }
    public string AssignActivo(int id_empleoyee, int id_activo, string delivery_date)
    {
        var newActivo = new AssignActivo
        {
            id_empleoyee = id_empleoyee,
            id_activo = id_activo,
            delivery_date = delivery_date,
        };

        string data = "";

        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            // Serializa el objeto newPerson a JSON
            var json = JsonConvert.SerializeObject(newActivo);

            // Crea el contenido de la solicitud POST con el JSON serializado
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Envía la solicitud POST a la URL deseada
            var response = client.PostAsync(_URL_HOST + "Activo_Employee", content).Result;

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

    public string UpdateActivoEmployee(int id_empleoyee, int id_activo)
    {
        var assignActivo = new DeliveryActivoEmployee
        {
            id_activo = id_activo,
            id_empleoyee = id_empleoyee,
        };

        string data = "";

        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            // Serializa el objeto newPerson a JSON
            var json = JsonConvert.SerializeObject(assignActivo);

            // Crea el contenido de la solicitud POST con el JSON serializado
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Envía la solicitud POST a la URL deseada
            var response = client.PutAsync(_URL_HOST + "Activo_Employee", content).Result;

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
            var response = client.PostAsync(_URL_HOST +"Auth", content).Result;

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
            var response = client.GetAsync(_URL_HOST + "Employees").Result;

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
            var response = client.GetAsync(_URL_HOST + "Employees").Result;

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
            var response = client.PostAsync(_URL_HOST + "Employees", content).Result;

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
    public string UpdateEmployee(int num_employee, string email, bool status, string name, string last_name, string birth_date)
    {
        var updateEmployee = new UpdateEmployee
        {
            name = name,
            birth_date = birth_date,
            email = email,
            status = status,
            last_name = last_name,
            num_employee = num_employee,
        };

        string data = "";

        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            // Serializa el objeto newPerson a JSON
            var json = JsonConvert.SerializeObject(updateEmployee);

            // Crea el contenido de la solicitud POST con el JSON serializado
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Envía la solicitud POST a la URL deseada
            var response = client.PutAsync(_URL_HOST + "Employees", content).Result;

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
    public string DeleteEmployee(int idEmployee)
    {
        string data = "";

        try
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            // Envía la solicitud DELETE a la URL deseada
            var response = client.DeleteAsync(_URL_HOST + "Employees?idEmployee=" + idEmployee).Result;

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
}
