using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de CreatePerson
/// </summary>
public class CreatePerson
{
    public string curp { get; set; }
    public string name { get; set; }
    public string last_name { get; set; }
    public string birth_date { get; set; }
    public string email { get; set; }
    public string password { get; set; }
}