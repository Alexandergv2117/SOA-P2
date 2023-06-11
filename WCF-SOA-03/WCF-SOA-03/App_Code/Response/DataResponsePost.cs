using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de DataResponsePost
/// </summary>
public class DataResponsePost
{
    [DataMember]
    public int Code { get; set; }
    [DataMember]
    public Object Data { get; set; }
    [DataMember]
    public string Message { get; set; }
}