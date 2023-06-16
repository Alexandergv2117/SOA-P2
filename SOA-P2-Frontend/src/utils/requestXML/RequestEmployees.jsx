import axios from "axios"
//import { useXML2JSON } from "../../hooks/XML2JSON"

const hostBack = import.meta.env.VITE_HOST_BACK

const xml2json = (xml, tagName) => {
  const parser = new DOMParser();
  const xmlDOM = parser.parseFromString(xml, 'application/xml');

  const data = xmlDOM.getElementsByTagName(tagName)[0].childNodes[0].nodeValue;

  return JSON.parse(data || '');
}

export const GetAllDataPerson = async() => {
  try {
    const data = `<?xml version="1.0" encoding="utf-8"?>
    <soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
      <soap:Body>
        <GetAllDataPerson xmlns="http://tempuri.org/"/>
      </soap:Body>
    </soap:Envelope>
    `
    const response = await axios.post(`${hostBack}`, data, {
       headers: {
        'Content-Type': 'text/xml; charset=utf-8',
        SOAPAction: 'http://tempuri.org/IService/GetAllDataPerson',
       },
       maxContentLength: Infinity,
    })
    
    return xml2json(response.data, 'GetAllDataPersonResult')

  } catch (e) {
    console.error(e)
    return e
  }
}

export const CreatePerson = async(person) => {
  try {
      const data = `<?xml version="1.0" encoding="utf-8"?>
      <soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
        <soap:Body>
          <CreatePersonAsync xmlns="http://tempuri.org/">
            <curp>${person.curp}</curp>
            <name>${person.name}</name>
            <last_name>${person.last_name}</last_name>
            <birth_date>${person.birth_date}</birth_date>
            <email>${person.email}</email>
            <password>${person.password}</password>
          </CreatePersonAsync>
        </soap:Body>
      </soap:Envelope>
      `
      const response = await axios.post(`${hostBack}`, data, {
         headers: {
            'Content-Type': 'text/xml; charset=utf-8',
            SOAPAction: 'http://tempuri.org/IService/CreatePersonAsync',
         },
         maxContentLength: Infinity,
      })
      
      return xml2json(response.data, 'CreatePersonAsyncResult')

  } catch (e) {
      console.error(e)
      return e
  }
}

export const DeleteEmployee = async(idEmployee) => {
  try {
      const data = `<?xml version="1.0" encoding="utf-8"?>
      <soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
        <soap:Body>
          <DeleteEmployee xmlns="http://tempuri.org/">
            <idEmployee>${Number(idEmployee)}</idEmployee>
          </DeleteEmployee>
        </soap:Body>
      </soap:Envelope>
      `
      const response = await axios.post(`${hostBack}`, data, {
         headers: {
            'Content-Type': 'text/xml; charset=utf-8',
            SOAPAction: 'http://tempuri.org/IService/DeleteEmployee',
         },
         maxContentLength: Infinity,
      })
      
      return xml2json(response.data, 'DeleteEmployeeResult')

  } catch (e) {
      console.error(e)
      return e
  }
}