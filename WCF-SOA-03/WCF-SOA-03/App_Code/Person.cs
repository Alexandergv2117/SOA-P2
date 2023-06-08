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
    public int id { get ; set; }
    [DataMember]
    public string nombre { get; set; }
    [DataMember]
    public string apellidos { get; set; }
}