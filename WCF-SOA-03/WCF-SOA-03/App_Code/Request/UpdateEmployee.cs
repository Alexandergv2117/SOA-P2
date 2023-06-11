using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de UpdateEmployee
/// </summary>
public class UpdateEmployee
{
    public int num_employee { get; set; }
    public string email { get; set; }
    public bool status { get; set; }
    public string name { get; set; }
    public string last_name { get; set; }
    public string birth_date { get; set; }
}