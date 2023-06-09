using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descripción breve de DataResponse
/// </summary>
[DataContract]
public class DataResponse<T>
{
    [DataMember]
    public int Code { get; set; }
    [DataMember]
    public T Data { get; set; }
    [DataMember]
    public string Message { get; set; }
}