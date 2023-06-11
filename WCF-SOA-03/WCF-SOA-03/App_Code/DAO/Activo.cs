using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de Activo
/// </summary>
[DataContract]
public class Activo
{
    [DataMember]
    public int id { get; set; }
    [DataMember]
    public string name { get; set; }
    [DataMember]
    public string description { get; set; }
    [DataMember]
    public bool status { get; set; }
    [DataMember]
    public bool? activo_Empleado { get; set; }
}