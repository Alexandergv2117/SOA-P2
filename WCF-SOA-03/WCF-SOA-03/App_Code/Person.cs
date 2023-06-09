using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de Person
/// </summary>

[DataContract]
public class Person
{
    [DataMember]
    public string curp { get; set; }
    [DataMember]
    public string name { get; set; }
    [DataMember]
    public string last_name { get; set; }
    [DataMember]
    public DateTime birth_date { get; set; }
    [DataMember]
    public int num_employee { get; set; }
    [DataMember]
    public string email { get; set; }
    [DataMember]
    public DateTime date_hire { get; set; }
    [DataMember]
    public bool status { get; set; }
}