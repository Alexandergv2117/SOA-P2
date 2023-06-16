import axios from "axios"

const hostBack = import.meta.env.VITE_HOST_BACK

const xml2json = (xml, tagName) => {
    const parser = new DOMParser();
    const xmlDOM = parser.parseFromString(xml, 'application/xml');
 
    const data = xmlDOM.getElementsByTagName(tagName)[0].childNodes[0].nodeValue;
 
    return JSON.parse(data || '');
 }

export const GetAllDataActivo = async() => {
    try {
        const data = `<?xml version="1.0" encoding="utf-8"?>
        <soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
          <soap:Body>
            <GetAllDataActivo xmlns="http://tempuri.org/"/>
          </soap:Body>
        </soap:Envelope>
        `
        const response = await axios.post(`${hostBack}`, data, {
           headers: {
              'Content-Type': 'text/xml; charset=utf-8',
              SOAPAction: 'http://tempuri.org/IService/GetAllDataActivo',
           },
           maxContentLength: Infinity,
        })

        return xml2json(response.data, 'GetAllDataActivoResult')

    } catch (e) {
        console.error(e)
        return e
    }
}

export const CreateActivo = async(body) => {
    try {
        const data = `<?xml version="1.0" encoding="utf-8"?>
        <soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
          <soap:Body>
            <CreateActivo xmlns="http://tempuri.org/">
              <name>${body.name}</name>
              <description>${body.description}</description>
            </CreateActivo>
          </soap:Body>
        </soap:Envelope>`

        const response = await axios.post(`${hostBack}`, data, {
            headers: {
               'Content-Type': 'text/xml; charset=utf-8',
               SOAPAction: 'http://tempuri.org/IService/CreateActivo',
            },
            maxContentLength: Infinity,
         })
 
         return xml2json(response.data, 'CreateActivoResult')
    } catch (e) {
        console.error(e)
        return e
    }
}