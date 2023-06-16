import axios from "axios"
//import { useXML2JSON } from "../../hooks/XML2JSON"

const hostBack = import.meta.env.VITE_HOST_BACK

const xml2json = (xml, tagName) => {
  const parser = new DOMParser();
  const xmlDOM = parser.parseFromString(xml, 'application/xml');

  const data = xmlDOM.getElementsByTagName(tagName)[0].childNodes[0].nodeValue;

  return JSON.parse(data || '');
}

export const GetAllDataActivoEmployee = async() => {
  try {
    const data = `<?xml version="1.0" encoding="utf-8"?>
    <soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
      <soap:Body>
        <GetAllDataActivoEmpleadoUndelivery xmlns="http://tempuri.org/"/>
      </soap:Body>
    </soap:Envelope>
    `
    const response = await axios.post(`${hostBack}`, data, {
       headers: {
        'Content-Type': 'text/xml; charset=utf-8',
        SOAPAction: 'http://tempuri.org/IService/GetAllDataActivoEmpleadoUndelivery',
       },
       maxContentLength: Infinity,
    })
    
    return xml2json(response.data, 'GetAllDataActivoEmpleadoUndeliveryResult')

  } catch (e) {
    console.error(e)
    return e
  }
}

export const UpdateActivoEmployee = async(object) => {
    try {
      const data = `<?xml version="1.0" encoding="utf-8"?>
      <soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
        <soap:Body>
          <UpdateActivoEmployee xmlns="http://tempuri.org/">
            <id_empleoyee>${object.id_empleoyee}</id_empleoyee>
            <id_activo>${object.id_activo}</id_activo>
          </UpdateActivoEmployee>
        </soap:Body>
      </soap:Envelope>
      `
      const response = await axios.post(`${hostBack}`, data, {
         headers: {
          'Content-Type': 'text/xml; charset=utf-8',
          SOAPAction: 'http://tempuri.org/IService/UpdateActivoEmployee',
         },
         maxContentLength: Infinity,
      })
      
      return xml2json(response.data, 'UpdateActivoEmployeeResult')
  
    } catch (e) {
      console.error(e)
      return e
    }
}

export const AssignActivo  = async(object) => {
    try {
      const data = `<?xml version="1.0" encoding="utf-8"?>
      <soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
        <soap:Body>
          <AssignActivo xmlns="http://tempuri.org/">
            <id_empleoyeem>${object.id_empleoyee}</id_empleoyeem>
            <id_activo>${object.id_activo}</id_activo>
            <delivery_date>${object.delivery_date}</delivery_date>
          </AssignActivo>
        </soap:Body>
      </soap:Envelope>
      `
      const response = await axios.post(`${hostBack}`, data, {
         headers: {
          'Content-Type': 'text/xml; charset=utf-8',
          SOAPAction: 'http://tempuri.org/IService/AssignActivo',
         },
         maxContentLength: Infinity,
      })
      
      return xml2json(response.data, 'AssignActivoResult')
  
    } catch (e) {
      console.error(e)
      return e
    }
}