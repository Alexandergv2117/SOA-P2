import axios from "axios"

const hostBack = import.meta.env.VITE_HOST_BACK

const xml2json = (xml, tagName) => {
  const parser = new DOMParser();
  const xmlDOM = parser.parseFromString(xml, 'application/xml');

  const data = xmlDOM.getElementsByTagName(tagName)[0].childNodes[0].nodeValue;

  return JSON.parse(data || '');
}

export const LoginAsync = async(credentials) => {
  try {
    const data = `<?xml version="1.0" encoding="utf-8"?>
    <soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
      <soap:Body>
        <LogIn xmlns="http://tempuri.org/">
          <email>${credentials.email}</email>
          <password>${credentials.password}</password>
        </LogIn>
      </soap:Body>
    </soap:Envelope>
    `
    const response = await axios.post(`${hostBack}`, data, {
       headers: {
        'Content-Type': 'text/xml; charset=utf-8',
        SOAPAction: 'http://tempuri.org/IService/LogIn',
       },
       maxContentLength: Infinity,
    })
    
    return xml2json(response.data, 'LogInResult')

  } catch (e) {
    console.error(e)
    return e
  }
}