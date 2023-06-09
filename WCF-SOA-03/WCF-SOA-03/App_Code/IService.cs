using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{
    // Activo
    [OperationContract]
    string CreateActivo(string name, string description);
    [OperationContract]
    string GetAllDataActivo();
	[OperationContract]
	string UpdateActivo(int id, bool status);
    [OperationContract]
    string DeleteActivo(int id);

	// Activo_Employee
	[OperationContract]
	string GetAllDataActivoEmpleadoUndelivery();
	[OperationContract]
	string AssignActivo(int id_empleoyeem, int id_activo, string delivery_date);
    [OperationContract]
    string UpdateActivoEmployee(int id_empleoyee, int id_activo);


    // Auth
    [OperationContract]
    string LogIn(string email, string password);

    // Employees

    [OperationContract]
	string GetData(int value);

	[OperationContract]
	string GetDataPersonById(int id);
	[OperationContract]
	string GetAllDataPerson();
	[OperationContract]
	string CreatePersonAsync(string curp, string name, string last_name, string birth_date, string email, string password);

    // TODO: agregue aquí sus operaciones de servicio
}

// Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
[DataContract]
public class CompositeType
{
	bool boolValue = true;
	string stringValue = "Hello ";

	[DataMember]
	public bool BoolValue
	{
		get { return boolValue; }
		set { boolValue = value; }
	}

	[DataMember]
	public string StringValue
	{
		get { return stringValue; }
		set { stringValue = value; }
	}
}
