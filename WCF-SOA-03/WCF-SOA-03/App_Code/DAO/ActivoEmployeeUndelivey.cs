using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de ActivoEmployeeUndelivey
/// </summary>
[DataContract]
public class ActivoEmployeeUndelivey
{
    [DataMember]
    public string nameEmployee { get; set; }
    [DataMember]
    public string lastnameEmployee { get; set; }
    [DataMember]
    public string email { get; set; }
    [DataMember]
    public string nameActivo { get; set; }
    [DataMember]
    public string description { get; set; }
    [DataMember]
    public DateTime assignmentDate { get; set; }
    [DataMember]
    public DateTime releseDate { get; set; }
    [DataMember]
    public int id { get; set; }
    [DataMember]
    public int id_empleoyee { get; set; }
    [DataMember]
    public int id_activo { get; set; }
    [DataMember]
    public DateTime assignment_date { get; set; }
    [DataMember]
    public DateTime release_date { get; set; }
    [DataMember]
    public DateTime delivery_date { get; set; }
}